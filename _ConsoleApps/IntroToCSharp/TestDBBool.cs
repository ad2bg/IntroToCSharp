
using System;

/// <summary>
/// CommonUtilities
/// </summary>
/// <remarks>
/// Parts of the examples/exercises are moved to this DLL
/// which is another project in this solution.
/// </remarks>
using CommonUtils;

namespace IntroToCSharp
{
    class TestDBBool
    {
       static void _Main()
        {
            DBBool a, b;
            a = DBBool.dbTrue;
            b = DBBool.dbNull;

            Console.WriteLine("!{0} = {1}", a, !a);
            Console.WriteLine("!{0} = {1}", b, !b);
            Console.WriteLine("{0} & {1} = {2}", a, b, a & b);
            Console.WriteLine("{0} | {1} = {2}", a, b, a | b);
            // Invoke the true operator to determine the Boolean 
            // value of the DBBool variable:
            if (b)
                Console.WriteLine("b is definitely true");
            else
                Console.WriteLine("b is not definitely true");
        }
    }
}