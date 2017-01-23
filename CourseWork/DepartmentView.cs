using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers;

namespace CourseWork
{
    class DepartmentView
    {
        private static string[] options = { "1.Добавить отдел", "2.Изменить название", "3.Данные конкретного отдела",
            "4.Сортировать по должности", "5.Сортировать по стоимости проектов", "6.Назад", "7.Выход" };
        
        public static void DepartmentMenu()
        {
            Console.Clear();
            foreach(string option in options)
            {
                Console.WriteLine(option);
            }

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Введите название отдела: ");
                    string name = Parse.ParseString();

                    DepartmentController.AddDepartment(name);
                    CallMenu();
                    break;
                case "2":
                    ChangeName();
                    CallMenu();
                    break;
                case "3":
                    GetDepartment();
                    CallMenu();
                    break;
                case "4":
                    GetDepartmentByPosition();
                    CallMenu();
                    break;
                case "5":
                    GetDepartmentByProject();
                    CallMenu();
                    break;
                case "6":
                    MainView.MainMenu();
                    break;
                case "7":
                    Environment.Exit(0);
                    break;
                default:
                    DepartmentMenu();
                    break;
            }            
        }

        private static void CallMenu()
        {
            Console.Write("Нажмите любую клавишу...");
            Console.ReadKey();
            DepartmentMenu();
        }

        private static void ChangeName()
        {
            if (DepartmentController.GetDepartments().Count > 0)
            {
                foreach (DepartmentController item in DepartmentController.GetDepartments())
                {
                    Console.WriteLine(item.DepartmentID + " " + item.Name);
                }


                Console.WriteLine("\nВведите номер отдела");

                int id = Parse.ParseInt();

                Console.WriteLine("Введите новое название отдела");

                string name = Parse.ParseString();

                DepartmentController.ChangeDepartment(id, name);
            }
            else
            {
                Console.WriteLine("Информация не найдена");
            }
        }

        private static void GetDepartment()
        {
            if (DepartmentController.GetDepartments().Count > 0)
            {
                List<DepartmentController> departments = DepartmentController.GetDepartments();

                foreach (DepartmentController item in departments)
                {
                    Console.WriteLine(item.DepartmentID + " " + item.Name);
                }

                Console.WriteLine("\nВведите номер отдела");
                int id = Parse.ParseInt();

                if (DepartmentController.GetDepartment(id) != null)
                {
                    DepartmentController department = DepartmentController.GetDepartment(id);
                    List<EmployeeController> employees = DepartmentController.GetEmployeeList(id);

                    Console.WriteLine(department.DepartmentID + " " + department.Name);

                    if (employees.Count > 0)
                    {
                        foreach (EmployeeController employee in employees)
                        {
                            Console.WriteLine
                                (employee.Id + " " +
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
                        Console.WriteLine("В отделе нет работников");
                    }
                }
                else
                {
                    Console.WriteLine("Такого отдела нет");
                }
            }
            else
            {
                Console.WriteLine("Информация не найдена");
            }
        }

        private static void GetDepartmentByPosition()
        {
            if (DepartmentController.GetDepartments().Count > 0)
            {
                List<DepartmentController> departments = DepartmentController.GetDepartments();

                foreach (DepartmentController item in departments)
                {
                    Console.WriteLine(item.DepartmentID + " " + item.Name);
                }

                Console.WriteLine("\nВведите номер отдела");
                int id = Parse.ParseInt();

                DepartmentController department = DepartmentController.GetDepartment(id);
                List<EmployeeController> employees = DepartmentController.GetEmployeeByPosition(id);

                Console.WriteLine(department.DepartmentID + " " + department.Name);

                foreach (EmployeeController employee in employees)
                {
                    Console.WriteLine
                        (employee.Id + " " +
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
                Console.WriteLine("Информация не найдена");
            }

        }

        private static void GetDepartmentByProject()
        {
            if (DepartmentController.GetDepartments().Count > 0)
            {
                List<DepartmentController> departments = DepartmentController.GetDepartments();

                foreach (DepartmentController item in departments)
                {
                    Console.WriteLine(item.DepartmentID + " " + item.Name);
                }

                Console.WriteLine("\nВведите номер отдела");
                int id = Parse.ParseInt();

                if (DepartmentController.GetDepartment(id) != null)
                {
                    DepartmentController department = DepartmentController.GetDepartment(id);

                    List<EmployeeController> employees = DepartmentController.GetEmployeeBySumProjectPrice(id);

                    Console.WriteLine(department.DepartmentID + " " + department.Name);
                    if (DepartmentController.GetEmployeeBySumProjectPrice(id).Count > 0)
                    {
                        foreach (EmployeeController employee in employees)
                        {
                            Console.WriteLine
                                (employee.Id + " " +
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
                        Console.WriteLine("В отделе нет работников");
                    }
                }
                else
                {
                    Console.WriteLine("Такого отдела нет");
                }
            }
            else
            {
                Console.WriteLine("Информация не найдена");
            }
        }
    }
}
