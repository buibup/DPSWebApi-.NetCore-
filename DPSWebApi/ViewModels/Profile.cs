using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPSWebApi.ViewModels
{
    public class Profile
    {
		public int ProfileId { get; set; }
		public string DoctorId { get; set; }
		public string EmpId { get; set; }
		public string TitleTh { get; set; }
		public string ThaiName { get; set; }
		public string TitleEn { get; set; }
		public string EngName { get; set; }
		public string Marital { get; set; }
		public string Race { get; set; }
		public string RaceOther { get; set; }
		public string Nationality { get; set; }
		public string NationalityOther { get; set; }
		public string ReligionName { get; set; }
		public string ProfileCardId { get; set; }
		public DateTime? ProfileCardExpiration { get; set; }
		public string SpecialtyName { get; set; }
		public string SubSpecialtyName { get; set; }
		public DateTime? StartDate { get; set; }
		public string WorkPosition { get; set; }
		public string WorkStatus { get; set; }
		public string HospitalName { get; set; }
		public string Department { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string Gender { get; set; }
		public string PrimaryEmail { get; set; }
		public string SecondaryEmail { get; set; }
		public string Username { get; set; }
		public string MedicalLicenseID { get; set; }
		public string PCU_Id { get; set; }
		public string ProfilePhoto { get; set; }
		public string PCG { get; set; }
		public string ProfileFlag { get; set; }
	}
}
