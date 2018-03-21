using DPSWebApi.Models;
using DPSWebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPSWebApi.DataProvider
{
    public interface IDPSDataProvider
    {
		Task<IEnumerable<Profile>> GetProfiles(int appId);
	}
}
