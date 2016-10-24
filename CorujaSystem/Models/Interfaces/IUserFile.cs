using System;
using System.Collections.Generic;

namespace CorujaSystem.Models
{
	public interface IUserFile
	{
        int IdUser { get; set; }

        string FileType { get; set; }

        string Name { get; set; }

        string Local { get; set; }

        string Extension { get; set; }

        string Size { get; set; }

        string Desc { get; set; }

        DateTime? DtUpload { get; set; }

        IEnumerable<Report> Rpts { get; set; }

    }
}
