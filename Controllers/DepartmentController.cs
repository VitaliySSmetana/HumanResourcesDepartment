using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Services;

namespace Controllers
{
    public class DepartmentController
    {
        private int departmentID;
        private string name;

        public DepartmentController(int departmentID, string name)
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
            DepartmentService.AddDepartment(name);
        }

        public static List<DepartmentController> GetDepartments()
        {
            List<DepartmentController> departments = new List<DepartmentController>();

            List<DepartmentService> getDepartments = DepartmentService.GetDepartments();

            foreach (var item in getDepartments)
            {
                DepartmentController toAdd = new DepartmentController(
                    item.DepartmentID,
                    item.Name );

                departments.Add(toAdd);
            }
            

            return departments;
        }

        public static bool DeleteDepartments(int departmentId)
        {
            return DepartmentService.DeleteDepartments(departmentId);
        }

        public static void ChangeDepartment(int departmentId, string name)
        {
            DepartmentService.ChangeDepartment(departmentId, name);
        }

        public static DepartmentController GetDepartment(int departmentId)
        {
            DepartmentController department = null;

            DepartmentService getDepartment = DepartmentService.GetDepartment(departmentId);

            
            if(getDepartment != null)
            {               
                department = new DepartmentController(getDepartment.DepartmentID, getDepartment.Name);
            }            
            
            return department;
        }

        public static List<EmployeeController> GetEmployeeList(int id)
        {
            List<EmployeeController> employees = new List<EmployeeController>();

            List<EmployeeService> getEmployees = DepartmentService.GetEmployeeList(id);
            
            if (getEmployees.Count != 0)
            {               
                foreach (EmployeeService item in getEmployees)
                {
                    EmployeeController toAdd = new EmployeeController(
                        item.Id,
                        item.Name, 
                        item.Surname, 
                        item.AccountNumber,
                        item.Experience, 
                        item.DepartmentName, 
                        item.PositionName);

                    employees.Add(toAdd);
                }
            }
                        
            return employees;
        }
        
        public static List<EmployeeController> GetEmployeeByPosition(int id)
        {
            List<EmployeeController> employeeByPosition = new List<EmployeeController>();

            List<EmployeeService> getEmployeeByPosition = DepartmentService.GetEmployeeByPosition(id);

            if(getEmployeeByPosition.Count != 0)
            {
                for(int i = 0; i < getEmployeeByPosition.Count; i++)
                {
                    employeeByPosition.Add(new EmployeeController
                        (getEmployeeByPosition[i].Id,
                        getEmployeeByPosition[i].Name,
                        getEmployeeByPosition[i].Surname,
                        getEmployeeByPosition[i].AccountNumber,
                        getEmployeeByPosition[i].Experience,
                        getEmployeeByPosition[i].DepartmentName,
                        getEmployeeByPosition[i].PositionName));
                }
            }
                        
            return employeeByPosition;
        }
        
        public static List<EmployeeController> GetEmployeeBySumProjectPrice(int id)
        {
            List<EmployeeService> getEmployees = DepartmentService.GetEmployeeBySumProjectPrice(id);

            List<EmployeeController> employees = new List<EmployeeController>();

            if(getEmployees.Count != 0)
            {
                for (int i = 0; i < getEmployees.Count; i++)
                {
                    employees.Add(new EmployeeController
                        (getEmployees[i].Id,
                        getEmployees[i].Name,
                        getEmployees[i].Surname,
                        getEmployees[i].AccountNumber,
                        getEmployees[i].Experience,
                        getEmployees[i].DepartmentName,
                        getEmployees[i].PositionName));
                }
            }

            return employees;
        }
    }
}
