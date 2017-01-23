using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Services
{
    public class PositionService
    {
        private int positionId;
        private string name;
        private double payment;
        private double hours;

        public double Hours
        {
            get
            {
                return hours;
            }
        }

        public double Payment
        {
            get
            {
                return payment;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public int PositionId
        {
            get
            {
                return positionId;
            }
        }

        public PositionService(int positionId, string name, double hours, double payment)
        {
            this.positionId = positionId;
            this.name = name;
            this.hours = hours;
            this.payment = payment;
        }

        public static void AddPosition(string name, double hours, double payment)
        {
            using (HumanResourcesDepartmentContext db = new HumanResourcesDepartmentContext())
            {
                Position position = new Position { Name = name, Hours = hours, Payment = payment };

                db.Positions.Add(position);
                db.SaveChanges();
            }
        }

        public static List<PositionService> GetPositions()
        {
            List<PositionService> positions = new List<PositionService>();

            using (HumanResourcesDepartmentContext db = new HumanResourcesDepartmentContext())
            {
                var query = from b in db.Positions
                            select b;

                foreach (var item in query)
                {
                    PositionService toAdd = new PositionService(
                        item.PositionID,
                        item.Name,
                        item.Hours,
                        item.Payment);

                    positions.Add(toAdd);
                }
            }

            return positions;
        }

        public static void ChangeName(int positionId, string name)
        {
            using (HumanResourcesDepartmentContext db = new HumanResourcesDepartmentContext())
            {
                if (db.Positions.Find(positionId) != null)
                {
                    db.Positions.Find(positionId).Name = name;
                }
            }
        }

        public static void ChangeHours(int positionId, double hours)
        {
            using (HumanResourcesDepartmentContext db = new HumanResourcesDepartmentContext())
            {
                if (db.Positions.Find(positionId) != null)
                {
                    db.Positions.Find(positionId).Hours = hours;
                }
            }
        }

        public static void ChangePayment(int positionId, double payment)
        {
            using (HumanResourcesDepartmentContext db = new HumanResourcesDepartmentContext())
            {
                if (db.Positions.Find(positionId) != null)
                {
                    db.Positions.Find(positionId).Payment = payment;
                }
            }
        }

        public static List<PositionService> GetTopPosition()
        {
            List<PositionService> positions = GetPositions();
            List<PositionService> fivePositions = new List<PositionService>();
            
            if (positions.Count != 0 && positions.Count <= 5)
            {
                fivePositions = positions.OrderBy(o => o.Hours / o.Payment).ToList();

            }
            else if (positions.Count != 0 && positions.Count >= 5)
            {
                positions = positions.OrderBy(o => o.Hours / o.Payment).ToList();

                for (int i = 0; i < 5; i++)
                {
                    fivePositions.Add(positions[i]);
                }
            }

            return fivePositions;
        }

        public static EmployeeService GetTopEmployee(int positionId)
        {
            EmployeeService employee = null;

            using (HumanResourcesDepartmentContext db = new HumanResourcesDepartmentContext())
            {
                if (db.Positions.Find(positionId) != null && db.Positions.Find(positionId).Employees.Count != 0)
                {
                    List<Employee> dbEmployees = db.Positions.Find(positionId).Employees;
                    List<EmployeeService> employees = new List<EmployeeService>();

                    foreach (var item in dbEmployees)
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

                    employee = employees.OrderBy(o => o.Experience / o.SumProjectPrice).ToList()[0];
                }
            }

            return employee;
        }
    }
}
