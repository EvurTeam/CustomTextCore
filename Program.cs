using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomTextCore
{
    class Program
    {
        public static void Main()
        {
            var a = "\"abc\"";
            var b = "abc";
            var c = "12,7";
            var d = "63";
            var e = "true";
            Console.WriteLine(TextParser.GetTypeByString(a));
            Console.WriteLine(TextParser.GetTypeByString(b));
            Console.WriteLine(TextParser.GetTypeByString(c));
            Console.WriteLine(TextParser.GetTypeByString(d));
            Console.WriteLine(TextParser.GetTypeByString(e));

            Console.ReadLine();
        }
    }
}
