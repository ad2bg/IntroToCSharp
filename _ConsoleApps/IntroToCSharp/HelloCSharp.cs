
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// CommonUtilities
/// </summary>
/// <remarks>
/// Parts of the examples/exercises are moved to this DLL
/// which is another project in this solution.
/// </remarks>
using CommonUtils;

/// <summary>
/// Needed for the BigInteger class
/// </summary>
using System.Numerics;

/// <summary>
/// Permutations, Combinations and Variations
/// </summary>
/// <remarks>
/// with and without 'Repetition'. This refers to the modules in the
/// Combinatorics sub-folder.
/// Taken from:
/// http://www.codeproject.com/Articles/26050/Permutations-Combinations-and-Variations-using-C-G
/// </remarks>
using Facet.Combinatorics;


/// <summary>
/// Introduction to Programming with C#
/// </summary>
/// <remarks>
/// Examples and exercises from Telerik book:
/// Въведение в програмирането със C#
/// Compiled by Alex Dimitrov
/// </remarks>
namespace IntroToCSharp
{
    static class HelloCSharp
    {
        #region Chapter 01 - Introduction To Programming

        /// <summary>
        /// Example DateTime.Now.ToString
        /// Console.OutputEncoding
        /// for loop
        /// </summary>


        /// <summary>
        /// Examples of Int.TryParse and DateTime.AddYears
        /// </summary>
        static void Ch01ExampleTryParse()
        {
            int iUserInput;
            DateTime DOB;

            do
            {
                Console.Write("Enter your age: ");
            } while (!int.TryParse(Console.ReadLine(), out iUserInput));

            Console.Write("In 10 years you'll be: ");
            Console.WriteLine(iUserInput + 10);

            do
            {
                do
                {
                    Console.WriteLine();
                    Console.Write("Enter your date of birth [DD MM YYYY]: ");
                } while (!DateTime.TryParse(Console.ReadLine(), out DOB));
            } while (DOB.Year == DateTime.Now.Year);

            Console.Write("You will be " + (iUserInput + 10));
            Console.WriteLine(" on " +
                DOB.AddYears(iUserInput + 10).
                ToString("ddd, dd MMM yyyy"));
        }


        #endregion Chapter 01 - Introduction To Programming




        #region Chapter 02 - Primitive Types and Variables


        static void Ch02ExampleIntTypes()
        {
            byte centuries = 20;
            ushort years = 2000;
            uint days = 730480;
            ulong hours = 17531520;
            // Print the result on the console
            Console.WriteLine(
                centuries + " centuries are "
                + years + " years, or "
                + days + " days, or "
                + hours + " hours.");
        }


        static void Ch02ExampleMaxValue()
        {
            ulong maxIntValue = ulong.MaxValue;
            Console.WriteLine(maxIntValue);
            Console.WriteLine();
        }


        static void Ch02ExampleFloatAndDouble()
        {
            float floatPI = 3.14f;
            Console.WriteLine(floatPI); // 3.14

            double doublePI = 3.14;
            Console.WriteLine(doublePI); // 3.14

            double nan = Double.NaN;
            Console.WriteLine(nan); // NaN

            double infinityP = Double.PositiveInfinity;
            Console.WriteLine(infinityP); // Infinity

            double infinityN = Double.NegativeInfinity;
            Console.WriteLine(infinityN); // NegativeInfinity
        }


        static void Ch02Example2FloatAndDouble()
        {
            // Declare some variables
            float floatPI = 3.141592653589793238f;
            double doublePI = 3.141592653589793238;

            // Print the results on the console
            Console.WriteLine("Float PI is: " + floatPI);
            Console.WriteLine("Double PI is: " + doublePI);

            float f = 0.1f;
            Console.WriteLine(f); // 0.1 (correct due to rounding)

            double d = 0.1f;
            Console.WriteLine(d); // 0.100000001490116 (incorrect)

            float ff = 1.0f / 3;
            Console.WriteLine(ff); // 0.3333333 (correct due to rounding)

            double dd = ff;
            Console.WriteLine(dd); // 0.333333343267441 (incorrect)
        }


        static void Ch02ExampleDecimal()
        {
            decimal decimalPI = 3.14159265358979323846m;
            Console.WriteLine(decimalPI); // 3.14159265358979323846
        }


        static void Ch02ExampleBool()
        {
            // Declare some variables
            int a = 1;
            int b = 2;

            // Which one is greater?
            bool greaterAB = (a > b);

            // Is 'a' equal to 1?
            bool equalA1 = (a == 1);

            // Print the results on the console
            if (greaterAB)
            {
                Console.WriteLine("A > B");
            }
            else
            {
                Console.WriteLine("A <= B");
            }

            Console.WriteLine("greaterAB = " + greaterAB);
            Console.WriteLine("equalA1 = " + equalA1);

            // Console output:
            // A <= B
            // greaterAB = False
            // equalA1 = True
        }


        static void Ch02ExampleChar()
        {
            // Declare a variable
            char symbol = 'a';
            // Print the results on the console
            Console.WriteLine(
                "The code of '" + symbol + "' is: " +
                (int)symbol + " = Hex " + "{0:X}", (int)symbol);
            symbol = 'b';
            Console.WriteLine(
                "The code of '" + symbol + "' is: " +
                (int)symbol + " = Hex " + "{0:X}", (int)symbol);
            symbol = 'A';
            Console.WriteLine(
                "The code of '" + symbol + "' is: " +
                (int)symbol + " = Hex " + symbol.ToHex());
            // Console output:
            // The code of 'a' is: 97 = Hex 61
            // The code of 'b' is: 98 = Hex 62
            // The code of 'A' is: 65 = Hex 41
        }


        static void Ch02ExampleString()
        {
            // Declare some variables
            string firstName = "Ivan";
            string lastName = "Ivanov";
            string fullName = firstName + " " + lastName;

            // Print the results on the console
            Console.WriteLine("Hello, " + firstName + "!");
            Console.WriteLine("Your full name is " + fullName + ".");
            //// Console output:
            //// Hello, Ivan!
            //// Your full name is Ivan Ivanov.
        }


        static void Ch02ExampleObject()
        {
            // Declare some variables
            object container1 = 5;
            object container2 = "Five";

            // Print the results on the console
            Console.WriteLine("The value of container1 is: " + container1);
            Console.WriteLine("The value of container2 is: " + container2);

            // Console output:
            // The value of container is: 5
            // The value of container2 is: Five.
        }


        static void Ch02NullableTypes()
        {
            int? i1 = null;  // Nullable<int> i1 = null;
            int? i2 = i1;

            int i = 5;
            int? ni = i;
            Console.WriteLine(ni); // 5

            //// i = ni; // this will fail to compile
            Console.WriteLine(ni.HasValue); // True
            i = ni.Value;
            Console.WriteLine(i); // 5

            ////ni = null;
            Console.WriteLine(ni.HasValue); // False

            //i = ni.Value; // System.InvalidOperationException
            i = ni.GetValueOrDefault();
            Console.WriteLine(i); // 0
        }


        static void Ch02Literals()
        {
#if false

            // The following variables are initialized with the same value
            int numberInDec = 16;
            int numberInHex = 0x10;
            // This will cause an error, because the value 234L is not int
            //int longInt = 234L;

            // The following is the correct way of assigning a value:
            float realNumber = 12.5f;
            // This is the same value in exponential format:
            realNumber = 1.25e+1f;
            // The following causes an error, because 12.5 is double
            //float realNumber2 = 12.5;
#endif
        }

        /// <summary>
        /// Escape Sequences
        /// </summary>
        static void Ch02EscapeSequences()
        {
            // An ordinary symbol
            char symbol = 'a';
            Console.WriteLine(symbol);
            // Unicode symbol code in a hexadecimal format
            symbol = '\u003A';
            Console.WriteLine(symbol);
            // Assigning the single quote symbol (escaped as \')
            symbol = '\'';
            Console.WriteLine(symbol);
            // Assigning the backslash symbol(escaped as \\)
            symbol = '\\';
            Console.WriteLine(symbol);
            // Console output:
            // a
            // :
            // '
            // \

            string quotation = "\"Hello, Jude\", he said.";
            Console.WriteLine(quotation);
            string path = "C:\\Windows\\Notepad.exe";
            Console.WriteLine(path);
            string verbatim = @"The \ is not escaped as \\.
            I am at a new line.";
            Console.WriteLine(verbatim);
            // Console output:
            // "Hello, Jude", he said.
            // C:\Windows\Notepad.exe
            // The \ is not escaped as \\.
            // I am at a new line.
        }


        // assigning values to value types
        static void Ch02Exercise01()
        {
#if false
            ushort usN1 = 52130;
            sbyte sbN2 = -115;
            uint uiN3 = 4825932;
            byte bN4 = 97;
            short sN5 = -10000;
            short sN6 = 20000;
            byte bN7 = 224;
            int iN8 = 970700000;
            sbyte sbN9 = 112;
            sbyte sbN10 = -44;
            int iN11 = -1000000;
            short sN12 = 1990;
            decimal dN13 = 123456789123456789;
#endif
        }


        // assigning values to decimals
        static void CH02Exercise02()
        {
            double dN1 = 34.567839023;
            float fN2 = 12.345f;
            double dN3 = 8923.1234857;
            decimal mN4 = 3456.091124875956542151256683467m;

            Console.WriteLine(dN1);
            Console.WriteLine(fN2);
            Console.WriteLine(dN3);
            Console.WriteLine(mN4);
        }


        // division of decimals with 0.000001 precision
        static void Ch02Exercise03()
        {
            do
            {
                Console.Write("Enter a number: ");
                decimal aNumber = Convert.ToDecimal(Console.ReadLine());
                if (aNumber == 0)
                {
                    return;
                }
                Console.Write("Enter a divisor: ");
                decimal aDivisor = Convert.ToDecimal(Console.ReadLine());
                if (aDivisor == 0)
                {
                    return;
                }
                Console.WriteLine("{0}/{1} = {2:0.######}",
                    aNumber, aDivisor, aNumber / aDivisor);
                Console.WriteLine();

            } while (true);
        }


        // Example  assign a Hex value to an int
        static void Ch02Exercise04()
        {
            int myInt = 0x100;
            Console.WriteLine(myInt); // 256
        }


        // Example  assign a Unicode value to a char
        static void Ch02Exercise05()
        {
            char myChar = '\u0048';
            Console.WriteLine("{0} = Unicode {1}",
                myChar, (int)myChar); // H = Unicode 72
        }


        // Example  assign a value to a bool
        static void Ch02Exercise06()
        {
            // bool isMale = true;
        }


        // Example  assign a string value to an object
        static void Ch02Exercise07()
        {
            string hi = "Hello";
            string who = "World";

            object myObj = string.Concat(hi, ' ', who);
            // the space can be a char - i.e. in single quotes
            Console.WriteLine(myObj);
        }


        // Example  assign an object value to a string - typecasting
        static void Ch02Exercise08()
        {
            string hi = "Hello";
            string who = "World";

            object myObj = string.Concat(hi, ' ', who);
            // the space can be a char - i.e. in single quotes
            string myString = myObj.ToString();
            Console.WriteLine(myString);
        }


        // Example  escape sequences
        static void Ch02Exercise09()
        {
            string myStr1 = @"The ""use"" of quotations causes difficulties.";
            string myStr2 = "The \"use\" of quotations causes difficulties.";
            Console.WriteLine(myStr1);
            Console.WriteLine(myStr2);
        }


        // Example  Console.WriteLine()
        static void Ch02Exercise10()
        {
            Console.WriteLine("  O   O");
            Console.WriteLine(" O O O O");
            Console.WriteLine("  O O O");
            Console.WriteLine("   O O");
            Console.WriteLine("    O");
        }


        // Example  Console.WriteLine()
        static void Ch02Exercise11()
        {
            char symbol = '\u00A9'; // copyright sign
            string txt = "";
            txt = txt + "    X\n";
            txt = txt + "   X X\n";
            txt = txt + "  X   X\n";
            txt = txt + " X     X\n";
            txt = txt + "XXXXXXXXX\n";

            txt = txt.Replace('X', symbol);

            Console.WriteLine(txt);
        }


        // Example  data types
        static void Ch02Exercise12()
        {
            /*
            string firstName;
            string lastName;
            byte? age;
            bool isMale;
            int id;
            */
        }


