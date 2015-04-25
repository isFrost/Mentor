using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace TeacherModule
{
    class PassEncryptor
    {
        private static string CreateSalt()
        {
            //создает случайное чисто

            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[64];
            rng.GetBytes(buff);

            //возвращает стороку представляющую созднное число

            return Convert.ToBase64String(buff);
        }

        //создает хэшированный пароль из введеннгог пароля и соли
        private static string HashPassword(string pwd, string salt)
        {
            string saltAndPwd = String.Concat(pwd, salt);
            byte[] bytePass = Encoding.ASCII.GetBytes(saltAndPwd);

            HashAlgorithm sha256 = new SHA256CryptoServiceProvider();

            byte[] result = sha256.ComputeHash(bytePass);
            return Convert.ToBase64String(result);
        }

        //метод достает соль
        public static string GetSalt()
        {
            return CreateSalt();
        }

        //метод достает хэшированный пароль
        public static string GetPassword(string pwd, string salt)
        {
            return HashPassword(pwd, salt);
        }
    }
}
