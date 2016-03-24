using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightORM.Core
{
	public interface IDataConnection
	{
		Guid Id { get; set; }
		string Name { get; set; }
	}
}
