using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Xunit;

namespace bdd.workshop.calculator.tests.tdd.steps
{
    [Binding]
    public sealed class Calculator
    {
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
            _scenarioContext.Add("Result", Operator.Add(firstNumber, secondNumber));
        }

        [Then(@"the result should be (.*)")]
        [Then(@"the result shall be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            Assert.True(result == _scenarioContext.Get<int>("Result"));
        }

        [When(@"I substract first number to second number")]
        public void WhenISubstractFirstNumberToSecondNumber()
        {
            var firstNumber = _scenarioContext.Get<int>("FirstNumber");
            var secondNumber = _scenarioContext.Get<int>("SecondNumber");
            _scenarioContext.Add("Result", Operator.Substract(firstNumber, secondNumber));
        }

        [When(@"I multiply both numbers")]
        public void WhenIMultiplyBothNumbers()
        {
            var firstNumber = _scenarioContext.Get<int>("FirstNumber");
            var secondNumber = _scenarioContext.Get<int>("SecondNumber");
            _scenarioContext.Add("Result", Operator.Multiply(firstNumber, secondNumber));
        }

        [When(@"I divide first number by second number")]
        public void WhenIDivideFirstNumberBySecondNumber()
        {
            var firstNumber = _scenarioContext.Get<int>("FirstNumber");
            var secondNumber = _scenarioContext.Get<int>("SecondNumber");
            _scenarioContext.Add("Result", Operator.Divide(firstNumber, secondNumber));
        }

        [When(@"I take the square root of first number")]
        public void WhenIRootFirstNumberBySecondNumber()
        {
            var firstNumber = _scenarioContext.Get<int>("FirstNumber");
            _scenarioContext.Add("Result", Operator.SqrRoot(firstNumber));
        }

        [Then(@"the result is (.*)")]
        public void ThenTheResultIs(double result)
        {
            Assert.True(result == _scenarioContext.Get<double>("Result"));
        }

    }
}
