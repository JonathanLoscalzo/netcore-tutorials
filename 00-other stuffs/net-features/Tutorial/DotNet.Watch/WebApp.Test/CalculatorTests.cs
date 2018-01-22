using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet.Watch_Example.Controllers;
using WebApp.Controllers;
using Xunit;

namespace WebApp.Test
{
    public class CalculatorTests
    {
        [Fact]
        public void TestSum()
        {
            Assert.Equal(9, Calculator.Sum(4, 5));
        }

        [Fact]
        public void TestProduct()
        {
            Assert.Equal(20, Calculator.Product(4, 5));
        }
    }
}