        // Example  swaps
        static void Ch02Exercise13()
        {
            int i1 = 5;
            int i2 = 10;

            // swap
            int temp;
            temp = i1;
            i1 = i2;
            i2 = temp;

            Console.WriteLine("{0}, {1}", i1, i2);

            // swap again
            i1 = i1 + i2;
            i2 = i1 - i2;
            i1 = i1 - i2;

            Console.WriteLine("{0}, {1}", i1, i2);

            // swap again
            Misc.Swap(ref i1, ref i2);
            Console.WriteLine("{0}, {1}  ints", i1, i2);

            // swap objects
            object obj1 = i1;
            object obj2 = i2;
            Misc.Swap(ref obj1, ref obj2);
            Console.WriteLine("{0}, {1}  objects", obj1, obj2);

            // swap strings
            string str1 = obj1.ToString();
            string str2 = obj2.ToString();
            Misc.Swap(ref str1, ref str2);
            Console.WriteLine("{0}, {1}  strings", str1, str2);

            // swap chars
            char c1 = Convert.ToChar(str1.Substring(0, 1));
            char c2 = Convert.ToChar(str2.Substring(0, 1));
            Misc.Swap(ref c1, ref c2);
            Console.WriteLine("{0}, {1}  chars", c1, c2);
        }


        #endregion Chapter 02 - Primitive Types and Variables




        #region Chapter 03 - Operators and Expressions


        static void Ch03Exercise01()
        {
            double x = 14;
            bool isEven = ((int)(x % 2) == 0);
            Console.WriteLine(isEven);
        }


        // Is a number multiples of 5 and 7?
        static void Ch03Exercise02()
        {
            double x = 35;
            bool isOK = ((int)(x % 5) == 0 && (int)(x % 7) == 0);
            Console.WriteLine(isOK);
        }


        // Is the third digit from the right == 7?
        static void Ch03Exercise03()
        {
            long x = -1723;
            Console.WriteLine(x.GetDigit(2) == 7);

            x = x / 100;
            x = x % 10;
            Console.WriteLine(Math.Abs(x) == 7);
        }


        // Check third bit from right to left
        static void Ch03Exercise04()
        {
            byte a = 7;
            Console.WriteLine((a & 4) == 0 ? 0 : 1);
            Console.WriteLine(((long)a).GetBit(2));
        }


        // Area of a trapezoid
        static void CH03Exercise05()
        {
            double a = 5;
            double b = 4;
            double h = 3;

            Console.WriteLine((a + b) / 2 * h);
        }


        // Get rectangle height and width and calculate the perimeter & area
        static void Ch03Exercise06()
        {
            double theLength;
            double theWidth;
            do
            {
                Console.Write("Enter length: ");
            } while (!double.TryParse(Console.ReadLine(), out theLength));

            do
            {
                Console.Write("Enter width: ");
            } while (!double.TryParse(Console.ReadLine(), out theWidth));

            Console.WriteLine(
                "The perimeter is: {0:0.00}  The area is {1:0.00}",
                2 * (theLength + theWidth), theLength * theWidth);
        }


        // Calculate weight on the Moon
        static void Ch03Exercise07()
        {
            double WeightOnEarth;
            do
            {
                Console.Write("Input your weight on Earth: ");
            } while (!double.TryParse(Console.ReadLine(), out WeightOnEarth));

            Console.WriteLine("Your weight on the Moon is {0:0.00}",
                WeightOnEarth * 0.17);
        }


        // Check if a point is within a circle
        static void Ch03Exercise08()
        {
            Console.Write("Input the Center of the Circle's X: ");
            double cX = double.Parse(Console.ReadLine());
            Console.Write("Input the Center of the Circle's Y: ");
            double cY = double.Parse(Console.ReadLine());
            Console.Write("Input the Radius of the Circle R: ");
            double cR = double.Parse(Console.ReadLine());
            Console.Write("Input the Point's X: ");
            double pX = double.Parse(Console.ReadLine());
            Console.Write("Input the Point's Y: ");
            double pY = double.Parse(Console.ReadLine());

            double distanceToCenter;

            //distanceToCenter =
            //    Math.Sqrt(
            //        Math.Pow((pX - cX), 2) +
            //        Math.Pow((pY - cY), 2));

            distanceToCenter = Maths.PtToPt(pX, pY, cX, cY);

            Console.Write("The point is ");
            if (distanceToCenter < cR)
            {
                Console.Write("inside");
            }
            if (Math.Abs(distanceToCenter - cR) < double.Epsilon)
            {
                Console.Write("on");
            }
            if (distanceToCenter > cR)
            {
                Console.Write("out of");
            }
            Console.WriteLine(" the circle.");
        }


        // Raising to power
        static void ExamplePower()
        {
            int value = 2;
            for (int power = 0; power <= 32; power++)
                Console.WriteLine("{0}^{1} = {2:N0} (0x{2:X})",
                                  value, power, (long)Math.Pow(value, power));
            // Output:
            // 2^0 = 1 (0x1)
            // 2^1 = 2 (0x2)
            // 2^2 = 4 (0x4)
            // 2^3 = 8 (0x8)
            // 2^4 = 16 (0x10)
            // 2^5 = 32 (0x20)
            // 2^6 = 64 (0x40)
            // 2^7 = 128 (0x80)
            // 2^8 = 256 (0x100)
            // 2^9 = 512 (0x200)
            // 2^10 = 1,024 (0x400)
            // 2^11 = 2,048 (0x800)
            // 2^12 = 4,096 (0x1000)
            // ...

            // Checking if a point is inside a circle and outside of a rectangle
        }

        // Напишете програма, която проверява дали дадена точка О (x, y)
        // е вътре в окръжността К ((0,0), 5) и едновременно с това извън
        // правоъгълника ((-1, 1), (5, 5).
        // Пояснение: правоъгълникът е зададен чрез координатите на
        // горния си ляв и долния си десен ъгъл.
        static void Ch03Exercise09()
        {
            double cX = 0;
            double cY = 0;
            double cR = 5;

            double r1X = -1;
            double r1Y = 1;
            double r2X = 5;
            double r2Y = 5;

            double pX = -4;
            double pY = 0;

            //bool isInCircle =
            //    (Math.Sqrt(
            //        Math.Pow((pX - cX), 2) +
            //        Math.Pow((pY - cY), 2))
            //    < cR);

            bool isInCircle = (Maths.PtToPt(pX, pY, cX, cY) < cR);
            bool isInRect = (r1X <= pX && pX <= r2X && r1Y <= pY && pY <= r2Y);

            Console.WriteLine(isInCircle && (!isInRect));
        }


        // Digit swaps in a 4-digit number (string)
        static void Ch03Exercise10()
        {
            string abcd;
            char a, b, c, d;
            do
            {
                do
                {
                    Console.Write("Enter number in format 'ABCD' : ");
                    abcd = Console.ReadLine();
                } while (abcd.Length != 4);

                a = abcd[0];
                b = abcd[1];
                c = abcd[2];
                d = abcd[3];

            } while (!(Char.IsDigit(a) && Char.IsDigit(b) &&
                     Char.IsDigit(c) && Char.IsDigit(d)));


            Console.WriteLine("a+b+c+d = " +
                (a + b + c + d - '0' - '0' - '0' - '0'));
            Console.WriteLine("a+b+c+d = " +
                (a.ToInt() + b.ToInt() + c.ToInt() + d.ToInt()));

            Console.WriteLine("DCBA = " + d + c + b + a);
            Console.WriteLine("DABC = " + d + a + b + c);
            Console.WriteLine("ACBD = " + a + c + b + d);

            //short a = Convert.ToInt16(abcd.Substring(0, 1));
            //short b = Convert.ToInt16(abcd.Substring(1, 1));
            //short c = Convert.ToInt16(abcd.Substring(2, 1));
            //short d = Convert.ToInt16(abcd.Substring(3, 1));
            //Console.WriteLine("a+b+c+d = " + (a + b + c + d));

            Console.WriteLine();
            Console.WriteLine("1234".Left(2));
            Console.WriteLine("1234".Right(1));
            Console.WriteLine("1".Right(2));
            Console.WriteLine("1".Left(2));
        }


        // Get the bit from position p (0-based r to l) in a number n
        static int Ch03Exercise11(long n, byte p)
        {

            //byte n = 35;
            //byte p = 5;

            //int result = (n >> p) % 2;

            int result = n.GetBit(p);

            //Console.WriteLine(result);

            return result;

        }


        // Check if the bit at position p from a number v is 1
        static bool Ch03Exercise12(byte v, byte p)
        {
            //byte v = 5;
            //byte p = 1;

            bool result;
            result = ((v >> p) % 2) == 1;
            result = ((long)v).GetBit(p) == 1;

            //Console.WriteLine(result);

            return result;
        }


        // Set the bit at position p to 0 or 1
        static long Ch03Exercise13(long n, byte p, byte v)
        {
            //int n = 35;
            //byte p = 2;
            //byte v = 1;

            //int result = v == 1 ? n | (1 << p) : n & ~(1 << p);

            long result = n.SetBit(p, v);

            //Console.WriteLine(result);

            return result;
        }


        // Check if a number (1 to 100) is a prime number
        static void Ch03Exercise14()
        {
            while (true)
            {
                int n = new int().ReadInt("Enter int [1-100]: ", 1, 100);
                Console.WriteLine("Prime: " + n.isPrimeNumber());
            }
        }


        // Swapping bits 3, 4 and 5 with 24, 25,and 26
        static void Ch03Exercise15()
        {
            long n = 0xCCCCCCC;
            Console.WriteLine("{0:X} = {1}", n, Convert.ToString(n, 2));
            n = n.SwapBits(3, 24);
            n = n.SwapBits(4, 25);
            n = n.SwapBits(5, 26);
            Console.WriteLine("{0:X} = {1}", n, Convert.ToString(n, 2));
        }


        // Swapping bits {p,p+1,...,p+k-1} with {q,q+1,...,q+k-1}
        static void Ch03Exercise16()
        {
            long n = 0xCCCCCCC;
            byte k = 4;
            byte p = 2;
            byte q = 7;

            Console.WriteLine("{0:X} = {1}", n, Convert.ToString(n, 2));

            for (byte i = 0; i < k; i++)
            {
                Console.WriteLine("{0} {1}", p + i, q + i);
                n = n.SwapBits((byte)(p + i), (byte)(q + i));
                Console.WriteLine("{0:X} = {1}", n, Convert.ToString(n, 2));
            }
        }


        #endregion Chapter 03 - Operators and Expressions




        #region Chapter 04 - Console Input and Output


        static void Ch04Example01StandardNumericFormats()
        {
            Console.WriteLine("{0:C2}", 123.456);
            //Output: 123,46 лв.
            Console.WriteLine("{0:D6}", -1234);
            //Output: -001234
            Console.WriteLine("{0:E2}", 123);
            //Output: 1,23Е+002
            Console.WriteLine("{0:F2}", -123.456);
            //Output: -123,46
            Console.WriteLine("{0:N2}", 1234567.8);
            //Output: 1 234 567,80
            Console.WriteLine("{0:P}", 0.456);
            //Output: 45,60 %
            Console.WriteLine("{0:X}", 254);
            //Output: FE
            //
            Console.WriteLine("{0:0.00}", 1);
            //Output: 1,00
            Console.WriteLine("{0:#.##}", 0.234);
            //Output: ,23
            Console.WriteLine("{0:#####}", 12345.67);
            //Output: 12346
            Console.WriteLine("{0:(0#) ### ## ##}", 29342525);
            //Output: (02) 934 25 25
            Console.WriteLine("{0:%##}", 0.234);
            //Output: %23
            //
            // Dates
            var d = new DateTime(2009, 10, 23, 15, 30, 22);
            Console.WriteLine("{0:dd/MM/yyyy HH:mm:ss}", d);
            Console.WriteLine("{0:d.MM.yy г.}", d);
            //
            // Enums
            Console.WriteLine("{0:G}", DayOfWeek.Wednesday);
            Console.WriteLine("{0:D}", DayOfWeek.Wednesday);
            Console.WriteLine("{0:X}", DayOfWeek.Wednesday);
            //Wednesday
            //3
            //00000003
            //
            // Localization = CultureInfo
            System.Threading.Thread.CurrentThread.CurrentCulture =
            System.Globalization.CultureInfo.GetCultureInfo("en-US");
            Console.WriteLine("{0:N}", 1234.56);
            Console.WriteLine("{0:D}", d);

            Console.WriteLine();
            Console.OutputEncoding = Encoding.UTF8;
            Misc.SetCulture("bg-BG");
            Console.WriteLine("Александър Димитров");
            Console.WriteLine("{0:N}", 1234.56);
            Console.WriteLine("{0:D}", d);
        }


