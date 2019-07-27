using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practical_Exam_Bitmascot.Helper
{
    class Encrypt
    {
        public static string EncryptPassword(string password) {

            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(password);
            string EncryptedPass = Convert.ToBase64String(b);


            return EncryptedPass;
        }
    }
}