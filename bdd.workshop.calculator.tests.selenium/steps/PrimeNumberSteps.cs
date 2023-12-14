using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace bdd.workshop.calculator.tests.selenium.steps
{
    [Binding]
    public sealed class PrimeNumberSteps : WebBrowser
    {
        private readonly ScenarioContext _scenarioContext;

        public PrimeNumberSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _scenarioContext.Add("Wait", new WebDriverWait(Driver, TimeSpan.FromSeconds(10)));
        }
        [When(@"number (.*) is checked")]
        public void WhenNumberIsChecked(int number)
        {
            var wait = _scenarioContext.Get<WebDriverWait>("Wait");
            var numberXPath = @"//input[@id='TheNumber']";
            var submitButton = "//input[@type='submit']";
            Driver.Url = "https://bddworkshopcalculatorwebugr.azurewebsites.net/NumberProperties";
            var inputA = FindElement(numberXPath, wait);
            var button = FindElement(submitButton, wait);
            inputA.SendKeys(number.ToString());
            button.Click();
        }
        
        [Then(@"the answer to know whether is prime or not is (.*)")]
        public void ThenTheAnswerToKnowWhetherIsPrimeOrNotIsUnknown(string primeNumberInfo)
        {
            var wait = _scenarioContext.Get<WebDriverWait>("Wait");
            var isPrimeNumberXPath = "//td[@id='isPrimeNumber']";
            var isNotPrimeNumberXPath = "//td[@id='IsNotPrimeNumber']";
            var isUndefinedXPath = "//td[@id='IsUndefined']";
            var isPrimeNumberMark = FindElement(isPrimeNumberXPath, wait).Text == "X";
            var isNotPrimeNumberMark = FindElement(isNotPrimeNumberXPath, wait).Text == "X";
            var isUndefinedMark = FindElement(isUndefinedXPath, wait).Text == "X";
            bool isPrime = false;
            bool isNotPrime = false;
            bool isUndefined = false;
            switch (primeNumberInfo)
            {
                case "Yes":
                    isPrime = true;
                    break;
                case "No":
                    isNotPrime = true;
                    break;
                case "Unknown":
                    isUndefined = true;
                    break;
                default:
                    break;
            }
            Assert.True(isPrime == isPrimeNumberMark);
            Assert.True(isNotPrime == isNotPrimeNumberMark);
            Assert.True(isUndefined == isUndefinedMark);
        }
    }
}
