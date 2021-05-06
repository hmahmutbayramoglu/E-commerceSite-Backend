using Businness.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
             //ProductTest();

           // OrderTest();



        }
 
        //private static void OrderTest()
        //{
        //    OrderManager orderMeneger = new OrderManager(new EfOrderDal());

 
        //    foreach (var order in orderMeneger.GetAll())
        //    {
        //        Console.WriteLine(order.ShipCity);
        //    }
        //}

        //private static void ProductTest()
        //{
        //    ProductManager productMeneger = new ProductManager(new EfProductDal());

        //    var result = productMeneger.GetProductDetails();

        //    if (result.Success == true)
        //    {
        //        foreach (var product in result.Data)
        //        {
        //            Console.WriteLine(product.ProductName + " / " + product.CategoryName);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine(result.Message);
        //    }

      
        //}
    }
}
