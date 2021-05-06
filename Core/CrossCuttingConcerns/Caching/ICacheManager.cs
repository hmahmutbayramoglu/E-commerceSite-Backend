using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {

        T Get<T>(string key);

        object Get(string key);

        void Add(string key, object value, int duration);

        //Cache de veri varmı onu kontrol edecek varsa ordan getirecek
        //yoksa veri tabanından getirip cache de tutacak
        //bu method sadece kontrol edecek
        bool IsAdd(string key);

        //Cacheden silme
        void Remove(string key);


        void RemoveByPattern(string pattern);



    }
}
