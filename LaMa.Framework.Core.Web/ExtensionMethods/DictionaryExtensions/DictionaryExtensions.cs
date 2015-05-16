using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaMa.Framework.Core.Web.ExtensionMethods.DictionaryExtensions
{
    public static class DictionaryExtensions
    {
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,TKey key)
        {
            if (dictionary.ContainsKey(key))
            {
                return dictionary[key];
            }
            return default (TValue);
        }
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key,TValue defaultValue)
        {
            if (dictionary.ContainsKey(key))
            {
                return dictionary[key];
            }
            return defaultValue;
        } 
    }
}