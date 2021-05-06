﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    // Generic constraint - Generic kısıt
    // Class demek referans tip olmalı demek 
    // IEntity olabilir veya IEntity den iplemente olmalıdır
    //new : new'lenebilir kısıtı yani interface olamaz IEntity'nin gelmesini engelledik

    public interface IEntityRepository<T>  where T:class , IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);

        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

 
    }
}
