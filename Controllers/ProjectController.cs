using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Services;

namespace Controllers
{
    public class ProjectController
    {
        private int projectId;
        private string name;
        private int price;

        public ProjectController(int projectId, string name, int price)
        {
            this.projectId = projectId;
            this.name = name;
            this.price = price;
        }

        public int ProjectId
        {
            get
            {
                return projectId;
            }
        }

        public int Price
        {
            get
            {
                return price;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public static void AddProject(string name, int price, int employeeId)
        {
            ProjectService.AddProject(name, price, employeeId);
        }
    }
}
