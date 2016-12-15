using System;
using System.Web.Mvc;
using System.Resources;
using System.Collections;
using System.Globalization;
using System.Collections.Generic;

namespace RegularExpressionsCalculator.Controllers
{
    public class RootController : Controller
    {
        /// <summary>
        /// gets a random int in the ASCII character range for capital letters. used by CalculatorController.
        /// </summary>
        /// <returns></returns>
        public int getRandCharUpper()
        {
            return new Random().Next(64, 91);
        }

        /// <summary>
        /// gets a resource set from one of the resource files. used by all controllers.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ResourceSet getResources(string name)
        {
            ResourceSet resource;
            if (name == "error") resource = App_Data.ErrorMessages.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            else if (name == "keywords") resource = App_Data.Keywords.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            else if (name == "overlay") resource = App_Data.OverlayContent.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            else if (name == "links") resource = App_Data.MenuLinks.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            else if (name == "plaintext") resource = App_Data.RegexPlainText.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            else resource = App_Data.SampleAnalysisText.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);

            return resource;
        }

        /// <summary>
        /// gets text for overlay-def div in _Overlay. queries resource
        /// file using key and returns text for entry in overlay-def div.
        /// the overlay is used by all three views.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public JsonResult getContent(string key)
        {
            var set = getResources("overlay");
            var split = set.GetString(key).Split(';');
            return Json(new KeyValuePair<string, string>(split[0], split[1]), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// gets link text for overlay-link div in _Overlay. queries resource file using a key
        /// and returns list for entry in title div. the overlay is used by all three views.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public JsonResult getLinks(string key)
        {
            var list = new List<KeyValuePair<string, string>>();
            var set = getResources("links");
            var links = set.GetString(key).Split(';');

            foreach (var link in links)
            {
                var split = link.Split(',');
                list.Add(new KeyValuePair<string, string>(split[0], split[1]));
            }

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// gets key words for overlay-keywords div in _Overlay. queries resource file using a
        /// key and returns text for entry in keywords div. the overlay is used by all three views.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public JsonResult getKeywords(string input)
        {
            var words = string.Empty;
            var set = getResources("keywords");
            while (string.IsNullOrEmpty(words))
            {
                foreach (DictionaryEntry entry in set)
                {
                    if (entry.Key.ToString().Equals(input)) words = entry.Value.ToString();
                }
            }
            return Json(words, JsonRequestBehavior.AllowGet);
        }
    }
}