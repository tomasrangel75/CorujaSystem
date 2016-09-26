using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coruja.Model.Models
{
    public class UserMapKey
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdKey { get; set; }
        public virtual IEnumerable<ReportKey> ReportKeys { get; set; }
    }
}
