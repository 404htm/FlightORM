﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightORM.SQL
{
    public class SQLTemplateBuilder
    {
        SqlTableInfo _tableInfo;
        string _columns;
        string _identity;
        string _skip;
        string _take;

        public SQLTemplateBuilder(SqlTableInfo TableInfo)
        {
            _columns = TableInfo.ColumnInfo.Select(c => $"[{c.Name}]").Aggregate((a, b) => $"{a}, {b}");
            _identity = TableInfo.ColumnInfo
                .Where(c => c.Identity)
                .Select(c => $"[{c.Name}] = @{c.Name}")
                .Aggregate((a, b) => $"{a} AND {b}");

        }

        public string BuildGetByIdQuery()
        {
            var query = $"SELECT {_columns} FROM [{_tableInfo.Schema}].[{_tableInfo.Name}] WHERE ({_identity});";
            return query;
        }

        public string BuildGetByNameQuery()
        {
            if (!_tableInfo.ColumnInfo.Any(c => c.Name.ToLower() == "name")) return null;
            var query = $"SELECT {_columns} FROM [{_tableInfo.Schema}].[{_tableInfo.Name}] WHERE (name = @name);";
            return query;
        }

        public string BuildGetActiveQuery()
        {
            //TODO: Skip/Take
            if (!_tableInfo.ColumnInfo.Any(c => c.Name.ToLower() == "active")) return null;
            var query = $"SELECT {_columns} FROM [{_tableInfo.Schema}].[{_tableInfo.Name}] WHERE active;";
            return query;
        }


    }
}
