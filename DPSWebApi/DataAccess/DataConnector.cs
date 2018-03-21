using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DPSWebApi.DataProvider;
using DPSWebApi.Models;

namespace DPSWebApi.DataAccess
{
	public class DataConnector //: IDataConnection
	{
		private DbConnection _dbConnection;
		public DataConnector(DbConnection dbConnection)
		{
			_dbConnection = dbConnection;
		}
		public async Task<IEnumerable<PersonalProfile>> GetPersonalProfiles()
		{
			return await _dbConnection.WithConnection(async c =>
			{
				return await c.QueryAsync<PersonalProfile>(QueryDb.GetPersonalProfile());
			});
		}
	}
}
