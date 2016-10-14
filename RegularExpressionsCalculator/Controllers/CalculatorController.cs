using System;
using System.Web.Mvc;
using System.Collections;
using System.Globalization;
using System.Collections.Generic;

namespace RegularExpressionsCalculator.Controllers
{
    public class CalculatorController : Controller
    {
        public ActionResult Calculator()
        {
            ViewBag.SampleText = GetText(); 
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
            var rand = (char) GetRand();
            var set = App_Data.SampleText.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);

            while (string.IsNullOrEmpty(text))
            {
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

        public JsonResult GetOverlayTitle(string key)
        {
            var regexset = App_Data.RegexSymbols.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            return Json(new { Title = regexset.GetString(key) });
        }

        public JsonResult GetOverlayDef(string key)
        {
            var defset = App_Data.RegexDefinitions.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            return Json(new { Definition = defset.GetString(key) });
        }
        
        public JsonResult GetOverlayLinks(string key)
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
        #endregion
    }
}