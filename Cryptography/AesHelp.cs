using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;
using Newtonsoft.Json;

namespace JTC_Help.Cryptography
{
    public class Idmodel
    {
        public long id { get; set; }
    }
    public class iIdmodel
    {
        public int id { get; set; }
    }
    public class AesHelp
    {
        public long AesD(string id)
        {
            string json = Decrypt(id);
            Idmodel model = JsonConvert.DeserializeObject<Idmodel>(json);
            return model.id;
        }
        public string AesE(long id)
        {
            Idmodel model = new Idmodel() { id = id };
            string json = JsonConvert.SerializeObject(model);
            return Encrypt(json);
        }

        public int iAesD(string id)
        {
            string json = Decrypt(id);
            iIdmodel model = JsonConvert.DeserializeObject<iIdmodel>(json);
            return model.id;
        }
        public string iAesE(int id)
        {
            iIdmodel model = new iIdmodel() { id = id };
            string json = JsonConvert.SerializeObject(model);
            return Encrypt(json);
        }

        public string Decrypt(string hexString)
        {
            return Decrypt(hexString, ConfigurationManager.AppSettings["AesKeyOfBP"], ConfigurationManager.AppSettings["AesIV"]);
        }
        public string Encrypt(string hexString)
        {
            return Encrypt(hexString, ConfigurationManager.AppSettings["AesKeyOfBP"], ConfigurationManager.AppSettings["AesIV"]);
        }

        public static string Decrypt(string hexString, string key16B, string iv16B)
        {
            AesCryptoServiceProvider provider = new AesCryptoServiceProvider
            {
                Key = Encoding.ASCII.GetBytes(key16B),
                IV = Encoding.ASCII.GetBytes(iv16B)
            };
            byte[] inputBuffer = new byte[hexString.Length / 2];
            int num = 0;

            for (int i = 0; i < (hexString.Length / 2); i++)
            {
                inputBuffer[i] = byte.Parse(hexString[num].ToString() + hexString[num + 1], NumberStyles.HexNumber);
                num += 2;
            }

            ICryptoTransform decryptor = provider.CreateDecryptor();
            byte[] decryptedData = decryptor.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);

            return Encoding.UTF8.GetString(decryptedData);
        }

        public string Encrypt(string original, string key16B, string iv16B)
        {
            AesCryptoServiceProvider provider = new AesCryptoServiceProvider
            {
                Key = Encoding.ASCII.GetBytes(key16B),
                IV = Encoding.ASCII.GetBytes(iv16B)
            };
            byte[] bytes = Encoding.UTF8.GetBytes(original);
            ICryptoTransform encryptor = provider.CreateEncryptor();
            byte[] enctyptedData = encryptor.TransformFinalBlock(bytes, 0, bytes.Length);

            return BitConverter.ToString(enctyptedData).Replace("-", string.Empty);
        }
    }
}
