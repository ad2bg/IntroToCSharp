using System;
using System.Collections.Generic;
using System.Text;

namespace CommonUtils
{
    class TestBiDictionary
    {
        static void testBiDictionary()//Main()//
        {
            var greek = new BiDictionary<int, string>();
            greek.Add(1, "Alpha");
            greek.Add(2, "Beta");
            greek.Add(5, "Beta");
            greek.GetBySecond("Alpha").PrintIListToConsole("Alpha: ");
            greek.GetBySecond("Beta").PrintIListToConsole("Beta: ");
            greek.GetBySecond("Gamma").PrintIListToConsole("Gamma: ");
        }
        static void GetKeys<K, V>(BiDictionary<K, V> dict, V value)
        {
            var builder = new StringBuilder();
            IList<K> keys = dict[value];
            foreach (var key in keys)
            {
                if (builder.Length != 0) builder.Append(", ");
                builder.Append(key);
            }
            Console.WriteLine("{0}: [{1}]", value, builder);
        }
    }


    /// <summary>
    /// Bi-directional Dictionary
    /// </summary>
    /// <typeparam name="TFirst"></typeparam>
    /// <typeparam name="TSecond"></typeparam>
    public class BiDictionary<TFirst, TSecond>
    {
        IDictionary<TFirst, IList<TSecond>> firstToSecond =
            new Dictionary<TFirst, IList<TSecond>>();
        [System.Diagnostics.CodeAnalysis.
            SuppressMessage("Common Practices and Code Improvements",
            "RECS0092:Convert field to readonly", Justification = "<Pending>")]
        IDictionary<TSecond, IList<TFirst>> secondToFirst =
            new Dictionary<TSecond, IList<TFirst>>();
        [System.Diagnostics.CodeAnalysis.
            SuppressMessage("Common Practices and Code Improvements",
            "RECS0092:Convert field to readonly", Justification = "<Pending>")]
        static IList<TFirst> EmptyFirstList = new TFirst[0];
        static IList<TSecond> EmptySecondList = new TSecond[0];

        public void Add(TFirst first, TSecond second)
        {
            IList<TFirst> firsts;
            IList<TSecond> seconds;
            if (!firstToSecond.TryGetValue(first, out seconds))
            {
                seconds = new List<TSecond>();
                firstToSecond[first] = seconds;
            }
            if (!secondToFirst.TryGetValue(second, out firsts))
            {
                firsts = new List<TFirst>();
                secondToFirst[second] = firsts;
            }
            seconds.Add(second);
            firsts.Add(first);
        }

        // Note potential ambiguity using indexers
        // (e.g. mapping from int to int)
        // Hence the methods as well...
        public IList<TSecond> this[TFirst first] => GetByFirst(first);

        public IList<TFirst> this[TSecond second] => GetBySecond(second);

        public IList<TSecond> GetByFirst(TFirst first)
        {
            IList<TSecond> list;
            if (!firstToSecond.TryGetValue(first, out list))
            {
                return EmptySecondList;
            }
            return new List<TSecond>(list); // Create a copy for sanity
        }

        public IList<TFirst> GetBySecond(TSecond second)
        {
            IList<TFirst> list;
            if (!secondToFirst.TryGetValue(second, out list))
            {
                return EmptyFirstList;
            }
            return new List<TFirst>(list); // Create a copy for sanity
        }



        ////public List<K> GetKeys<K, V>(BiDictionary<K, V> dict, V value)
        ////{
        ////    List<K> list = new List<K>();
        ////    IList<K> keys = dict[value];
        ////    foreach (var key in keys) list.Add(key);
        ////    return list;
        ////}

    }
}