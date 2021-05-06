using System;
using System.Collections.Generic;
using System.Text;
using Businness.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Businness.Concrete
{
    public class OrderManager : IOrderService
    {
        //Bir iş sınıfı başka sınıfları new lemez

        IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        public List<Order> GetAll()
        {
            return _orderDal.GetAll();
        }

        public Order GetById(int Id)
        {
            return _orderDal.Get(c=>c.OrderId == Id);
        }
    }
}
