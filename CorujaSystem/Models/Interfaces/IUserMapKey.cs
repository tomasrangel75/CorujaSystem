using System;


namespace CorujaSystem.Models
{
	interface IUserMapKey
	{
		int IdKey { get; set; }
		int IdUser { get; set; }
		System.Collections.Generic.IEnumerable<ReportKey> ReportKeys { get; set; }
	}
}
