using System;

namespace CommonUtils
{
    /// <summary>
    /// Miscellaneous utilities.
    /// </summary>
    /// <includes>
    /// SetCulture, void
    /// Swap<T>, void
    /// IncrementLoopsIndexes, int
    /// AssemblyFolder, string
    /// LaunchFile, void
    /// </includes>
    public static class Misc
    {
        public static void SetCulture(string strCulture = "en-US")
        {
            System.Threading.Thread.CurrentThread.CurrentCulture =
            System.Globalization.CultureInfo.GetCultureInfo(strCulture);
        }


        /// <summary>
        /// Swaps two values.
        /// </summary>
        /// <typeparam name="T">Any type.</typeparam>
        /// <param name="lhs">Left hand side value.</param>
        /// <param name="rhs">Right hand side value.</param>
        public static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }


        /// <summary>
        /// For implementation of k "nested" loops.
        /// </summary>
        /// <Description>
        /// Implemented with array of indexes.
        /// </Description>
        /// <param name="indexes">
        /// An array of ints that hold the indexes
        /// </param>
        /// <param name="n">
        /// Maximum value of all indexes.
        /// If zero then use the ixMaximums parameter.
        /// </param>
        /// <param name="ixMaximums">
        /// Array of ints for the maximum values of the loops indexes.
        /// </param>
        /// <returns>
        /// The index number up to which the incrementation reached.
        /// </returns>
        public static int IncrementLoopsIndexes(
            this int[] indexes, int n = 0, int[] ixMaximums = null)
        {
            int nrIndexes = indexes.Length;
            if (n > 0)
            {
                ixMaximums = new int[nrIndexes];
                for (int i = 0; i < nrIndexes; i++) { ixMaximums[i] = n; }
            }

            int ixNr = 0;
            indexes[0]++;
            bool incr;
            do
            {
                incr = false;
                if (indexes[ixNr] == ixMaximums[ixNr])
                {
                    incr = true;
                    indexes[ixNr] = 0;
                    ixNr++;
                    if (ixNr < nrIndexes) indexes[ixNr]++;
                }
            }
            while (incr && (ixNr < nrIndexes));
            return ixNr;
        }


        /// <summary>
        /// Returns the Assembly folder
        /// </summary>
        public static string AssemblyFolder()
        {
            string codeBase =
                System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return System.IO.Path.GetDirectoryName(path);
        }


        /// <summary>
        /// Launches a file with its associated program
        /// </summary>
        /// <param name="fileFullPath"></param>
        /// <param name="windowStyle"></param>
        public static void LaunchFile(
            this string fileFullPath,
            System.Diagnostics.ProcessWindowStyle windowStyle =
            System.Diagnostics.ProcessWindowStyle.Normal,
            bool enableRaisingEvents = false)
        {
            var proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = fileFullPath;
            proc.StartInfo.WindowStyle = windowStyle;
            proc.EnableRaisingEvents = enableRaisingEvents;
            proc.Start();
        }
    }
}