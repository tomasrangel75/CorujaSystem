using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorujaSystem.Models
{
	public class UserMapKey: Base
    {
		public int IdUser { get; set; }
		public int IdKey { get; set; }
		public virtual IEnumerable<ReportKey> ReportKeys { get; set; }
	}
}
