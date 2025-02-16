using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Client.Helper
{
    internal class XOREncrypter
    {
        public static string ToHex(string input)
        {
            return BitConverter.ToString(Encoding.UTF8.GetBytes(input)).Replace("-", "");
        }

        public static string FromHex(string hex)
        {
            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
