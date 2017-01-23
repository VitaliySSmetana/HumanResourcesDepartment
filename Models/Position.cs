using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Position
    {
        public int PositionID { get; set; }
        public string Name { get; set; }
        public double Payment { get; set; }
        public double Hours { get; set; }
        
        public virtual List<Employee> Employees { get; set; }       
    }
}
