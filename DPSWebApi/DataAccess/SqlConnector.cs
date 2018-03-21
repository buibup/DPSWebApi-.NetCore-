using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DPSWebApi.Models;

namespace DPSWebApi.DataAccess
{
	public class SqlConnector //: IDataConnection
	{
		public Task<IEnumerable<PersonalProfile>> GetPersonalProfiles()
		{
			throw new NotImplementedException();
		}

	}
}
