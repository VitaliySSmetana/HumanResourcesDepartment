using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Services;

namespace Controllers
{
    public class SearchController
    {
        public static List<EmployeeController> FindEmployees(string key)
        {
            List<EmployeeController> employees = null;

            List<EmployeeService> getEmployees = SearchService.FindEmployees(key);

            if (getEmployees != null && getEmployees.Count > 0)
            {
                employees = new List<EmployeeController>();

                foreach(var item in getEmployees)
                {
                    employees.Add(new EmployeeController(
                        item.Id,
                        item.Name,
                        item.Surname,
                        item.AccountNumber,
                        item.Experience,
                        item.DepartmentName,
                        item.PositionName));
                }
            }

            return employees;
        }

        public static List<EmployeeController> ExtendedFindEmployees(string key, int keyNumber)
        {
            List<EmployeeController> employees = null;

            List<EmployeeService> getEmployees = SearchService.ExtendedFindEmployees(key, keyNumber);

            if (getEmployees != null && getEmployees.Count > 0)
            {
                employees = new List<EmployeeController>();

                foreach (var item in getEmployees)
                {
                    employees.Add(new EmployeeController(
                        item.Id,
                        item.Name,
                        item.Surname,
                        item.AccountNumber,
                        item.Experience,
                        item.DepartmentName,
                        item.PositionName));
                }
            }

            return employees;
        }

        public static List<PositionController> FindPosition(string key)
        {
            List<PositionController> positions = null;

            List<PositionService> getPositions = SearchService.FindPositions(key);

            if (getPositions != null && getPositions.Count > 0)
            {
                positions = new List<PositionController>();

                foreach(var item in getPositions)
                {
                    positions.Add(new PositionController(
                        item.PositionId,
                        item.Name,
                        item.Hours,
                        item.Payment));
                }
            }
            
            return positions;
        }

        public static List<ProjectController> FindProjects(string key)
        {
            List<ProjectController> projects = null;

            List<ProjectService> getProjects = SearchService.FindProjects(key);

            if(getProjects != null && getProjects.Count > 0)
            {
                projects = new List<ProjectController>();

                foreach(var item in getProjects)
                {
                    projects.Add(new ProjectController
                        (item.ProjectId,
                        item.Name,
                        item.Price));
                }
            }

            return projects;
        }

        public static List<DepartmentController> FindDepartments(string key)
        {
            List<DepartmentController> departments = null;

            List<DepartmentService> getDepartments = SearchService.FindDepartments(key);

            if(getDepartments != null && getDepartments.Count > 0)
            {
                departments = new List<DepartmentController>();

                foreach(var item in getDepartments)
                {
                    departments.Add(new DepartmentController
                        (item.DepartmentID,
                        item.Name));
                }
            }

            return departments;
        }
    }
}
