using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
namespace ArthsAppProject
{
    public static class Hash
    {
        public static string HashSHA512(this string value)
        {
            using (var sha = SHA512.Create())
            {
                return Convert.ToBase64String(sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(value)));
            }
        }
    }


}
