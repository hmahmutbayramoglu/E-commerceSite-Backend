using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businness.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            // p = Product
            //Productname i min 2 olmalı

            // FluentValidation araştır

            //Yan yanada yazılabilir ama SOLİD e aykırı 'S' e aykırı
            RuleFor(p=>p.ProductName).MinimumLength(2);

            RuleFor(p => p.ProductName).NotEmpty();

            RuleFor(p => p.UnitPrice).NotEmpty();

            RuleFor(p => p.UnitPrice).GreaterThan(0);

            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);

            //kendi yazacağımız method böyle yazılır
            //StartWithA kendi methodumuz
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");
        }

        // true ise kurala uygun false döner
        private bool StartWithA(string arg)
        {
            // A ile başlıyosa true değilse false
            return arg.StartsWith("A"); 
        }
    }
}
