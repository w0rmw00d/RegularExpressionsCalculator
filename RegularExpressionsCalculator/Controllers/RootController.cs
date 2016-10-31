using System;
using System.Web.Mvc;
using System.Collections;
using System.Globalization;
using System.Collections.Generic;

namespace RegularExpressionsCalculator.Controllers
{
    public class RootController : Controller
    {
        /// <summary>
        /// gets a random int in the ASCII character range.
        /// </summary>
        /// <returns></returns>
        public int getCharRand()
        {
            Random random = new Random();
            return random.Next(65, 90);
        }

        /// <summary>
        /// gets title for overlay-title div in _Overlay. queries resource
        /// file using key and returns resource for entry in title div.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public JsonResult getOverlayTitle(string key)
        {
            var regexset = App_Data.RegexSymbols.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            return Json(new { Title = regexset.GetString(key) });
        }

        /// <summary>
        /// gets text for overlay-def div in _Overlay. queries resource
        /// file using key and returns text for entry in overlay-def div.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public JsonResult getOverlayDef(string key)
        {
            var defset = App_Data.RegexDefinitions.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            return Json(new { Definition = defset.GetString(key) });
        }

        /// <summary>
        /// gets link text for overlay-link div in _Overlay. queries resource
        /// file using key and returns list for entry in title div.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
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

        /// <summary>
        /// gets key words for overlay-keywords div in _Overlay. queries resource
        /// file using key and returns text for entry in keywords div.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public JsonResult getOverlayKeyWords(string input)
        {
            var words = string.Empty;
            var keySet = App_Data.TextKeys.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            while (string.IsNullOrEmpty(words))
            {
                foreach (DictionaryEntry entry in keySet)
                {
                    if (entry.Key.ToString().Equals(input)) words = entry.Value.ToString();
                }
            }
            return Json(new { keyWords = words });
        }
    }
}