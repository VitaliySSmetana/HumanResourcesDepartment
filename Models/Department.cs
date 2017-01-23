using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        
        public virtual List<Employee> Employees { get; set; }
    }
}
