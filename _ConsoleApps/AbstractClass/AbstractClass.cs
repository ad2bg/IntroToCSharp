using System;

namespace AbstractClass
{
    class AbstractClass
    {
        abstract class ShapesClass
        {
            abstract public int Area();
        }


        class Square : ShapesClass
        {
            int side = 0;

            public Square(int n)
            {
                side = n;
            }

            // Area method is required to avoid a compile-time error.
            public override int Area() => side * side;
        }


        static void Main()
        {
            var sq = new Square(12);
            Console.WriteLine("Area of the square = {0}", sq.Area());

            //// An abstract class that implements an interface
            //// might map the interface methods onto abstract methods.
            //// For example:
            //interface I
            //{
            //    void M();
            //}
            //abstract class C : I
            //{
            //    public abstract void M();
            //}
        }
    }
}
