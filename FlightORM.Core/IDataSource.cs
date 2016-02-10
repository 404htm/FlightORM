using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightORM.Core
{
	interface IDataSource
	{
		Guid Id { get; set; }
		string Name { get; set; }
	}
}
