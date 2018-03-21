using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPSWebApi.Models
{
    public class JobWork
    {
		public int? WorkId { get; set; }
		public int? ProfileId { get; set; }
		public DateTime? StartDate { get; set; }
		public string WorkPosition { get; set; }
		public string WorkStatus { get; set; }
	}
}
