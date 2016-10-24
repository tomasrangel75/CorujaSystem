using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorujaSystem.Models
{
    public class Test:Base, ITest
    {
        public string TestName { get; set; }
        public string Desc { get; set; }

    }
}
