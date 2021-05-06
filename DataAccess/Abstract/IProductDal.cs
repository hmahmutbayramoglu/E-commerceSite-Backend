using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
   public interface IProductDal:IEntityRepository<Product>
    {
        //IProduct Dal a ayrı operasyonlar yazılacak

        //DTO Operasyonu
        List<ProductDetailDTO> GetProductDetails();

    }
}
