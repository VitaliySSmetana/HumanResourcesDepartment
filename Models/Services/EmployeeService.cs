using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Services
{
    public class EmployeeService
    {
        private int id;
        private string name;
        private string surname;
        private int accountNumber;
        private int experience;
        private string departmentName;
        private string positionName;
        private int sumProjectPrice = 0;

        public EmployeeService(int id, string name, string surname, int accountNumber,
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

        public int SumProjectPrice
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
        }

        public static void AddEmployee(string name, string surname, int accountnumber,
            int experience, int idDepartment, int idPosition)
        {

            using (HumanResourcesDepartmentContext db = new HumanResourcesDepartmentContext())
            {

                Employee employee = new Employee
                {
                    Name = name,
                    Surname = surname,
                    AccountNumber = accountnumber,
                    Experience = experience,
                    Department = db.Departments.Find(idDepartment),
                    Position = db.Positions.Find(idPosition)
                };

                db.Employees.Add(employee);
                db.SaveChanges();
            }
        }


        public static List<EmployeeService> GetEmployees()
        {
            List<EmployeeService> employees = new List<EmployeeService>();
            using (HumanResourcesDepartmentContext db = new HumanResourcesDepartmentContext())
            {
                var query = from b in db.Employees
                            select b;

                foreach (var item in query)
                {
                    EmployeeService toAdd = new EmployeeService(
                        item.Id,
                        item.Name,
                        item.Surname,
                        item.AccountNumber,
                        item.Experience,
                        item.Department.Name,
                        item.Position.Name);

                    employees.Add(toAdd);
                }
            }
            return employees;
        }

        public static EmployeeService GetEmployee(int id)
        {
            EmployeeService employee = null;
            Employee find = null;

            using (HumanResourcesDepartmentContext db = new HumanResourcesDepartmentContext())
            {
                if (db.Employees.Find(id) != null)
                {
                    find = db.Employees.Find(id);

                    employee = new EmployeeService(
                        find.Id,
                        find.Name,
                        find.Surname,
                        find.AccountNumber,
                        find.Experience,
                        find.Department.Name,
                        find.Position.Name);
                }
            }

            return employee;
        }

        public static bool DeleteEmployee(int id)
        {
            bool flag = false;
            using (HumanResourcesDepartmentContext db = new HumanResourcesDepartmentContext())
            {

                if (db.Employees.Find(id) != null)
                {
                    foreach(var item in db.Employees.Find(id).Projects)
                    {
                        item.Employee = null;
                    }
                    db.Employees.Remove(db.Employees.Find(id));
                    db.SaveChanges();

                    flag = true;

                }

            }
            return flag;
        }


        public static List<EmployeeService> GetByName()
        {
            List<EmployeeService> employees = new List<EmployeeService>();
            using (HumanResourcesDepartmentContext db = new HumanResourcesDepartmentContext())
            {
                var query = from b in db.Employees
                            orderby b.Name
                            select b;

                foreach (var item in query)
                {
                    EmployeeService toAdd = new EmployeeService
                        (item.Id,
                        item.Name,
                        item.Surname,
                        item.AccountNumber,
                        item.Experience,
                        item.Department.Name,
                        item.Position.Name);

                    employees.Add(toAdd);
                }
            }
            return employees;
        }

        public static List<EmployeeService> GetBySurname()
        {
            List<EmployeeService> employees = new List<EmployeeService>();
            using (HumanResourcesDepartmentContext db = new HumanResourcesDepartmentContext())
            {
                var query = from b in db.Employees
                            orderby b.Surname
                            select b;

                foreach (var item in query)
                {
                    EmployeeService toAdd = new EmployeeService
                        (item.Id,
                        item.Name,
                        item.Surname,
                        item.AccountNumber,
                        item.Experience,
                        item.Department.Name,
                        item.Position.Name);

                    employees.Add(toAdd);
                }
            }
            return employees;
        }

        public static List<EmployeeService> GetByPayment()
        {
            List<EmployeeService> employees = new List<EmployeeService>();
            using (HumanResourcesDepartmentContext db = new HumanResourcesDepartmentContext())
            {
                var query = from b in db.Employees
                            orderby b.Position.Payment
                            select b;

                foreach (var item in query)
                {
                    EmployeeService toAdd = new EmployeeService
                        (item.Id,
                        item.Name,
                        item.Surname,
                        item.AccountNumber,
                        item.Experience,
                        item.Department.Name,
                        item.Position.Name);

                    employees.Add(toAdd);
                }
            }
            return employees;
        }

        public static List<ProjectService> GetEmployeeProjects(int id)
        {
            List<ProjectService> projects = new List<ProjectService>();

            using (HumanResourcesDepartmentContext db = new HumanResourcesDepartmentContext())
            {
                if (db.Employees.Find(id) != null)
                {
                    List<Project> dbProjects = db.Employees.Find(id).Projects;

                    foreach (Project item in dbProjects)
                    {
                        projects.Add(new ProjectService
                            (item.ProjectId,
                            item.Name,
                            item.Price));
                    }
                }
            }
            return projects;
        }

        public static void ChangeName(int id, string name)
        {
            using (HumanResourcesDepartmentContext db = new HumanResourcesDepartmentContext())
            {
                if (db.Employees.Find(id) != null)
                {
                    db.Employees.Find(id).Name = name;
                    db.SaveChanges();
                }
            }
        }

        public static void ChangeSurname(int id, string surname)
        {
            using (HumanResourcesDepartmentContext db = new HumanResourcesDepartmentContext())
            {
                if (db.Employees.Find(id) != null)
                {
                    db.Employees.Find(id).Surname = surname;
                    db.SaveChanges();
                }
            }
        }

        public static void ChangeAccountNumber(int id, int accountNummber)
        {
            using (HumanResourcesDepartmentContext db = new HumanResourcesDepartmentContext())
            {
                if (db.Employees.Find(id) != null)
                {
                    db.Employees.Find(id).AccountNumber = accountNummber;
                    db.SaveChanges();
                }
            }
        }

        public static void ChangeExperience(int id, int experience)
        {
            using (HumanResourcesDepartmentContext db = new HumanResourcesDepartmentContext())
            {
                if (db.Employees.Find(id) != null)
                {
                    db.Employees.Find(id).Experience = experience;
                    db.SaveChanges();
                }
            }
        }

        public static void ChangeDepartment(int id, int departmentId)
        {
            using (HumanResourcesDepartmentContext db = new HumanResourcesDepartmentContext())
            {
                if (db.Employees.Find(id) != null)
                {
                    db.Employees.Find(id).Department = db.Departments.Find(departmentId);
                    db.SaveChanges();
                }
            }
        }

        public static void ChangePosition(int id, int positionId)
        {
            using (HumanResourcesDepartmentContext db = new HumanResourcesDepartmentContext())
            {
                if (db.Employees.Find(id) != null)
                {
                    db.Employees.Find(id).Position = db.Positions.Find(positionId);
                    db.SaveChanges();
                }
            }
        }
    }
}
