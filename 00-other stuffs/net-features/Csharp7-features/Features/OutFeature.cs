using System;

namespace Csharp7_features.Features
{
    public static class OutFeature
    {
        /**
            out declaration inline.!-- 
            The code is easier to read.
            You declare the out variable where you use it, not on another line above.
            No need to assign an initial value.
            By declaring the out variable where it is used in a method call
                , you can't accidentally use it before it is assigned.
         */
        public static void OldExample(string input = "1232")
        {
            int numericResult;
            if (int.TryParse(input, out numericResult))
                Console.WriteLine(numericResult);
            else
                Console.WriteLine("Could not parse input");
        }

        public static void NewExample(string input = "12312")
        {
            if (int.TryParse(input, out var answer))
                Console.WriteLine(answer);
            else
                Console.WriteLine("Could not parse input");
        }
    }
}