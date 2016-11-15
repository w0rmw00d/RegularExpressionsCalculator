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
        /// gets text for overlay-def div in _Overlay. queries resource
        /// file using key and returns text for entry in overlay-def div.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public JsonResult getOverlayContent(string key)
        {
            var defset = App_Data.OverlayContent.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            var split = defset.GetString(key).Split(';');
            return Json(new { Title = split[0], Content = split[1] });
        }

        /// <summary>
        /// gets link text for overlay-link div in _Overlay. queries resource
        /// file using key and returns list for entry in title div.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public JsonResult getLinks(string key)
        {
            var list = new List<Tuple<string, string>>();
            var linkset = App_Data.MenuLinks.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
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
        public JsonResult getKeywords(string input)
        {
            var words = string.Empty;
            var keySet = App_Data.Keywords.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
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