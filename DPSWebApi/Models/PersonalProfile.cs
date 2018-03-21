using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPSWebApi.Models
{
    public class PersonalProfile
    {
		public int ProfileId { get; set; }
		public string DoctorId { get; set; }
		public string EmpId { get; set; }
		public int? ProfileTitleThId { get; set; }
		public string ThaiName { get; set; }
		public int? ProfileTitleEngId { get; set; }
		public string EngName { get; set; }
		public string Marital { get; set; }
		public string Race { get; set; }
		public string RaceOther { get; set; }
		public string Nationality { get; set; }
		public string NationalityOther { get; set; }
		public int? ReligionId { get; set; }
		public string ProfileCardId { get; set; }
		public DateTime? ProfileCardExpiration { get; set; }
		public string SpecialtyName { get; set; }
		public string SubSpecialtyName { get; set; }
		public int? HospitalId { get; set; }
		public int? DepartmentId { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string Gender { get; set; }
		public string Username { get; set; }
		public string MedicalLicenseID { get; set; }
		public string PCU_Id { get; set; }
		public string ProfilePhoto { get; set; }
		public string PCG { get; set; }
		public string ProfileFlag { get; set; }
	}
}
