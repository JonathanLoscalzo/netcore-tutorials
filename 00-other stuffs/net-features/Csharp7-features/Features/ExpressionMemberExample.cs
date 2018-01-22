using System;

namespace Csharp7_features.Features
{
    public class ExpressionMemberExample
    {
        // Expression-bodied constructor
        public ExpressionMemberExample(string label) => this.Label = label;
        
        // Expression-bodied finalizer
        ~ExpressionMemberExample() => Console.Error.WriteLine("Finalized!");
        private string label;
        
        // Expression-bodied get / set accessors.
        public string Label
        {
            get => label;
            set => this.label = value ?? "Default label";
        }
    }
}