using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DPSWebApi.AppSetings;
using DPSWebApi.Models;

namespace DPSWebApi.DataAccess
{
	public class OdbcConnector : IDataConnection
	{
		private ConnectionStrings _connectionStrings;
		public OdbcConnector(ConnectionStrings connectionStrings)
		{
			_connectionStrings = connectionStrings;
		}
		public async Task<IEnumerable<PersonalProfile>> GetPersonalProfiles()
		{
			using (var db = new OdbcConnection(_connectionStrings.DPSOdbc))
			{
				await db.OpenAsync();

				var data = await db.QueryAsync<PersonalProfile>(QueryDb.GetPersonalProfile());

				return data;
			}
		}

		public async Task<IEnumerable<Title>> GetTitles()
		{
			using (var db = new OdbcConnection(_connectionStrings.DPSOdbc))
			{
				await db.OpenAsync();

				var data = await db.QueryAsync<Title>(QueryDb.GetTitle());

				return data;
			}
		}

		public async Task<IEnumerable<Religion>> GetReligions()
		{
			using (var db = new OdbcConnection(_connectionStrings.DPSOdbc))
			{
				await db.OpenAsync();

				var data = await db.QueryAsync<Religion>(QueryDb.GetReligion());

				return data;
			}
		}

		public async Task<JobWork> GetJobWorkByProfileId(int profileId)
		{
			using(var db = new OdbcConnection(_connectionStrings.DPSOdbc))
			{
				await db.OpenAsync();

				var data = await db.QueryFirstOrDefaultAsync<JobWork>(QueryDb.GetJobWorkByProfileId(), new { PROFILE_ID = profileId });

				return data;
			}
		}

		public async Task<IEnumerable<Hospital>> GetHospital()
		{
			using(var db = new OdbcConnection(_connectionStrings.DPSOdbc))
			{
				await db.OpenAsync();

				var data = await db.QueryAsync<Hospital>(QueryDb.GetHospital());

				return data;
			}
		}

		public async Task<IEnumerable<Department>> GetDepartment()
		{
			using(var db = new OdbcConnection(_connectionStrings.DPSOdbc))
			{
				await db.OpenAsync();

				var data = await db.QueryAsync<Department>(QueryDb.GetDepartment());

				return data;
			}
		}

		public async Task<IEnumerable<PersonalEmail>> GetPersonalEmail(string profileIds)
		{
			using(var db = new OdbcConnection(_connectionStrings.DPSOdbc))
			{
				await db.OpenAsync();

				var data = await db.QueryAsync<PersonalEmail>(QueryDb.GetPersonalEmail(profileIds));

				return data;
			}
		}

		public async Task<IEnumerable<JobWork>> GetJobWork(string profileIds)
		{
			using (var db = new OdbcConnection(_connectionStrings.DPSOdbc))
			{
				await db.OpenAsync();

				var data = await db.QueryAsync<JobWork>(QueryDb.GetJobWork(profileIds));

				return data;
			}
		}
	}
}