        // Console.Read
        static void Ch04Example02ConsoleRead()
        {
            int codeRead = 0;
            do
            {
                codeRead = Console.Read();
                if (codeRead != 0)
                {
                    Console.Write((char)codeRead);
                }
            }
            while (codeRead != 10);
        }


        // Reading Numbers
        static void CH04Example03ReadingNumbers()
        {
            // this method may cause System.FormatException
            Console.Write("a = ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("b = ");
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine("{0} + {1} = {2}", a, b, a + b);
            Console.WriteLine("{0} * {1} = {2}", a, b, a * b);

            Console.Write("f = ");
            double f = double.Parse(Console.ReadLine());

            Console.WriteLine("{0} * {1} / {2} = {3}",
            a, b, f, a * b / f);

            // TryParse returns true if successful
            string str = Console.ReadLine();
            int intValue;
            bool parseSuccess = Int32.TryParse(str, out intValue);
            Console.WriteLine(parseSuccess ?
            "The square of the number is " + intValue * intValue + "."
            : "Invalid number!");

            // ReadKey
            ConsoleKeyInfo key = Console.ReadKey();
            // ReadKey(true) hides the pressed key
            Console.WriteLine();
            Console.WriteLine("Character entered: " + key.KeyChar);
            Console.WriteLine("Special keys: " + key.Modifiers);
            Console.WriteLine("Alt is {0}pressed.",
                key.isAltPressed() ? "" : "not ");
            //Character entered: A
            //Special keys: Shift
        }


        static void Ch04Example04LetterTemplate()
        {
            Console.Write("Enter person name: ");
            string person = Console.ReadLine();
            Console.Write("Enter book name: ");
            string book = Console.ReadLine();
            string from = "Authors Team";

            Console.WriteLine(" Dear {0},", person);
            Console.Write("We are pleased to inform " +
            "you that \"{1}\" is the best Bulgarian book. {2}" +
            "The authors of the book wish you good luck {0}!{2}",
            person, book, Environment.NewLine);
            Console.WriteLine(" Yours,");
            Console.WriteLine(" {0}", from);
        }


        // Summing integers
        static void Ch04Exercise01()
        {
            int a;
            int b;
            int c;
            bool isInt;

            do
            {
                Console.Write("a = ");
                isInt = int.TryParse(Console.ReadLine(), out a);
            } while (!isInt);

            do
            {
                Console.Write("b = ");
                isInt = int.TryParse(Console.ReadLine(), out b);
            } while (!isInt);

            do
            {
                Console.Write("c = ");
                isInt = int.TryParse(Console.ReadLine(), out c);
            } while (!isInt);

            Console.WriteLine("{0} + {1} + {2} = {3}"
                               , a, b, c, a + b + c);
        }


        // Circle area and perimeter
        static void Ch04Exercise02()
        {
            double r;
            bool isDouble;

            do
            {
                Console.Write("r = ");
                isDouble = double.TryParse(Console.ReadLine(), out r);
            } while (!isDouble);

            Console.WriteLine("Perimeter = {0:0.##}  Area =  {1:0.##}"
                                    , 2 * Math.PI * r, Math.PI * r * r);
        }


        static void Ch04Exercise03()
        {
            string companyName;
            string companyAddress;
            string companyPhone;
            string companyFax;
            string managerFirstName;
            string managerLastName;
            string managerPhone;
            string stringText;

            Console.Write("Company name: ");
            companyName = Console.ReadLine();

            Console.Write("Company address: ");
            companyAddress = Console.ReadLine();

            Console.Write("Company phone: ");
            companyPhone = Console.ReadLine();

            Console.Write("Company fax: ");
            companyFax = Console.ReadLine();

            Console.Write("Manager first name: ");
            managerFirstName = Console.ReadLine();

            Console.Write("Manager last name: ");
            managerLastName = Console.ReadLine();

            Console.Write("Manager phone: ");
            managerPhone = Console.ReadLine();

            stringText =
                "Company {0} (Address: {1}  Phone: {2}  Fax: {3}){7}" +
                "is managed by {4} {5} (Phone: {6})";

            Console.WriteLine();
            Console.WriteLine(
                stringText,
                companyName,
                companyAddress,
                companyPhone,
                companyFax,
                managerFirstName,
                managerLastName,
                managerPhone,
                Environment.NewLine);
        }


        static void Ch04Exercise04()
        {
            int a = 0xFFAA;
            double b = 12.3456;
            double c = -12.3456;

            Console.WriteLine("{0,-10:X}{1,-10:F2}{2,-10:F2}", a, b, c);
        }


        // Count multiples of f between integers a and b (inclusive)
        static void Ch04Exercise05()
        {
            int a;
            int b;

            const int f = 5;

            bool isValid;

            Console.WriteLine(
                "This procedure returns the number of integers {1}" +
                "which are multiples of {0}, " +
                "between integers A and B that you input."
                , f, Environment.NewLine);

            Console.WriteLine("It loops until you enter number B < number A.");

            do
            {
                do
                {
                    Console.Write("A = ");
                    isValid = int.TryParse(Console.ReadLine(), out a);
                } while (!isValid);

                do
                {
                    Console.Write("B = ");
                    isValid = int.TryParse(Console.ReadLine(), out b);
                } while (!isValid);

                if (b < a)
                {
                    Console.WriteLine("{1} < {0}", a, b);
                    return; // exit method
                }

                int result = (b - a) / f;

                result +=
                    ((b - f * (int)Math.Floor((double)b / f)) <
                     (a - f * (int)Math.Floor((double)a / f)) ?
                        (b % f == 0 ? 0 : 1)
                        : 0);

                result += (a % f == 0 ? 1 : 0);
                result += (b % f == 0 ? ((b - a) % f == 0 ? 0 : 1) : 0);

                Console.WriteLine("{0,5} - {1,5} :  {2}", a, b, result);
                Console.WriteLine();

            } while (true); // infinite loop
        }


        // Determining Min & Max of two integers w/o using logical operators
        static void Ch04Exercise06()
        {
            int a = 1990;
            int b = 2011;

            // Using Math.Max
            Console.WriteLine("Max: {0}", Math.Max(a, b));
            Console.WriteLine("Min: {0}", Math.Min(a, b));
            Console.WriteLine();

            // Using Math.Abs
            Console.WriteLine("Max: {0}", (a + b + Math.Abs(a - b)) / 2);
            Console.WriteLine("Min: {0}", (a + b - Math.Abs(a - b)) / 2);
            Console.WriteLine();

            // Using bit operations
            Console.WriteLine("Max: {0}", a - ((a - b) & ((a - b) >> 31)));
            Console.WriteLine("Min: {0}", b + ((a - b) & ((a - b) >> 31)));
            //Console.WriteLine(Convert.ToString(a - b, 2));
            //Console.WriteLine(Convert.ToString(((a - b) >> 31), 2));
            //Console.WriteLine(Convert.ToString((a - b) & ((a - b) >> 31), 2));
        }


        // Read integers and sum them
        static void Ch04Exercise07()
        {
            int n; // number of integers to read

            do
            {
                Console.Clear();
                Console.Write("Please enter an integer > 1  :  ");
            } while (!(int.TryParse(Console.ReadLine(), out n) && n > 1));

            Console.WriteLine();
            Console.WriteLine("Now you need to enter {0} integers.", n);
            Console.WriteLine();

            long sum = 0;
            int[] ints = new int[n];

            for (int i = 0; i < n; i++)
            {
                do
                {
                    Console.Write("Please enter an integer {0}:  ", i + 1);
                } while (!(int.TryParse(Console.ReadLine(), out ints[i])));

                sum += ints[i];
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write(ints[i]);
                if (i < n - 1) Console.Write(" + ");
            }
            Console.WriteLine(" = " + sum);
        }


        // Read numbers and find the biggest one
        static void Ch04Exercise08()
        {
            int n; // number of numbers to read

            do
            {
                Console.Clear();
                Console.Write("Please enter an integer > 1  :  ");
            } while (!(int.TryParse(Console.ReadLine(), out n) && n > 1));

            Console.WriteLine();
            Console.WriteLine("Now you need to enter {0} 'double's.", n);
            Console.WriteLine();

            double biggest = double.MinValue;
            double[] doubles = new double[n];

            for (int i = 0; i < n; i++)
            {
                do
                {
                    Console.Write("Please enter 'double' {0}:  ", i + 1);
                } while
                (!(double.TryParse(Console.ReadLine(), out doubles[i])));

                if (doubles[i] > biggest) biggest = doubles[i];

                // Optionally, keep the numbers being entered
                // in ascending order
                bool keepAscending = true;
                if (keepAscending)
                {
                    {
                        int j = i;
                        while (j > 0 && doubles[j] < doubles[j - 1])
                        {
                            Misc.Swap(ref doubles[j], ref doubles[j - 1]);
                            j--;
                        }
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("The biggest 'double' in the below list...");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(doubles[i].ToString());
            }
            Console.WriteLine("... is ...");
            Console.WriteLine(biggest + " !!!");
        }


        // Solve A*x^2 + B*x + C = 0
        static void Ch04Exercise09()
        {
            double a, b, c, d, x1, x2;

            do
            {
                Console.Clear();
                Console.Write("Please enter 'double' A:  ");
            } while
            (!(double.TryParse(Console.ReadLine(), out a)));

            do
            {
                Console.Clear();
                Console.Write("Please enter 'double' B:  ");
            } while
            (!(double.TryParse(Console.ReadLine(), out b)));

            do
            {
                Console.Clear();
                Console.Write("Please enter 'double' C:  ");
            } while
            (!(double.TryParse(Console.ReadLine(), out c)));

            Console.Clear();
            Console.WriteLine("{0} * x^2  +  {1} * x  +  {2}  =  0",
                a, b, c);
            Console.WriteLine();

            // Solving the square equation.
            // D = Math.Sqrt( (b * b) - (4 * a * c) )
            // if D==0  ->  x1=x2= - b / 2 / a
            // if D>0   ->  x1 = (-b + D) / 2 / a;  x2 = (-b - D) / 2 / a;
            // if D<0   ->  x1 = NaN; x2 = NaN;

            // Solving the equation is taken to a separate method.
            Maths.SolveSquareEquation(a, b, c, out d, out x1, out x2);

            // Displaying result.
            if (double.IsNaN(x1) && double.IsNaN(x2))
            {
                Console.WriteLine("has no real solutions.");
            }
            // Comparison of floating point numbers with equality operator
#pragma warning disable RECS0018
            else if (x1 == x2)
            // Comparison of floating point numbers with equality operator
#pragma warning restore RECS0018
            {
                Console.WriteLine("has one solution: " + x1);
            }
            else
            {
                Console.WriteLine("has two solutions: {0} and {1}", x1, x2);
            }
        }


        // Read doubles and sum them
        static void Ch04Exercise10()
        {
            int n; // number of doubles to sum
            double sum = 0;

            do
            {
                Console.Clear();
                Console.Write("Please enter an integer > 1  :  ");
            } while (!(int.TryParse(Console.ReadLine(), out n) && n > 1));

            Console.WriteLine();
            Console.WriteLine("Now you need to enter {0} doubles to sum.", n);
            Console.WriteLine();

            double[] doubles = new double[n];


            //checked -
            // checked is unnecessary as adding up even the longest numbers
            // that can be entered in the Console manually (255 digits of 9),
            // even if starting with sum = double.MaxValue  is rounded,
            // so it cannot exceed double.MaxValue and does NOT throw an
            // OverflowException.
            {
                try
                {
                    for (int i = 0; i < n; i++)
                    {
                        do
                        {
                            Console.WriteLine(
                                "Please enter a number (type 'double') {0}:",
                                i + 1);
                        } while
                        (!(double.TryParse(Console.ReadLine(), out doubles[i])
                          ));
                        Console.WriteLine();

                        sum += doubles[i];
                        Console.WriteLine("Sum=" + sum);
                        Console.WriteLine("Max=" + double.MaxValue);
                        Console.WriteLine();
                    }
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine
                        ("Sorry. The sum overflowed the allowable range\n" +
                        "{0} - {1}\n\n" +
                        "Entering the numbers in a different order " +
                        "might solve the problem.",
                        double.MinValue, double.MaxValue);
                    throw ex;
                }
            }


            for (int i = 0; i < n; i++)
            {
                Console.Write(doubles[i]);
                if (i < n - 1) Console.Write(" + ");
            }
            Console.WriteLine(" = " + sum);
        }


        // Read an integer and print the numbers 1..n each on a new line
        static void Ch04Exercise11()
        {
            int n;

            do
            {
                Console.Clear();
                Console.Write("Please enter an integer > 1  :  ");
            } while (!(int.TryParse(Console.ReadLine(), out n) && n > 1));

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(i);
            }
        }


        // Print the first n Fibonacci's numbers
        static void Ch04Exercise12()
        {
            int n = 100;

            // requires reference to System.Numerics.dll
            BigInteger x, x1 = 0, x2 = 0;
            BigInteger x3 = 0; // needed only for Alex's numbers

            bool fibonacci = true;
            if (fibonacci) // Fibonacci's numbers: 0,1,{n=(n-1)+(n-2)}
            {
                for (int i = 1; i <= n; i++)
                {
                    if (i == 2) { x = 1; x1 = 1; x2 = 0; }
                    else
                    {
                        x = x1 + x2;
                        x2 = x1;
                        x1 = x;
                    }

                    bool example = false;
                    if (example)
                    {
                        Console.Write(x);
                        if (i < n) Console.Write(", ");
                    }
                    else
                    {
                        Console.WriteLine("{0,3} : {1,21}", i, x);
                        if (i % 10 == 0) Console.WriteLine();
                    }
                }
            }
            else // why not Alex's numbers: 0,1,2,{n=(n-1)+(n-2)+(n-3)}   ;)
            {
                for (int i = 1; i <= n; i++)
                {
                    switch (i)
                    {
                        case 1: x = 0; break;
                        case 2: x = 1; break;
                        case 3: x = 2; x1 = 2; x2 = 1; x3 = 0; break;
                        default:
                            x = x1 + x2 + x3;
                            x3 = x2;
                            x2 = x1;
                            x1 = x;
                            break;
                    }

                    bool example = false;
                    if (example)
                    {
                        Console.Write(x);
                        if (i < n) Console.Write(", ");
                    }
                    else
                    {
                        Console.WriteLine("{0,3} : {1,26}", i, x);
                        if (i % 10 == 0) Console.WriteLine();
                    }
                }
            } // Fibonacci / Alex

            Console.WriteLine();
        }


        // Compute 1+ 1/2 + 1/3 + 1/4 + 1/5 + ... with accuracy 0.001
        static void Ch04Exercise13()
        {
            double accuracy = 0.001;
            double x = 1, y = 0;
            int i = 1;

            while ((x - y) > accuracy)
            {
                Console.WriteLine(
                    "i={0,5}:  " + "x={1,17:0.000000000000000}", i, x);
                i++;
                y = x;
                x += (1 / (double)i);
            }
            Console.WriteLine("{0:0.000}", x);
        }


        #endregion Chapter 04 - Console Input and Output




        #region Chapter 05 - Conditional Constructions


        static void Ch05Example01()
        {
            string str = "beer";
            string anotherStr = str;
            string thirdStr = "be" + 'e' + 'r';
            Console.WriteLine("string = {0}", str);
            Console.WriteLine("anotherStr = {0}", anotherStr);
            Console.WriteLine("thirdStr = {0}", thirdStr);
            Console.WriteLine(str == anotherStr); // True - same object
            Console.WriteLine(str == thirdStr); // True - equal objects
            Console.WriteLine((object)str == (object)anotherStr); // True
            Console.WriteLine((object)str == (object)thirdStr); // False
        }


        // Swap ints if first is bigger than second
        static void Ch05Exercise01()
        {
            int x = 1, y = 0;
            if (x > y) Misc.Swap(ref x, ref y);
            Console.WriteLine(x + "\t" + y);
        }



        // Find sign of multiplication of three real numbers,
        // without actually computing it.
        [System.Diagnostics.CodeAnalysis.
        SuppressMessage("Potential Code Quality Issues",
        "RECS0018:Comparison of floating point numbers with equality operator",
        Justification = "<Pending>")]
        static void Ch05Exercise02()
        {
            double a, b, c;

            do
            {
                Console.Clear();
                Console.Write("Please enter 'double' A:  ");
            } while
            (!(double.TryParse(Console.ReadLine(), out a)));

            do
            {
                Console.Clear();
                Console.Write("Please enter 'double' B:  ");
            } while
            (!(double.TryParse(Console.ReadLine(), out b)));

            do
            {
                Console.Clear();
                Console.Write("Please enter 'double' C:  ");
            } while
            (!(double.TryParse(Console.ReadLine(), out c)));


            if (a == 0 || b == 0 || c == 0)
            {
                Console.WriteLine(0);
            }
            else if (a > 0)
            {
                Console.WriteLine
                    ((b > 0 && c > 0) || (b < 0 && c < 0) ? "+" : "-");
            }
            else if (a < 0)
            {
                Console.WriteLine
                    ((b > 0 && c > 0) || (b < 0 && c < 0) ? "-" : "+");
            }
        }


        // Find the biggest of three numbers
        static double Ch05Exercise03()
        {
            double a = 0, b = 0, c = 0;

            if (a > b)
            {
                if (a > c)
                {
                    return a;
                }
                return c;
            }
            if (b > c)
            {
                return b;
            }
            return c;
        }


        // Sort three real numbers in descending order.
        static void Ch05Exercise04()
        {
            double a = 3, b = 1, c = 4;

            if (a > b)
            {
                if (a > c)
                {
                    if (b > c)
                    {
                        Console.WriteLine("{0} >= {1} >= {2}", a, b, c);
                    }
                    else
                    {
                        Console.WriteLine("{0} >= {1} >= {2}", a, c, b);
                    }
                }
                else
                {
                    Console.WriteLine("{0} >= {1} >= {2}", c, a, b);
                }
            }
            else // b > a
            {
                if (b > c)
                {
                    if (a > c)
                    {
                        Console.WriteLine("{0} >= {1} >= {2}", b, a, c);
                    }
                    else
                    {
                        Console.WriteLine("{0} >= {1} >= {2}", b, c, a);
                    }
                }
                else
                {
                    Console.WriteLine("{0} >= {1} >= {2}", c, b, a);
                }
            }
        }


        // Spell out a digit in Bulgarian
        //private static void Main()
        //{
        //    Console.OutputEncoding = Encoding.UTF8;
        //    Console.WriteLine(Ch05Exercise05(3));
        //}
        static string DigitInBG(int n) // Ch05Exercise05
        {
            string bg = "";
            switch (n)
            {
                case 0: bg = "нула"; break;
                case 1: bg = "едно"; break;
                case 2: bg = "две"; break;
                case 3: bg = "три"; break;
                case 4: bg = "четири"; break;
                case 5: bg = "пет"; break;
                case 6: bg = "шест"; break;
                case 7: bg = "седем"; break;
                case 8: bg = "осем"; break;
                case 9: bg = "девет"; break;
            }
            return bg;
        }

        // Solve A*x^2 + B*x + C = 0
        static void Ch05Exercise06()
        {
            Ch04Exercise09(); // duplicated task
        }


        // Find the biggest of five numbers
        static void Ch05Exercise07()
        {
            Ch04Exercise08(); // very similar task
        }


        // Read int, double or string and perform some actions
        static void Ch05Exercise08()
        {
            int option = 0;
            string s;
            int i = 0;
            double d = 0;

            Console.Write("Enter int or double or string: ");
            s = Console.ReadLine();

            if (int.TryParse(s, out i)) option = 1;
            else if (double.TryParse(s, out d)) option = 2;

            switch (option)
            {
                case 0: // string
                    s += "*";
                    Console.WriteLine("string: " + s);
                    break;
                case 1: // int
                    i++;
                    Console.WriteLine("int: " + i);
                    break;
                case 2: // double
                    d++;
                    Console.WriteLine("double: " + d);
                    break;
            }
        }


        // Find all subsets of 5 ints, which have a sum of zero
        // I am implementing this for the more general case -
        // array with (n) number of ints
        static void TestCh05Exercise09()
        {
            int[] ints;

            ints = new int[] { 3, -2, 1, 1, 8 };
            Ch05Exercise09(ints, aSum: 0);
            ints = new int[] { 3, 1, -7, 35, 22 };
            Ch05Exercise09(ints, aSum: 0);
        }
        static void Ch05Exercise09(int[] ints, int aSum)
        {
            int n = ints.Length;

            ints.PrintArrayToConsole("Array: ");
            Console.WriteLine();

            int countSolutions = ints.IterateSubSets(aSum: aSum);

            Console.WriteLine("Total number of solutions: " + countSolutions);
            Console.WriteLine("\n\n");
        }



        // Switch exercise
        static void Ch05Exercise10()
        {
            int points = 4;
            switch (points)
            {
                case 1:
                case 2:
                case 3: points *= 10; break;
                case 4:
                case 5:
                case 6: points *= 100; break;
                case 7:
                case 8:
                case 9: points *= 100; break;
                default:
                    Console.WriteLine("Error.");
                    return;
            }
            Console.WriteLine(points);
        }



        // Напишете програма, която преобразува дадено число в интервала
        // [0..999] в текст, съответстващ на българското произношение на
        // числото.
        static void TestSpellOutLongInBG()
        {
            Console.Clear();
            ConsoleWindow.Maximize();
            long input;
            do
            {
                //do
                //{
                //    Console.Clear();
                //    Console.Write(
                //        "Please enter a 'long' [0 - 999 999 999 999] : ");
                //    long.TryParse(Console.ReadLine(), out input);
                //    Console.WriteLine(input + " =");
                //} while (!(0 < input && input < 1e12));


                input = new Random().Next(0, int.MaxValue);
                try
                {
                    input *= new Random().Next(0, 500);
                }
                finally { }


                try
                {
                    Console.OutputEncoding = Encoding.UTF8;
                    Console.WriteLine(
                        $"{input:n0} = \n{input.SpellOutLongInBG(null)}");
                    Console.ReadLine();
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (true);
        }

        #endregion Chapter 05 - Conditional Constructions




        #region Chapter 06 - Loops

        // Print ints 1--N which are not multiples of both 3 and 7
        static void Ch06Exercise02()
        {
            int n;

            do
            {
                Console.Clear();
                Console.Write("Please enter an integer > 1  :  ");
            } while (!(int.TryParse(Console.ReadLine(), out n) && n > 1));

            for (int i = 1; i <= n; i++)
            {
                if (i % (3 * 7) != 0) Console.WriteLine(i);
            }
        }


        // Find biggest and smallest of doubles
        // Напишете програма, която чете от конзолата поредица от цели числа
        // и отпечатва най-малкото и най-голямото от тях.
        static void Ch06Exercise03()
        {
            int n; // number of numbers to read

            do
            {
                Console.Clear();
                Console.Write("Please enter an integer > 1  :  ");
            } while (!(int.TryParse(Console.ReadLine(), out n) && n > 1));

            Console.WriteLine();
            Console.WriteLine("Now you need to enter {0} 'double's.", n);
            Console.WriteLine();

            double biggest = double.MinValue;
            double smallest = double.MaxValue;
            double[] doubles = new double[n];

            for (int i = 0; i < n; i++)
            {
                do
                {
                    Console.Write("Please enter 'double' {0}:  ", i + 1);
                } while
                (!(double.TryParse(Console.ReadLine(), out doubles[i])));

                if (doubles[i] > biggest) biggest = doubles[i];

                if (doubles[i] < smallest) smallest = doubles[i];

                // Optionally, keep the numbers being entered
                // in ascending order
                bool keepAscending = true;
                if (keepAscending)
                {
                    {
                        int j = i;
                        while (j > 0 && doubles[j] < doubles[j - 1])
                        {
                            Misc.Swap(ref doubles[j], ref doubles[j - 1]);
                            j--;
                        }
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("The biggest 'double' in the below list...");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(doubles[i].ToString());
            }
            Console.WriteLine("... is ...");
            Console.WriteLine(biggest + " !!!");
            Console.WriteLine("And the smallest 'double' is...");
            Console.WriteLine(smallest + " !!!");
            Console.WriteLine();
        }


        // Напишете програма, която отпечатва всички възможни карти от
        // стандартно тесте карти без джокери
        // (имаме 52 карти: 4 бои по 13 карти).
        static void Ch06Exercise04()
        {
            string[] colors = { "Spades", "Diamonds", "Hearts", "Clubs" };
            //char[] colors = new char[] {
            //    '\u2660','\u2663',
            //    '\u2665','\u2666'};
            string[] cards = {
                    "2", "3", "4", "5", "6", "7", "8",
                    "9", "10", "J", "D", "K", "A" };
            foreach (var color in colors)
            {
                foreach (string card in cards)
                {
                    Console.WriteLine($"{card} of {color}");
                }
            }
            Console.ReadLine();
        }


        // Напишете програма, която чете от конзолата числото N и отпечатва
        // сумата на първите N члена от редицата на Фибоначи
        // Fibonacci's numbers: 0,1,{n=(n-1)+(n-2)}
        static void Ch06Exercise05() // see Ch04Exercise12
        {
            int n = 9;
            //n = int.Parse(Console.ReadLine());

            // requires a reference to System.Numerics.dll
            BigInteger fibonacciNr, x1 = 0, x2 = 0, sum = 0;

            for (int i = 1; i <= n; i++)
            {
                if (i == 2) { fibonacciNr = 1; x1 = 1; x2 = 0; }
                else
                {
                    fibonacciNr = x1 + x2;
                    x2 = x1;
                    x1 = fibonacciNr;
                }

                sum += fibonacciNr;
            }

            Console.WriteLine(
                $"Sum of the first {n} Fibonacci's numbers: {sum}");
        }



        // ? N! / K! for (1<K<N)
        static BigInteger Ch06Exercise06(int k, int n)
        {
            if (k >= n) return -1;

            BigInteger r = 1;
            for (int i = k + 1; i <= n; i++)
            {
                r *= i;
            }
            return r;
        }


        // ? N!*K!/(N-K)! for (1<K<N)
        static void Ch06Exercise07()
        {
            int k = 3, n = 9;
            double d = 1;
            for (int i = 1; i <= k; i++)
            {
                d *= i * (n - k + i);
            }
            Console.WriteLine($"Result = {d}");
        }


        //// Catalan's numbers: Cn = (2n)! / (n+1)! n!
        //// Напишете програма, която изчислява n-тото число
        //// на Каталан за дадено n.
        static void Ch06Exercise08()
        {
            int n = 5;
            double c = 1;
            for (int i = 2; i <= n; i++)
            {
                c *= (double)(n + i) / i;
            }
            Console.WriteLine($"Catalan's number({n}) = {c}");
        }


        // Напишете програма, която за дадено цяло число n, пресмята сумата
        // S = 1 + 1!/x + 2!/x^2  +  n!/x^n
        static void Ch06Exercise09()
        {
            double sum = 1;
            double fact = 1;
            double power = 1;

            int x = 5, n = 7;
            int i;
            for (i = 1; i <= n; i++)
            {
                fact *= i;
                power *= x;
                sum += fact / power;
            }
            Console.WriteLine("S= " + sum);
        }


        // Напишете програма, която чете от конзолата положително
        // цяло число N(N< 20) и отпечатва матрица с числа като на
        // фигурата по-долу.
        static void Ch06Exercise10()
        {
            int n = 5;
            string str = "|";
            for (int i = 1; i <= n; i++)
            {
                str += $" {i,2} |";
            }

            for (int i = 1; i <= n + 1; i++)
            {
                Console.WriteLine(str);
                str = str.Substring(5) + $" {n + i,2} |";
            }
        }


        // Напишете програма, която пресмята с колко нули
        // завършва факториелът на дадено число.
        static void Ch06Exercise11()
        {
            int n = 125;

            int i = 0;
            while (n >= 5)
            {
                i += n / 5;
                n /= 5;
            }
            Console.WriteLine(i);
        }


        // преобразуване от една бройна система в друга (2 - 16)
        static void Ch06Exercises12to15()
        {
            int b1 = 2, b2 = 16;
            int n = 1234;
            string str1 = Convert.ToString(n, b1).ToUpper();
            string str = str1.ConvertBase(b1, b2);
            Console.WriteLine($"({b1}) {str1}  = ({b2}) {str}");
        }


        //Напишете програма, която по дадено число N отпечатва числата
        // от 1 до N, разбъркани в случаен ред.
        static void Ch06Exercises16()
        {
            do
            {
                int n = 5;
                string formatStr = "";
                // with ints
                //List<int> orderedList = new List<int>(Enumerable.Range(1, n));
                //List<int> randomizedList = new List<int>();


                // with doubles
                //List<double> orderedList = new List<double>();
                //for (double i = 1; i <= n; i++)
                //{
                //    orderedList.Add(1 / (i + 1));
                //}
                //List<double> randomizedList = new List<double>();
                //formatStr = "{0:0.00}";

                // with strings
                Console.OutputEncoding = Encoding.UTF8;
                var orderedList = new List<string>();
                for (double i = 1; i <= n; i++)
                {
                    orderedList.Add(((long)i).SpellOutLongInBG(null));
                }
                formatStr = "[ {0} ]";
                IList<string> randomizedList = orderedList.RandomizeIList();

                randomizedList.PrintIListToConsole(formatString: formatStr);
                Console.ReadLine();
            } while (true);
        }


        // Напишете програма, която за дадени две числа,
        // намира най-големия им общ делител.
        static void Ch06Exercises17()
        {
            Console.WriteLine(Maths.Gcd((long)35, (byte)25));
        }


        // Напишете програма, която по дадено число n,
        // извежда матрица във формата на спирала
        static void Ch06Exercises18()
        {
            int n = 4;

            int[,] arr = new int[n, n];

            const int right = 0;
            const int down = 1;
            const int left = 2;
            const int up = 3;

            int direction = right;

            int x = 0, y = 0; // initial position
            int c = 1;        // counter

            while (arr[x, y] == 0)
            {
                arr[x, y] = c;
                c++;

                if (direction == right &&
                    (y == n - 1 || arr[x, y + 1] != 0))
                    direction = down;

                if (direction == down &&
                    (x == n - 1 || arr[x + 1, y] != 0))
                    direction = left;

                if (direction == left &&
                    (y == 0 || arr[x, y - 1] != 0))
                    direction = up;

                if (direction == up &&
                    (x == 0 || arr[x - 1, y] != 0))
                    direction = right;

                if (direction == right) y++;
                if (direction == down) x++;
                if (direction == left) y--;
                if (direction == up) x--;
            }
            arr.PrintArrayToConsole("Spiral:", "| {0,3} ", "", "|\n");
        }


        #endregion Chapter 06 - Loops




        #region Chapter 07 - Arrays


        // Two-dimensional arrays
        static void Ch07Exc01()
        {
            int[,] arr = new int[2, 3].ReadIntArrayFromConsole();
            arr.PrintArrayToConsole();

            string[,] strArr =
            {
                { "x0y0","x0y1","x0y2","x0y3"},
                { "x1y0","x1y1","x1y2","x1y3"}
            };
            strArr.PrintArrayToConsole();
        }

        // Jagged arrays.
        static void Ch07Exc02()
        {
            int n = 3;
            int[][,] arr = new int[n][,];

            for (int i = 0; i < n; i++)
            {
                int[,] matrix = new int[i + 1, 2 * i + 2].
                    ReadIntArrayFromConsole($"Matrix {i}:", $"[{i}]");
                arr[i] = matrix;
            }

            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                arr[i].PrintArrayToConsole("Matrix " + i);
            }
        }


        // Jagged arrays.
        static void Ch07Example01()
        {
            int[][] jaggedArray;
            jaggedArray = new int[2][];
            jaggedArray[0] = new int[5];
            jaggedArray[1] = new int[3];
        }


        // Да се напише програма, която създава масив с 20 елемента
        // от целочислен тип и инициализира всеки от елементите със
        // стойност равна на индекса на елемента умножен по 5.
        // Елементите на масива да се изведат на конзолата.
        static void Ch07Exercise01()
        {
            int n = 20;
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = i * 5;
            }

            arr.PrintArrayToConsole();
            Console.ReadLine();
        }


        // Да се напише програма, която чете два масива от конзолата
        // и проверява дали са еднакви.
        static void Ch07Exercise02()
        {
            int n = 2;
            int m = 3;
            int[,] arr1 = new int[n, m].ReadIntArrayFromConsole("Arr1:");
            int[,] arr2 = new int[n, m].ReadIntArrayFromConsole("Arr2:");

            bool areEqual = true;
            for (int x = 0; x < n; x++)
            {
                for (int y = 0; y < m; y++)
                {
                    if (arr1[x, y] != arr2[x, y])
                    {
                        areEqual = false;
                        break;
                    }
                }
                if (!areEqual) break;
            }
            Console.WriteLine("The arrays are {0}equal.",
                areEqual ? "" : "not ");
        }


        // Да се напише програма, която сравнява два масива от тип char
        // лексикографски (буква по буква) и проверява кой от двата е
        // по-рано в лексикографската подредба.
        static void Ch07Exercise03()
        {
            int n = 2;
            char[] arr1 = new char[n];
            char[] arr2 = new char[n];

            Console.WriteLine("Characters array 1:");
            for (int i = 0; i < n; i++)
            {
                arr1[i] = char.Parse(Console.ReadLine().Left(1));
            }

            Console.WriteLine("Characters array 2:");
            for (int i = 0; i < n; i++)
            {
                arr2[i] = char.Parse(Console.ReadLine().Left(1));
            }

            int higher = 0;
            for (int i = 0; i < n; i++)
            {
                if (arr1[i] > arr2[i]) { higher = 1; break; }
                if (arr1[i] < arr2[i]) { higher = 2; break; }
            }

            arr1.PrintArrayToConsole("Array1: ");
            arr2.PrintArrayToConsole("Array2: ");

            if (higher == 0)
            {
                Console.WriteLine("Arrays are equal.");
            }
            else
            {
                Console.WriteLine(
                    $"Array{higher} is higher.\nArray{3 - higher} is lower.");
            }
            Console.ReadLine();
        }


        // Напишете програма, която намира максимална редица
        // от последователни еднакви елементи в масив.
        static void Ch07Exercise04()
        {
            int[] arr = { 2, 1, 1, 2, 3, 3, 3, 2, 3, 4, 3, 2,
                2, 2, 1, 1, 2, 1, 1, 1, 1, 3, 2, 3, 3, 3 };

            int psn = 0, psnMax = 0;
            int count = 0, countMax = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] != arr[i - 1])
                {
                    psn = i;
                    count = 1;
                }
                else
                {
                    count++;
                    if (count > countMax)
                    {
                        psnMax = psn;
                        countMax = count;
                    }
                }
            }

            Console.WriteLine($"position: {psnMax}  count: {countMax}");
        }


        // Напишете програма, която намира максималната редица
        // от последователни нарастващи елементи в масив.
        static void Ch07Exercise05()
        {
            int[] arr = { 2, 1, 1, 2, 3, 3, 3, 2, 3, 4, 3, 2,
                2, 2, 1, 1, 2, 1, 1, 1, 1, 3, 2, 3, 3, 3 };

            int psn = 0, psnMax = 0;
            int count = 0, countMax = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] <= arr[i - 1])
                {
                    psn = i;
                    count = 1;
                }
                else
                {
                    count++;
                    if (count > countMax)
                    {
                        psnMax = psn;
                        countMax = count;
                    }
                }
            }

