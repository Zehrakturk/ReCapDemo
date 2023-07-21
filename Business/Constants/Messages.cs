using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string productNameInvalid = "Ürün ismi geçersiz";
        public static string MainrenanceTime = "Sistem bakimda";
        public static string ProductsListed = "ürünler listelendi";
        public static string CategoryError = "Bir kategoride en fazla 10 ürün volabilir ";
        public static string ProductNameAlreadyExists="Bu isimde zaten başka bir ürün var ";
        public static string CategoryAdded = "Category eklendi ";
        public static string CategoryListed="Category listelendi";
        public static string CategoryLimitExceded = "Kategory limiti aşıldığı yeni ürün eklenemiyor";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

    }
}
