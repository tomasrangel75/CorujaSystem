using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorujaSystem.Models
{
    
    public class Especialist : Base
    {
        public int IdUser { get; set; }
        public string EspecName { get; set; }
        public IEnumerable<Student> Kids { get; set; }

    }

    public class Student:Base
    {
        public string PersonName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }
        public string DtRegister { get; set; }

        public int idEspec { get; set; }
        public Especialist Espec { get; set; }

        public IEnumerable<Pontuacao> Pontuacaos { get; set; }

    }

    public class Pontuacao : Base
    {
        public int  IdQuestion { get; set; }
        public Boolean Correct { get; set; }
        public int Attempt { get; set; }
        public string TimeForQest { get; set; }
        public string Mouse { get; set; }
        public string Clicks { get; set; }
        public DateTime? DtTime { get; set; }

        public int idPerson { get; set; }
        public Student PersonTested { get; set; }

    }


}
