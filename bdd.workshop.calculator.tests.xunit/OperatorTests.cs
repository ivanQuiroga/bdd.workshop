using System;
using Xunit;

namespace bdd.workshop.calculator.tests.xunit
{
    public class OperatorTests
    {
        [Theory(DisplayName = "Square Root Theory")]
        [Trait("TestType", "Theory")]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(4, 2)]
        [InlineData(9, 3)]
        [InlineData(16, 4)]
        [InlineData(25, 5)]
        [InlineData(36, 6)]
        [InlineData(49, 7)]
        [InlineData(64, 8)]
        [InlineData(81, 9)]
        [InlineData(-1, double.MinValue)]
        public void CalculateSquareRoot(double square, double root)
        {
            Assert.True(Operator.SqrRoot(square) == root);
        }

        [Fact]
        [Trait("TestType", "UT")]
        public void BasicAdd()
        {
            int a = 1;
            int b = 2;
            double result = 3;
            Assert.True(Operator.Add(a, b) == result);
        }
        [Fact]
        [Trait("TestType", "UT")]
        public void BasicMultiply()
        {
            int a = 10;
            int b = 4;
            double result = 40;
            Assert.True(Operator.Multiply(a, b) == result);
        }

        [Theory(DisplayName ="Division Theory")]
        [Trait("TestType", "Theory")]
        [InlineData(20, 4, 5)]
        [InlineData(10, 4, 2.5)]
        public void DivisionTheory(int a, int b, double result)
        {
            Assert.True(Operator.Divide(a, b) == result);
        }
        //[Fact]
        //[Trait("TestType", "UT")]
        //public void BasicDivide()
        //{
        //    int a = 20;
        //    int b = 4;
        //    double result = 5;
        //    Assert.True(Operator.Divide(a, b) == result);
        //}

        [Fact]
        [Trait("TestType", "UT")]
        public void BasicSubstract()
        {
            int a = 20;
            int b = 4;
            double result = 16;
            Assert.True(Operator.Substract(a, b) == result);
        }
        //[Fact]
        //[Trait("TestType","NRT")]
        //public void DividingNonIntegerResult()
        //{
        //    int a = 10;
        //    int b = 4;
        //    double result = 2.5;
        //    Assert.True(Operator.Divide(a, b) == result);
        //}

        [Theory(DisplayName ="Prime Number Theory")]
        [Trait("TestType","Theory")]
        [InlineData(0, PrimeNumberInfo.Unknown)]
        [InlineData(1, PrimeNumberInfo.No)]
        [InlineData(2, PrimeNumberInfo.Yes)]
        [InlineData(3, PrimeNumberInfo.Yes)]
        [InlineData(4, PrimeNumberInfo.No)]
        [InlineData(5, PrimeNumberInfo.Yes)]
        [InlineData(6, PrimeNumberInfo.No)]
        [InlineData(7, PrimeNumberInfo.Yes)]
        [InlineData(8, PrimeNumberInfo.No)]
        [InlineData(9, PrimeNumberInfo.No)]
        [InlineData(10, PrimeNumberInfo.No)]
        [InlineData(11, PrimeNumberInfo.Yes)]
        [InlineData(997, PrimeNumberInfo.Yes)]
        [InlineData(98689, PrimeNumberInfo.Yes)]
        [InlineData(86743, PrimeNumberInfo.Yes)]
        public void IsThisNumberPrime(int number,PrimeNumberInfo isPrimeNumber)
        {
            Assert.True(isPrimeNumber == Operator.IsPrimeNumber(number) );
        }
    }
}
