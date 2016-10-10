using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorujaPresentation.Models
{
    public class Report: Base
    {
       public int IdUser { get; set; }
       public string RptType { get; set; }
       public DateTime DtGeracao { get; set; }
       public string Dominio { get; set; }

    }
}
