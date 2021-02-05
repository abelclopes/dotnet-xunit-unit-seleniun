using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Domain.Util
{
    public static class HashManager
    {
        public static string GetSha1HashData(string data)
        {
            //create new instance of md5
            SHA1 sha1 = SHA1.Create();

            //convert the input text to array of bytes
            byte[] hashData = sha1.ComputeHash(Encoding.Default.GetBytes(data));

            //create new instance of StringBuilder to save hashed data
            StringBuilder returnValue = new StringBuilder();

            //loop for each byte and add it to StringBuilder
            foreach (var t in hashData)
            {
                returnValue.Append(t.ToString());
            }

            // return hexadecimal string
            return returnValue.ToString();
        }
        public static bool ValidateSHA1HashData(string inputData, string storedHashData)
        {
            string getHashInputData = GetSha1HashData(inputData);

            return String.CompareOrdinal(getHashInputData, storedHashData) == 0;
        }
        public static DateTime convertDateTime(string date)
        {
            var input = date;
            var pattern = @"(-)|(/)";
            var datan = Regex.Split(input, pattern);

            return new DateTime(int.Parse(datan[4]), int.Parse(datan[2]), int.Parse(datan[0]));

        }
    }
}
