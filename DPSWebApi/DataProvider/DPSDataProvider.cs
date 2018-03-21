using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DPSWebApi.AppSetings;
using DPSWebApi.DataAccess;
using DPSWebApi.Models;
using DPSWebApi.ViewModels;
using Microsoft.Extensions.Configuration;

namespace DPSWebApi.DataProvider
{
	public class DPSDataProvider : IDPSDataProvider
	{
		IDataConnection Data { get; }

		public DPSDataProvider(IDataConnection data)
		{
			Data = data;
		}

		public async Task<IEnumerable<Profile>> GetProfiles(int appId)
		{
			var profiles = new List<Profile>();

			var personalProfiles = await Data.GetPersonalProfiles();
			var personalProfilesString = String.Join(",", personalProfiles.Select(x => x.ProfileId));
			var titles = await Data.GetTitles();
			var religions = await Data.GetReligions();
			var jobWorks = await Data.GetJobWork(personalProfilesString);
			var hospitals = await Data.GetHospital();
			var departments = await Data.GetDepartment();
			var personalEmail = await Data.GetPersonalEmail(personalProfilesString);

			foreach (var personalProfile in personalProfiles)
			{
				var profileId = personalProfile.ProfileId;
				var jobWork = jobWorks.OrderByDescending(j => j.ProfileId == profileId).FirstOrDefault();

				if (jobWork == null)
				{
					jobWork = new JobWork()
					{
						ProfileId = profileId,
						WorkId = null,
						StartDate = null,
						WorkPosition = "",
						WorkStatus = "",
					};
				}

				var titleTh = titles.FirstOrDefault(t => t.TitleId == personalProfile.ProfileTitleThId);
				var titleEn = titles.FirstOrDefault(t => t.TitleId == personalProfile.ProfileTitleEngId);

				var religion = religions.FirstOrDefault(r => r.ReligionId == personalProfile.ReligionId);
				var religionName = religion == null ? "" : religion.ReligionName;

				var hospital = hospitals.FirstOrDefault(h => h.HospitalId == personalProfile.HospitalId);
				var hospitalName = hospital == null ? "" : hospital.HospitalShortname;

				var department = departments.FirstOrDefault(d => d.DepartmentId == personalProfile.DepartmentId);
				var departmentName = department == null ? "" : department.DepartmentName;

				var personalEmailPrimary = personalEmail == null ? "" : personalEmail.FirstOrDefault(e => e.EmailType == "P").EmailAddress;
				var personalEmailSecondary = personalEmail == null ? "" : personalEmail.FirstOrDefault(e => e.EmailType == "S").EmailAddress;

				try
				{
					var profile = new Profile()
					{
						ProfileId = profileId,
						DoctorId = personalProfile.DoctorId,
						EmpId = personalProfile.EmpId,
						TitleTh =titleTh == null ? "" : titleTh.TitleName,
						ThaiName = personalProfile.ThaiName,
						TitleEn = titleEn == null ? "" : titleEn.TitleName,
						EngName = personalProfile.EngName,
						Marital = personalProfile.Marital,
						Race = personalProfile.Race,
						RaceOther = personalProfile.RaceOther,
						Nationality = personalProfile.Nationality,
						NationalityOther = personalProfile.NationalityOther,
						ReligionName = religionName,
						ProfileCardId = personalProfile.ProfileCardId,
						ProfileCardExpiration = personalProfile.ProfileCardExpiration,
						SpecialtyName = personalProfile.SpecialtyName,
						SubSpecialtyName = personalProfile.SubSpecialtyName,
						StartDate = jobWork?.StartDate,
						WorkPosition = jobWork.WorkPosition,
						WorkStatus = jobWork.WorkStatus,
						HospitalName = hospitalName,
						Department = departmentName,
						DateOfBirth = personalProfile.DateOfBirth,
						Gender = personalProfile.Gender,
						PrimaryEmail = personalEmailPrimary,
						SecondaryEmail = personalEmailSecondary,
						Username = personalProfile.Username,
						MedicalLicenseID = personalProfile.MedicalLicenseID,
						PCU_Id = personalProfile.PCU_Id,
						ProfilePhoto = personalProfile.ProfilePhoto,
						PCG = personalProfile.PCG,
						ProfileFlag = personalProfile.ProfileFlag
					};
					profiles.Add(profile);
				}
				catch (Exception)
				{
				}

			}

			return profiles;
		}
	}
}
