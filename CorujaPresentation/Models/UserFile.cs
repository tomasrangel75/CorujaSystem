using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using CorujaPresentation.Models;

namespace CorujaPresentation
{
    public class UserFile: Base
    {
        public int IdUser { get; set; }

        public string FileType { get; set; }

        public string Name { get; set; }

        public string Local { get; set; }

        public string Extensao { get; set; }

        public string Tamanho { get; set; }

        public string Descricao { get; set; }

        public DateTime? DtUpload { get; set; }

    }
}