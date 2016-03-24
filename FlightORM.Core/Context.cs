using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FlightORM.Core
{
	[DataContract]
	public class Context:StoreableBase<Context>
	{
		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public IList<IDataSource> DataSources { get; set; }

		[DataMember]
		public IList<QueryDefinition> Queries { get; set; }


	}
}
