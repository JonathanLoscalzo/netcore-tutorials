using System;
using System.Linq;
using System.Collections.Generic;

namespace Csharp7_features.Features
{
    /*
    Tuples were available before C# 7 as an API, but had many limitations. 
    Most importantly, the members of these tuples were named Item1, Item2 and so on.
    The language support enables semantic names for the fields of a Tuple.
     */
    public static class TupleFeature
    {
        /// Declaration
        public static void CreateTuple()
        {
            var letters = ("a", "b");
            Console.WriteLine($"{letters.Item1}, {letters.Item2}"); /// string interpolation

            (string Alpha, string Beta) namedLetters = ("a", "b");
            Console.WriteLine(namedLetters.Alpha + " - " + namedLetters.Beta);

            var alphabetStart = (Alpha: "a", Beta: "b"); //cool;
            Console.WriteLine(alphabetStart.Alpha + " - " + alphabetStart.Beta);
        }

        ///Returning Tuple
        public static (int Max, int Min) GetMaxAndMin(IEnumerable<int> numbers)
        {
            var max = numbers.Max();
            var min = numbers.Min();
            return (max, min);
        }

        ///Example of Deconstruct
        public class Point
        {
            public Point(double x, double y)
            {
                this.X = x;
                this.Y = y;
            }

            private double X { get; }
            private double Y { get; }

            /*
                Deconstruct is for use a class Like a tuple
                var p = new TupleFeature.Point(1.1, 2.2);
                (double X, double Y) = p;
             */
            public void Deconstruct(out double x, out double y)
            {
                /* Can Declare Deconstruct Extension for all objects.
                public static class Extensions
                {
                    public static void Deconstruct(this Student s, out string first, out string last, out double gpa)
                    {
                        first = s.FirstName;
                        last = s.LastName;
                        gpa = s.GPA;
                    }
                } */
                x = this.X;
                y = this.Y;
            }
        }
    }
}