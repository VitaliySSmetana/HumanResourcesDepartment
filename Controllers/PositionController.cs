using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Services;

namespace Controllers
{
    public class PositionController
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

        public PositionController(int positionId, string name, double hours, double payment)
        {
            this.positionId = positionId;
            this.name = name;
            this.hours = hours;
            this.payment = payment;
        }

        public static void AddPosition(string name, double hours, double payment)
        {
            PositionService.AddPosition(name, hours, payment);
        }

        public static List<PositionController> GetPositions()
        {
            List<PositionController> positions = new List<PositionController>();

            List<PositionService> getPositions = PositionService.GetPositions();

            foreach (var item in getPositions)
            {
                PositionController toAdd = new PositionController
                    (item.PositionId,
                    item.Name,
                    item.Hours,
                    item.Payment);

                positions.Add(toAdd);
            }
            
            
            return positions;
        }

        public static void ChangeName(int positionId, string name)
        {
            PositionService.ChangeName(positionId, name);
        }

        public static void ChangeHours(int positionId, double hours)
        {
            PositionService.ChangeHours(positionId, hours);
        }

        public static void ChangePayment(int positionId, double payment)
        {
            PositionService.ChangePayment(positionId, payment);
        }

        public static List<PositionController> GetTopPosition()
        {
            List<PositionService> getTop = PositionService.GetTopPosition();
            List<PositionController> fivePositions = new List<PositionController>();
            
            if(getTop.Count != 0)
            {
                foreach(PositionService position in getTop)
                {
                    fivePositions.Add(new PositionController
                        (position.PositionId,
                        position.Name,
                        position.Hours,
                        position.Payment));
                }
            }

            return fivePositions;            
        }

        public static EmployeeController GetTopEmployee(int positionId)
        {
            EmployeeController employee = null;

            EmployeeService getEmployee = PositionService.GetTopEmployee(positionId);
                           
            if (getEmployee != null)
            {               
               employee = new EmployeeController(
                   getEmployee.Id,
                   getEmployee.Name,
                   getEmployee.Surname,
                   getEmployee.AccountNumber,
                   getEmployee.Experience,
                   getEmployee.DepartmentName,
                   getEmployee.PositionName);
            }            

            return employee;
        }
    }
}
