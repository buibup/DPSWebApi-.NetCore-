using DPSWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DPSWebApi.DataAccess
{
    public interface IDataConnection
    {
		Task<IEnumerable<PersonalProfile>> GetPersonalProfiles();
		Task<IEnumerable<Title>> GetTitles();
		Task<IEnumerable<Religion>> GetReligions();
		Task<IEnumerable<JobWork>> GetJobWork(string profileIds);
		Task<JobWork> GetJobWorkByProfileId(int profileId);
		Task<IEnumerable<Hospital>> GetHospital();
		Task<IEnumerable<Department>> GetDepartment();
		Task<IEnumerable<PersonalEmail>> GetPersonalEmail(string profileIds);
	}
}
