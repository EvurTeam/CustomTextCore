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
            var a = "a(b / c)";
            var result = TextParser.GetExpressionByString(a, out _);
            Console.WriteLine($"{result.HasFlag(SomeOperations.Call)} {result.HasFlag(SomeOperations.Div)}");
            Console.ReadLine();
        }
    }
}
