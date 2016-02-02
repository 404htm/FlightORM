using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightORM.SQL
{
    public class SQLSchemaReader : IDisposable
    {
        SqlConnection _cnn;

        public SQLSchemaReader(string connectionString)
        {
            _cnn = new SqlConnection(connectionString);
            _cnn.Open();
        }


        public IEnumerable<string> GetTables(string schema = null, bool includeSchema = true)
        {
            return RunInfoSchemaQuery(schema, includeSchema, "BASE TABLE");
        }

        public IEnumerable<string> GetViews(string schema = null, bool includeSchema = true)
        {
            return RunInfoSchemaQuery(schema, includeSchema, "VIEW");
        }

        private IEnumerable<string> RunInfoSchemaQuery(string schema, bool includeSchema, string type)
        {
            string query = "SELECT * FROM information_schema.tables WHERE TABLE_TYPE = @type";
            if (schema != null) query += " AND TABLE_SCHEMA = @schema";

            var command = new SqlCommand(query, _cnn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@type", type);
            if (schema != null) command.Parameters.AddWithValue("@schema", schema);

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                string result = (includeSchema) ?
                    $"{reader["TABLE_SCHEMA"]}.{reader["TABLE_NAME"]}" :
                    $"{reader["TABLE_NAME"]}";
                yield return result;
            }

        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _cnn.Close();
                }
                disposedValue = true;
            }
        }


        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
