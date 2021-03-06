﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorujaSystem.Models
{
	public class ReportKey: Base, IReportKey
    {
		public string KeyCode { get; set; }
		public int ReportNumber { get; set; }
		public bool IsActive { get; set; }
		public DateTime? ActivationDate { get; set; }
		public string KeyType { get; set; }
		public UserMapKey UserMapK { get; set; }
	}
}
