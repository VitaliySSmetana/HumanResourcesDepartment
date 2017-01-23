using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Services
{
    public class DepartmentService
    {
        private int departmentID;
        private string name;

        public DepartmentService(int departmentID, string name)
        {
            this.departmentID = departmentID;
            this.name = name;
        }

        public int DepartmentID
        {
            get
            {
                return departmentID;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public static void AddDepartment(string name)
        {
            using (HumanResourcesDepartmentContext db = new HumanResourcesDepartmentContext())
            {
                Department department = new Department { Name = name };

                db.Departments.Add(department);
                db.SaveChanges();
            }
        }

        public static List<DepartmentService> GetDepartments()
        {
            List<DepartmentService> departments = new List<DepartmentService>();

            using (HumanResourcesDepartmentContext db = new HumanResourcesDepartmentContext())
            {
                var query = from b in db.Departments
                            select b;

                foreach (var item in query)
                {
                    DepartmentService toAdd = new DepartmentService(
                        item.DepartmentID,
                        item.Name);

                    departments.Add(toAdd);
                }
            }

            return departments;
        }

        public static bool DeleteDepartments(int departmentId)
        {
            bool flag = false;
            using (HumanResourcesDepartmentContext db = new HumanResourcesDepartmentContext())
            {
                if (db.Departments.Find(departmentId) != null)
                {
                    db.Departments.Remove(db.Departments.Find(departmentId));
                    db.SaveChanges();

                    flag = true;
                }
            }
            return flag;
        }

        public static void ChangeDepartment(int departmentId, string name)
        {
            using (HumanResourcesDepartmentContext db = new HumanResourcesDepartmentContext())
            {
                if (db.Departments.Find(departmentId) != null)
                {
                    db.Departments.Find(departmentId).Name = name;
                    db.SaveChanges();
                }
            }
        }

        public static DepartmentService GetDepartment(int departmentId)
        {
            DepartmentService department = null;

            using (HumanResourcesDepartmentContext db = new HumanResourcesDepartmentContext())
            {
                if (db.Departments.Find(departmentId) != null)
                {
                    Department find = db.Departments.Find(departmentId);


                    department = new DepartmentService(find.DepartmentID, find.Name);
                }
            }

            return department;
        }

        public static List<EmployeeService> GetEmployeeList(int id)
        {
            List<EmployeeService> employees = new List<EmployeeService>();

            using (HumanResourcesDepartmentContext db = new HumanResourcesDepartmentContext())
            {
                if (db.Departments.Find(id) != null)
                {
                    Department find = db.Departments.Find(id);

                    List<Employee> findEmployees = db.Departments.Find(id).Employees;


                    foreach (Employee item in findEmployees)
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
            }
            return employees;
        }

        public static List<EmployeeService> GetEmployeeByPosition(int id)
        {
            List<EmployeeService> employeeByPosition = GetEmployeeList(id);

            if (employeeByPosition.Count != 0)
            {
                employeeByPosition = employeeByPosition.OrderBy(o => o.PositionName).ToList();
            }

            return employeeByPosition;
        }

        public static List<EmployeeService> GetEmployeeBySumProjectPrice(int id)
        {
            List<EmployeeService> employees = GetEmployeeList(id);

            if (employees.Count != 0)
            {
                employees = employees.OrderBy(o => o.SumProjectPrice).ToList();
            }

            return employees;
        }
    }
}
