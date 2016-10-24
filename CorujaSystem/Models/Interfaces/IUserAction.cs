using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorujaSystem.Models
{
    interface IUserAction
    {
        int IdUser { get; set; }
        string EvtType { get; set; }
        string Desc { get; set; }
        DateTime EvtDt { get; set; }
    }
}
