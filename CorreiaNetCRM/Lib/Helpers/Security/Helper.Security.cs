﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace CorreiaNetCRM.Lib.Helpers
{
    public static partial class Helper
    {

        public static class Security
        {

            static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("ZeroCool");

            /// <summary>
            /// Encrypt a string.
            /// </summary>
            /// <param name="originalString">The original string.</param>
            /// <returns>The encrypted string.</returns>
            /// <exception cref="ArgumentNullException">This exception will be 
            /// thrown when the original string is null or empty.</exception>
            public static string Encrypt(string originalString)
            {
                if (String.IsNullOrEmpty(originalString))
                {
                    throw new ArgumentNullException
                           ("The string which needs to be encrypted can not be null.");
                }
                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream,
                    cryptoProvider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
                StreamWriter writer = new StreamWriter(cryptoStream);
                writer.Write(originalString);
                writer.Flush();
                cryptoStream.FlushFinalBlock();
                writer.Flush();
                return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
            }

            /// <summary>
            /// Decrypt a crypted string.
            /// </summary>
            /// <param name="cryptedString">The crypted string.</param>
            /// <returns>The decrypted string.</returns>
            /// <exception cref="ArgumentNullException">This exception will be thrown 
            /// when the crypted string is null or empty.</exception>
            public static string Decrypt(string cryptedString)
            {
                if (String.IsNullOrEmpty(cryptedString))
                {
                    throw new ArgumentNullException
                       ("The string which needs to be decrypted can not be null.");
                }
                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                MemoryStream memoryStream = new MemoryStream
                        (Convert.FromBase64String(cryptedString));
                CryptoStream cryptoStream = new CryptoStream(memoryStream,
                    cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
                StreamReader reader = new StreamReader(cryptoStream);
                return reader.ReadToEnd();
            }

        }
    }
}