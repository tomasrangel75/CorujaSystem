using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using CorujaSystem.Models;
using System.Collections.Generic;

namespace CorujaSystem
{
    public class UserFile: Base, IUserFile
    {
        public int IdUser { get; set; }

        public string FileType { get; set; }

        public string Name { get; set; }

        public string Local { get; set; }

        public string Extension { get; set; }

        public string Size { get; set; }

        public string Desc { get; set; }

        public DateTime? DtUpload { get; set; }
        
        public IEnumerable<Report> Rpts { get; set; }

       
    }
}