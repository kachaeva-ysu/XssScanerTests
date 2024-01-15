using Microsoft.AspNetCore.Mvc;

namespace XssScanerTests.Controllers
{
    public class TestsController : Controller
    {
        public async Task<IActionResult> DOMBasedXSS()
        {
            // #<script>alert('XSS')</script>

            return View();
        }

        public async Task<IActionResult> OutsideOfTag(string input)
        {
            // <script>alert('XSS')</script>

            ViewBag.Input = input;
            return View();
        }

        public async Task<IActionResult> InsideTagSingleQuotes(string input)
        {
            // foo' onerror="alert('XSS')" src name='bar

            ViewBag.Input = input;
            return View();
        }

        public async Task<IActionResult> InsideTagDoubleQuotes(string input)
        {
            // foo" onerror="alert('XSS')" src name="bar

            ViewBag.Input = input;
            return View();
        }

        public async Task<IActionResult> InsideTagOutsideQuotes(string input)
        {
            // foo onerror="alert('XSS')" src

            ViewBag.Input = input;
            return View();
        }

        public async Task<IActionResult> InsideComment(string input)
        {
            // --><script>alert('XSS')</script>

            ViewBag.Input = input;
            return View();
        }

        public async Task<IActionResult> InsideScriptTagSingleQuotes(string input)
        {
            // foo'); alert('XSS

            ViewBag.Input = input;
            return View();
        }

        public async Task<IActionResult> InsideScriptTagDoubleQuotes(string input)
        {
            // foo"); alert("XSS

            ViewBag.Input = input;
            return View();
        }

        public async Task<IActionResult> InsideScriptTagOutsideQuotes(string input)
        {
            // 'foo'); alert('XSS'

            ViewBag.Input = input;
            return View();
        }
    }
}