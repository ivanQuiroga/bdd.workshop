using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace bdd.workshop.calculator.test.selenium
{
    public class CalculatorTests : WebBrowser
    {
        private void EvaluateOperation(int a, int b, string operation, double result)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            var aXpath = "//input[@id='A_TheNumber']";
            var bXpath = "//input[@id='B_TheNumber']";
            var cmdXpath = "//input[@id='Command']";
            var submitButton = "//input[@type='submit']";
            Driver.Url = "https://bddworkshopcalculatorwebugr.azurewebsites.net/Calculator";
            var inputA = FindElement(aXpath, wait);
            var inputCmd = FindElement(cmdXpath, wait);
            var inputB = FindElement(bXpath, wait);
            var button = FindElement(submitButton, wait);
            inputA.SendKeys(a.ToString());
            inputCmd.SendKeys(operation);
            inputB.SendKeys(b.ToString());
            button.Click();
            var theResult = "//td[@id='theResult']";
            var outputResultString = FindElement(theResult, wait).Text;
            Assert.True(double.TryParse(outputResultString, out double outputResult));
            Assert.True(result == outputResult);
        }

        [Theory(DisplayName ="Operations Theory")]
        [Trait("TestType", "Functional Theories")]
        [InlineData(1, "+", 2, 3)]
        [InlineData(10, "x", 4, 40)]
        [InlineData(20, "/", 4, 5)]
        [InlineData(20, "-", 4, 16)]
        [InlineData(10, "/", 4, 2.5)]
        public void OperationsTheory(int a, string operation, int b, double result)
        {
            EvaluateOperation(a, b, operation, result);
        }
        /// ***** COMMENTS ARE LEFT FOR COMPARISSON PURPOSES ONLY////
        //[Fact]
        //[Trait("TestType", "FT")]
        //public void BasicAdd()
        //{
        //    int a = 1;
        //    int b = 2;
        //    double result = 3;
        //    string operation = "+";
        //    EvaluateOperation(a, b, operation, result);
        //}
        //[Fact]
        //[Trait("TestType", "FT")]
        //public void BasicMultiply()
        //{
        //    int a = 10;
        //    int b = 4;
        //    double result = 40;
        //    string operation = "x";
        //    EvaluateOperation(a, b, operation, result);
        //}
        //[Fact]
        //[Trait("TestType", "FT")]
        //public void BasicDivide()
        //{
        //    int a = 20;
        //    int b = 4;
        //    double result = 5;
        //    string operation = "/";
        //    EvaluateOperation(a, b, operation, result);
        //}

        //[Fact]
        //[Trait("TestType", "FT")]
        //public void BasicSubstract()
        //{
        //    int a = 20;
        //    int b = 4;
        //    double result = 16;
        //    string operation = "-";
        //    EvaluateOperation(a, b, operation, result);
        //}
        //[Fact]
        //[Trait("TestType", "FT")]
        //public void DividingNonIntegerResult()
        //{
        //    int a = 10;
        //    int b = 4;
        //    double result = 2.5;
        //    string operation = "/";
        //    EvaluateOperation(a, b, operation, result);
        //}
    }
}
