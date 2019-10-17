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

            // todo
            var re = new Regex("^\"(([^\"]|(\\\")) +)\"$", RegexOptions.Multiline);
            if (re.Match(source).Success)
                return SomeTypes.String;
            else
                return SomeTypes.Unknown;
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
}
