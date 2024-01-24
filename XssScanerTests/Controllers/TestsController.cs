using Microsoft.AspNetCore.Mvc;
using XssScanerTests.Helpers;

namespace XssScanerTests.Controllers
{
    public class TestsController : Controller
    {
        public IActionResult DOMBasedXSS()
        {
            // #<script>alert('XSS')</script>

            return View();
        }

        public IActionResult OutsideOfTag(string input)
        {
            // <script>alert('XSS')</script>

            ViewBag.Input = input;
            return View();
        }

        public IActionResult InsideTagSingleQuotes(string input)
        {
            // foo' onerror="alert('XSS')" src name='bar

            ViewBag.Input = input;
            return View();
        }

        public IActionResult InsideTagDoubleQuotes(string input)
        {
            // foo" onerror="alert('XSS')" src name="bar

            ViewBag.Input = input;
            return View();
        }

        public IActionResult InsideTagOutsideQuotes(string input)
        {
            // foo onerror="alert('XSS')" src

            ViewBag.Input = input;
            return View();
        }

        public IActionResult InsideComment(string input)
        {
            // --><script>alert('XSS')</script>

            ViewBag.Input = input;
            return View();
        }

        public IActionResult InsideScriptTagSingleQuotes(string input)
        {
            // foo'); alert('XSS

            ViewBag.Input = input;
            return View();
        }

        public IActionResult InsideScriptTagDoubleQuotes(string input)
        {
            // foo"); alert("XSS

            ViewBag.Input = input;
            return View();
        }

        public IActionResult InsideScriptTagOutsideQuotes(string input)
        {
            // 'foo'); alert('XSS'

            ViewBag.Input = input;
            return View();
        }

        public IActionResult DiscussionBoard(string name, string email, string post)
        {
            if (!string.IsNullOrEmpty(post))
                StringHolder.posts += post + "   ";

            ViewBag.Posts = StringHolder.posts;
            ViewBag.Name = name;
            ViewBag.Email = email;

            return View();
        }

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