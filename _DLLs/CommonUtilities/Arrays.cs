using System;
using System.Collections.Generic;

namespace CommonUtils
{
    /// <summary>
    /// Utilities for Arrays.
    /// </summary>
    /// <includes>
    /// ReadIntArrayFromConsole, int[]
    /// ReadIntArrayFromConsole, int[,]
    /// FillRandoms, int[]
    /// FillRandoms, int[,]
    /// PrintArrayToConsole, T[]
    /// PrintArrayToConsole, T[,]
    /// SwapInArray T[]
    /// IndexMax, int
    /// IndexMin, int
    /// MaxInArray, int
    /// MinInArray, int
    /// BubbleSort, int[]
    /// SelectionSort, int[]
    /// InsertionSort, int[]
    /// MergeSortIterative, int[]
    /// MergeSortRecursive, int[]
    /// QuickSortRecursive, int[]
    /// QuickSortIterative, int[]
    /// ReverseArray, T[]
    /// SumElements, int
    /// GetIndex, int
    /// BinarySearchIterative, int
    /// BinarySearchRecursive, int
    /// IterateSubSets, int
    /// Permutations, int[,]
    /// Variations, int[,]
    /// VariationsWithRepetition, int[,]
    /// Combinations, int[,]
    /// AllUniqueValues, bool
    /// CombineJaggedArrayToList, List(string)
    ///
    /// </includes>
    public static class Arrays
    {
        /// <summary>
        /// Read int[] from Console.
        /// </summary>
        /// <param name="arr">int[]</param>
        /// <param name="prompt">Text to print above inputs.</param>
        /// <param name="formatString">
        /// Format string for each input prompt.
        /// </param>
        /// <param name="min">Min value.</param>
        /// <param name="max">Max value.</param>
        /// <returns>int[]</returns>
        public static int[] ReadIntArrayFromConsole(
            this int[] arr,
            string prompt = "Enter the values of a vector array int[{0}]:",
            string formatString = "Value [{0}] : ",
            int min = int.MinValue, int max = int.MaxValue)
        {
            int len = arr.Length;

            Console.WriteLine(prompt, len);

            for (int i = 0; i < len; i++)
            {
                arr[i] = arr[i].
                    ReadInt(string.Format(formatString, i), min: min, max: max);
            }
            return arr;
        }

        /// <summary>
        /// Read int[,] from Console.
        /// </summary>
        /// <param name="arr">int[]</param>
        /// <param name="prompt">Text to print above inputs.</param>
        /// <param name="formatString">
        /// Format string for each input prompt.
        /// </param>
        /// <param name="min">Min value.</param>
        /// <param name="max">Max value.</param>
        /// <returns>int[]</returns>
        public static int[,] ReadIntArrayFromConsole(
            this int[,] arr,
            string prompt = "Enter the cells of the array int[{0},{1}]:",
            string formatString = "Value [{0}, {1}] : ",
            int min = int.MinValue, int max = int.MaxValue)
        {
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);

