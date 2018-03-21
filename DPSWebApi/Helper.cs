using DPSWebApi.AppSetings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPSWebApi
{
    public class Helper
    {
		SettingsDPS SettingsDPS { get; }
		public Helper(SettingsDPS settingsDPS)
		{
			SettingsDPS = settingsDPS;
		}
		public bool IsCurrectAppId(int appId)
		{
			int? _appId = appId;
			var isAppIdNull = _appId == null ? true : false;

			if (isAppIdNull)
			{
				return false;
			}

			if (!IsMatchedAppId(appId))
			{
				return false;
			}

			return true;
		}

		private bool IsMatchedAppId(int appId)
		{
			int castAppId = 0;

			var appIdStr = SettingsDPS.AppId.ToString();
			var appIdArr = appIdStr.Split('|');


			foreach (var _appId in appIdArr)
			{
				castAppId = int.Parse(_appId);
				if (castAppId == appId)
				{
					return true;
				}
			}

			return false;
		}
	}
}
