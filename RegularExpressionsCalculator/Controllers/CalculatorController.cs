using System;
using System.Web.Mvc;
using System.Collections;
using System.Globalization;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RegularExpressionsCalculator.Controllers
{
    public class CalculatorController : Controller
    {
        public ActionResult Calculator()
        {
            var split = GetText().Split('\n');
            var formatted = string.Empty;
            foreach (var item in split)
            {
                formatted = string.Concat(formatted, item, "<br/>");
            }
            ViewBag.SampleText = formatted;
            return View();
        }

        public ActionResult RegularEngine()
        {
            return View();
        }

        public ActionResult RegularLanguages()
        {
            return View();
        }

        #region Helpers
        public int GetRand()
        {
            Random random = new Random();
            return random.Next(65, 90);
        }

        public string GetText()
        {
            var text = string.Empty;
            var set = App_Data.SampleText.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);

            while (string.IsNullOrEmpty(text))
            {
                var rand = (char) GetRand();
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

        public JsonResult getOverlayTitle(string key)
        {
            var regexset = App_Data.RegexSymbols.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            return Json(new { Title = regexset.GetString(key) });
        }

        public JsonResult getOverlayDef(string key)
        {
            var defset = App_Data.RegexDefinitions.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            return Json(new { Definition = defset.GetString(key) });
        }
        
        public JsonResult getOverlayLinks(string key)
        {
            var list = new List<Tuple<string, string>>();
            var linkset = App_Data.RegexLinks.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            var linkStr = linkset.GetString(key).Split(';');

            foreach (var link in linkStr)
            {
                var split = link.Split(',');
                list.Add(Tuple.Create(split[0], split[1]));
            }
            
            return Json(new { Links = list });
        }

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

        public JsonResult interpretPlainText(string input)
        {
            var message = string.Empty;
            return Json(new { interpreted = message });
        }
        #endregion
    }
}