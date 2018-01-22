using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Csharp7_features.Features
{
    public static class AlphabetIterator
    {
        /// The exception is thrown when resultSet is iterated, not when resultSet is created.
        public static IEnumerable<char> AlphabetSubset(char start, char end)
        {
            if (start < 'a' || start > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(start), message: "start must be a letter");
            if (end < 'a' || end > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(end), message: "end must be a letter");
            if (end <= start)
                throw new ArgumentException($"{nameof(end)} must be greater than {nameof(start)}");
            // cool, using yield.
            for (var c = start; c < end; c++)
                yield return c; // The exception is thrown when resultSet is iterated, not when resultSet is created
        }

        ///You can refactor the code so that the public
        ///method validates all arguments, and a private method generates the enumeration
        public static IEnumerable<char> AlphabetSubset2(char start, char end)
        {
            if (start < 'a' || start > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(start), message: "start must be a letter");
            if (end < 'a' || end > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(end), message: "end must be a letter");
            if (end <= start)
                throw new ArgumentException($"{nameof(end)} must be greater than {nameof(start)}");
            return alphabetSubsetImplementation(start, end);
            /*
            This refactored version will throw exceptions immediately 
            because the public method is not an iterator method;
            only the private method uses the yield return syntax. */
        }

        ///The private method should only be called from the public interface method, because otherwise all argument
        ///validation is skipped. Readers of the class must discover this fact by reading the entire class and searching for any
        ///other references to the alphabetSubsetImplementation method.
        private static IEnumerable<char> alphabetSubsetImplementation(char start, char end)
        {
            for (var c = start; c < end; c++)
                yield return c;
        }

        public static IEnumerable<char> AlphabetSubsetUsingLocals(char start, char end)
        {
            if (start < 'a' || start > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(start), message: "start must be a letter");
            if (end < 'a' || end > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(end), message: "end must be a letter");
            if (end <= start)
                throw new ArgumentException($"{nameof(end)} must be greater than {nameof(start)}");
            return alphabetSubsetImplementation();
            /*
            Using Locals makes clear that 'alphabetSubsetImplementation' could't call outer this method.
             */
            IEnumerable<char> alphabetSubsetImplementation()
            {
                for (var c = start; c < end; c++)
                    yield return c;
            }
        }
    }

    [Obsolete("Ver como se usa esto, sino no sirve el ejemplo")]
    public static class AlphabetIteratorWithTask
    {
        private static async Task<string> FirstWork(string address)
        {
            await Task.Delay(50);
            return address;
        }

        private static async Task<string> SecondStep(int index, string name)
        {
            await Task.Delay(100);
            return $"{index.ToString()} - {name}";
        }

        /// Ver TASK, AWAIT y ASYNC
        public static Task<string> PerformLongRunningWork(string address, int index, string name)
        {
            ///ver async, await & Task
            if (string.IsNullOrWhiteSpace(address))
            {
                throw new ArgumentException(message: "An address is required", paramName: nameof(address));
            }
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(paramName: nameof(index), message: "The index must be non-negative");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(message: "You must supply a name", paramName: nameof(name));
            }

            return longRunningWorkImplementation();

            //declaring Local longRunningWorkImplementation
            async Task<string> longRunningWorkImplementation()
            {
                var interimResult = await FirstWork(address);
                var secondResult = await SecondStep(index, name);
                return $"The results are {interimResult} and {secondResult}. Enjoy.";
            }
        }
    }
}