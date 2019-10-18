using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CustomTextCore
{
    public static class StringHelper
    {
        // -> bool

        public static bool Like(this string s, string val)
        {
            var a = s.ToLower();
            var b = val.ToLower();
            return (a == b || a.Contains(b) || b.Contains(a));
        }

        public static bool IsEmpty(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        public static bool IsLetters(this string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (!char.IsLetter(s[i])) return false;
            }
            return true;
        }

        public static bool IsDigits(this string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (!char.IsDigit(s[i])) return false;
            }
            return true;
        }

        public static bool IsLettersOrDigits(this string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (!char.IsLetterOrDigit(s[i])) return false;
            }
            return true;
        }

        public static bool IsControls(this string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (!char.IsControl(s[i])) return false;
            }
            return true;
        }

        public static bool IsWhiteSpaces(this string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (!char.IsWhiteSpace(s[i])) return false;
            }
            return true;
        }

        public static bool IsNumbers(this string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (!char.IsNumber(s[i])) return false;
            }
            return true;
        }

        public static bool IsPunctuations(this string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (!char.IsPunctuation(s[i])) return false;
            }
            return true;
        }

        public static bool IsSeparator(this string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (!char.IsSeparator(s[i])) return false;
            }
            return true;
        }

        public static bool IsSymbol(this string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (!char.IsSymbol(s[i])) return false;
            }
            return true;
        }

        public static bool IsLower(this string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (!char.IsLower(s[i])) return false;
            }
            return true;
        }

        public static bool IsUpper(this string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (!char.IsUpper(s[i])) return false;
            }
            return true;
        }

        // -> string

        public static string RegexReplace(this string s, string pattern, string replacement)
        {
            var re = new Regex(pattern);
            return re.Replace(s, replacement);
        }

        public static string RemoveMultipleSpaces(this string s)
        {
            var re = new Regex("(\\s{2,})");
            return re.Replace(s, " ");
        }

        public static string Multiple(this string s, int val)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < val; i++)
            {
                sb.Append(s);
            }
            return sb.ToString();
        }

        public static string Cut(this string s, string find)
        {
            return s.Replace(find, ""); 
        }

        public static string CutAll(this string s, params string[] find)
        {
            var sb = new StringBuilder(s);
            foreach (var item in find)
            {
                sb.Replace(item, "");
            }
            return sb.ToString();
        }

        public static string ReplaceTab(this string s, int count = 4)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                sb.Append(" ");
            }
            return s.Replace("\t", sb.ToString());
        }
    }
}
