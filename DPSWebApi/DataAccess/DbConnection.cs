using Dapper;
using DPSWebApi.AppSetings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DPSWebApi.DataAccess
{
	public class DbConnection
	{
		private readonly ConnectionStrings _connectionString;
		private IDbConnection dbConnection;
		public DbConnection(ConnectionStrings connectionString)
		{
			_connectionString = connectionString;
		}

		// use for buffered queries that return a type
		public async Task<T> WithConnection<T>(Func<IDbConnection, Task<T>> getData)
		{
			var sqlTuple = SqlConnected();
			var odbcTuple = OdbcConnected();
			try
			{
				if(SqlConnected())
				{
					using (var connection = new SqlConnection(_connectionString.DPSSql))
					{
						connection.Open();
						return await getData(connection);
					}
				}
				else if (OdbcConnected())
				{
					using (var connection = new OdbcConnection(_connectionString.DPSOdbc))
					{
						connection.Open();
						return await getData(connection);
					}
				}
				else
				{
					throw new Exception("Can not connect database.");
				}


			}
			catch (TimeoutException ex)
			{
				throw new Exception(String.Format("{0}.WithConnection() experienced a SQL timeout", GetType().FullName), ex);
			}
			catch (SqlException ex)
			{
				throw new Exception(String.Format("{0}.WithConnection() experienced a SQL exception (not a timeout)", GetType().FullName), ex);
			}
		}

		private bool SqlConnected()
		{
			using (var con = new SqlConnection(_connectionString.DPSSql))
			{
				try
				{
					con.Open();
					dbConnection = con;
					return true;
				}
				catch (SqlException)
				{
					return false;
				}
			}
		}

		private bool OdbcConnected()
		{
			using (var con = new OdbcConnection(_connectionString.DPSOdbc))
			{
				try
				{
					con.Open();
					dbConnection = con;
					return true;
				}
				catch (SqlException)
				{
					return false;
				}
			}
		}
	}
}
