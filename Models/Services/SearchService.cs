using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Services
{
    public class SearchService
    {
        public static List<EmployeeService> FindEmployees(string key)
        {
            List<EmployeeService> employees = null;

            using(HumanResourcesDepartmentContext db = new HumanResourcesDepartmentContext())
            {
                var query = from b in db.Employees
                            where b.Name.StartsWith(key)
                            select b;

                if(query.Count() > 0)
                {
                    employees = new List<EmployeeService>();

                    foreach(var item in query)
                    {
                        employees.Add(new EmployeeService
                            (item.Id,
                            item.Name,
                            item.Surname,
                            item.AccountNumber,
                            item.Experience,
                            item.Department.Name,
                            item.Position.Name));
                    }
                }
            }

            return employees;
        }

        public static List<EmployeeService> ExtendedFindEmployees(string key, int keyNumber)
        {
            List<EmployeeService> employees = null;

            using(HumanResourcesDepartmentContext db = new HumanResourcesDepartmentContext())
            {
                var query = from b in db.Employees
                            where b.Name.StartsWith(key)
                            || b.Surname.StartsWith(key)
                            || b.AccountNumber.Equals(keyNumber)
                            || b.Experience.Equals(keyNumber)
                            select b;

                if (query.Count() > 0)
                {
                    employees = new List<EmployeeService>();

                    foreach (var item in query)
                    {
                        employees.Add(new EmployeeService
                            (item.Id,
                            item.Name,
                            item.Surname,
                            item.AccountNumber,
                            item.Experience,
                            item.Department.Name,
                            item.Position.Name));
                    }
                }
            }

            return employees;
        }

        public static List<ProjectService> FindProjects(string key)
        {
            List<ProjectService> projects = null;
            
            using(HumanResourcesDepartmentContext db = new HumanResourcesDepartmentContext())
            {
                var query = from b in db.Projects
                            where b.Name.StartsWith(key)
                            select b;

                if(query.Count() > 0)
                {
                    projects = new List<ProjectService>();

                    foreach(var item in query)
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

        public static List<PositionService> FindPositions(string key)
        {
            List<PositionService> positions = null;

            using(HumanResourcesDepartmentContext db = new HumanResourcesDepartmentContext())
            {
                var query = from b in db.Positions
                            where b.Name.StartsWith(key)
                            select b;

                if (query.Count() > 0)
                {
                    positions = new List<PositionService>();

                    foreach (var item in query)
                    {
                        positions.Add(new PositionService
                            (item.PositionID,
                            item.Name,
                            item.Hours,
                            item.Payment));
                    }
                }
            }

            return positions;
        }

        public static List<DepartmentService> FindDepartments(string key)
        {
            List<DepartmentService> departments = null;

            using (HumanResourcesDepartmentContext db = new HumanResourcesDepartmentContext())
            {
                var query = from b in db.Departments
                            where b.Name.StartsWith(key)
                            select b;

                if (query.Count() > 0)
                {
                    departments = new List<DepartmentService>();

                    foreach (var item in query)
                    {
                        departments.Add(new DepartmentService
                            (item.DepartmentID,
                            item.Name));
                    }
                }
            }

            return departments;
        }
    }
}
