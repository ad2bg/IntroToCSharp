using System;
using System.Linq;

namespace CommonUtils
{
    /// <summary>
    /// Math utilities.
    /// </summary>
    /// <includes>
    /// PtToPt, double, (Pythagoras - a*a + b*b = c*c)
    /// SolveSquareEquation, void, (A * x^2 + B*x + C = 0)
    //// Gcd, int (Greatest Common Denominator)
    /// isPrimeNumber, bool
    /// SwapBits, long
    /// GetBit, byte
    /// SetBit, long
    /// GetDigit, byte
    /// GetNumberOfFractionalDigits, int
    ///
    /// </includes>
    public static class Maths
    {
        /// <summary>
        /// Distance between points in a plane.
        /// </summary>
        /// <param name="x1">Point1 X</param>
        /// <param name="y1">Point1 Y</param>
        /// <param name="x2">Point2 X</param>
        /// <param name="y2">Point2 Y</param>
        /// <returns>Distance as double.</returns>
        public static double PtToPt(
            double x1, double y1, double x2, double y2) =>
            Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));

        /// <summary>
        /// Solves: A * x^2  +  B * x  +  C  =  0
        /// </summary>
        /// <param name="a">A as double</param>
        /// <param name="b">B as double</param>
        /// <param name="c">C as double</param>
        /// <param name="d">out = Sqrt((b * b) - (4 * a * c)</param>
        /// <param name="x1">(-b + d) / 2 / a</param>
        /// <param name="x2">(-b - d) / 2 / a</param>
        public static void SolveSquareEquation(
        double a, double b, double c,
        out double d, out double x1, out double x2)
        {
            d = Math.Sqrt((b * b) - (4 * a * c));

            if (Math.Abs(d) < double.Epsilon)
            {
                x1 = x2 = -b / 2 / a;  // same as: x2 = -b / 2 / a; x1 = x2;
            }
            else if (d > 0)
            {
                x1 = (-b + d) / 2 / a;
                x2 = (-b - d) / 2 / a;
            }
            else
            {
                x1 = double.NaN; x2 = double.NaN; // no real solutions available
            }
        }

        /// <summary>
        /// Greatest Common Denominator (най-голям общ делител)
        /// </summary>
        /// <typeparam name="T">Numeral type.</typeparam>
        /// <typeparam name="U">Numeral type.</typeparam>
        /// <param name="a">Number 1.</param>
        /// <param name="b">Number 2.</param>
        /// <returns>Greatest Common Denominator as int.</returns>
        public static int Gcd<T, U>(T a, U b)
        {
            long aa = 0; long.TryParse(a.ToString(), out aa);
            long bb = 0; long.TryParse(b.ToString(), out bb);

            // procedural
            while (bb != 0)
            {
                long tt = bb;
                bb = aa % bb;
                aa = tt;
            }
            return (int)aa;

            //// w/o dividing
            ////while (aa != bb)
            ////{
            ////    if (aa > bb) aa -= bb;
            ////    else bb -= aa;
            ////}
            ////return (int)aa;

            //// recursive
            ////if (bb == 0) return (int)aa;
            ////else return gcd(bb, aa % bb);
        }

        /// <summary>
        /// isPrimeNumber  (просто число)
        /// </summary>
        /// <param name="n">Int number to test</param>
        /// <returns>True if it is a prime number.</returns>
        public static bool isPrimeNumber(this int n)
        {
            bool isPrime = true;

            for (int i = 3; i < n; i += 2)
            {
                if ((n % i) == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            return isPrime;
        }

        /// <summary>
        /// Swaps bits in a number.
        /// </summary>
        /// <param name="n">Int number.</param>
        /// <param name="p1">Position 1.</param>
        /// <param name="p2">Position 2.</param>
        /// <returns>Int number.</returns>
        public static long SwapBits(this long n, byte p1, byte p2)
        {
            // Get bits b1 and b2 from positions p1 and p2
            var b1 = (byte)(n.GetBit(p1) % 2);
            var b2 = (byte)(n.GetBit(p2) % 2);
            // Do the swap
            byte temp = b1;
            n = SetBit(n, p1, b2);
            n = SetBit(n, p2, temp);
            return n;
        }

        /// <summary>
        /// Get a bit from a number.
        /// </summary>
        /// <remarks>
        //// alternatively - return (byte)((n >> psn) & 1);
        /// </remarks>
        /// <param name="n">Long number.</param>
        /// <param name="psn">Position: right to left; 0 based</param>
        /// <returns>Long number.</returns>
        public static byte GetBit(this long n, byte psn) =>
            (byte)((n >> psn) % 2);

        /// <summary>
        /// Sets a bit in a number.
        /// </summary>
        /// <param name="n">Long number.</param>
        /// <param name="p">Position: right to left; 0 based.</param>
        /// <param name="v">Value of bit: 0 or 1.</param>
        /// <returns>Long number.</returns>
#pragma warning disable CS0675
        // Bitwise-or operator used on a sign-extended operand
        public static long SetBit(this long n, byte p, byte v) =>
            v == 1 ? n | (1 << p) : n & ~(1 << p);
#pragma warning restore CS0675

        /// <summary>
        /// Gets a digit from a number.
        /// </summary>
        /// <param name="n">Long number.</param>
        /// <param name="psn">Position: right to left; 0 based.</param>
        /// <returns>Digit as byte.</returns>
        public static byte GetDigit(this long n, byte psn)
        {
            // r to l; 0 based

            long x = n;
            for (int i = 0; i < psn; i++)
            {
                x = x / 10;
            }
            x = x % 10;
            return (byte)Math.Abs(x);
        }

        /// <summary>
        /// Gets the number of digits in a double after the decimal point
        /// </summary>
        /// <param name="d">double</param>
        /// <returns>number of digits</returns>
        public static int GetNumberOfFractionalDigits(this double d) =>
            d.ToString(
            System.Globalization.CultureInfo.InvariantCulture).
            Split('.').Count() > 1 ?
            d.ToString(System.Globalization.CultureInfo.InvariantCulture).
            Split('.').ToList().ElementAt(1).Length :
            0;
    }
}