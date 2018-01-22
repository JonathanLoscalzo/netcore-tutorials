using System;

namespace Csharp7_features.Features
{
    ///     In C#, throw has always been a statement. Because throw is a statement, not an expression, there were C#
    /// constructs where you could not use it. These included conditional expressions, null coalescing expressions, and
    /// some lambda expressions. The addition of expression-bodied members adds more locations where throw
    /// expressions would be useful
    /// So that you can write any of these constructs, C# 7 introduces throw expressions.

    public class ThrowExceptionsFeatures
    {
        private string name { get; set; }
        /// The syntax is the same as you've always used for throw statements. The only difference is that now you can place
        /// them in new locations, such as in a conditional expression:
        public string Name
        {
            get => name;
            set => name = value ??
                throw new ArgumentNullException(paramName: nameof(value), message: "New name must not be null");
        }

        public ThrowExceptionsFeatures(string name)
        {
            if (name == null)
                throw new InvalidOperationException("Could not load name");
        }
    }
}