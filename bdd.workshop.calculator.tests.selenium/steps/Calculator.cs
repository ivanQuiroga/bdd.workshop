using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Xunit;

namespace bdd.workshop.calculator.tests.selenium.steps
{
    [Binding]
    public sealed class Calculator : WebBrowser
    {
        private double EvaluateOperation(int a, int b, string operation)
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

            return double.Parse(outputResultString);
        }

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public Calculator(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"the first number is (.*)")]
        public void GivenTheFirstNumberIs(int firstNumber)
        {
            _scenarioContext.Add("FirstNumber", firstNumber);
        }

        [Given(@"the second number is (.*)")]
        public void GivenTheSecondNumberIs(int secondNumber)
        {
            _scenarioContext.Add("SecondNumber", secondNumber);
        }

        [When(@"the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            var firstNumber = _scenarioContext.Get<int>("FirstNumber");
            var secondNumber = _scenarioContext.Get<int>("SecondNumber");
            _scenarioContext.Add("Result", EvaluateOperation(firstNumber, secondNumber, "+"));
        }

        [Then(@"the result should be (.*)")]
        [Then(@"the result shall be (.*)")]
        public void ThenTheResultShouldBe(double result)
        {
            Assert.True(result == _scenarioContext.Get<double>("Result"));
        }

        [When(@"I substract first number to second number")]
        public void WhenISubstractFirstNumberToSecondNumber()
        {
            var firstNumber = _scenarioContext.Get<int>("FirstNumber");
            var secondNumber = _scenarioContext.Get<int>("SecondNumber");
            _scenarioContext.Add("Result",EvaluateOperation(firstNumber, secondNumber, "-"));
        }

        [When(@"I multiply both numbers")]
        public void WhenIMultiplyBothNumbers()
        {
            var firstNumber = _scenarioContext.Get<int>("FirstNumber");
            var secondNumber = _scenarioContext.Get<int>("SecondNumber");
            _scenarioContext.Add("Result", EvaluateOperation(firstNumber, secondNumber, "x"));
        }

        [When(@"I divide first number by second number")]
        public void WhenIDivideFirstNumberBySecondNumber()
        {
            var firstNumber = _scenarioContext.Get<int>("FirstNumber");
            var secondNumber = _scenarioContext.Get<int>("SecondNumber");
            _scenarioContext.Add("Result", EvaluateOperation(firstNumber, secondNumber, "/"));
        }


        [When(@"I take the root of first number using the second number as the base.")]
        public void WhenIRootFirstNumberBySecondNumber()
        {
            var firstNumber = _scenarioContext.Get<int>("FirstNumber");
            var secondNumber = _scenarioContext.Get<int>("SecondNumber");
            _scenarioContext.Add("Result", EvaluateOperation(firstNumber, secondNumber, "sqrt"));
        }


        [Then(@"the result is (.*)")]
        public void ThenTheResultIs(double result)
        {
            Assert.True(result == _scenarioContext.Get<double>("Result"));
        }
        private void EvaluateNumberBox(int expectedNumber, string numberXPath)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            var textInBox = FindElement(numberXPath, wait).Text;
            Assert.True(int.TryParse(textInBox, out int numberInBox), $"{textInBox} is not an integer");
            Assert.True(numberInBox == expectedNumber);
        }
        [Then(@"displayed first name is (.*)")]
        public void ThenDisplayedFirstNameIs(int firstNumber)
        {
            EvaluateNumberBox(firstNumber, "//td[@id='theA']");
        }
        [Then(@"displayed second name is (.*)")]
        public void ThenDisplayedSecondNameIs(int secondNumber)
        {
            EvaluateNumberBox(secondNumber, "//td[@id='theB']");
        }
    }
}
