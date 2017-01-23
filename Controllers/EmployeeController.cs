using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Services;

namespace Controllers
{
    public class EmployeeController
    {
        private int id;
        private string name;
        private string surname;
        private int accountNumber;
        private int experience;
        private string departmentName;
        private string positionName;
        private int sumProjectPrice = 0;

        public EmployeeController(int id, string name, string surname, int accountNumber,
            int experience, string departmentName, string positionName)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.accountNumber = accountNumber;
            this.experience = experience;
            this.departmentName = departmentName;
            this.positionName = positionName;
        }

        public int Id
        {
            get
            {
                return id;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }
        }

        public int AccountNumber
        {
            get
            {
                return accountNumber;
            }
        }

        public int Experience
        {
            get
            {
                return experience;
            }
        }

        public string DepartmentName
        {
            get
            {
                return departmentName;
            }
        }

        public string PositionName
        {
            get
            {
                return positionName;
            }
        }

      /*  public int SumProjectPrice
        {
            get
            {
                using (HumanResourcesDepartmentContext db = new HumanResourcesDepartmentContext())
                {
                    if (db.Employees.Find(id) != null)
                    {
                        List<Project> dbProjects = db.Employees.Find(id).Projects;

                        foreach (Project item in dbProjects)
                        {
                            sumProjectPrice += item.Price;
                        }
                    }
                }
                return sumProjectPrice;
            }
        }*/

        public static void AddEmployee(string name, string surname, int accountnumber,
            int experience, int idDepartment, int idPosition)
        {

            EmployeeService.AddEmployee(name, surname, accountnumber, experience, idDepartment, idPosition);               
            
        }


        public static List<EmployeeController> GetEmployees()
        {
            List<EmployeeController> employees = new List<EmployeeController>();

            List<EmployeeService> getEmployees = EmployeeService.GetEmployees();

            foreach (var item in getEmployees)
            {
                EmployeeController toAdd = new EmployeeController(
                    item.Id,
                    item.Name,
                    item.Surname,
                    item.AccountNumber,
                    item.Experience,
                    item.DepartmentName,
                    item.PositionName );

                employees.Add(toAdd);
            }
            
            return employees;
        }

        public static EmployeeController GetEmployee(int id)
        {
            EmployeeController employee = null;
            EmployeeService getEmployee = EmployeeService.GetEmployee(id);
            
            if(getEmployee != null)
            {
                employee = new EmployeeController
                    (getEmployee.Id,
                    getEmployee.Name,
                    getEmployee.Surname,
                    getEmployee.AccountNumber,
                    getEmployee.Experience,
                    getEmployee.DepartmentName,
                    getEmployee.PositionName);
            }

            return employee;
        }

        public static bool DeleteEmployee(int id)
        {
            return EmployeeService.DeleteEmployee(id);            
        }


        public static List<EmployeeController> GetByName()
        {
            List<EmployeeController> employees = new List<EmployeeController>();

            List<EmployeeService> byName = EmployeeService.GetByName();

            foreach (var item in byName)
            {
                EmployeeController toAdd = new EmployeeController
                    (item.Id,
                    item.Name,
                    item.Surname,
                    item.AccountNumber,
                    item.Experience,
                    item.DepartmentName,
                    item.PositionName);

                employees.Add(toAdd);
            }
            
            return employees;
        }
    
        public static List<EmployeeController> GetBySurname()
        {
            List<EmployeeController> employees = new List<EmployeeController>();

            List<EmployeeService> bySurname = EmployeeService.GetBySurname();

            foreach (var item in bySurname)
            {
                EmployeeController toAdd = new EmployeeController
                    (item.Id,
                    item.Name,
                    item.Surname,
                    item.AccountNumber,
                    item.Experience,
                    item.DepartmentName,
                    item.PositionName);

                employees.Add(toAdd);
            }

            return employees;
        }
    
        public static List<EmployeeController> GetByPayment()
        {
            List<EmployeeController> employees = new List<EmployeeController>();

            List<EmployeeService> byPayment = EmployeeService.GetByPayment();

            foreach (var item in byPayment)
            {
                EmployeeController toAdd = new EmployeeController
                    (item.Id,
                    item.Name,
                    item.Surname,
                    item.AccountNumber,
                    item.Experience,
                    item.DepartmentName,
                    item.PositionName);

                employees.Add(toAdd);
            }

            return employees;
        }

        public static List<ProjectController> GetEmployeeProjects(int id)
        {
            List<ProjectController> projects = new List<ProjectController>();

            List<ProjectService> getProjects = EmployeeService.GetEmployeeProjects(id);
            if (getProjects != null)
            {
                foreach(ProjectService item in getProjects)
                {
                    projects.Add(new ProjectController
                        (item.ProjectId,
                        item.Name,
                        item.Price));
                }
            }
            
            return projects;
        }

        public static void ChangeName(int id, string name)
        {
            EmployeeService.ChangeName(id, name);
        }

        public static void ChangeSurname(int id, string surname)
        {
            EmployeeService.ChangeSurname(id, surname);
        }

        public static void ChangeAccountNumber(int id, int accountNummber)
        {
            EmployeeService.ChangeAccountNumber(id, accountNummber);
        }

        public static void ChangeExperience(int id, int experience)
        {
            EmployeeService.ChangeExperience(id, experience);
        }

        public static void ChangeDepartment(int id, int departmentId)
        {
            EmployeeService.ChangeDepartment(id, departmentId);
        }

        public static void ChangePosition(int id, int positionId)
        {
            EmployeeService.ChangePosition(id, positionId);
        }
    }
}
