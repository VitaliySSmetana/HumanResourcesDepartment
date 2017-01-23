using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers;

namespace CourseWork
{
    class EmployeeView
    {
        private static string[] options = 
            {"1.Добавить работника", "2.Удалить работника", "3.Сменить данные",
            "4.Просмотреть работника", "5.Просмотерть проекты работника", "6.Все работники",
            "7.Отсортировать работников", "8.Назад", "9.Выход" };

        public static void EmployeeMenu()
        {
            Console.Clear();
            foreach(string option in options)
            {
                Console.WriteLine(option);
            }

            switch (Console.ReadLine())
            {
                case "1":
                    AddEmployee();
                    CallMenu();
                    break;
                case "2":
                    DeleteEmployee();
                    CallMenu();
                    break;
                case "3":
                    ChangeInf();
                    CallMenu();
                    break;
                case "4":
                    ShowEmployee();
                    CallMenu();
                    break;
                case "5":
                    ShowProject();
                    CallMenu();
                    break;
                case "6":
                    ShowEmployees();
                    CallMenu();
                    break;
                case "7":
                    Sort();
                    CallMenu();
                    break;
                case "8":
                    MainView.MainMenu();
                    break;
                case "9":
                    Environment.Exit(0);
                    break;
                default:
                    EmployeeMenu();
                    break;
            }
        }

        private static void CallMenu()
        {
            Console.Write("Нажмите любую клавишу...");
            Console.ReadKey();
            EmployeeMenu();
        }

        private static void AddEmployee()
        {
            if (DepartmentController.GetDepartments().Count > 0 && PositionController.GetPositions().Count > 0)
            {
                Console.WriteLine("Введите данные:");

                Console.Write("Имя: ");
                string name = Parse.ParseString();
                Console.Write("Фамилия: ");
                string surname = Parse.ParseString();
                Console.Write("Номер счета: ");
                int accountNumber = Parse.ParseInt();
                Console.Write("Опыт: ");
                int experience = Parse.ParseInt();

                foreach (DepartmentController item in DepartmentController.GetDepartments())
                {
                    Console.WriteLine(item.DepartmentID + " " + item.Name);
                }
                Console.WriteLine("Выберите id отдела: ");
                int departmentId = Parse.ParseInt();

                foreach (PositionController item in PositionController.GetPositions())
                {
                    Console.WriteLine(item.PositionId + " " + item.Name);
                }
                Console.WriteLine("Выберите id должности: ");
                int positionId = Parse.ParseInt();

                EmployeeController.AddEmployee(name, surname, accountNumber, experience, departmentId, positionId);
            }
            else
            {
                Console.WriteLine("Сначала добавьте отдел и позиции");
            }
        }

        private static void DeleteEmployee()
        {
            if (EmployeeController.GetEmployees().Count > 0)
            {
                foreach (EmployeeController employee in EmployeeController.GetEmployees())
                {
                    Console.WriteLine(employee.Id + " " + employee.Name + " " + employee.Surname);
                }

                Console.WriteLine("Кого удалить?(Введите Id)");

                int id = Parse.ParseInt();

                bool res = EmployeeController.DeleteEmployee(id);

                if (res)
                {
                    Console.WriteLine("Удалено");
                }
                else
                {
                    Console.WriteLine("Неправильный ID");
                }
            }
            else
            {
                Console.WriteLine("Информация не найдена");
            }
        }

