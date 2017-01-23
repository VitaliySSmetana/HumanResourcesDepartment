using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers;

namespace CourseWork
{
    class SearchView
    {
        private static string[] options = {"1.Поиск работников", "2.Поиск проектов",
            "3.Расширенный поиск работников", "4.Поиск по всем данным", "5.Назад", "6.Выход"};
        
        public static void SearchMenu()
        {
            Console.Clear();
            foreach(string option in options)
            {
                Console.WriteLine(option);
            }

            switch (Console.ReadLine())
            {
                case "1":
                    FindEmployees();
                    CallMenu();
                    break;
                case "2":
                    FindProjects();
                    CallMenu();
                    break;
                case "3":
                    ExtendedFindEmployees();
                    CallMenu();
                    break;
                case "4":
                    FindAll();
                    CallMenu();
                    break;
                case "5":
                    MainView.MainMenu();
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    SearchMenu();
                    break;
            }
        }

        private static void CallMenu()
        {
            Console.ReadKey();
            SearchMenu();
        }

        private static void FindEmployees()
        {
            Console.Write("Введите ключевое слово: ");
            string key = Console.ReadLine();

            List<EmployeeController> employees = SearchController.FindEmployees(key);

            if (employees != null && employees.Count > 0)
            {
                foreach(var employee in employees)
                {
                    Console.WriteLine(
                        employee.Id + " " +
                        employee.Name + " " +
                        employee.Surname + " " +
                        employee.AccountNumber + " " +
                        employee.Experience + " " +
                        employee.DepartmentName + " " +
                        employee.PositionName);
                }
            }
            else
            {
                Console.WriteLine("Ничего не найдено");
            }
        }

        private static void ExtendedFindEmployees()
        {
            Console.Write("Введите ключевое слово: ");
            string key = Console.ReadLine();

            Console.Write("Введите ключевое число: ");
            int keyNumber = Parse.ParseInt();

            List<EmployeeController> employees = SearchController.ExtendedFindEmployees(key, keyNumber);

            if (employees != null && employees.Count > 0)
            {
                foreach (var employee in employees)
                {
                    Console.WriteLine(
                        employee.Id + " " +
                        employee.Name + " " +
                        employee.Surname + " " +
                        employee.AccountNumber + " " +
                        employee.Experience + " " +
                        employee.DepartmentName + " " +
                        employee.PositionName);
                }
            }
            else
            {
                Console.WriteLine("Ничего не найдено");
            }
        }
        
        private static void FindProjects()
        {
            Console.Write("Введите ключевое слово: ");
            string key = Console.ReadLine();

            List<ProjectController> projects = SearchController.FindProjects(key);

            if(projects != null && projects.Count > 0)
            {
                foreach(var project in projects)
                {
                    Console.WriteLine
                        (project.ProjectId + " " +
                        project.Name + " " +
                        project.Price);
                }
            }
            else
            {
                Console.WriteLine("Ничего не найдено");
            }
        }

        private static void FindAll()
        {
            Console.Write("Введите ключевое слово: ");
            string key = Console.ReadLine();

            List<EmployeeController> employees = SearchController.FindEmployees(key);

            if (employees != null && employees.Count > 0)
            {
                foreach (var employee in employees)
                {
                    Console.WriteLine(
                        employee.Id + " " +
                        employee.Name + " " +
                        employee.Surname + " " +
                        employee.AccountNumber + " " +
                        employee.Experience + " " +
                        employee.DepartmentName + " " +
                        employee.PositionName);
                }
            }
            else
            {
                Console.WriteLine("В работниках ничего не найдено");
            }

            List<ProjectController> projects = SearchController.FindProjects(key);

            if (projects != null && projects.Count > 0)
            {
                foreach (var project in projects)
                {
                    Console.WriteLine
                        (project.ProjectId + " " +
                        project.Name + " " +
                        project.Price);
                }
            }
            else
            {
                Console.WriteLine("В проектах ничего не найдено");
            }

            List<PositionController> positions = SearchController.FindPosition(key);

            if (positions != null && positions.Count > 0)
            {
                foreach(var position in positions)
                {
                    Console.WriteLine(position.PositionId + " " + position.Name + " " + position.Hours + " " + position.Payment);
                }
            }
            else
            {
                Console.WriteLine("В должностях ничего не найдено");
            }

            List<DepartmentController> departments = SearchController.FindDepartments(key);

            if (departments != null && departments.Count > 0)
            {
                foreach(var department in departments)
                {
                    Console.WriteLine(department.DepartmentID + " " + department.Name);
                }
            }
            else
            {
                Console.WriteLine("В отделах ничего не найдено");
            }
        }
    }
}
