using System;
using static System.Math;
using System.Threading.Tasks;

namespace Csharp7_features.Features
{
    public class Csharp6Features
    {
        //From C# 6
        //Property Initializers can be used with read/write properties as well as read only properties, as shown here
        public int YearInSchool { get; set; } = 2017;
        public int Sexteen = 16;
        //Expression-bodied function members
        public override string ToString() => $"{YearInSchool.ToString()}, {Sexteen.ToString()}";
        public string FullName => $"{YearInSchool.ToString()}, {Sexteen.ToString()}";

        // using static System.Math;
        public double UsingStaticMathExample()
        {
            return Cos(90);
        }

        //Null-conditional operators
        private string NullConditionalExample = null;

        /// In the preceding example, the variable first is assigned null if the NullConditionalExample object is null
        /// Otherwise, it getsassigned the value of the FirstName property. Most importantly, the ?. means that this line of code does not
        /// generate a NullReferenceException when the person variable is null . Instead, it short-circuits and produces
        /// null .
        public string NullConditionOperator()
        {
            var first = NullConditionalExample?.ToString();
            return first;
            //The most common use of member functions with the null conditional operator is to
            //safely invoke delegates (or event handlers) that may be null
            /*
            // preferred in C# 6:
            this.SomethingHappened?.Invoke(this, eventArgs);
            */
        }

        //Exception Filters
        public static async Task<string> MakeRequest()
        {
            var client = new System.Net.Http.HttpClient();
            var streamTask = client.GetStringAsync("https://localHost:10000");
            try
            {
                var responseText = await streamTask;
                return responseText;
            }
            catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("301"))
            {
                return "Site Moved";
            }
        }
        public string MethodThatFailsSometimes()
        {
            var client = new System.Net.Http.HttpClient();
            var streamTask = client.GetStringAsync("https://localHost:10000");
            try
            {
                throw new Exception();
            }
            catch (Exception e) when (e.LogException())
            {
                // This is never reached!
                // The exceptions are never caught, because the LogException method always returns false . That always false
                // exception filter means that you can place this logging handler before any other exception handlers:
                return "Site Moved";
            }
        }

        //nameof Expressions
        // The nameof expression evaluates to the name of a symbol. It's a great way to get tools working whenever you
        // need the name of a variable, a property, or a member field.

        ///One of the most common uses for nameof is to provide the name of a symbol that caused an exception:
        public string NameOfExample(string param)
        {
            if (string.IsNullOrEmpty(param))
            {
                throw new ArgumentException(message:"Cannot be blank", paramName: nameof(param));
            }
            
            return param;
        }
    }

    public static class ExceptionsFeatures
    {
        public static bool LogException(this Exception e)
        {
            Console.Error.WriteLine(@"Exceptions happen: {e}");
            return false;
        }
    }
}