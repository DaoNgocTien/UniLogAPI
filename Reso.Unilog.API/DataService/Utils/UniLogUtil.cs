using DataService.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace DataService.Utils
{
    public  class UniLogModel
    {
        [JsonProperty("Key")]
        public  string Key { get; set; }
        [JsonProperty("IV")]
        public  string IV { get; set; }
        [JsonProperty("UniLogToken")]
        public  string UniLogToken { get; set; }
    }
    public  class UniLogUtil
    {
        /// <summary>
        /// Pass the gmt time and get the time code
        /// </summary>
        /// <param name="gmt"></param>
        /// <returns></returns>
        public  static string GetTimeCode(int gmt)
        {
            var now = DateTime.UtcNow;
            var trueGmt = now.AddHours(gmt);
            string timeCode = trueGmt.ToString("ddMMyyyyHHmmssfff");
            return timeCode;
        }
        public  string GetMd5HashData(string str)
        {
            //string result = string.Join("", MD5.Create().ComputeHash(Convert.FromBase64String(str)).Select(p => p.ToString("x2")));
            string result = string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(str)).Select(s => s.ToString("x2")));
            return result;
        }
        public  static string GetRandomString()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Range(1, 8).Select(s => chars[random.Next(chars.Length)]).ToArray());
        }
        public  string EncryptString(string plainText, string key, string IV)
        {
            byte[] keyEncrypt = Convert.FromBase64String(key);
            byte[] IVEncrypt = Convert.FromBase64String(IV);
            byte[] encrypted;
            // Create TripleDESCryptoServiceProvider  
            using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider())
            {
                ICryptoTransform encryptor = tripleDES.CreateEncryptor(keyEncrypt, IVEncrypt);
                using (MemoryStream ms = new MemoryStream())
                {
                    // Create crypto stream using the CryptoStream class. This class is the key to encryption  
                    // and encrypts and decrypts data from any given stream. In this case, we will pass a memory stream  
                    // to encrypt  
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        // Create StreamWriter and write data to a stream  
                        using (StreamWriter sw = new StreamWriter(cs))
                            sw.Write(plainText);
                        encrypted = ms.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(encrypted);
        }
        public  string DecryptString(string cipherText, string key, string IV)
        {
            byte[] cipherTextDecrypt = Convert.FromBase64String(cipherText);
            byte[] keyDecrypt = Convert.FromBase64String(key);
            byte[] IVDecrypt = Convert.FromBase64String(IV);
            string decrypt = null;
            // Create TripleDESCryptoServiceProvider  
            using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider())
            {
                // Create a decryptor  
                ICryptoTransform decryptor = tripleDES.CreateDecryptor(keyDecrypt, IVDecrypt);
                // Create the streams used for decryption.  
                using (MemoryStream ms = new MemoryStream(cipherTextDecrypt))
                {
                    // Create crypto stream  
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        // Read crypto stream  
                        using (StreamReader reader = new StreamReader(cs))
                            decrypt = reader.ReadToEnd();
                    }
                }
            }
            return decrypt;
        }
        public  string GenerateKeyAndIV()
        {
            byte[] key = null;
            byte[] iv = null;
            using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider())
            {
                TripleDES provider = TripleDES.Create();

                key = provider.Key;
                iv = provider.IV;
            }
            return "Key: " + key + " ;IV: " + iv;
        }

        public  UniLogModel GetConfigModel()
        {
            var result = new UniLogModel();
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
            var root = configurationBuilder.Build();
            result = root.GetSection("UniLogConfig").Get<UniLogModel>();
            return result;
        }

    }
}
