using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CustomTextCore
{
    public static class TextParser
    {
        public static FindResult Find(string source, string pattern, RegexOptions options = RegexOptions.Multiline)
        {
            var re = new Regex(pattern, options);
            var m = re.Match(source);
            if (m.Success)
            {
                return new FindResult(m);
            }
            return null;
        }

        public static List<FindResult> FindAll(string source, string pattern, RegexOptions options = RegexOptions.Multiline)
        {
            var list = new List<FindResult>();
            var re = new Regex(pattern, options);
            var m = re.Match(source);
            while (m.Success)
            {
                list.Add(new FindResult(m));
                m = m.NextMatch();
            }
            return list;
        }

        public static SomeTypes GetTypeByString(string source)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                return SomeTypes.Empty;
            }
            else if (source == "false" || source == "true")
            {
                return SomeTypes.Bool;
            }
            else if (source.Contains(".") || source.Contains(","))
            {
                var res = float.TryParse(source.Replace(".", ","), out _);
                if (res) return SomeTypes.Float;
            }
            else if (int.TryParse(source, out _))
            {
                return SomeTypes.Int;
            }

            var re = new Regex("^\"(([^\"]|(\\\"))+)\"$", RegexOptions.Multiline);
            if (re.Match(source).Success)
                return SomeTypes.String;
            else
                return SomeTypes.Unknown;
        }

        public static SomeOperations GetExpressionByString(string source, out OperationData data)
        {
            // дополнительные результаты парсинга TODO
            data = new OperationData();
            // первая часть выражения (присваинвание, вызов или ничего)
            SomeOperations firstParam;
            // вторая часть выражения (сложение, вычитание и т.д.)
            SomeOperations secondParam = SomeOperations.Unknown;

            var reCall = new Regex("^.+\\(.*\\)$");
            var m = reCall.Match(source);
            // если первая часть - вызов
            if (m.Success)
            {
                firstParam = SomeOperations.Call;
            }
            else
            {
                var reSet = new Regex("[^=]+= *.+");
                m = reSet.Match(source);
                // если первая часть - присваивание
                if (m.Success)
                    firstParam = SomeOperations.Set;
                else 
                    return SomeOperations.Unknown;
            }

            var reOps = new Regex(".+ *([+\\-*\\/%]) *.+");
            m = reOps.Match(source);
            // если бинарные операции
            if (m.Success)
            {
                var op = m.Groups[1].Value;
                switch (op)
                {
                    case "+":
                        secondParam = SomeOperations.Add;
                        break;
                    case "-":
                        secondParam = SomeOperations.Sub;
                        break;
                    case "*":
                        secondParam = SomeOperations.Mul;
                        break;
                    case "/":
                        secondParam = SomeOperations.Div;
                        break;
                    case "%":
                        secondParam = SomeOperations.Mod;
                        break;
                    default:
                        break;
                }
            }
            // если не бинарные оперции
            if (secondParam == SomeOperations.Unknown)
            {
                // TODO
            }

            if (secondParam == SomeOperations.Unknown)
            {
                if (firstParam == SomeOperations.Set)
                    return SomeOperations.Unknown;
                else
                    return firstParam;
            }
            return firstParam | secondParam;
        }
    }

    public enum SomeTypes
    {
        Empty,
        Bool,
        String,
        Int,
        Float,
        Unknown
    }

    public enum SomeOperations
    {
        Set = 1,
        Call = Set << 1,
        PostfixIncrement = Set << 2,
        PostfixDecrement = Set << 3,
        Add = Set << 4,
        Sub = Set << 5,
        Mul = Set << 6,
        Div = Set << 7,
        Mod = Set << 8,

        Unknown
    }
}
