using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Order :IEntity
    {


        private int _orderId;

        private string _customerId;

        private int _employeeId;

        private DateTime _orderDate;

        private  string _shipCity;
 
        public int OrderId { get => _orderId; set => _orderId = value; }
        public string CustomerId { get => _customerId; set => _customerId = value; }
        public int EmployeeId { get => _employeeId; set => _employeeId = value; }
        public DateTime OrderDate { get => _orderDate; set => _orderDate = value; }
        public string ShipCity { get => _shipCity; set => _shipCity = value; }
    }
}
