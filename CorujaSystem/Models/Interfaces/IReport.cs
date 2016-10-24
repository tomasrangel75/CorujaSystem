using System;


namespace CorujaSystem.Models
{
	public interface IReport
	{
        string RptName { get; set; }
        string RptType { get; set; }
        DateTime DtCreated { get; set; }
        int IdFile { get; set; }
        UserFile RptFileResult { get; set; }
    }
}