        private static void ChangeInf()
        {
            if (EmployeeController.GetEmployees().Count > 0)
            {
                foreach (EmployeeController employee in EmployeeController.GetEmployees())
                {
                    Console.WriteLine(employee.Id + " " + employee.Name + " " + employee.Surname);
                }

                Console.WriteLine("Выберите работника(Введите Id)");

                int id = Parse.ParseInt();

                Console.WriteLine("1.Имя\n2.Фамилия\n3.Номер счета\n4.Опыт\n5.Отдел\n6.Должность");

                switch (Console.ReadLine())
                {
                    case "1":
                        ChangeName(id);
                        break;
                    case "2":
                        ChangeSurname(id);
                        break;
                    case "3":
                        ChangeAccountNumber(id);
                        break;
                    case "4":
                        ChangeExperience(id);
                        break;
                    case "5":
                        ChangeDepartment(id);
                        break;
                    case "6":
                        ChangePosition(id);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Информация не найдена");
            }
        }

        private static void ChangeName(int id)
        {
            Console.WriteLine("Введите имя");

            string name = Parse.ParseString();

            EmployeeController.ChangeName(id, name);
        }

        private static void ChangeSurname(int id)
        {
            Console.WriteLine("Введите фамилию");

            string surname = Parse.ParseString();

            EmployeeController.ChangeSurname(id, surname);
        }

        private static void ChangeAccountNumber(int id)
        {
            Console.WriteLine("Введите номер счета");

            int number = Parse.ParseInt();

            EmployeeController.ChangeAccountNumber(id, number);
        }

        private static void ChangeExperience(int id)
        {
            Console.WriteLine("Введите опыт работника");

            int experience = Parse.ParseInt();

            EmployeeController.ChangeExperience(id, experience);
        }

        private static void ChangeDepartment(int id)
        {
            List<DepartmentController> departments = DepartmentController.GetDepartments();

            foreach (DepartmentController item in departments)
            {
                Console.WriteLine(item.DepartmentID + " " + item.Name);
            }

            Console.WriteLine("Введите id отдела");

            int departmentId = Parse.ParseInt();

            EmployeeController.ChangeDepartment(id, departmentId);
        }

        private static void ChangePosition(int id)
        {
            List<PositionController> positions = PositionController.GetPositions();

            foreach(PositionController item in positions)
            {
                Console.WriteLine(item.PositionId + " " + item.Name);
            }

            Console.WriteLine("Введите id должности");

            int positionId = Parse.ParseInt();

            EmployeeController.ChangePosition(id, positionId);
        }

        private static void ShowEmployee()
        {
            if (EmployeeController.GetEmployees().Count > 0)
            {
                foreach (EmployeeController item in EmployeeController.GetEmployees())
                {
                    Console.WriteLine(item.Id + " " + item.Name + " " + item.Surname);
                }

                Console.WriteLine("Выберите работника(Введите Id)");

                int id = Parse.ParseInt();

                EmployeeController employee = EmployeeController.GetEmployee(id);

                Console.WriteLine
                       (employee.Id + " " +
                       employee.Name + " " +
                       employee.Surname + " " +
                       employee.AccountNumber + " " +
                       employee.Experience + " " +
                       employee.DepartmentName + " " +
                       employee.PositionName);
            }
            else
            {
                Console.WriteLine("Информация не найдена");
            }
        }

        private static void ShowProject()
        {
            if (EmployeeController.GetEmployees().Count > 0)
            {
                foreach (EmployeeController item in EmployeeController.GetEmployees())
                {
                    Console.WriteLine(item.Id + " " + item.Name + " " + item.Surname);
                }

                Console.WriteLine("Выберите работника(Введите Id)");

                int id = Parse.ParseInt();

                List<ProjectController> projects = EmployeeController.GetEmployeeProjects(id);

                foreach (ProjectController project in projects)
                {
                    Console.WriteLine
                        (project.ProjectId + " " +
                        project.Name + " " +
                        project.Price);
                }
            }
            else
            {
                Console.WriteLine("Информация не найдена");
            }
        }

        private static void ShowEmployees()
        {
            if (EmployeeController.GetEmployees().Count > 0)
            {
                foreach (EmployeeController item in EmployeeController.GetEmployees())
                {
                    Console.WriteLine(item.Id + " " + item.Name + " " + item.Surname);
                }
            }
            else
            {
                Console.WriteLine("Информация не найдена");
            }
        }

        private static void Sort()
        {
            if (EmployeeController.GetEmployees().Count > 0)
            {
                Console.Clear();
                Console.WriteLine("1.Сортировать по имени\n2.Сортировать по фамилии\n3.Сортировать по плате");

                switch (Console.ReadLine())
                {
                    case "1":
                        SortByName();
                        break;
                    case "2":
                        SortBySurname();
                        break;
                    case "3":
                        SortByPayment();
                        break;
                    default:
                        Sort();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Информация не найдена");
            }
        }

        private static void SortByName()
        {
            foreach (EmployeeController item in EmployeeController.GetByName())
            {
                Console.WriteLine(item.Id + " " + item.Name + " " + item.Surname);
            }
        }

        private static void SortBySurname()
        {
            foreach (EmployeeController item in EmployeeController.GetBySurname())
            {
                Console.WriteLine(item.Id + " " + item.Name + " " + item.Surname);
            }
        }

        private static void SortByPayment()
        {
            foreach (EmployeeController item in EmployeeController.GetByPayment())
            {
                Console.WriteLine(item.Id + " " + item.Name + " " + item.Surname);
            }
        }
    }
}
