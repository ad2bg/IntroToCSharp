
using System;

namespace CommonUtils
{
    /// <summary>
    /// Utilities for manipulating strings.
    /// </summary>
    /// <includes>
    /// Reverse, string
    /// RepeatChar, string
    /// Left, string
    /// Right, string
    /// RemoveLeft, string
    /// RemoveRight, string
    /// RemoveMid, string
    /// RemoveDuplicatedChars, string
    /// ToHex, string
    /// ToInt, int
    /// SwapCharacters, string
    /// SpellOutLongInBG, string
    /// SpellOutInt0to999InBG, string
    /// SpellOutLongInEN, string
    /// SpellOutInt0to999InEN, string
    /// ConvertBase, string
    ///
    /// </includes>
    public static class StringUtils
    {
        /// <summary>
        /// Reverse a string (using a char array).
        /// </summary>
        /// <param name="text">String to reverse.</param>
        /// <returns>Reversed string.</returns>
        public static string Reverse(this string text)
        {
            if (text == null) return null;

            char[] array = text.ToCharArray();
            Array.Reverse(array);
            return new string(array);

            //return Microsoft.VisualBasic.Strings.StrReverse(text);
        }

        public static string RepeatChar(this char aChar, int n) =>
            new string(aChar, n);

        public static string Left(this string strString, int n)
        {
            if (n <= 0) return "";
            if (n < strString.Length)
            {
                return strString.Substring(0, n);
            }
            return strString;
        }

        public static string Right(this string strString, int n)
        {
            if (n <= 0) return "";
            if (n < strString.Length)
            {
                return strString.Substring(strString.Length - n, n);
            }
            return strString;
        }

        public static string RemoveLeft(this string strString, int n)
        {
            if (n <= 0) return strString;
            if (n < strString.Length)
            {
                return strString.Substring(n);
            }
            return "";
        }

        public static string RemoveRight(this string strString, int n)
        {
            if (n <= 0) return strString;
            if (n < strString.Length)
            {
                return strString.Substring(0, strString.Length - n);
            }
            return "";
        }

        public static string RemoveMid(this string strSting, int positionFrom, int positionTo)
        {
            int p1 = Math.Min(positionFrom, positionTo);
            int p2 = Math.Max(positionFrom, positionTo);
            return strSting.Left(p1) + strSting.RemoveLeft(p2 + 1);
        }

