using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Math;

namespace Csharp7_features.Features
{
    public class NumericLiteralSyntaxFeature
    {
        Comparison<int> comparator = (l, r) => l.CompareTo(r);
        //binary literals,
        public const int Eight = 0b1000;
        public const int Sexteen = 0b1000_0000;

        //and digit separators.
        public const long BillionsAndBillions = 100_000_000_000;

        //The digit separator can be used with decimal , float and double types as well
        public const double AvogadroConstant = 6.022_140_857_747_474e23;
        public const decimal GoldenRatio = 1.618_033_988_749_894_848_204_586_834_365_638_117_720_309_179M;

        private void TestingExample()
        {
            var l = new List<int> { 1, 2, 3, 4, 5, 6 };
            l.Where(x => x>3);
        }
    }
}