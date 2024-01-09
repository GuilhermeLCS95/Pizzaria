using System.Security.Cryptography;
using System.Text;

namespace Pizzaria.Helper
{
    public static class Cryptography
    {
        public static string GenerateHash(this string s)
        {
            var hash = SHA256.Create(); 
            var encoding = Encoding.UTF8;
            var array = encoding.GetBytes(s);

            array = hash.ComputeHash(array);

            var strHex = new StringBuilder();

            foreach (var item in array)
            {
                strHex.Append(item.ToString("x2"));
            }

            return strHex.ToString();
        }
    }
}
