using Businness.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.IsMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            ProductMeneger productMeneger = new ProductMeneger(new EfProductDal());


            foreach (var product in productMeneger.GetAllByCategoryId(1))
            {
                Console.WriteLine(product.ProductName);
            }

    
        }
 

    }
}
