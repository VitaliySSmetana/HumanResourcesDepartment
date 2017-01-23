using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers;

namespace CourseWork
{
    class PositionView
    {
        private static string[] options = { "1.Добавить должность", "2.Изменить данные", "3.Пять востребованных должностей",
            "4.Самый прибыльный работник должности", "5.Назад", "6.Выход" };

        public static void PositionMenu()
        {
            Console.Clear();
            foreach(string option in options)
            {
                Console.WriteLine(option);
            }

            switch (Console.ReadLine())
            {
                case "1":
                    AddPosition();
                    CallMenu();
                    break;
                case "2":
                    ChangeInf();
                    CallMenu();
                    break;
                case "3":
                    TopFivePosition();
                    CallMenu();
                    break;
                case "4":
                    TopEmployee();
                    CallMenu();
                    break;
                case "5":
                    MainView.MainMenu();
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    PositionMenu();
                    break;
            }
        }

        private static void CallMenu()
        {
            Console.Write("Нажмите любую клавишу...");
            Console.ReadKey();
            PositionMenu();
        }

        private static void AddPosition()
        {
            Console.Write("Введите название должности: ");
            string name = Parse.ParseString();

            Console.Write("Введите рабочие время: ");
            double hours = Parse.ParseDouble();

            Console.Write("Введите оплату: ");
            double payment = Parse.ParseDouble();

            PositionController.AddPosition(name, hours, payment);
        }

        private static void ChangeInf()
        {
            if (PositionController.GetPositions().Count > 0)
            {
                foreach (PositionController position in PositionController.GetPositions())
                {
                    Console.WriteLine(position.PositionId + " " + position.Name + " " + position.Hours + " " + position.Payment);
                }
                Console.WriteLine("Выберите должность");

                int id = Parse.ParseInt();

                Console.WriteLine("1.Название\n2.Время\n3.Оплату");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Введите название");
                        string name = Parse.ParseString();
                        PositionController.ChangeName(id, name);
                        break;
                    case "2":
                        Console.WriteLine("Введите время");
                        double hours = Parse.ParseDouble();
                        PositionController.ChangeHours(id, hours);
                        break;
                    case "3":
                        Console.WriteLine("Введите оплату");
                        double payment = Parse.ParseDouble();
                        PositionController.ChangePayment(id, payment);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Информация не найдена");
            }
        }

        private static void TopFivePosition()
        {
            if (PositionController.GetPositions().Count > 0)
            {
                foreach (PositionController position in PositionController.GetTopPosition())
                {
                    Console.WriteLine(position.PositionId + " " + position.Name + " " + position.Hours + " " + position.Payment);
                }
            }
            else
            {
                Console.WriteLine("Информация не найдена");
            }
        }

        private static void TopEmployee()
        {
            if (PositionController.GetPositions().Count > 0)
            {
                foreach (PositionController position in PositionController.GetPositions())
                {
                    Console.WriteLine(position.PositionId + " " + position.Name + " " + position.Hours + " " + position.Payment);
                }
                Console.WriteLine("Выберите должность");

                int id = Parse.ParseInt();

                EmployeeController employee = PositionController.GetTopEmployee(id);

                if (employee != null)
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
                else
                {
                    Console.WriteLine("Работник не найден");
                }
            }
            else
            {
                Console.WriteLine("Информация не найдена");
            }
        }
    }
}
