using Microsoft.AspNetCore.Mvc;

namespace XssScanerTests.Controllers
{
    public class ExamplesController : Controller
    {
        public IActionResult StoredXSS(string input)
        {
            //"<script>alert('XSS')</script>

            var fileName = "TextFiles/reviews.txt";

            if (!string.IsNullOrEmpty(input))
            {
                using var sw = new StreamWriter(fileName, true);
                sw.Write(input + "   ");
                sw.Close();
            }

            using var sr = new StreamReader(fileName);
            var reviews = sr.ReadToEnd();
            ViewBag.Reviews = reviews;
            sr.Close();

            return View();
        }

        public IActionResult ReflectedXss(string urlParameter)
        {
            //?urlParameter=<script>alert('XSS')</script>

            ViewBag.UrlParameter = urlParameter;
            return View();
        }

        public IActionResult CodingWeakness(string input)
        {
            //javascript:alert(document.cookie)

            ViewBag.Input = input;
            return View();
        }
    }
}
