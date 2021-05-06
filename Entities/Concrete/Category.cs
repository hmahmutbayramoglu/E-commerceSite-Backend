using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;


namespace Entities.Concrete
{
    public class Category :IEntity
    {

        private int _categoryId;

        private string _categoryName;
 
        public int CategoryId { get => _categoryId; set => _categoryId = value; }
        public string CategoryName { get => _categoryName; set => _categoryName = value; }
    }
}
