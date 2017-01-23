using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public Employee Employee { get; set; }
    }
}
