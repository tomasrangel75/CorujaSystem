using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorujaSystem.Models
{
    public class Report: Base
    {
       public string RptName { get; set; }
       public string RptType { get; set; }
       public DateTime DtCreated { get; set; }
       public int IdFile { get; set; }
       public UserFile RptFileResult { get; set; }

    }
}
