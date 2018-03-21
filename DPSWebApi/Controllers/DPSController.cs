using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DPSWebApi.DataProvider;
using DPSWebApi.Models;
using DPSWebApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DPSWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DPSController : Controller
    {
		private IDPSDataProvider _dataProvider;
		private Helper _helper;

		public DPSController(IDPSDataProvider dataProvider, Helper helper)
		{
			_dataProvider = dataProvider;
			_helper = helper;
		}

		[HttpGet("GetProfile/{appId:int}")]
		public async Task<IEnumerable<Profile>> GetProfile(int appId)
		{
			if (!_helper.IsCurrectAppId(appId))
			{
				return new List<Profile>();
			}
			return await _dataProvider.GetProfiles(appId);

		}
	}
}
