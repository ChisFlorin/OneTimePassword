using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace OneTimePassword
{
    public class EncriptionManager
    {
        public string EncryptData(string data)
        {
            byte[] encrypted = null;
            using (RijndaelManaged myRijndael = new RijndaelManaged())
            {
                ICryptoTransform encryptor = myRijndael.CreateEncryptor(GetKey(), GetIV());

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(data);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(encrypted);
        }

        public string DecryptData(string data)
        {
            string result = null;
            using (RijndaelManaged myRijndael = new RijndaelManaged())
            {
                ICryptoTransform decryptor = myRijndael.CreateDecryptor(GetKey(), GetIV());

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(data)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            result = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return result;
        }


        public byte[] GetKey()
        {
            return Configuration.Key.ToString().Split(',').Select(s => byte.Parse(s)).ToArray();
        }

        public byte[] GetIV()
        {
            return Configuration.IV.ToString().Split(',').Select(s => byte.Parse(s)).ToArray();
        }
    }
}
