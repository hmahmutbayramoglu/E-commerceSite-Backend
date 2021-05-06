using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businness.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();

        IDataResult<Product> GetById(int productId);

        IDataResult<List<Product>> GetAllByCategoryId(int categoryId);

        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);

        IDataResult<List<ProductDetailDTO>> GetProductDetails();

        IResult Add(Product product);

        IResult Update(Product product);

        IResult AddTransactionalTest(Product product);
    }
}
