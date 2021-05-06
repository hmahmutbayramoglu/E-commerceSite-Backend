using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Businness.Constants
{
    public static class Messages
    {
        //static olunca newlemeye gerek yok
        public static string ProductAdded = "Ürün Eklendi";

        public static string ProductNameInvalid = "Ürün ismi geçersiz";

        public static string MainTenanceTime = "Sistem Bakımda";

        public static string ProductListed="Ürünler Listelendi";

        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir";

        public static string ProductNameAlreadyExists = "Bu isimde zaten ürün var";

        public static string CategoryLimitExeded = "En fazla 15 kategori olabilir";

        public static string AuthorizationDenied = "Yetkiniz Yok";

        public static string UserRegistered = "Kayıt İşlemi Başarılı";

        public static string UserNotFound = "Kullanıcı Bulunamadı";

        public static string PasswordError = "Parola Hatası";
        public static string SuccessfulLogin = "Giriş Yapıldı";
        public static string UserAlreadyExists = "Kullanıcı Mevcut";
        public static string AccessTokenCreated = "Erişim Jetonu Oluşturuldu";
    }                                                     
}                                                         
                                                          