            Console.WriteLine($"position: {psnMax}  count: {countMax}");
        }

        //// Напишете програма, която намира максималната под-редица
        //// от нарастващи елементи в масив arr[n].
        //// Елементите може и да не са последователни.
        //// Пример: {9, 6, 2, 7, 4, 7, 6, 5, 8, 4} => {2, 4, 6, 8}.
        ////Задачата може да се реши с два вложени цикъла и допълнителен
        ////масив len[0..n-1]. Нека в стойността len[i] пазим дължината на
        ////най-дългата нарастваща под-редица, която започва някъде в масива
        ////(не е важно къде) и завършва с елемента arr[i]. Тогава len[0]=1, a
        ////len[x] е максималната сума max(1 + len[prev]), където prev < x и
        ////arr[prev] < arr[x].
        ////Следвайки дефиницията len[0..n-1] може да се пресметне с два вложени
        ////цикъла по следния начин: първият цикъл обхожда масива последователно
        ////отляво надясно с водеща променлива x. Вторият цикъл (който е вложен
        ////в първия) обхожда масива от началото до позиция x-1 и търси елемент
        ////prev с максимална стойност на len[prev],
        ////за който arr[prev] < arr[x].
        ////След приключване на търсенето len[x] се инициализира с
        ////1 + най-голямата намерена стойност на len[prev] или с 1,
        ////ако такава не е намерена.
        ////Описаният алгоритъм намира дължините на всички максимални нарастващи
        ////под-редици, завършващи във всеки негов елемент.
        ////Най-голямата от тези стойности е дължината на най-дългата нарастваща
        ////под-редица.
        ////Ако трябва да намерим самите елементи съставящи тази максимална
        ////нарастваща под-редица, можем да започнем от елемента, в който тя
        ////завършва (нека той е на индекс x), да го отпечатаме и да търсим
        ////предходния елемент (prev).
        ////За него е в сила, че prev < x и len[x] = 1+len[prev].
        ////Така намирайки и отпечатвайки предходния елемент докато има такъв,
        ////можем да намерим елементите съставящи най-дългата нарастваща
        ////под-редица в обратен ред (от последния към първия).
        static void Ch07Exercise06()
        {
            int[] arr = { 9, 6, 2, 7, 4, 7, 6, 5, 8, 4 };

            int[] len = new int[arr.Length];
            int maxLen;

            for (int x = 0; x < arr.Length; x++)
            {
                if (x > 0)
                {
                    maxLen = 0;
                    bool found = false;

                    for (int i = 0; i < x; i++)
                    {
                        if (arr[i] < arr[x] &&
                            len[i] > maxLen)
                        {
                            maxLen = len[i];
                            found = true;
                        }
                    }
                    len[x] = found ? maxLen + 1 : 1;
                }
                else { len[0] = 1; }
            }

            maxLen = len.MaxInArray();
            int maxLenIx = len.IndexMax();

            arr.PrintArrayToConsole("Arr: ");
            len.PrintArrayToConsole("Len: ");

            Console.WriteLine();
            //Console.WriteLine($"end index: {maxLenIx}  count: {maxLen}");

            int[] result = new int[maxLen];
            int[] resultIxs = new int[maxLen];
            int resultIx = maxLen - 1;
            result[resultIx] = arr[maxLenIx];
            resultIxs[resultIx] = maxLenIx;

            for (int i = maxLenIx - 1; i >= 0; i--)
            {
                if (arr[i] < arr[maxLenIx] && len[i] == len[maxLenIx] - 1)
                {
                    resultIx--;
                    maxLenIx = i;
                    result[resultIx] = arr[maxLenIx];
                    resultIxs[resultIx] = maxLenIx;
                }
            }
            result.PrintArrayToConsole("result: ", formatString: "{0,3}");
            resultIxs.PrintArrayToConsole("index:  ", formatString: "{0,3}");
        }


        // Да се напише програма, която чете от конзолата две цели
        // числа N и K (K<N), и масив от N елемента. Да се намерят
        // тези K поредни елемента, които имат максимална сума.
        static void Ch07Exercise07()
        {
            int n = 0, k = 0;
            n = n.ReadInt("Length of array N: (min=3) : ",
                min: 3, cls: true);
            k = k.ReadInt($"Integer K: (min=2, max={n - 1}) : ",
                min: 2, max: n - 1, cls: true);

            Console.WriteLine($"\nN = {n}   K = {k}");

            int[] arr = new int[n].ReadIntArrayFromConsole("\nEnter array:");

            int[] sums = new int[n - k + 1];

            // compute sum[0]
            sums[0] = arr.SumElements(0, k - 1);

            // compute sums [ 1 - n-k ] and find the biggest one
            int maxSum = int.MinValue;

            for (int i = 1; i <= n - k; i++)
            {
                sums[i] = sums[i - 1] - arr[i - 1] + arr[i + k - 1];
                if (sums[i] > maxSum) maxSum = sums[i];
            }
            Console.WriteLine($"Max sum = {maxSum}");
        }


        // Напишете програма, която сортира масив.
        // Да се използва алгоритъма "Selection sort".
        static void Ch07Exercise08()
        {
            int n = 0; n = n.ReadInt("Enter size of int array to sort: ");
            new int[n].ReadIntArrayFromConsole().SelectionSort(reverse: true).
                PrintArrayToConsole("Sorted: ");
            // added bonus - reversed!  -  also possible as per below:
            //new int[5].ReadIntArrayFromConsole().SelectionSort().
            //    ReverseArray().PrintArrayToConsole("Sorted: ");
        }

        // Напишете програма, която намира последователност от числа,
        // чиито сума е максимална.
        // Пример: {2, 3, -6, -1, 2, -1, 6, 4, -8, 8} -> 2, -1, 6, 4 = 11
        static void Ch07Exercise09()
        {
            int n = 0; n = n.ReadInt("Enter the size of int array : ");

            int[] arr = new int[n];
            // arr.ReadIntArrayFromConsole().PrintArrayToConsole("Array : ");

            while (true)
            {
                int maxSumLeft = 0, maxSumRight = 0, maxSum = int.MinValue;
                int i = 0, sum = 0, sumLeft = 0, sumRight = 0;

                // This is for testing of both calculation methods below.
                var r = new Random();
                for (i = 0; i < n; i++) arr[i] = r.Next(-99, 100);
                //i = i.ReadInt("\nEnter the index of item to change : ");
                //arr[i] = arr[i].ReadInt("Enter new value for item [" +
                //    i + "] (=" + arr[i] + ") : ");

                arr.PrintArrayToConsole("\nArray : ");
                Console.WriteLine();

                // Method 1 - check all sums
                for (i = 0; i < n; i++)
                {
                    for (int j = i; j < n; j++)
                    {
                        sum = arr.SumElements(i, j);
                        if (sum > maxSum)
                        {
                            maxSum = sum;
                            maxSumLeft = i;
                            maxSumRight = j;
                        }
                    }
                }

                arr.PrintArrayToConsole(
                    "Max sum - method 1 : " + maxSum + " = ",
                    from: maxSumLeft, to: maxSumRight, delimiter: " + ",
                    formatString: "({0,3})");

                // Method 2 - Dynamically optimized
                while (i < n - 1) // while within the array
                {
                    // Skip negative numbers.
                    while (arr[i] <= 0 && i < n - 1)
                    {
                        // This will find the result in case that
                        // all numbers are negative.
                        if (arr[i] > maxSum)
                        {
                            maxSum = arr[i]; maxSumLeft = i; maxSumRight = i;
                        }
                        i++;
                    }

                    // Reset sum.
                    sum = 0;

                    // Sum numbers while sum is above zero
                    // or until end of array;
                    // Maintain max sum in maxSum and the
                    // left and right indexes in maxSumLeft and maxSumRight.
                    while (sum >= 0 && i < n - 1)
                    {
                        sum += arr[i]; sumLeft = i; sumRight = i;
                        if (sum > maxSum)
                        {
                            maxSum = sum;
                            maxSumLeft = sumLeft;
                            maxSumRight = sumRight;
                        }
                        i++;
                    }
                }

                arr.PrintArrayToConsole(
                    "Max sum - method 2 : " + maxSum + " = ",
                    from: maxSumLeft, to: maxSumRight, delimiter: " + ",
                    formatString: "({0,3})");

                Console.ReadLine();
            }
        }


        // Напишете програма, която намира най-често срещания елемент в масив.
        // Пример: {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} -> 4 ( 5 пъти).
        static void Ch07Exercise10()
        {
            // Да сортираме масива или да заменяме числата с int.MinValue
            // означава да загубим оригиналното съдържание на масива.
            // Да го копираме в нов масив - може да отнеме доста време и RAM.
            // Да го направим с Dictionary.

            int n = 0; n = n.ReadInt("Enter the size of int array : ", 3);

            int[] arr = new int[n];
            while (true)
            {
                var r = new Random();
                for (int i = 0; i < n; i++) arr[i] = r.Next(0, 10);
                arr.PrintArrayToConsole("\nArray: ");

                var d = new Dictionary<int, int>();

                foreach (int number in arr)
                {
                    if (d.ContainsKey(number)) d[number] += 1;
                    else d.Add(number, 1);
                }

                Console.WriteLine();
                d.PrintToConsole("Key: {0}   Times: {1}");

                int times = d.Values.Max();
                int key = d.FirstOrDefault(x => x.Value == times).Key;
                Console.Write("\nMost frequent number(s) ({0} times): ", times);

                var list = new List<int>();

                foreach (var dkey in d.Keys)
                    if (d[dkey] == times) list.Add(dkey);

                list.Sort();
                list.PrintIListToConsole("");

                Console.ReadLine();
            }
        }


        // Да се напише програма, която намира последователност от числа в
        // масив, които имат сума равна на число, въведено от конзолата(ако
        // има такава). Пример: {4, 3, 1, 4, 2, 5, 8}, S=11 -> {4, 2, 5}.
        static void Ch07Exercise11()
        {
            int n = new int().ReadInt("Enter size of array: ", 3);
            int[] arr = new int[n].ReadIntArrayFromConsole().
                PrintArrayToConsole();

            while (true)
            {
                int s = new int().ReadInt("\nEnter desired sum: ");
                int i = 0, j = 0, sum = 0;

                for (i = 0; i < n; i++)
                {
                    sum = 0;
                    for (j = i; j < n; j++)
                    {
                        sum += arr[j];
                        if (sum == s) break;
                    }
                    if (sum == s) break;
                }
                if (sum == s)
                    arr.PrintArrayToConsole("Solution: ", formatString: "[{0}]",
                    delimiter: " + ", from: i, to: j, suffixLine: " = " + s);
                else Console.WriteLine("No solution.");

                Console.ReadLine();
            }
        }


        // Напишете програма, която създава следните квадратни матрици и ги
        // извежда на конзолата във форматиран вид.Размерът на матриците се
        // въвежда от конзолата.
        static void Ch07Exercise12()
        {
            int n = new int().ReadInt("Enter size of matrices : ", min: 3);

            int[,] arr = new int[n, n];

            const int right = 0;
            const int down = 1;
            const int left = 2;
            const int up = 3;

            int direction;
            int x, y; // initial position
            int c;    // counter

            // a) Vertical, top to bottom
            c = 1;        // counter
            for (y = 0; y < n; y++)
            {
                for (x = 0; x < n; x++)
                {
                    arr[x, y] = c++;
                }
            }
            arr.PrintArrayToConsole(
                prefixLine: "\na) Vertical, top to bottom:\n",
                formatString: "| {0,3} ",
                delimiter1: "",
                delimiter2: "|\n");


            // b) Vertical, top to bottom and bottom to top
            c = 1;        // counter
            for (y = 0; y < n; y++)
            {
                for (x = 0; x < n; x++)
                {
                    arr[(y % 2 == 0 ? x : n - 1 - x), y] = c++;
                }
            }
            arr.PrintArrayToConsole(
                prefixLine: "\nb) Vertical, top to bottom and bottom to top:\n",
                formatString: "| {0,3} ",
                delimiter1: "",
                delimiter2: "|\n");


            // c) Diagonal, top-left to bottom-right,
            //    starting from bottom-left corner.
            x = n - 1; y = 0; // initial position
            c = 1;          // counter


            while (c <= n * n)
            {
                arr[x, y] = c;
                if (y == n - 1)
                {
                    if (x == n - 1) { x = 0; y = 1; }
                    else { y = n - x; x = 0; }
                }
                else if (x == n - 1) { x = n - y - 2; y = 0; }
                else { x++; y++; }
                c++;
            }

            arr.PrintArrayToConsole(
                prefixLine: "\nc) Diagonal, top-left to bottom-right,\n" +
                "   starting from bottom-left corner:\n",
                formatString: "| {0,3} ",
                delimiter1: "",
                delimiter2: "|\n");


            // d) - Spiral
            x = 0; y = 0; // initial position
            c = 1;        // counter
            direction = right;
            arr = new int[n, n];
            while (arr[x, y] == 0)
            {
                arr[x, y] = c;
                c++;

                if (direction == right &&
                    (y == n - 1 || arr[x, y + 1] != 0))
                    direction = down;

                if (direction == down &&
                    (x == n - 1 || arr[x + 1, y] != 0))
                    direction = left;

                if (direction == left &&
                    (y == 0 || arr[x, y - 1] != 0))
                    direction = up;

                if (direction == up &&
                    (x == 0 || arr[x - 1, y] != 0))
                    direction = right;

                if (direction == right) y++;
                if (direction == down) x++;
                if (direction == left) y--;
                if (direction == up) x--;
            }
            arr.PrintArrayToConsole(
                prefixLine: "\nd) Spiral:\n",
                formatString: "| {0,3} ",
                delimiter1: "",
                delimiter2: "|\n",
                horizontalX: false);
        }

        //// Да се напише програма, която създава правоъгълна матрица с размер
        //// n на m. Размерността и елементите на матрицата да се четат от
        //// конзолата. Да се намери под-матрицата с размер (3,3), която има
        //// максимална сума.
        static void Ch07Exercise13()
        {
            int n = new int().ReadInt("Enter N: ", min: 3);
            int m = new int().ReadInt("Enter M: ", min: 3);

            int[,] a = new int[n, m];

            a.FillRandoms();              // Comment out
            a.ReadIntArrayFromConsole();  // one of these lines.

            a.PrintArrayToConsole(formatString: "{0,2}");

            int maxSum = int.MinValue, maxSumI = 0, maxSumJ = 0, sum = 0;
            for (int i = 0; i <= n - 3; i++)
            {
                for (int j = 0; j <= m - 3; j++)
                {
                    sum =
                        a[i + 0, j + 0] + a[i + 0, j + 1] + a[i + 0, j + 2] +
                        a[i + 1, j + 0] + a[i + 1, j + 1] + a[i + 1, j + 2] +
                        a[i + 2, j + 0] + a[i + 2, j + 1] + a[i + 2, j + 2];

                    if (sum > maxSum)
                    { maxSum = sum; maxSumI = i; maxSumJ = j; }
                }
            }
            Console.WriteLine($"\nI = {maxSumI}  J = {maxSumJ} Sum = {maxSum}");
            a.PrintArrayToConsole(formatString: "{0,2}",
                fromX: maxSumI, toX: maxSumI + 2,
                fromY: maxSumJ, toY: maxSumJ + 2);
        }

        // TODO: Да се напише програма, която намира най-дългата последователност
        // от еднакви string елементи в матрица. Последователност в матрица
        // дефинираме като елементите са на съседни и са на същия ред, колона
        // или диагонал.
        static void Ch07Exercise14()//Main()
        {
            int n = new int().ReadInt("Enter N: ", min: 3);
            int m = new int().ReadInt("Enter M: ", min: 3);

            string[,] a = new string[n, m];

            // Enter data.
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"Enter a[{i},{j}]: ");
                    a[i, j] = Console.ReadLine();
                }
            }

            // Print data.
            a.PrintArrayToConsole();

            int maxLen = 0;

            // Solve.
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int len = CheckCell(a, i, j);
                    if (len > maxLen) maxLen = len;
                }
            }
            Console.WriteLine($"Max length = {maxLen}");
        }
        static int CheckCell(string[,] a, int i, int j)
        {
            int len = 0;

            int n = a.GetLength(0);
            int m = a.GetLength(1);

            int[,] b = new int[n, m];

            string s = a[i, j];

            return len;
        }


        // Да се напише програма, която създава масив с всички букви от
        // латинската азбука. Да се даде възможност на потребител да въвежда
        // дума от конзолата и в резултат да се извеждат индексите на буквите
        // от думата.
        static void Ch07Exercise15()
        {
            char[] a = new char[26];
            int i;
            for (i = 0; i < 26; i++)
            {
                a[i] = (char)('a' + i);
            }

            Console.Write("Enter a word: ");
            string s = Console.ReadLine();

            foreach (char ch in s.ToArray())
            {
                Console.WriteLine("{0} = {1}", ch, a.GetIndex(ch));
            }
            for (i = 0; i < 26; i++)
            {
                Console.Write(a[i]);
            }
            Console.ReadLine();
        }

        // Да се реализира двоично търсене (binary search)
        // в сортиран целочислен масив.
        static void Ch07Exercise16()
        {
            while (true)
            {
                int n = 10;
                int[] arr = new int[n].FillRandoms(0, 20).
                    MergeSortRecursive().PrintArrayToConsole();
                //Console.WriteLine(arr.BinarySearchRecursive(5));
                Console.WriteLine(arr.BinarySearchIterative(5));

                Console.ReadLine();
            }
        }

        // Напишете програма, която сортира целочислен масив по алгоритъма
        // "merge sort".
        static void Ch07Exercise17()//TestMergeSortAlgorithms()
        {
            //new int[] { 3, 8, 7, 5, 2, 1, 9, 6, 4 }.MergeSortRecursive().
            //    PrintArrayToConsole("Sorted with MergeSortRecursive: ");
            //new int[] { 3, 8, 7, 5, 2, 1, 9, 6, 4 }.MergeSortIterative().
            //    PrintArrayToConsole("Sorted with MergeSortIterative: ");

            int[] arr1 = { 3, 8, 7, 5, 2, 1, 9, 6, 4 };
            int[] arr = { 3, 8, 7, 5, 2, 1, 9, 6, 4 };
            long t0, t1;
            while (true)
            {
                t0 = DateTime.Now.Ticks;
                for (int i = 0; i < 100000; i++)
                {
                    arr = arr1;
                    arr = arr.MergeSortRecursive();
                }
                t1 = DateTime.Now.Ticks - t0;
                arr.PrintArrayToConsole("Sorted with MergeSortRecursive: ");
                Console.WriteLine(t1 / 1e6);

                //arr = new int[] { 3, 8, 7, 5, 2, 1, 9, 6, 4 };
                t0 = DateTime.Now.Ticks;
                for (int i = 0; i < 100000; i++)
                {
                    arr = arr1;
                    arr = arr.MergeSortIterative();
                }
                t1 = DateTime.Now.Ticks - t0;
                arr.PrintArrayToConsole("Sorted with MergeSortIterative: ");
                Console.WriteLine(t1 / 1e6);

                Console.ReadLine();
            }
        }

        // Напишете програма, която сортира целочислен масив по алгоритъма
        // "quick sort".
        // Ch07Exercise18()
        static void TestQuickSortRecursive()
        {
            Console.WriteLine("\nQuickSort Recursive Method\n");
            new int[] { 3, 8, 7, 5, 2, 1, 9, 6, 4 }.
                PrintArrayToConsole("Unsorted : ").
                QuickSortRecursive().
                PrintArrayToConsole("Sorted   : ");

            Console.ReadLine();
        }
        static void TestQuickSortIterative()
        {
            Console.WriteLine("\nQuickSort Iterative Method\n");
            int[] arr = new int[] { 3, 8, 7, 5, 2, 1, 9, 6, 4 }.
                PrintArrayToConsole("Unsorted : ");
            arr.QuickSortIterative().
            PrintArrayToConsole("Sorted   : ");

            Console.ReadLine();
        }

        // Напишете програма, която намира всички прости числа в
        // диапазона [1…10 000 000].
        static void Ch07Exercise19()//
        {
            int c = 0, i0 = 0, di = 0, mdi = 0;
            for (int i = 1; i < 1e7; i++)
            {
                if (i.isPrimeNumber())
                {
                    c++;
                    di = i - i0; if (di > mdi) mdi = di;
                    Console.WriteLine($"{c,9:n0}: {i,12:n0} : {di,4} : {mdi}");
                    i0 = i;
                    //if (c % 20 == 0) Console.ReadLine();
                }
            }
        }

        // Напишете програма, която по дадени N числа и число S,
        // проверява дали може да се получи сума равна на S с използване на
        // под-масив от N-те числа (не непременно последователни).
        // Пример: {2, 1, 2, 4, 3, 5, 2, 6}, S = 14 -> yes(1 + 2 + 5 + 6 = 14)
        static void TestCh07Exercise20()
        {
            int[] ints;

            ints = new int[] { 2, 1, 2, 4, 3, 5, 2, 6 };
            Ch07Exercise20(ints, 14);
        }
        static void Ch07Exercise20(int[] ints, int aSum)
        {
            int n = ints.Length;

            ints.PrintArrayToConsole("Array: ");
            Console.WriteLine();

            int countSolutions = ints.IterateSubSets(aSum: aSum);

            Console.WriteLine("Total number of solutions: " + countSolutions);
            Console.WriteLine("\n\n");
        }


        // Напишете програма, която по дадени N, K и S,
        // намира К на брой елементи измежду N-те числа,
        // чиито сума е точно S или показва, че това е невъзможно.
        static void TestCh07Exercise21()
        {
            int n = new int().ReadInt("N: (min: 3) : ", min: 3);

            int[] arr = new int[n].FillRandoms(-5, 5).PrintArrayToConsole();

            int k = new int().ReadInt("K: (min: 2) : ", min: 2);
            int s = new int().ReadInt("S: ");

            arr.PrintArrayToConsole("Array: ");
            Console.WriteLine();

            int countSolutions = arr.IterateSubSets(nSubset: k, aSum: s);

            Console.WriteLine("Total number of solutions: " + countSolutions);
            Console.WriteLine("\n\n");
        }


        // Напишете програма, която прочита от конзолата масив от цели числа
        // и премахва минимален на брой числа, така че останали числа да са
        // сортирани в нарастващ ред. Отпечатайте резултата.
        static void TestCh07Exercise22()
        {
            Ch07Exercise06();
        }


        // Напишете програма, която прочита цяло число N от конзолата и
        // отпечатва всички пермутации на числата [1…N].
        // Пример: N = 3 ->
        // {1, 2, 3},
        // {2, 1, 3},
        // {1, 3, 2},
        // {2, 3, 1},
        // {3, 1, 2},
        // {3, 2, 1}
        static void TestCh07Exercise23()
        {
            new int().ReadInt("N: ", min: 2).Permutations().
                PrintArrayToConsole();
        }

        // Напишете програма, която прочита цели числа N и K от конзолата и
        // отпечатва всички вариации от К елемента на числата [1…N].
        // Пример: N = 3, K = 2 ->
        // {1, 1},
        // {1, 2},
        // {1, 3},
        // {2, 1},
        // {2, 2},
        // {2, 3},
        // {3, 1},
        // {3, 2},
        // {3, 3}
        //
        // Условието е "Variations with repetition" - има дублирани елементи!
        // Броят е =  n^k = 3^2 = 9 и се решава с
        // k на брой вложени цикъла, които ще реализирам с масив за индексите.
        //
        // При "Variations without repetition" няма повтарящи се елементи
        // и V(n,k) = n! / (n-k)!
        // Отново решение с масив за индексите, като се прескачат тези
        // състояния които имат повтарящи се индекси.
        // За N = 3, K = 2 ->  V(3,2) = 3!/1! = 6
        static void TestCh07Exercise24()
        {
            int n = new int().ReadInt("N: ", min: 3);
            int k = new int().ReadInt("K: ", min: 2);

            // решение по условието - "Variations with repetition"
            int[,] v = n.VariationsWithRepetition(k);
            v.PrintArrayToConsole(flipHorizontal: true);

            // решение за "Variations without repetition"
            // Пример: N = 3, K = 2 ->
            // {1, 2},
            // {1, 3},
            // {2, 1},
            // {2, 3},
            // {3, 1},
            // {3, 2}

            n.Variations(k).PrintArrayToConsole(
                prefixLine: "Variations without repetition",
                flipHorizontal: true);
        }


        // Напишете програма, която прочита цяло число N от конзолата
        // и отпечатва всички комбинации от К елемента на числата [1…N].
        static void TestCh07Exercise25()
        {
            int n = new int().ReadInt("N: ", min: 3);
            int k = new int().ReadInt("K: ", min: 2);

            n.Combinations(k).PrintArrayToConsole(
                prefixLine: "Combinations without repetition",
                flipHorizontal: true);
        }


        // Напишете програма, която обхожда матрица (NxN) по следния начин
        // 16 15 13 10     7 11 14 16
        // 14 12  9  6     4  8 12 15
        // 11  8  5  3     2  5  9 13
        //  7  4  2  1     1  3  6 10
        static void TestCh07Exercise26()
        {
            int n = new int().ReadInt("Enter size of matrices : ", min: 3);

            int[,] arr = new int[n, n];

            int x = n - 1, y = 0; // initial position
            int c = 1;            // counter

            while (c <= n * n)
            {
                arr[x, y] = c;
                if (y == n - 1)
                {
                    if (x == n - 1) { x = 0; y = 1; }
                    else { y = n - x; x = 0; }
                }
                else if (x == n - 1) { x = n - y - 2; y = 0; }
                else { x++; y++; }
                c++;
            }

            // a) Diagonal, bottom-left to top-right,
            //    starting from bottom-right corner.
            arr.PrintArrayToConsole(
                prefixLine: "\nc) Diagonal, bottom-left to top-right,\n" +
                "   starting from bottom-right corner:\n",
                formatString: "| {0,3} ", delimiter1: "", delimiter2: "|\n",
                flipVertical: true, horizontalX: false);

            // b) Diagonal, top-left to bottom-right,
            //    starting from bottom-left corner.
            arr.PrintArrayToConsole(
                prefixLine: "\nc) Diagonal, top-left to bottom-right,\n" +
                "   starting from bottom-left corner:\n",
                formatString: "| {0,3} ", delimiter1: "", delimiter2: "|\n");
        }



        // Напишете програма, която по подадена матрица намира най-голямата
        // област от еднакви числа. Под област разбираме съвкупност от
        // съседни (по ред и колона) елементи.
        static void TestCh07Exercise27()
        {
            // TODO:
        }

        /// <summary>
        /// Demo Combinatorics
        /// </summary>
        /// <remarks>
        /// Permutations, Combinations and Variations
        /// WithoutRepetition and WithRepetition
        /// using Facet.Combinatorics;
        /// Modules: in Combinatorics sub-folder.
        /// </remarks>
        static void TestFacetCombinatorics()
        {
            int[] ints;
            ints = new int[] { 1, 1, 3 };
            ints.PrintArrayToConsole("\nArray: ");

            Console.WriteLine(
                "\nPermutations of array elements WithoutRepetition");
            new Permutations<int>(
                values: ints,
                type: GenerateOption.WithoutRepetition).
                PrintIListCollection();

            Console.WriteLine(
                "\nPermutations of 3 elements WithRepetition");
            new Permutations<int>(
                values: new int[] { 1, 1, 3 },
                type: GenerateOption.WithRepetition).
                PrintIListCollection();


            ints = new int[] { 1, 2, 3 };
            ints.PrintArrayToConsole("\nArray: ");

            Console.WriteLine(
                "\nCombinations '3 select 2' WithoutRepetition");
            new Combinations<int>(
                values: ints,
                lowerIndex: 2,
                type: GenerateOption.WithoutRepetition).
                PrintIListCollection();

            Console.WriteLine(
                "\nCombinations '3 select 2' WithRepetition");
            new Combinations<int>(
                values: ints,
                lowerIndex: 2,
                type: GenerateOption.WithRepetition).
                PrintIListCollection();

            Console.WriteLine(
                "\nVariations '3 select 2' WithoutRepetition");
            new Variations<int>(
                values: ints,
                lowerIndex: 2,
                type: GenerateOption.WithoutRepetition).
                PrintIListCollection();

            Console.WriteLine(
                "\nVariations '3 select 2' WithRepetition");
            new Variations<int>(
                values: ints,
                lowerIndex: 2,
                type: GenerateOption.WithRepetition).
                PrintIListCollection();
        }

        static void TestCombineJaggedArrayToList()
        {
            new string[][]
            {
            new string[]{"Max", "Jack", "Roger"},
            new string[]{"Loves", "hates", "knows"},
            new string[]{"Java", "C#", "Python", "Visual Basic", "C++"}
            }.
            CombineJaggedArrayToList(prefix: ">").
            PrintIListToConsole(prefix: "List:\n", delimiter: "\n");

            new int[][]
            {
            new int[]{100, 200, 300},
            new int[]{10, 20, 30},
            new int[]{1, 2, 3, 4, 5}
            }.
            CombineJaggedArrayToList(prefix: ">", delimiter: "+").
            PrintIListToConsole(prefix: "List:\n", delimiter: "\n");
        }

        static void TestInsertionSort()
        {
            Console.Write(
                "\nAscending order of ints using INSERTION SORT");

            int n = new int().ReadInt(
                "\n\nEnter the total number of elements: ", min: 2);

            new int[n].ReadIntArrayFromConsole().
                PrintArrayToConsole("Unsorted :    ").
                InsertionSort().
                PrintArrayToConsole("Sorted   :    ");

            Console.ReadLine();
        }

        static void TestBubbleSort()
        {
            Console.Write(
                "\nAscending order of ints using BUBBLE SORT");

            int n = new int().ReadInt(
                "\n\nEnter the total number of elements: ", min: 2);

            new int[n].ReadIntArrayFromConsole().
                PrintArrayToConsole("Unsorted :    ").
                BubbleSort(true).
                PrintArrayToConsole("Sorted   :    ");

            Console.ReadLine();
        }

        #endregion Chapter 07 - Arrays




        #region Chapter 08 - Numeral Systems

        static void TestConvertBase()
        {
            string d = "", x; int b1 = 0, b2 = 0, precision, i;
            while (true)
            {
                Console.Write("Enter a number  : ");
                x = Console.ReadLine(); if (x != "") d = x;
                i = new int().ReadInt("Base 1: "); if (i != 0) b1 = i;
                i = new int().ReadInt("Base 2: "); if (i != 0) b2 = i;
                precision = new int().ReadInt("Precision: ");
                try
                {
                    Console.Write("Converted number: {0}\n",
                                     d.ConvertBase(b1, b2, precision));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.ReadLine();
            }
        }


        static void TestCh08Exercises01To09()
        {
            double d = 0;
            d = 154; Console.Write("(10) {0}  =  (2) {1}\n",
                          d, d.ToString().ConvertBase(10, 2, 0));
            d = 35; Console.Write("(10) {0}  =  (2) {1}\n",
                          d, d.ToString().ConvertBase(10, 2, 0));
            d = 43; Console.Write("(10) {0}  =  (2) {1}\n",
                          d, d.ToString().ConvertBase(10, 2, 0));
            d = 251; Console.Write("(10) {0}  =  (2) {1}\n",
                          d, d.ToString().ConvertBase(10, 2, 0));
            d = -0.41; Console.Write("(10) {0}  =  (2) {1}\n",
                          d, d.ToString().ConvertBase(10, 2, 40));
            string v;
            v = "1111010110011110";
            Console.Write("(2) {0}  =  (16) {1}\n", v, v.ConvertBase(2, 16));
            Console.Write("(2) {0}  =  (10) {1}\n", v, v.ConvertBase(2, 10));
            v = "F59E";
            Console.Write("(16) {0}  =  (10) {1}\n", v, v.ConvertBase(16, 10));
            Console.Write("(16) {0}  =  (2) {1}\n", v, v.ConvertBase(16, 2));

            v = "2A3E";
            Console.Write("(16) {0}  =  (10) {1}\n", v, v.ConvertBase(16, 10));
            Console.Write("(16) {0}  =  (2) {1}\n", v, v.ConvertBase(16, 2));
            v = "FA";
            Console.Write("(16) {0}  =  (10) {1}\n", v, v.ConvertBase(16, 10));
            Console.Write("(16) {0}  =  (2) {1}\n", v, v.ConvertBase(16, 2));
            v = "FFFF";
            Console.Write("(16) {0}  =  (10) {1}\n", v, v.ConvertBase(16, 10));
            Console.Write("(16) {0}  =  (2) {1}\n", v, v.ConvertBase(16, 2));
            v = "5A0E9";
            Console.Write("(16) {0}  =  (10) {1}\n", v, v.ConvertBase(16, 10));
            Console.Write("(16) {0}  =  (2) {1}\n", v, v.ConvertBase(16, 2));
        }



        public static void Main()
        {
            Ch06Exercises16();
        }

        #endregion


    }
}


