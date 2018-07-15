using System;
using System.Text;

namespace GifTag.Api
{
    public static class Converter
    {
        public static string ToBase64(int input)
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(input.ToString()));
        }

        public static string ToBase64(string input)
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(input));
        }

        public static string FromBase64(string input)
        {
            return Encoding.ASCII.GetString(Convert.FromBase64String(input));
        }
    }
}
