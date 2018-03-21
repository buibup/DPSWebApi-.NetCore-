using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPSWebApi.DataAccess
{
    public class QueryDb
    {
		public static string GetPersonalProfile()
		{
			const string query = @"
				SELECT P.PROFILE_ID ProfileId, P.DOCTOR_ID DoctorId, EMP_ID EmpId,
				P.PROFILE_TITLE_THA_ID ProfileTitleThId,
				P.PROFILE_FIRST_NAME_THA + ' ' + P.PROFILE_LAST_NAME_THA As [ThaiName],
				P.PROFILE_TITLE_ENG_ID ProfileTitleEngId,
				P.PROFILE_FIRST_NAME_ENG + ' ' + P.PROFILE_LAST_NAME_ENG As [EngName],
				CASE P.MARITAL WHEN 1 THEN 'Single' WHEN 2 THEN 'Married' WHEN 3 THEN 'Divorced' WHEN 4 THEN 'Widowed' END As Marital,
				CASE P.RACE WHEN 1 THEN 'Thai' WHEN 2 THEN 'Other' End As Race,
				P.RaceOther,
				CASE P.NATIONALITY WHEN 1 THEN 'Thai' WHEN 2 THEN 'Other' End As Nationality,
				P.NationalityOther,
				P.RELIGION_ID ReligionId,
				P.PROFILE_CARD_ID ProfileCardId,
				P.PROFILE_CARD_EXPIRATION ProfileCardExpiration,
				S.SPECIALTY_NAME SpecialtyName,S.SUBSPECIALTY_NAME SubSpecialtyName,
				P.Hospital_Id HospitalId,
				P.DEPARTMENT_ID DepartmentId,
				P.PROFILE_BIRTH_DATE As [DateOfBirth],
				P.PROFILE_GENDER As [Gender],
				P.ACCOUNT_ID As [Username],
				P.PROFILE_MEDICAL_LICENSE As [MedicalLicenseID],
				P.PCU_Id,
				P.PROFILE_PHOTO ProfilePhoto,
				P.PCG,
				P.PROFILE_FLAG ProfileFlag
				FROM [DPS].[dbo].DPS_PERSONAL_PROFILE P LEFT JOIN [DPS].[dbo].DPS_TRAINING_SPECIALTY S on P.PROFILE_ID = S.PROFILE_ID
				WHERE HOSPITAL_ID in (1,10,22)
			";

			return query;
		}

		public static string GetTitle()
		{
			const string query = @"
				select Title_ID TitleId,TITLE_NAME TitleName,TITLE_TYPE TitleType
				from [DPS].[dbo].DPS_MT_TITLE";

			return query;
		}

		public static string GetReligion()
		{
			const string query = @"
				select RELIGION_ID ReligionId, RELIGION_CODE ReligionCode, RELIGION_NAME ReligionName
				from [DPS].[dbo].DPS_MT_RELIGION";

			return query;
		}

		public static string GetJobWork(string profileIds)
		{
			string query = @"
				WITH worker AS (
					SELECT w.WORK_ID, w.PROFILE_ID, w.WORK_GROUP, w.WORK_POSITION, w.WORK_START_DATE, 
					ROW_NUMBER() OVER (PARTITION BY PROFILE_ID ORDER BY WORK_ID DESC) AS wklast
					FROM [DPS].[dbo].DPS_JOB_WORK  AS w
					where PROFILE_ID in ({profileIds})
				)
				SELECT WORK_ID WorkId, PROFILE_ID ProfileId, WORK_START_DATE StartDate,
				WORK_POSITION_NAME WorkPosition, WORK_GROUP_NAME WorkStatus 
				FROM worker W LEFT JOIN [DPS].[dbo].DPS_MT_WORK_POSITION WP ON W.WORK_POSITION = WP.WORK_POSITION_ID
				LEFT JOIN [DPS].[dbo]. DPS_MT_WORK_GROUP MG ON W.WORK_GROUP = MG.WORK_GROUP_ID
				WHERE wklast = 1;
			";

			query = query.Replace("{profileIds}", profileIds);

			return query;
		}

		public static string GetJobWorkByProfileId()
		{
			const string query = @"
				select top 1 WORK_ID WorkId, PROFILE_ID ProfileId, WORK_START_DATE StartDate,
				WORK_POSITION_NAME WorkPosition, WORK_GROUP_NAME WorkStatus
				from [DPS].[dbo].DPS_JOB_WORK W LEFT JOIN [DPS].[dbo].DPS_MT_WORK_POSITION WP ON W.WORK_POSITION = WP.WORK_POSITION_ID
				LEFT JOIN[DPS].[dbo]. DPS_MT_WORK_GROUP MG ON W.WORK_GROUP = MG.WORK_GROUP_ID Where W.PROFILE_ID = ?
				order by W.WORK_ID desc";

			return query;
		}

		public static string GetHospital()
		{
			const string query = @"
				select HOSPITAL_ID HospitalId, HOSPITAL_SHORTNAME HospitalShortname, HOSPITAL_NAME HospitalName
				from [DPS].[dbo].DPS_HOSPITAL_INFO
			";

			return query;
		}

		public static string GetDepartment()
		{
			const string query = @"
				select DEPARTMENT_ID DepartmentId, DEPARTMENT_NAME DepartmentName
				from [DPS].[dbo].DPS_MT_DEPARTMENT
			";

			return query;
		}

		public static string GetPersonalEmail(string profileIds)
		{
			string query = @"
				SELECT EMAIL_ID EmailId, PROFILE_ID ProfileId, EMAIL_TYPE EmailType, EMAIL_ADDRESS EmailAddress
				FROM [DPS].[dbo].DPS_PERSONAL_EMAIL
				WHERE PROFILE_ID in ({profileIds})
			";

			query = query.Replace("{profileIds}", profileIds);

			return query;
		}
	}
}
