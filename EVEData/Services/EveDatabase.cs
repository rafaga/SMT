using System;
using System.Data;
using Microsoft.Data.Sqlite;

namespace EVEData.Services
{
	public enum eDatabaseType
    {
		None,
		SQLlite
    }

	public class EveDatabase
	{

		private IDbConnection? _connection;
		private eDatabaseType? _dbType;

		public eDatabaseType? DatabaseType
        {
			get => _dbType;
			private set {
				_dbType = value;
            }
        }

		public EveDatabase(eDatabaseType type)
		{
			if(type == eDatabaseType.SQLlite)
            {
				_connection = new SqliteConnection();
				_connection.ConnectionString = "Data Source=smt.db";
            }
			DatabaseType = type;
		}

		public IDbConnection? Connection
        {
			get => _connection;
			private set
            {
				_connection = value;
            }
        }
	}
}

