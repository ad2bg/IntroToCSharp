using System;
using System.Collections.Generic;

namespace CommonUtils
{
    /// <summary>
    /// Utilities for List and IList.
    /// </summary>
    /// <includes>
    /// RandomizeIList, List<T>
    /// PrintIListToConsole, List<T>
    /// </includes>
    public static class Lists
    {
        /// <summary>
        /// Randomizes an IList.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="iList"></param>
        /// <returns>Randomized IList</returns>
        public static IList<T> RandomizeIList<T>(this IList<T> iList)
        {
            int n = iList.Count;
            var randomizedList = new List<T>();
            var rand = new Random();
            for (int i = 0; i < n; i++)
            {
                int r = rand.Next(0, n - i);
                randomizedList.Add(iList[r]);
                iList.Remove(iList[r]);
            }
            return randomizedList;
        }

        /// <summary>
        /// Prints an IList to the Console.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="iList"></param>
        /// <param name="prefix">String to print before the iList.</param>
        /// <param name="suffix">String to print after the iList.</param>
        /// <param name="formatString">Format string for each item.</param>
        /// <param name="delimiter">Separator between items.</param>
        /// <param name="from">From item (zero-based).</param>
        /// <param name="to">To item (zero-based).</param>
        /// <param name="reverse">True: Prints the items in reverse.</param>
        /// <returns>Original iList.</returns>
        public static IList<T> PrintIListToConsole<T>(
            this IList<T> iList,
            string prefix = "List: ", string suffix = "",
            string formatString = "{0}", string delimiter = ", ",
            int from = 0, int to = -1,
            bool reverse = false)
        {
            int n = iList.Count;
            if (to == -1) to = n - 1;

            if (from < 0 || to < 0 || from >= n || to >= n || from > to)
                throw new ArgumentOutOfRangeException();

            Console.Write(prefix);
            if (reverse)
            {
                for (int i = to; i >= from; i--)
                {
                    Console.Write(formatString, iList[i]);
                    if (i > from) Console.Write(delimiter);
                }
            }
            else
            {
                for (int i = from; i <= to; i++)
                {
                    Console.Write(formatString, iList[i]);
                    if (i < to) Console.Write(delimiter);
                }
            }
            Console.WriteLine(suffix);
            return iList;
        }

        /// <summary>
        /// Print an IList collection to the Console.
        /// </summary>
        /// <remarks>
        /// Can be used to print whole collections from Combinatorics:
        /// Permutations, Combinations and Variations.
        /// See: TestFacetCombinatorics
        /// </remarks>
        /// <typeparam name="T">Value type.</typeparam>
        /// <param name="collection">IEnumerable</param>
        public static void PrintIListCollection<T>(
            this IEnumerable<IList<T>> collection)
        {
            int i = 0;
            foreach (IList<T> item in collection)
            {
                item.PrintIListToConsole(prefix: $"{i++,3} : ");
            }
        }
    }
}