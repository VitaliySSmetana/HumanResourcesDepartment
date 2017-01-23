using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    class MainView
    {
        private static string[] options = { "1.Отделы", "2.Должности", "3.Работники", "4.Проекты", "5.Поиск" , "6.Выход" };

        public static void MainMenu()
        {
            Console.Clear();
            foreach (string option in options)
            {
                Console.WriteLine(option);
            }

            switch (Console.ReadLine())
            {
                case "1":
                    DepartmentView.DepartmentMenu();
                    break;
                case "2":
                    PositionView.PositionMenu();
                    break;
                case "3":                    
                    EmployeeView.EmployeeMenu();
                    break;
                case "4":
                    ProjectView.ProjcetMenu();
                    break;
                case "5":
                    SearchView.SearchMenu();
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    MainMenu();
                    break;
            }
        }
    }
}