#if false // Notes

#region Specifications of Data Types:

  TYPE  Default Memory                    MinValue                          MaxValue         Accuracy

 sbyte  0       8b                       -128 = -(2^7)                        127 = 2^ 7 -1         1
  byte  0       8b                          0                                 255 = 2^ 8            1

 short  0      16b                    -32,768 = -(2^15)                    32,767 = 2^15 -1         1
ushort  0      16b                          0                              65,535 = 2^16            1

   int  0      32b             -2,147,483,648 = -(2^31)             2,147,483,647 = 2^31 -1         1
  uint  0      32b                          0                       4,294,967,295 = 2^32            1

  long  0L     64b -9,223,372,036,854,775,808 = -(2^63) 9,223,372,036,854,775,807 = 2^63 -1         1
 ulong  0u     64b                          0          18,446,744,073,709,551,615 = 2^64            1

 float  0.0f   32b                  ±1.5E-45                             ±3.4E38             7 digits
double  0.0d   64b                  ±5.0E-324                            ±1.7E308        15-16 digits

decimal 0.0m  128b                  ±1.0E-28                             ±7.9E28         28-29 digits
boolean false   8b          ( Only two values are possible - false & true )                         -

char  '\u0000' 16b                  '\u0000'                             '\uffff'                   -

object  null  heap                         -                                    -                   -
string  null  heap                         -                                    -                   -

