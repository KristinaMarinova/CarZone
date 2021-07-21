using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarZone.Services.jwtAuth.Helpers
{
    public class HashingHelper
    {
        public static string HashUsingPbkdf2(string password)
        {
            var bytes = Encoding.UTF8.GetBytes(password);
            using var hash = SHA512.Create();
            var hashedInputBytes = hash.ComputeHash(bytes);
            var hashedInputStringBuilder = new StringBuilder(128);
            foreach (var b in hashedInputBytes)
                hashedInputStringBuilder.Append(b.ToString("X2"));
            return hashedInputStringBuilder.ToString();

        }
    }
}
