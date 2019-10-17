using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomTextCore
{
    public static class DictionaryHelper
    {
        public static void AddIfExist<TKey,TVal>(this Dictionary<TKey,TVal> d, TKey key, TVal val)
        {
            if (!d.ContainsKey(key))
                d.Add(key, val);
        }

        public static TVal GetIfExist<TKey, TVal>(this Dictionary<TKey, TVal> d, TKey key)
        {
            if (d.ContainsKey(key))
                return d[key];
            return default;
        }
     }
}