#endregion

#region Common mistakes

INCORRECT
List values = new List() { "This ", "is ", "Sparta ", "!" };
string outputValue = string.Empty;
foreach (var value in values)
{
   outputValue += value;
}

CORRECT
StringBuilder outputValueBuilder = new StringBuilder();
foreach (var value in values)
{
    outputValueBuilder.Append(value);
}


INCORRECT
List numbers = new List() { 1, 4, 5, 9, 11, 15, 20, 21, 25, 34, 55 };
return numbers.Where(x => Fibonacci.IsInFibonacciSequence(x)).First();

PARTLY CORRECT
return numbers.First(x => Fibonacci.IsInFibonacciSequence(x));

CORRECT
return numbers.FirstOrDefault
(x => Fibonacci.IsInFibonacciSequence(x));


INCORRECT
var woman = (Woman)person;

CORRECT
var woman = person as Woman;


INCORRECT
try
{
   //some code that can throw exception [...]
}
catch (Exception ex)
{
   //some exception logic [...]
   throw ex;
}

CORRECT
try
{
    //some code that can throw exception [...]
}
catch (Exception ex)
{
    //some exception logic [...]
    throw;
}

 EVEN BETTER
try
{
   //doing something specific with SomeValue
}
catch (Exception ex)
{
   //some exception logic [...]
   throw new Exception(
      string.Format(“FAIL!
HERES’S SOME VALUE TO HELP FIND OUT WHY: { 0}”,
                    SomeValue),
      ex);
}

 gives you
 1.) nested stack trace,
 2.) something to tell the client
 3.) something to duplicate/fix the issue

 call it defensive programming if you must,
 but truth is computations generally don't fail,
 what fails is another part of the system out of your control
 writes data incorrectly or inconsistently
 or you're uncovering a heretounforeseen edge case



