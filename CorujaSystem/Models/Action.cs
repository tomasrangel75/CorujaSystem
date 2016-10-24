using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorujaSystem.Models
{
    public class UserAction:Base, IUserAction
    {
        public int IdUser { get; set; }
        public string EvtType { get; set; }
        public string Desc { get; set; }
        public DateTime EvtDt { get; set; }

    }
}
