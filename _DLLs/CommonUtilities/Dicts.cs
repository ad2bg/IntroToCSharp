using System;
using System.Collections.Generic;

namespace CommonUtils
{
    /// <summary>
    /// Utilities for Dictionaries. 
    /// </summary>
    /// <includes>
    /// PrintToConsole<K,V>, void
    /// </includes> 
    public static class Dicts
    {
        /// <summary>
        /// Prints a Dictionary to the Console.
        /// </summary>
        /// <typeparam name="K">Keys type.</typeparam>
        /// <typeparam name="V">Values type.</typeparam>
        /// <param name="aDictionary">A Dictionary containing values.</param>
        /// <param name="formatString">Format string for each element.</param>
        public static void PrintToConsole<K, V>(
            this Dictionary<K, V> aDictionary,
            string formatString = "Key = {0}, Value = {1}")
        {
            foreach (KeyValuePair<K, V> kvp in aDictionary)
            {
                Console.WriteLine(formatString, kvp.Key, kvp.Value);
            }
        }
    }
}