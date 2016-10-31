using System.Web.Mvc;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace RegularExpressionsCalculator.Controllers
{
    public class CalculatorController : RootController
    {
        /// <summary>
        /// controller for calculator view. fetches randomized text from resource file and
        /// formats it for display in the calculator view. serves as application home page.
        /// </summary>
        /// <returns></returns>
        public ActionResult Calculator()
        {
            var split = getText().Split('\n');
            var formatted = string.Empty;
            foreach (var item in split)
            {
                formatted = string.Concat(formatted, item, "<br/>");
            }
            ViewBag.SampleText = formatted;
            return View();
        }

        #region Helpers
        /// <summary>
        /// fetches randomized text from resource file. calls getRand in Root to get randomized  
        /// digit in ASCII character range and interprets randomized digit as character, then 
        /// compares it to the first letter of each resource title in SampleText to select text.
        /// </summary>
        /// <returns></returns>
        public string getText()
        {
            var text = string.Empty;
            var set = App_Data.SampleText.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);

            while (string.IsNullOrEmpty(text))
            {
                var rand = (char) getCharRand();
                foreach (DictionaryEntry entry in set)
                {
                    var firstChar = entry.Key.ToString().ToUpper().ToCharArray()[0];
                    if (firstChar == rand || firstChar + 5 <= rand || firstChar - 5 >= rand)
                    {
                        text = entry.Value.ToString();
                    }
                }
            }
            return text;
        }

        /// <summary>
        /// interprets input, splitting on '\', and attempts to parse it into
        /// commands, then fetches plain text interpretation from resource file.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public JsonResult interpretRegEx(string input)
        {
            var message = string.Empty;
            var split = Regex.Split(input, @"\\[^\]");
            var keySet = App_Data.RegexText.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            foreach (DictionaryEntry entry in keySet)
            {
                foreach(var item in split)
                {
                    if (entry.Value.ToString().Contains(item))
                    {
                        message = string.Concat(message, entry.Key, " ");
                    }
                }
            }

            return Json(new { interpreted = message });
        }

        /// <summary>
        /// interprets input, splitting it on keywords from a resource file, and attempts to parse
        /// it as regex, sending the results back to the page as a regex string for display in user-exp.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public JsonResult interpretPlainText(string input)
        {
            var message = string.Empty;
            return Json(new { interpreted = message });
        }
        #endregion
    }
}