using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers;

namespace CourseWork
{
    class ProjectView
    {
        private static string[] oprtions = { "1.Добавить проект", "2.Назад", "3.Выход" };

        public static void ProjcetMenu()
        {
            Console.Clear();
            foreach(string option in oprtions)
            {
                Console.WriteLine(option);
            }

            switch (Console.ReadLine())
            {
                case "1":
                    AddProject();
                    Console.Write("Нажмите любую клавишу...");
                    Console.ReadKey();
                    ProjcetMenu();
                    break;
                case "2":
                    MainView.MainMenu();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    ProjcetMenu();
                    break;
            }
        }

        private static void AddProject()
        {
            if (EmployeeController.GetEmployees().Count > 0)
            {
                Console.Write("Введите название проекта: ");
                string name = Parse.ParseString();

                Console.Write("Введите стоимость проекта: ");
                int price = Parse.ParseInt();

                foreach (EmployeeController item in EmployeeController.GetEmployees())
                {
                    Console.WriteLine(item.Id + " " + item.Name + " " + item.Surname);
                }

                Console.Write("Выберите работника(его id): ");
                int employeeId = Parse.ParseInt();

                ProjectController.AddProject(name, price, employeeId);
            }
            else
            {
                Console.WriteLine("Сначала добавьте работников");
            }
        }
    }
}
