using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bdd.workshop.calculator.web.Controllers
{
    public class NumberPropertiesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Properties(Models.Number number)
        {
            ViewData["Number"] = number.TheNumber;
            var primeNumberInfo = Operator.IsPrimeNumber((int) number.TheNumber);
            switch (primeNumberInfo)
            {
                case PrimeNumberInfo.Yes:
                    ViewData["IsNotPrimeNumber"] = string.Empty;
                    ViewData["IsPrimeNumber"] = "X";
                    ViewData["IsUndefined"] = string.Empty;
                    break;
                case PrimeNumberInfo.No:
                    ViewData["IsNotPrimeNumber"] = "X";
                    ViewData["IsPrimeNumber"] = string.Empty;
                    ViewData["IsUndefined"] = string.Empty;
                    break;
                case PrimeNumberInfo.Unknown:
                    ViewData["IsNotPrimeNumber"] = string.Empty;
                    ViewData["IsPrimeNumber"] = string.Empty;
                    ViewData["IsUndefined"] = "X";
                    break;
                default:
                    break;
            }
            return View();
        }
    }
}