//the below code:
using(SomeDisposableClass someDisposableObject = new SomeDisposableClass())
{
   someDisposableObject.DoTheJob();
}
//does the same as:
SomeDisposableClass someDisposableObject = new SomeDisposableClass();
try
{
   someDisposableObject.DoTheJob();
}
finally
{
   someDisposableObject.Dispose();
}

#endregion Common mistakes

#region Оператори
 Категория            Оператори
 аритметични          -, +, *, /, %, ++, --
 логически            &&, ||, !, ^
 побитови             &, |, ^, ~, <<, >>
 за сравнение         ==, !=, >, <, >=, <=
 за присвояване       =, +=, -=, *=, /=, %=, &=, |=, ^=, <<=, >>=
 слепване на низове   +
 за работа с типове   (type), as, is, typeof, sizeof
 други                ., new, (), [], ?:, ??

 Приоритет от най-висок към най-нисък:
 ++, -- (като постфикс), new, (type), typeof, sizeof
 ++, -- (като префикс), +, - (едноаргументни), !, ~
 *, /, %
 + (свързване на низове)
 +, -
 <<, >>
 <, >, <=, >=, is, as
 ==, !=
 &, ^, |
 &&
 ||
 ?:, ??
 =, *=, /=, %=,+=, -=, <<=, >>=, &=, ^=, |=


    x     y      !x   x && y   x || y   x ^ y
  true  true   false    true     true   false
  true false   false   false     true    true
 false  true    true   false     true    true
 false false    true   false    false   false


 !(a && b) == (!a || !b)
 !(a || b) == (!a && !b)


int? a = 5;
Console.WriteLine(a ?? -1);
// 5 string name = null; Console.WriteLine(name ?? "(no name)"); // (no name)

double d = 5e9d; // 5 * 10^9
Console.WriteLine(d); // 5000000000
int i = checked((int)d); // System.OverflowException
Console.WriteLine(i);

 is a number even ?
#endregion

#region WriteLine formatting - Standard Numeric Formats

- \' – единична кавичка
- \" – двойна кавичка
- \\ – лява наклонена черта
- \n – нов ред
- \t – отместване(табулация)
- \uXXXX – символ, зададен с Unicode номера си, примерно \u03A7

#endregion

#region  Римска цифра Десетична

I                  1
V                  5
X                 10
L                 50
C                100
D                500
М               1000

#endregion

#region Гръцка цифра Десетична

Ι                  1
Г                  5
Δ                 10
Η                100
Χ              1 000
Μ             10 000

#endregion

#endif
