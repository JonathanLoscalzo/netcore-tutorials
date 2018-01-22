using System;
using System.Linq;
using System.Collections.Generic;

namespace Csharp7_features.Features
{
    /// Pattern matching is a feature that allows you to implement method dispatch on properties other than the type of
    /// an object. You're probably already familiar with method dispatch based on the type of an object. In Object Oriented
    /// programming, virtual and override methods provide language syntax to implement method dispatching based on
    /// an object's type. Base and Derived classes provide different implementations. Pattern matching expressions extend
    /// this concept so that you can easily implement similar dispatch patterns for types and data elements that are not
    /// related through an inheritance hierarchy.
    /// Pattern matching supports is expressions and switch expressions. Each enables inspecting an object and its
    /// properties to determine if that object satisfies the sought pattern. You use the when keyword to specify additional
    /// rules to the pattern.
    public static class PatternMatchingFeature
    {
        private static IEnumerable<object> numbers = new List<object>
        {
            1,
            4,
            2,
            5,
            new PercentileDie(2,4),
            new List<object> { 1,2,3,4 } //new List<int> { 1,2,3,4 } no funciona
        };

        public static IEnumerable<object> Numbers { get => numbers; set => numbers = value; }

        public static int SumFlatten(IEnumerable<object> numbers)
        {
            /*
            As part of checking the type, you write a variable
            initialization. This creates a new variable of the validated runtime type. */
            var sum = 0;

            /// with sublist has a problem! :-( 
            numbers.ToList().ForEach(item =>
            {
                if (item is int num)
                {
                    sum += num;
                }
                else if (item is IEnumerable<object> sublist)
                {
                    sum += SumFlatten(sublist);
                }
            });

            return sum;
        }

        public static int SumFlatten2(IEnumerable<object> values)
        {
            var sum = 0;
            foreach (var item in values)
            {
                switch (item)
                {
                    case int val:
                        sum += val;
                        break;
                    case PercentileDie die: 
                        (int mul, int value) = die;
                        sum += mul * value;
                        break;
                    case IEnumerable<object> subList when subList.Any():
                        sum += SumFlatten2(subList);
                        break;
                    case IEnumerable<object> subList:
                        throw new Exception("List is empty");
                }
            }

            return sum;
        }

        public class PercentileDie
        {
            public int Value { get; }
            public int Multiplier { get; }
            public PercentileDie(int multiplier, int value)
            {
                this.Value = value;
                this.Multiplier = multiplier;
            }

            public void Deconstruct(out int Multiplier, out int Value){
                Multiplier = this.Multiplier;
                Value = this.Value;
            }
        }

    }
}