        public static string RemoveDuplicatedChars(this string s)
        {
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s.Left(i).Contains("" + s[i])) { s = s.Left(i) + s.Right(s.Length - i - 1); }
            }
            return s;
        }

        /// <summary>
        /// Number as string or char - convert to Hex string.
        /// </summary>
        /// <typeparam name="T">string or char</typeparam>
        /// <param name="c">number as string or char</param>
        /// <returns>Hex string.</returns>
        public static string ToHex<T>(this T c) =>
            $"{(int)(Convert.ToChar(c)):x}";

        /// <summary>
        /// Digit as string or char - convert to int.
        /// </summary>
        /// <typeparam name="T">string or char</typeparam>
        /// <param name="c">digit as string or char</param>
        /// <returns>digit as int</returns>
        public static int ToInt<T>(this T c) => Convert.ToChar(c) - '0';

        /// <summary>
        /// Swap characters in a string.
        /// </summary>
        /// <param name="aString">A string.</param>
        /// <param name="psn1">Position 1 (zero based)</param>
        /// <param name="psn2">Position 2 (zero based)</param>
        /// <returns>A string.</returns>
        public static string SwapCharacters(
            this string aString, int psn1, int psn2) =>
            new string(aString.ToCharArray().SwapInArray(psn1, psn2));

        /// <summary>
        /// Spell out long [0:999,999,999,999] in Bulgarian.
        /// </summary>
        /// <param name="input">Long [0:999,999,999,999]</param>
        /// <param name="isMale">
        /// True: Male
        /// False: Female
        /// Null: Neuter
        /// </param>
        /// <returns>String in Bulgarian language.</returns>
        /// <example>
        /// long x,y,z; x = 0; y = 1000000; z = 1;
        /// for (long i = x; i < y; i+=z) { Console.WriteLine($"{i:N0} = '{CommonUtils.StringUtils.SpellOutLongInBG(i)}'"); }
        /// </example>
        public static string SpellOutLongInBG(
            this long input, bool? isMale = null)
        {
            // isMale: true = м.р.  false = ж.р.  null = с.р.

            string sign = "";
            string part = "";
            string bg = "";
            if (Math.Abs(input) >= 1e12)
            {
                throw new ArgumentOutOfRangeException(
                    "Number to spell out is too big!");
            }

            sign = (input < 0 ? "минус " : "");
            input = Math.Abs(input);

            /*
            0-999 - SpellOutInt0to999InBG(остатък,isMale)
            1e3  =             1,000   хиляди - ж.р.
            1e6  =         1,000,000  милиони - м.р.
            1e9  =     1,000,000,000 милиарди - м.р.
            1e12 = 1,000,000,000,000 - exception
            */

            var billions = (int)(input / 1e9);
            var millions = (int)((input - billions * 1e9) / 1e6);
            var thousands = (int)
                (((input - billions * 1e9) - millions * 1e6) / 1e3);
            var remainder = (int)(input % 1e3);

            // process billions
            if (billions > 0)
            {
                bg += SpellOutInt0to999InBG(billions, true) +
                    (billions > 1 ? " милиарда" : " милиард");
            }

            // process millions
            if (millions > 0)
            {
                part = SpellOutInt0to999InBG(millions, true);

                if (bg == "")
                {
                    bg = part + (millions > 1 ? " милиона" : " милион");
                }
                else
                {
                    if (remainder > 0)
                    {
                        if (part.IndexOf(" и ") > 0)
                        {
                            bg += " " + part;
                        }
                        else
                        {
                            bg += " и " + part;
                        }
                    }

                    bg += (millions > 1 ? " милиона" : " милион");
                }
            }

            // process thousands
            if (thousands > 0)
            {
                part = SpellOutInt0to999InBG(thousands, false);

                if (bg == "")
                {
                    bg = (thousands > 1 ? part + " хиляди" : "хиляда");
                }
                else
                {
                    if (remainder > 0)
                    {
                        if (part.IndexOf(" и ") > 0)
                        {
                            bg += " " + part;
                        }
                        else
                        {
                            bg += " и " + part;
                        }
                    }

                    bg += (thousands > 1 ? " хиляди" : " хиляда");
                }
            }

            // process remainder
            part = SpellOutInt0to999InBG(remainder, isMale);
            if (bg == "")
            {
                bg = part;
            }
            else
            {
                if (remainder > 0)
                {
                    if (part.IndexOf(" и ") > 0)
                    {
                        bg += " " + part;
                    }
                    else
                    {
                        bg += " и " + part;
                    }

                }
            }

            return sign + bg;
        }


        /// <summary>
        /// Spell out int [0:999] in Bulgarian.
        /// </summary>
        /// <param name="input">int [0:999]</param>
        /// <param name="isMale">
        /// True: Male 
        /// False: Female 
        /// Null: Neuter 
        /// </param>
        /// <returns>String in Bulgarian language.</returns>
        /// <example>
        /// for (long i = x; i < y; i+=z) { Console.WriteLine($"{i} = '{CommonUtils.StringUtils.SpellOutLongInBG(i)}'"); }
        /// </example>
        private static string SpellOutInt0to999InBG(
            int input, bool? isMale = null)
        {
            string bg = "",
                ones = "",
                tens = "",
                hundreds = "";

            switch (input / 100)
            {
                case 0: hundreds = ""; break;
                case 1: hundreds = "сто"; break;
                case 2: hundreds = "двеста"; break;
                case 3: hundreds = "триста"; break;
                case 4: hundreds = "четиристотин"; break;
                case 5: hundreds = "петстотин"; break;
                case 6: hundreds = "шестстотин"; break;
                case 7: hundreds = "седемстотин"; break;
                case 8: hundreds = "осемстотин"; break;
                case 9: hundreds = "деветстотин"; break;
            }

            switch ((input % 100) / 10)
            {
                case 0: tens = ""; break;
                case 1: tens = "десет"; break;
                case 2: tens = "двадесет"; break;
                case 3: tens = "тридесет"; break;
                case 4: tens = "четиридесет"; break;
                case 5: tens = "петдесет"; break;
                case 6: tens = "шестдесет"; break;
                case 7: tens = "седемдесет"; break;
                case 8: tens = "осемдесет"; break;
                case 9: tens = "деветдесет"; break;
            }

            switch (input % 10)
            {
                case 0: ones = ""; break;
                case 1:
                    switch (isMale)
                    {
                        case true: ones = "един"; break;
                        case false: ones = "една"; break;
                        default: ones = "едно"; break;
                    }
                    break;
                case 2:
                    switch (isMale)
                    {
                        case true: ones = "два"; break;
                        default: ones = "две"; break;
                    }
                    break;
                case 3: ones = "три"; break;
                case 4: ones = "четири"; break;
                case 5: ones = "пет"; break;
                case 6: ones = "шест"; break;
                case 7: ones = "седем"; break;
                case 8: ones = "осем"; break;
                case 9: ones = "девет"; break;
            }

            if (tens == "" && ones == "")
            {
                bg = hundreds == "" ? "нула" : hundreds;
            }
            else if (tens == "десет")
            {
                bg = ones + "на" + "десет";
                if (ones == "") bg = "десет";
                if (ones == "едно") bg = "единадесет";
                if (ones == "две") bg = "дванадесет";

                if (hundreds != "") bg = hundreds + " и " + bg;
            }
            else
            {
                bg = ones;
                if (hundreds != "" || tens != "")
                    bg = tens +
                        (ones == "" ? " " :
                        (tens != "" ? " " : "") + "и " + bg);
                if (hundreds != "")
                    bg = hundreds +
                        (ones == "" ? " и " : " ") + bg;
            }

            return bg.Trim();
        }



        /// <summary>
        /// Spell out long [0:999,999,999,999] in US English.
        /// </summary>
        /// <param name="input">Long [0:999,999,999,999]</param>
        /// <returns>String in US English language.</returns>
        /// <see cref="https://www.ego4u.com/en/cram-up/vocabulary/numbers/generator"/>
        /// <example>
        /// for (int i = x; i < y; i+=z) { Console.WriteLine($"{i:N0} = '{CommonUtils.StringUtils.SpellOutLongInEN(i)}'"); }
        /// </example>
        public static string SpellOutLongInEN(this long input)
        {
            string sign = "";
            string part = "";
            string en = "";

            if (Math.Abs(input) >= 1e12)
            {
                throw new ArgumentOutOfRangeException(
                    "Number to spell out is too big!");
            }

            sign = (input < 0 ? "minus " : "");
            input = Math.Abs(input);

            /*
            0-999 - SpellOutInt0to999InEN(remainder)
            1e3  =             1,000   = thousand
            1e6  =         1,000,000   = million
            1e9  =     1,000,000,000   = billion
            1e12 = 1,000,000,000,000  -> exception
            */

            var billions = (int)(input / 1e9);
            var millions = (int)((input - billions * 1e9) / 1e6);
            var thousands = (int)
                (((input - billions * 1e9) - millions * 1e6) / 1e3);
            var remainder = (int)(input % 1e3);

            // process billions
            if (billions > 0)
            {
                en += $" { SpellOutInt0to999InEN(billions) } billion";
            }

            // process millions
            if (millions > 0)
            {
                part = SpellOutInt0to999InEN(millions);
                en += string.Format("{0}{1} million", (en == "" ? "" : ", "), part);
            }

            // process thousands
            if (thousands > 0)
            {
                part = SpellOutInt0to999InEN(thousands);
                en += string.Format("{0}{1} thousand", (en == "" ? "" : ", "), part);
            }

            // process remainder
            part = SpellOutInt0to999InEN(remainder);
            if (en == "")
            {
                en = part;
            }
            else
            {
                if (part != "zero") { en += ", " + part; }
            }

            return sign + en;
        }

        /// <summary>
        /// Spell out int [0:999] in US English.
        /// </summary>
        /// <param name="input">int [0:999]</param>
        /// <returns>String in US English language.</returns>
        /// <see cref="https://www.ego4u.com/en/cram-up/vocabulary/numbers/generator"/>
        /// <example>
        /// for (int i = x; i < y; i+=z) { Console.WriteLine($"{i:N0} = '{CommonUtils.StringUtils.SpellOutLongInEN(i)}'"); }
        /// </example>
        private static string SpellOutInt0to999InEN(int input)
        {
            const bool and = false;
            string en = "",
                ones = "",
                tens = "",
                hundreds = "";

            switch (input / 100)
            {
                case 0: hundreds = ""; break;
                case 1: hundreds = "one hundred"; break;
                case 2: hundreds = "two hundred"; break;
                case 3: hundreds = "three hundred"; break;
                case 4: hundreds = "four hundred"; break;
                case 5: hundreds = "five hundred"; break;
                case 6: hundreds = "six hundred"; break;
                case 7: hundreds = "seven hundred"; break;
                case 8: hundreds = "eight hundred"; break;
                case 9: hundreds = "nine hundred"; break;
            }

            switch ((input % 100) / 10)
            {
                case 0: tens = ""; break;
                case 1: tens = "ten"; break;
                case 2: tens = "twenty"; break;
                case 3: tens = "thirty"; break;
                case 4: tens = "fourty"; break;
                case 5: tens = "fifty"; break;
                case 6: tens = "sixty"; break;
                case 7: tens = "seventy"; break;
                case 8: tens = "eighty"; break;
                case 9: tens = "ninety"; break;
            }

            switch (input % 10)
            {
                case 0: ones = ""; break;
                case 1: ones = "one"; break;
                case 2: ones = "two"; break;
                case 3: ones = "three"; break;
                case 4: ones = "four"; break;
                case 5: ones = "five"; break;
                case 6: ones = "six"; break;
                case 7: ones = "seven"; break;
                case 8: ones = "eight"; break;
                case 9: ones = "nine"; break;
            }


            if (tens == "" && ones == "")
            {
                en = hundreds == "" ? "zero" : hundreds;
            }
            else if (tens == "ten")
            {
                switch (ones)
                {
                    case "": en = "ten"; break;
                    case "one": en = "eleven"; break;
                    case "two": en = "twelve"; break;
                    case "three": en = "thirteen"; break;
                    case "four": en = "fourteen"; break;
                    case "five": en = "fifteen"; break;
                    case "six": en = "sixteen"; break;
                    case "seven": en = "seventeen"; break;
                    case "eight": en = "eighteen"; break;
                    case "nine": en = "nineteen"; break;
                }

                if (hundreds != "") en = hundreds + (and ? " and " : " ") + en;
            }
            else
            {
                en = ones;
                if (tens != "") { en = tens + (ones == "" ? "" : "-" + en); }
                if (hundreds != "") { en = hundreds + (and ? " and " : " ") + en; }
            }

            return en;
        }



        /// <summary>
        /// Numeral systems conversion (as string).
        /// </summary>
        /// <remarks>From base [2:16] to base [2:16].</remarks>
        /// <param name="n">The number to convert (as string).</param>
        /// <param name="b1">From base; e.g. Binary = 2.</param>
        /// <param name="b2">To base;   e.g. Hex = 16.</param>
        /// <param name="requiredNumberOfDigitsAfterDecimalPoint">
        /// Maximum number of required digits after the decimal point.
        /// If reached, the number will be truncated there, not rounded.
        /// </param>
        /// <returns>Converted number as string</returns>
        public static string ConvertBase(
            this string n, int b1, int b2,
            int requiredNumberOfDigitsAfterDecimalPoint = 0)
        {
            const int m = 36; // max base	
            const string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            //double type precision is 15 to 16 digits

            if (!(2 <= b1 && b1 <= m && 2 <= b2 && b2 <= m))
            { throw new ArgumentOutOfRangeException(); }

            string validDigits = digits.Substring(0, b1);

            string integerPart = "", fractionalPart = "";

            string decimalPoint = System.Globalization.CultureInfo.
                CurrentCulture.NumberFormat.NumberDecimalSeparator;

            int decimalPointIndex = n.IndexOf(decimalPoint,
                StringComparison.CurrentCulture);
            if (decimalPointIndex == -1)
            {
                integerPart = n;
                fractionalPart = "";
            }
            else
            {
                integerPart = n.Left(decimalPointIndex);
                fractionalPart = n.Right(n.Length - decimalPointIndex - 1);
            }

            int lenIntegerPart = integerPart.Length;
            int lenFractionalPart = fractionalPart.Length;

            // Phase 1: Calculate the value of the string
            // from its numeral system (with base = b1)
            // towards decimal.
            char ch;
            int digitValue = 0;
            ulong ulongValue = 0;
            double fractionalValue = 0;
            double powerIndex = 1;
            bool isNegative = false;
            // first - process the integer part
            for (int i = 0; i < lenIntegerPart; i++)
            {
                ch = integerPart[lenIntegerPart - i - 1];
                if (ch == '-' && i == lenIntegerPart - 1)
                {
                    isNegative = true;
                }
                else
                {
                    digitValue = validDigits.IndexOf(ch.ToString().ToUpper(),
                        StringComparison.InvariantCulture);
                    if (digitValue == -1)
                        throw new ArgumentException("Invalid digit.");
                    ulongValue += (ulong)powerIndex * (ulong)digitValue;
                    powerIndex *= b1;
                }
            }
            // now - the decimal part (if there's such)
            digitValue = 0; // index	
            powerIndex = 1; // power index	
            for (int i = 0; i < lenFractionalPart; i++)
            {
                ch = fractionalPart[i];
                digitValue = validDigits.IndexOf(ch.ToString().ToUpper(),
                        StringComparison.InvariantCulture);
                if (digitValue == -1)
                    throw new ArgumentException("Invalid digit.");
                powerIndex /= b1;
                fractionalValue += powerIndex * digitValue;
                fractionalValue =
                    Math.Round(fractionalValue,
                    powerIndex.GetNumberOfFractionalDigits());
            }


            // Phase 2: Convert the decimal number
            // towards a string in the new numeral system (with base = b2).
            string str = "";
            // first - process the integer part
            do
            {
                str = digits[(int)(ulongValue % (ulong)b2)] + str;
                ulongValue /= (ulong)b2;
            }
            while (ulongValue > 0);
            if (isNegative) str = "-" + str;
            // now - the decimal part (if there's such)
            if (lenFractionalPart > 0 &&
                requiredNumberOfDigitsAfterDecimalPoint > 0)
            {
                str += ".";
                int countFractionalPartLength = 0;
                do
                {
                    fractionalValue *= b2;
                    str += digits[(int)(fractionalValue % b2)];
                    fractionalValue -= (int)(fractionalValue % b2);
                    countFractionalPartLength++;
                } while ((Math.Abs(fractionalValue) > double.Epsilon) &&
                (countFractionalPartLength <
                requiredNumberOfDigitsAfterDecimalPoint));
                // remove trailing zeros
                while (str.Right(1) == "0") { str = str.RemoveRight(1); }
            }

            return str;
        }
    }
}