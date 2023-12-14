using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bdd.workshop.calculator.web.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Operate(Models.Calculator calculator)
        {
            ViewData["a"] = calculator.A.TheNumber;
            ViewData["b"] = calculator.B.TheNumber;
            ViewData["operation"] = calculator.Command;
            switch (calculator.Command)
            {
                case ("+"):
                    ViewData["result"] = Operator.Add(calculator.A.TheNumber, calculator.B.TheNumber);
                    break;
                case ("-"):
                    ViewData["result"] = Operator.Substract(calculator.A.TheNumber, calculator.B.TheNumber);
                    break;
                case ("x"):
                    ViewData["result"] = Operator.Multiply(calculator.A.TheNumber, calculator.B.TheNumber);
                    break;
                case ("/"):
                    ViewData["result"] = Operator.Divide(calculator.A.TheNumber, calculator.B.TheNumber);
                    break;
                case ("sqrt"):
                    ViewData["result"] = Operator.Sqrt(calculator.A.TheNumber, calculator.B.TheNumber);
                    break;
                default:

                    break;
            }
            return View();
        }
    }
}
