using System;
using System.Security.Cryptography;
using System.Text;

namespace InventoryAPI.Models
{
    public class User
    { 

      public int userid { get; set; }
      public string Name { get; set; }
      public string Login { get; set; }
      public string Email { get; set; }
      public DateTime BirthDate { get; set; }
      public string Password { get; set; }

      // Provisório

      public bool isValidEmail(string email)
      { 
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
          return false;
        }
      }

      public string EncryptPassword(string password)
      {
            string hash = "Password@2022$";
            byte[] data = UTF8Encoding.UTF8.GetBytes(password);

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            TripleDESCryptoServiceProvider tripDES = new TripleDESCryptoServiceProvider(); 

            tripDES.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            tripDES.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripDES.CreateEncryptor();
            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);

            return Convert.ToBase64String(result);

      }
    
    }
}