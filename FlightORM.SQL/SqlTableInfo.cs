﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightORM.SQL
{
	public class SqlTableInfo
	{
		public string Name { get; set; }
		public string Schema { get; set; }
		public IList<SqlColumnInfo> ColumnInfo { get; set; }
		
	}
}
