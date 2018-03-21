using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPSWebApi.Models
{
    public class PersonalEmail
    {
		public int EmailId { get; set; }
		public int ProfileId { get; set; }
		public string EmailType { get; set; }
		public string EmailAddress { get; set; }
	}
}
