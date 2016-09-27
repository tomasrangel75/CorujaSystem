using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace CorujaPresentation
{
    public class UserFile
    {
        public int Id { get; set; }

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