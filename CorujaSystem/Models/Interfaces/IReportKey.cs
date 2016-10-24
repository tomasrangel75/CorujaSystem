using System;



namespace CorujaSystem.Models
{
	public interface IReportKey
	{
		DateTime? ActivationDate { get; set; }
		bool IsActive { get; set; }
		string KeyCode { get; set; }
		string KeyType { get; set; }
		int ReportNumber { get; set; }
		UserMapKey UserMapK { get; set; }
	}
}
