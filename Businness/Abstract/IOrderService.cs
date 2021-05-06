using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businness.Abstract
{
    public interface IOrderService
    {
        List<Order> GetAll();

        Order GetById(int Id);

    }
}
