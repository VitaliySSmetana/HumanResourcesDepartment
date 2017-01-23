using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int AccountNumber { get; set; }               
        public int Experience { get; set; }

        public virtual Department Department { get; set; }
        public virtual Position Position { get; set; }
        public virtual List<Project> Projects { get; set; }
    }
}
