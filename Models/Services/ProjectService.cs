using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Services
{
    public class ProjectService
    {
        private int projectId;
        private string name;
        private int price;

        public ProjectService(int projectId, string name, int price)
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
            using (HumanResourcesDepartmentContext db = new HumanResourcesDepartmentContext())
            {
                Project project = new Project
                {
                    Name = name,
                    Price = price,
                    Employee = db.Employees.Find(employeeId)
                };

                db.Projects.Add(project);
                db.SaveChanges();
            }
        }
    }
}
