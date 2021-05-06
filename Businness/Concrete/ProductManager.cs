using Businness.Abstract;
using Businness.BusinessAspects.Autofac;
using Businness.Constants;
using Businness.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Bussiness;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Businness.Concrete
{
    public class ProductManager : IProductService
    {

        //Bir iş sınıfı başka sınıfları new lemez

        IProductDal _productDal;

        ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;

            _categoryService = categoryService;
        }


        //Yetkilendirme
        [SecuredOperation("product.add,admin")]
        //Validation İşlemini yapar
        [ValidationAspect(typeof(ProductValidator))]
        //Cache kontrolü add işlemi başarılı olursa cache i sil
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {

          IResult result = BusinessRules.Run(
              //  CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                CheckIfCategoryLimitExceded(),
                CheckIfProductNameExists(product.ProductName));

            if (result != null)
            {
                return result;
            }

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);

            // Validation İş kodu ile ayrıdır
            // businness kodu ile doğrulama kodu ayrı yapılır

        }

        [ValidationAspect(typeof(ProductValidator))]
        //Cache kontrolü update işlemi başarılı olursa cache i sil
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }




        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            //İş kodları
           /* if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MainTenanceTime);
            }*/

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);

        }

        [CacheAspect]
        //Performans Yönetimi
        //[PerformanceAspect(5)]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == categoryId));
        }

       

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDTO>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 00)
            {
                return new ErrorDataResult<List<ProductDetailDTO>>(Messages.MainTenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDTO>>(_productDal.GetProductDetails());
        }



        //Sadece bu class içinde kullanılacak 
        // o yüzden private eğer public yapmamız gerekiyosa Servisede yazmamız lazım


        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;

            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();

        }


        private IResult CheckIfProductNameExists(string productName)
        {
            //Any içerisinde varmı diye sorar varsa true 
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();

            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();


        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();

            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExeded);
            }
            return new SuccessResult();

        }

        //Hata Yönetimi
        //[TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            throw new NotImplementedException();

            //örnek hata = ali ahmete para gönderiyor ali parayı gönderince alinin parası eksiliyor (veri tabanından alinin kasası güncelleniyor (parası Eksiliyor)).
            //daha sonra ahmetin parası artması (veri tabanından ahmetin parası güncelleniyor) gerekirken hata alıyoruz bu durumda alinin parası azaldı ama ahmetin parası artmadı
            //Yani ahmete para gitmedi o işlem gerçekleşmedi burada yapılması gereken alinin kasasının güncellenmesi geri alınmalı bunu [TransactionScopeAspect] 
            //ile yapacağız TransactionScopeAspect işlemi veri tabanının belleğinden siliyor.

        }
    }
}
