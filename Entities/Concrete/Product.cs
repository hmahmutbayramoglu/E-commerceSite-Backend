using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Product : IEntity
    {


        private int _productId;

        private int _categoryId;

        private string _productName;

        private short _unitsInStock;

        private decimal _unitPrice;

        public int ProductId { get => _productId; set => _productId = value; }
        public int CategoryId { get => _categoryId; set => _categoryId = value; }
        public string ProductName { get => _productName; set => _productName = value; }
        public short UnitsInStock { get => _unitsInStock; set => _unitsInStock = value; }
        public decimal UnitPrice { get => _unitPrice; set => _unitPrice = value; }
    }
}