            Console.WriteLine(prompt, rows, cols);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    arr[row, col] = arr[row, col].
                        ReadInt(string.Format(formatString, row, col),
                        min: min, max: max);
                }
            }
            return arr;
        }

        /// <summary>
        /// Fill int[] with random ints.
        /// </summary>
        /// <param name="arr">int[]</param>
        /// <param name="rFrom">Min value.</param>
        /// <param name="rTo">Max value.</param>
        /// <returns>int[]</returns>
        public static int[] FillRandoms(this int[] arr,
            int rFrom = int.MinValue, int rTo = int.MaxValue)
        {
            var r = new Random();
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            { arr[i] = r.Next(rFrom, (rTo == int.MaxValue ? rTo : rTo + 1)); }
            return arr;
        }

        /// <summary>
        /// Fill int[,] with random ints.
        /// </summary>
        /// <param name="arr">int[,]</param>
        /// <param name="rFrom">Min value.</param>
        /// <param name="rTo">Max value.</param>
        /// <returns>int[,]</returns>
        public static int[,] FillRandoms(this int[,] arr,
            int rFrom = int.MinValue, int rTo = int.MaxValue)
        {
            var r = new Random();
            int n = arr.GetLength(0);
            int m = arr.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    arr[i, j] =
                        r.Next(rFrom, (rTo == int.MaxValue ? rTo : rTo + 1));
                }
            }
            return arr;
        }

        /// <summary>
        /// Print T[] to Console.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr">T[]</param>
        /// <param name="prefixLine">Text to print above the T[].</param>
        /// <param name="suffixLine">Text to print below the T[].</param>
        /// <param name="formatString">Format string for each item.</param>
        /// <param name="delimiter">Separator.</param>
        /// <param name="from">From item (zero-based).</param>
        /// <param name="to">To item (zero-based).</param>
        /// <returns>T[]</returns>
        public static T[] PrintArrayToConsole<T>(
            this T[] arr,
            string prefixLine = "", string suffixLine = "",
            string formatString = "{0}", string delimiter = ", ",
            int from = 0, int to = -1)
        {
            int n = arr.Length;
            if (to == -1) to = n - 1;

            if (from < 0 || to < 0 || from >= n || to >= n || from > to)
                throw new ArgumentOutOfRangeException();

            Console.Write(prefixLine);
            for (int i = from; i <= to; i++)
            {
                Console.Write(formatString, arr[i]);
                if (i < to) Console.Write(delimiter);
            }
            Console.WriteLine(suffixLine);
            return arr;
        }

        /// <summary>
        /// Print T[,] to Console.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr">T[,]</param>
        /// <param name="prefixLine">Text to print above the T[,].</param>
        /// <param name="suffixLine">Text to print below the T[,].</param>
        /// <param name="delimiter1">Separator 1</param>
        /// <param name="delimiter2">Separator 2</param>
        /// <param name="formatString">Format string for each item.</param>
        /// <param name="horizontalX">
        /// True: Items T[0,] print on the top row. 
        /// False: Items T[,0] print on the top row. 
        /// </param>
        /// <param name="flipHorizontal">Flip horizontal.</param>
        /// <param name="flipVertical">Flip vertical.</param>
        /// <param name="fromX">From item X (zero-based).</param>
        /// <param name="toX">To item X (zero-based).</param>
        /// <param name="fromY">From item Y (zero-based).</param>
        /// <param name="toY">To item Y (zero-based).</param>
        /// <returns>T[,]</returns>
        public static T[,] PrintArrayToConsole<T>(
            this T[,] arr,
            string prefixLine = "", string suffixLine = "",
            string delimiter1 = ", ", string delimiter2 = "\n",
            string formatString = "", bool horizontalX = true,
            bool flipHorizontal = false, bool flipVertical = false,
            int fromX = 0, int toX = -1, int fromY = 0, int toY = -1)

        {
            Console.WriteLine(prefixLine);

            int fromXX, toXX, incrX = 1;
            int fromYY, toYY, incrY = 1;

            if (horizontalX)
            {
                if (toX == -1) toX = arr.GetLength(0) - 1;
                if (toY == -1) toY = arr.GetLength(1) - 1;

                if (flipHorizontal)
                { fromYY = toY; toYY = fromY; incrY = -1; }
                else { fromYY = fromY; toYY = toY; }

                if (flipVertical)
                { fromXX = toX; toXX = fromX; incrX = -1; }
                else { fromXX = fromX; toXX = toX; }

                for (int x = fromXX;
                    flipVertical ? x >= toXX : x <= toXX;
                    x += incrX)
                {
                    for (int y = fromYY;
                        flipHorizontal ? y >= toYY : y <= toYY;
                        y += incrY)
                    {
                        if (formatString == "") Console.Write(arr[x, y]);
                        else Console.Write(formatString, arr[x, y]);
                        if (flipHorizontal ? y > toYY : y < toYY)
                            Console.Write(delimiter1);
                    }
                    Console.Write(delimiter2);
                }
            }
            else
            {
                if (toY == -1) toY = arr.GetLength(0) - 1;
                if (toX == -1) toX = arr.GetLength(1) - 1;

                if (flipHorizontal)
                { fromYY = toY; toYY = fromY; incrY = -1; }
                else { fromYY = fromY; toYY = toY; }

                if (flipVertical)
                { fromXX = toX; toXX = fromX; incrX = -1; }
                else { fromXX = fromX; toXX = toX; }

                for (int x = fromXX;
                    flipVertical ? x >= toXX : x <= toXX;
                    x += incrX)
                {
                    for (int y = fromYY;
                        flipHorizontal ? y >= toYY : y <= toYY;
                        y += incrY)
                    {
                        if (formatString == "") Console.Write(arr[y, x]);
                        else Console.Write(formatString, arr[y, x]);
                        if (flipHorizontal ? y > toYY : y < toYY)
                            Console.Write(delimiter1);
                    }
                    Console.Write(delimiter2);
                }
            }
            Console.WriteLine(suffixLine);
            return arr;
        }


        /// <summary>
        /// Swap items in T[].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr">T[]</param>
        /// <param name="psn2">Position 1</param>
        /// <param name="psn1">Position 2</param>
        /// <returns>T[]</returns>
        public static T[] SwapInArray<T>(
            this T[] arr, int psn1, int psn2)
        {
            // example usage:
            // new int[] { 0, 1, 2, 3 }.SwapInArray(1, 3).
            //     PrintArrayToConsole();
            //   or
            // foreach (var item in new int[] { 0, 1, 2, 3 }.SwapInArray(1, 3))
            // Console.WriteLine(item);

            Misc.Swap(ref arr[psn1], ref arr[psn2]);
            //T temp = arr[psn1];
            //arr[psn1] = arr[psn2];
            //arr[psn2] = temp;

            return arr;
        }


        /// <summary>
        /// Get the index of Max item in int[].
        /// </summary>
        /// <param name="arr">int[]</param>
        /// <returns>Index - zero based.</returns>
        public static int IndexMax(this int[] arr)
        {
            int ixMax = -1;
            int max = int.MinValue;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max) { max = arr[i]; ixMax = i; }
            }
            return ixMax;
        }
        /// <summary>
        /// Get the index of Min item in int[].
        /// </summary>
        /// <param name="arr">int[]</param>
        /// <returns>Index - zero based.</returns>
        public static int IndexMin(this int[] arr)
        {
            int ixMin = -1;
            int min = int.MaxValue;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min) { min = arr[i]; ixMin = i; }
            }
            return ixMin;
        }


        /// <summary>
        /// Get Max value from int[].
        /// </summary>
        /// <param name="arr">int[]</param>
        /// <returns>Max value from int[].</returns>
        public static int MaxInArray(this int[] arr)
        {
            int max = int.MinValue;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max) max = arr[i];
            }
            return max;
        }
        /// <summary>
        /// Get Min value from int[].
        /// </summary>
        /// <param name="arr">int[]</param>
        /// <returns>Min value from int[].</returns>
        public static int MinInArray(this int[] arr)
        {
            int min = int.MaxValue;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min) min = arr[i];
            }
            return min;
        }


        /// <summary>
        /// Bubble sort of int[].
        /// </summary>
        /// <param name="arr">int[]</param>
        /// <param name="reverse">True: sort descending.</param>
        /// <returns>Sorted int[]</returns>
        public static int[] BubbleSort(
            this int[] arr, bool reverse = false)
        {
            int max = arr.Length;
            for (int i = 1; i < max; i++)
            {
                for (int j = 0; j < max - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
                //arr.PrintArrayToConsole("Iteration " + i + " : ");
            }
            if (reverse) arr = arr.ReverseArray();
            return arr;
        }
        /// <summary>
        /// Selection sort of int[].
        /// </summary>
        /// <param name="arr">int[]</param>
        /// <param name="reverse">True: sort descending.</param>
        /// <returns>Sorted int[]</returns>
        public static int[] SelectionSort(
            this int[] arr, bool reverse = false)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                    if (arr[j] < arr[minIndex])
                        minIndex = j;
                if (minIndex > i) arr.SwapInArray(i, minIndex);
            }
            if (reverse) arr = arr.ReverseArray();
            return arr;
        }
        /// <summary>
        /// Insertion sort of int[].
        /// </summary>
        /// <param name="arr">int[]</param>
        /// <param name="reverse">True: sort descending.</param>
        /// <returns>Sorted int[]</returns>
        public static int[] InsertionSort(
            this int[] arr, bool reverse = false)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int j = i;
                while (j > 0)
                {
                    if (arr[j - 1] > arr[j])
                    {
                        int temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                        j--;
                    }
                    else break;
                }
                //arr.PrintArrayToConsole("Iteration " + i + " : ");
            }
            if (reverse) arr = arr.ReverseArray();
            return arr;
        }


        /// <summary>
        /// Merge Sort Iterative for int[].
        /// </summary>
        /// <param name="arr">int[]</param>
        /// <param name="from">From index (zero-based).</param>
        /// <param name="to">To index (zero-based).</param>
        /// <param name="reverse">True: sort descending.</param>
        /// <returns>Sorted int[]</returns>
        public static int[] MergeSortIterative(
            this int[] arr, int from = 0, int to = -1, bool reverse = false)
        {
            int n = arr.Length;
            if (to == -1) to = n - 1;
            if (to <= from) return arr;

            var list1 = new List<MSortFromTo>();
            var list2 = new List<MSortFromTo>();

            var sort = new MSortFromTo { from = from, to = to };
            list1.Add(sort);

            while (list1.Count > 0)
            {
                from = list1[0].from;
                to = list1[0].to;
                list1.RemoveAt(0);

                //Debug.WriteLine("L1 pull: F = {0}         T = {1}", from, to);

                if (from < to)
                {
                    int mid = (to + from) / 2;

                    var sort2 = new MSortFromTo
                    { from = from, to = to, mid = mid + 1 };
                    list2.Add(sort2);

                    //Debug.WriteLine("L2 add:  F = {0}  M = {1}  T = {2}",
                    //    from, mid + 1, to);

                    sort.from = mid + 1;
                    sort.to = to;
                    list1.Add(sort);

                    sort.from = from;
                    sort.to = mid;
                    list1.Add(sort);
                }
            }
            for (int i = list2.Count - 1; i >= 0; i--)
                DoMerge(arr, list2[i].from, list2[i].mid, list2[i].to);

            if (reverse) arr = arr.ReverseArray();
            return arr;
        }
        /// <summary>
        /// Merge Sort Recursive for int[].
        /// </summary>
        /// <param name="arr">int[]</param>
        /// <param name="from">From index (zero-based).</param>
        /// <param name="to">To index (zero-based).</param>
        /// <param name="reverse">True: sort descending.</param>
        /// <returns>Sorted int[]</returns>
        public static int[] MergeSortRecursive(
            this int[] arr, int from = 0, int to = -1, bool reverse = false)
        {
            int n = arr.Length;
            if (to == -1) to = n - 1;

            if (from < to)
            {
                int mid = (from + to) / 2;
                MergeSortRecursive(arr, from, mid);
                MergeSortRecursive(arr, mid + 1, to);
                DoMerge(arr, from, (mid + 1), to);
            }
            if (reverse) arr = arr.ReverseArray();
            return arr;
        }
        /// <summary>
        /// Used by Merge Sort Iterative and Merge Sort Recursive.
        /// </summary>
        /// <param name="arr">int[]</param>
        /// <param name="from">From index (zero-based).</param>
        /// <param name="mid">Mid index (zero-based).</param>
        /// <param name="to">To index (zero-based).</param>
        static void DoMerge(int[] arr, int from, int mid, int to)
        {
            //Debug.WriteLine("R! F = {0}  M = {1}  T = {2}",
            //    from, mid, to);

            int leftEnd = mid - 1;
            int tempPos = from;
            int numElements = (to - from + 1);
            int[] tempArr = new int[arr.Length];
            // Merging.
            while ((from <= leftEnd) && (mid <= to))
            {
                tempArr[tempPos++] = arr[from] <= arr[mid] ?
                    arr[from++] : arr[mid++];
            }
            while (from <= leftEnd) tempArr[tempPos++] = arr[from++];
            while (mid <= to) tempArr[tempPos++] = arr[mid++];
            // Copying from tempArr to arr.
            for (int i = 0; i < numElements; i++)
            {
                arr[to] = tempArr[to];
                to--;
            }
        }
        /// <summary>
        /// Used by Merge Sort Iterative and Merge Sort Recursive.
        /// </summary>
        struct MSortFromTo
        {
            public int from;
            public int mid;
            public int to;
        };


        /// <summary>
        /// Quick Sort Recursive for int[].
        /// </summary>
        /// <param name="arr">int[]</param>
        /// <param name="from">From index (zero-based).</param>
        /// <param name="to">To index (zero-based).</param>
        /// <param name="reverse">True: sort descending.</param>
        /// <returns>Sorted int[]</returns>
        public static int[] QuickSortRecursive(
            this int[] arr, int from = 0, int to = -1, bool reverse = false)
        {
            int n = arr.Length;
            if (to == -1) to = n - 1;

            if (from < to)
            {
                int pivot = Partition(arr, from, to);
                if (pivot > 1) QuickSortRecursive(arr, from, pivot - 1);
                if (pivot + 1 < to) QuickSortRecursive(arr, pivot + 1, to);
            }
            if (reverse) arr = arr.ReverseArray();
            return arr;
        }
        /// <summary>
        /// Quick Sort Iterative for int[].
        /// </summary>
        /// <param name="arr">int[]</param>
        /// <param name="from">From index (zero-based).</param>
        /// <param name="to">To index (zero-based).</param>
        /// <param name="reverse">True: sort descending.</param>
        /// <returns>Sorted int[]</returns>
        static public int[] QuickSortIterative(
            this int[] arr, int from = 0, int to = -1, bool reverse = false)
        {
            int n = arr.Length;
            if (to == -1) to = n - 1;

            if (from >= to) return arr;

            var list = new List<QSortFromTo>();

            var sort = new QSortFromTo { from = from, to = to };
            list.Add(sort);

            while (list.Count > 0)
            {
                from = list[0].from;
                to = list[0].to;
                list.RemoveAt(0);

                int pivot = Partition(arr, from, to);

                if (pivot > 1)
                {
                    sort.from = from;
                    sort.to = pivot - 1;
                    list.Add(sort);
                }

                if (pivot + 1 < to)
                {
                    sort.from = pivot + 1;
                    sort.to = to;
                    list.Add(sort);
                }
            }
            if (reverse) arr = arr.ReverseArray();
            return arr;
        }
        /// <summary>
        /// Used by Quick Sort Iterative and Quick Sort Recursive.
        /// </summary>
        /// <param name="arr">int[]</param>
        /// <param name="from">From index (zero-based).</param>
        /// <param name="to">To index (zero-based).</param>
        /// <returns>int</returns>
        static int Partition(int[] arr, int from, int to)
        {
            int pivot = arr[from];
            while (true)
            {
                while (arr[from] < pivot) from++;
                while (arr[to] > pivot) to--;

                if (from < to) arr.SwapInArray(to, from);
                else return to;
            }
        }
        /// <summary>
        /// Used by Quick Sort Iterative and Quick Sort Recursive.
        /// </summary>
        struct QSortFromTo
        {
            public int from;
            public int to;
        };


        /// <summary>
        /// Reverse T[].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr">T[]</param>
        /// <returns>Reversed T[]</returns>
        public static T[] ReverseArray<T>(this T[] arr)
        {
            int length = arr.Length;
            T[] reversedArr = new T[length];
            for (int index = 0; index < length; index++)
            {
                reversedArr[length - index - 1] = arr[index];
            }
            return reversedArr;
        }


        /// <summary>
        /// Sum Elements from int[].
        /// </summary>
        /// <param name="arr">int[]</param>
        /// <param name="from">From index (zero-based).</param>
        /// <param name="to">To index (zero-based).</param>
        /// <returns>Sum as int.</returns>
        public static int SumElements(
            this int[] arr, int from = 0, int to = -1)
        {
            int sum = 0, n = arr.Length;
            if (to == -1) to = n - 1;
            if (from < 0 || to < 0 || from >= n || to >= n || from > to)
                throw new ArgumentOutOfRangeException();

            for (int i = from; i <= to; i++) sum += arr[i];

            return sum;
        }


        /// <summary>
        /// Get Index of item in T[].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr">T[]</param>
        /// <param name="value">Value searched for.</param>
        /// <returns>Index as int (zero-based).</returns>
        public static int GetIndex<T>(this T[] arr, T value)
        {
            int ix = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Equals(value)) { ix = i; break; }
            }
            return ix;
        }


        /// <summary>
        /// Binary Search Iterative in int[].
        /// </summary>
        /// <param name="arr">int[] must be pre-sorted ascending or descending</param>
        /// <param name="value">Value searched for.</param>
        /// <param name="from">From index (zero-based).</param>
        /// <param name="to">To index (zero-based).</param>
        /// <param name="descending">True: when int[] sorted descending.</param>
        /// <returns>Index as int (zero-based).</returns>
        public static int BinarySearchIterative(
            this int[] arr, int value, int from = 0, int to = -1,
            bool descending = false)
        {
            if (to == -1) to = arr.Length;

            while (from <= to)
            {
                int mid = (from + to) / 2;
                if (value == arr[mid]) { return mid; } // value found
                if (descending ^ (value < arr[mid])) { to = mid - 1; }
                else { from = mid + 1; }
            }
            return -1; // value not found
        }

        /// <summary>
        /// Binary Search Recursive in int[].
        /// </summary>
        /// <param name="arr">int[] must be pre-sorted ascending or descending</param>
        /// <param name="value">Value searched for.</param>
        /// <param name="from">From index (zero-based).</param>
        /// <param name="to">To index (zero-based).</param>
        /// <param name="descending">True: when int[] sorted descending.</param>
        /// <returns>Index as int (zero-based).</returns>
        public static int BinarySearchRecursive(
            this int[] arr, int value, int from = 0, int to = -1,
            bool descending = false)
        {
            if (to == -1) to = arr.Length;

            if (from > to) { return -1; } // bottom of recursion
            int mid = (from + to) / 2;
            if (value == arr[mid]) { return mid; } // value found
            if (descending ^ (value < arr[mid]))
            {
                return BinarySearchRecursive(arr, value, from, mid - 1);
            }
            return BinarySearchRecursive(arr, value, mid + 1, to);
        }



        /// <summary>
        /// Iterate all the subsets from T[].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr">T[]</param>
        /// <param name="aSum">
        /// Required sum of items in a subset.
        /// </param>
        /// <param name="nSubset">
        /// Required number of items in the subset.
        /// </param>
        /// <returns>(int) Count of Solutions.</returns>
        public static int IterateSubSets<T>(
            this T[] arr, int aSum, int nSubset = -1)
        {
            int n = arr.Length;
            T[] subArr = new T[0];
            int countSolutions = 0;

            // Iterating from 0 to (1<<k) (left shifting by 2 i.e. 2^k);
            // If i starts from 0 - that includes the EmptySubset;
            // Here i starts from 1, so the EmptySubset is not included.

            for (int i = 1; i < (1 << n); i++)
            //for (int i = (1 << n) - 1; i > 0; i--) // can reverse for debug
            {
                // Checking for each bit in a particular iteration
                // in order to get only those items from arr

                int count = 0;
                // Count the matched bits.
                for (int k = 0; k < n; k++)
                {
                    if (((1 << k) & i) != 0) count++;
                }

                if (nSubset > 0 && count != nSubset) continue;

                // Size the subArr.
                subArr = new T[count];

                // Fill subArr from arr.
                count = 0;
                for (int k = 0; k < n; k++)
                {
                    if (((1 << k) & i) != 0)
                    {
                        subArr[count] = arr[k];
                        count++;
                    }
                }

                if (DoStuffWithSubArr(subArr, aSum)) countSolutions++;
            }
            return countSolutions;
        }

        /// <summary>
        /// Do stuff with subsets
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subArr">subset T[]</param>
        /// <param name="aSum">Required sum of items in a subset.</param>
        /// <returns>True if sum = required sum.</returns>
        static bool DoStuffWithSubArr<T>(T[] subArr, int aSum)
        {
            // Here we copy T[]subArr to int[]ints
            // so that we can call CheckSubSet(ints).
            int[] ints = new int[subArr.Length];
            for (int j = 0; j < subArr.Length; j++)
            {
                ints[j] = Convert.ToInt32(subArr[j]);
            }

            // For debugging only:
            //subArr.PrintArrayToConsole("check subArr: ");
            //ints.PrintArrayToConsole  ("check ints  : ");
            //Console.WriteLine();

            if (CheckSubSet(ints, aSum))
            {
                ints.PrintArrayToConsole("Solution: ");
                Console.WriteLine();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check if the subset's sum equals the required sum.
        /// </summary>
        /// <param name="arr">int[]</param>
        /// <param name="aSum">Required sum.</param>
        /// <returns>True if sum = required sum.</returns>
        static bool CheckSubSet(int[] arr, int aSum)
        {
            int sum = 0;
            foreach (var value in arr)
            {
                sum += value;
            }
            return (sum == aSum);
        }


        /// <summary>
        /// Permutations Without Repetition - Recursive.
        /// </summary>
        /// <param name="n">int>=2</param>
        /// <returns>
        /// int[n!,n] ;
        /// n! rows.
        /// Each row contains one permutation of ints [1:n].
        /// </returns>
        public static int[,] Permutations(this int n)
        {
            if (n < 2) throw new ArgumentOutOfRangeException();
            if (n == 2)
            {
                return new int[,]
                    {
                        { 1, 2 },
                        { 2, 1 }
                    };
            }
            //
            int[,] drillDown = Permutations(n - 1);
            int rows = drillDown.GetLength(0);

            int[,] permutations = new int[rows * n, n];

            for (int i = 0; i < n; i++)        // n-times
            {
                for (int j = 0; j < rows; j++) // through r rows of drillDown
                {
                    int d = n - 1;
                    for (int y = n - 1; y >= 0; y--)  // n columns
                    {
                        int x = i * rows + j;
                        permutations[x, y] =
                            i + y == n - 1 ? n : drillDown[j, --d];
                    }
                }
            }
            return permutations;
        }


        /// <summary>
        /// Variations Without Repetition - Iterative
        /// </summary>
        /// <param name="n">int>=3</param>
        /// <param name="k">int>=2</param>
        /// <returns>
        /// int[x,k] ;   k = n!/(n-k)!
        /// Each row contains one variation of ints [1:k].
        /// </returns>
        public static int[,] Variations(this int n, int k)
        {
            if (n < 3) throw new ArgumentOutOfRangeException();
            if (k < 2) throw new ArgumentOutOfRangeException();

            int x = 1; // number of variations
            for (int i = n - k + 1; i <= n; i++) { x *= i; }

            int[] indexes = new int[k];        // indexes of the "nested loops"
            int[,] variations = new int[x, k];
            int counter = 0;

            do
            {
                if (AllUniqueValues(indexes))
                {
                    for (int kk = 0; kk < k; kk++)
                    { variations[counter, kk] = indexes[kk] + 1; }
                    counter++;
                }
                indexes.IncrementLoopsIndexes(n);
            } while (counter < x);
            return variations;
        }


        /// <summary>
        /// Variations With Repetition - Iterative
        /// </summary>
        /// <param name="n">int>=3</param>
        /// <param name="k">int>=2</param>
        /// <returns>
        /// int[x,k] ;   x = n ^ k
        /// Each row contains one variation of ints [1:k].
        /// </returns>
        public static int[,] VariationsWithRepetition(this int n, int k)
        {
            if (n < 3) throw new ArgumentOutOfRangeException();
            if (k < 2) throw new ArgumentOutOfRangeException();

            var x = (int)Math.Pow(n, k); // number of variations with repetition
            int[] indexes = new int[k];  // indexes of the "nested loops"
            int[,] variations = new int[x, k];
            int i = 0, j = 0;            // i=0 to n^k -1     j=0 to k-1
            while (j < k)
            {
                for (j = 0; j < k; j++) { variations[i, j] = indexes[j] + 1; }
                i++; if (i == x) i = 0;
                j = indexes.IncrementLoopsIndexes(n);
            }
            return variations;
        }


        /// <summary>
        /// Combinations Without Repetition - Iterative
        /// </summary>
        /// <param name="n">int>=3</param>
        /// <param name="k">int>=2</param>
        /// <returns>
        /// int[x,k] ;   k = n! / ( (n-k)!k! )
        /// Each row contains one combination of ints [1:k].
        /// </returns>
        public static int[,] Combinations(this int n, int k)
        {
            if (n < 3) throw new ArgumentOutOfRangeException();
            if (k < 2) throw new ArgumentOutOfRangeException();

            int x = 1; // number of combinations
            for (int i = n - k + 1; i <= n; i++) { x *= i; }
            for (int i = 1; i <= k; i++) { x /= i; }

            int[] indexes = new int[k];
            int[,] combinations = new int[x, k];
            int counter = 0;

            do
            {
                if (IsOrdered(indexes, inReverse: true))
                {
                    for (int kk = 0; kk < k; kk++)
                    {
                        combinations[counter, kk] = indexes[kk] + 1;
                    }
                    counter++;
                }
                indexes.IncrementLoopsIndexes(n);
            } while (counter < x);
            return combinations;
        }



        /// <summary>
        /// Checks if all values in a int[] are ordered.
        /// </summary>
        /// <remarks>
        /// This is used by the Combinations method.
        /// </remarks>
        /// <param name="arr">int[]</param>
        /// <returns>
        /// True: if all values are ordered. Not necessarily successive.
        /// False: if they are not.
        /// </returns>
        public static bool IsOrdered(int[] arr, bool inReverse = false)
        {
            int k = arr.Length;
            for (int i = 0; i < k; i++)
            {
                for (int j = i + 1; j < k; j++)
                {
                    if (inReverse)
                    {
                        if (arr[i] <= arr[j]) return false;
                    }
                    else
                    {
                        if (arr[i] >= arr[j]) return false;
                    }

                }
            }
            return true;
        }



        /// <summary>
        /// Checks if all values in a int[] are unique.
        /// </summary>
        /// <param name="arr">int[]</param>
        /// <returns>
        /// True: if all values are unique.
        /// False: if any two value match.
        /// </returns>
        public static bool AllUniqueValues(int[] arr)
        {
            int k = arr.Length;
            for (int i = 0; i < k; i++)
            {
                for (int j = i + 1; j < k; j++)
                { if (arr[i] == arr[j]) return false; }
            }
            return true;
        }



        /// <summary>
        /// Combine Jagged Array To List
        /// </summary>
        /// <remarks>
        /// Each of the subArrays contains elements that are combined with
        /// each element of every other subArray.
        /// The combinations are done recursively!
        /// </remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">T[][]</param>
        /// <param name="newList">Only used by the recursion; skip!</param>
        /// <param name="index">Only used by the recursion; skip!</param>
        /// <param name="prefix">Prefix for each combination; default ""</param>
        /// <param name="delimiter">Separator.</param>
        /// <returns>List<string> containing all combinations.</returns>
        public static List<string> CombineJaggedArrayToList<T>(
            this T[][] list, List<string> newList = null,
            int index = 0, string prefix = "", string delimiter = " ")
        {
            if (newList == null) newList = new List<string>();
            if (index == list.Length) return newList;
            foreach (T item in list[index])
            {
                CombineJaggedArrayToList(
                    list, newList,
                    index + 1,
                    prefix + (index == 0 ? "" : delimiter) + item,
                    delimiter: delimiter);
                if (index == list.Length - 1)
                {
                    newList.Add(prefix + delimiter + item);
                }
            }
            return newList;
        }
    }
}