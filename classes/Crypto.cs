using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace HackatonAnketApp.classes
{
    public class Crypto
    {
        String data = "";
        int nonce = 0;
        public string hash { get; set; }
        public List<string> Hashing(string data)
        {
            this.data = data;
            this.hash = this.hesapla();
            //this.nonce = 0;//nonce

            List<string> Result = new List<string>();
            Result.Add(this.nonce.ToString());
            Result.Add(this.hash);

            return Result;
        }
       
        public string hesapla()
        {
            string ozet;
            while (true)
            {
                this.nonce = this.nonce + 1;
                ozet = SHA_256_Encrypting(data + nonce);
                if (ozet.Substring(0, 2) == "00")
                {
                    break;
                }
            }
            return ozet;//hash
        }

        public string SHA_256_Encrypting(string deger)//Sha 256 şifreleme kod başlangıcı
        {
            SHA256 sha = SHA256.Create();
            byte[] degerBytes = Encoding.UTF8.GetBytes(deger);
            byte[] shaBytes = sha.ComputeHash(degerBytes);
            return HashToByte(shaBytes);
        }

        public static string HashToByte(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            foreach (byte item in hash)
            {
                result.Append(item.ToString("x2"));

            }
            return result.ToString();
        }//Sha 256 şifreleme kod sonu     
    }
}