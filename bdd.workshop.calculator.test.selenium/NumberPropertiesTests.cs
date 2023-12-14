using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace bdd.workshop.calculator.test.selenium
{
    public class NumberPropertiesTests : WebBrowser
    {
        [Theory(DisplayName = "Number Properties Prime Number Theory")]
        [Trait("TestType", "Functional Theories")]
        [InlineData(13, true, false, false)]
        [InlineData(86743, true, false, false)]
        [InlineData(1, false, true, false)]
        [InlineData(8, false, true, false)]
        [InlineData(369, false, true, false)]
        [InlineData(0, false, false, true)]
        public void PrimeNumberTest(int number,bool isPrime,bool isNotPrime, bool isUndefined)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            var numberXPath = @"//input[@id='TheNumber']";
            var submitButton = "//input[@type='submit']";
            Driver.Url = "https://bddworkshopcalculatorwebugr.azurewebsites.net/NumberProperties";
            var inputA = FindElement(numberXPath, wait);
            var button = FindElement(submitButton, wait);
            inputA.SendKeys(number.ToString());
            button.Click();
            var isPrimeNumberXPath = "//td[@id='isPrimeNumber']";
            var isNotPrimeNumberXPath = "//td[@id='IsNotPrimeNumber']";
            var isUndefinedXPath = "//td[@id='IsUndefined']";
            var isPrimeNumberMark = FindElement(isPrimeNumberXPath, wait).Text == "X";
            var isNotPrimeNumberMark = FindElement(isNotPrimeNumberXPath, wait).Text == "X";
            var isUndefinedMark = FindElement(isUndefinedXPath, wait).Text == "X";
            Assert.True(isPrime == isPrimeNumberMark);
            Assert.True(isNotPrime == isNotPrimeNumberMark);
            Assert.True(isUndefined == isUndefinedMark);
        }
    }
}
