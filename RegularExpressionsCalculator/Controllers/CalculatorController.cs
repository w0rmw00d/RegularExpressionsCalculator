using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections;
using System.Globalization;
using System.Collections.Generic;
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
            var split = getSampleText().Split('\n');
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
        public string getSampleText()
        {
            var text = string.Empty;
            var set = App_Data.SampleAnalysisText.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);

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
        /// fetches a list of keywords from the Keywords resource file. called by interpretPlainText. 
        /// </summary>
        /// <returns></returns>
        public List<string> getKeywords()
        {
            var list = new List<string>();
            var keySet = App_Data.Keywords.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            foreach (DictionaryEntry entry in keySet)
            {
                var value = entry.Value.ToString().Split(',');
                foreach (var item in value)
                {
                    list.Add(item);
                }
            }
            return list;
        }

        /// <summary>
        /// parses out regex symbols from overlay content and creates list of symbols and keys. called by interpretRegEx.
        /// </summary>
        /// <returns></returns>
        public List<Tuple<string, string>> getSymbols()
        {
            var list = new List<Tuple<string, string>>();
            var keySet = App_Data.OverlayContent.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            foreach (DictionaryEntry entry in keySet)
            {
                var value = entry.Value.ToString().Split(';');
                list.Add(Tuple.Create(value[0], entry.Key.ToString()));
            }
            return list;
        }

        /// <summary>
        /// splits input on metacharacters '\', '?', '^', ']', '}', ')', or '$'.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string[] splitRegEx(string input)
        {
            // capture patterns for each of the metacharacters, followed by one or more non-metacharacters
            var patterns = @"?[^\\$]+" + @"\\[^\\]+" + @"$[^$]+" + @"\$" + @"]" + @"}" + @"]";
            return Regex.Split(input, patterns);
        }

        /// <summary>
        /// returns key for variety of range or group types.
        /// NOTE: since range or group contents vary wildly, this
        /// has to be parsed explicitly.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string filterGroupsAndRanges(string input)
        {
            var key = string.Empty;

            // filtering for quantifiers
            if (input.Contains('{'))
            {
                if (!input.Contains(',')) key = "Exact";
                else if (input.Contains(",}")) key = "RangeQuantMore";
                else key = "RangeQuant";
            }
            // filtering for assertions or groups
            else if (input.Contains('('))
            {
                if (input.Contains("?(") && !input.Contains('|')) key = "IfThen";
                else if (input.Contains("?(")) key = "IfThenElse";
                else if (input.Contains("(?:")) key = "PassiveRange";
                else if (input.Contains('|')) key = "OrRange";
                else key = "GroupRange";
            }
            // filtering for ranges
            else if (input.Contains('['))
            {
                if (input.Contains('^') && !input.Contains('-')) key = "NonOr";
                else if (input.Contains('^')) key = "NonRange";
                else if (input.Contains('-')) key = "BracketRange";
                else key = "OrBracket";
            }
            
            return key;
        }

        public string filterExactMatches(string input)
        {
            List<Tuple<string, string>> list = getSymbols();
            return list.FirstOrDefault(a => a.Item2.Contains(input)).Item2;
        }

        /// <summary>
        /// returns key for variety of special cases.
        /// NOTE: since special cases can vary wildly,
        /// this has to be parsed explicitly.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string filterSpecialCases(string input)
        {
            var key = string.Empty;
            int number;
            
            // filtering for hex by attempting to parse input substring as hex number
            if (int.TryParse(input.Split('x')[1], NumberStyles.HexNumber, CultureInfo.CurrentUICulture, out number))
            {
                key = "HexStrChar";
            }
            // filtering for octal characters by searching string for values less than '0' or greater than '7'
            else if(isOctal(input.Split('\\')[1]))
            {
                key = "OctalStr";
            }
            // filtering for any subpattern following '\'
            else if (input.Contains('\\'))
            {
                key = "Subpattern";
            }
            return key;
        }

        /// <summary>
        /// trivial caller for three methods used to find the key for a plain text interpretation of regex patterns.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string getKey(string input)
        {
            var key = string.Empty;
            while(string.IsNullOrEmpty(key))
            {
                filterExactMatches(input);
                filterGroupsAndRanges(input);
                filterSpecialCases(input);
            }

            return key;
        }

        public string getRawPattern(string input)
        {
            var list = getSymbols().Select(a => a.Item1);
            foreach(var item in list)
            {
                // if the input contains an exact match, remove special characters
                if (input.Contains(item))
                {
                    var index = input.IndexOf(item);
                    return input.Remove(index, item.Length);
                }
                // if the input contains a group or range, remove special characters and return formatted string
                else if (!string.IsNullOrEmpty(filterGroupsAndRanges(item)))
                {
                    var pattern = string.Empty;

                    foreach(char c in item)
                    {
                        if ((c >= 48 && c <= 57) || (c >= 65 && c <= 90) || (c <= 97 && c >= 122)) pattern = string.Concat(pattern, c);
                    }
                }
                else if (!string.IsNullOrEmpty(filterSpecialCases(item)))
                {

                }
            }
            return null;
        }

        public bool isOctal(string candidate)
        {
            foreach(char c in candidate)
            {
                if (c <= '0' && c >= '7') return false;
            }
            return true;
        }

        /// <summary>
        /// substitutes raw pattern for placeholders in values from resource file RegexPlainText.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string replaceGenerics(string input, string raw)
        {
            var keySet = App_Data.RegexPlainText.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            var generic = keySet.GetString(getKey(input));

            if (generic.Contains(" z"))
            {

            }
            else if (generic.Contains(" y"))
            {

            }
            else
            {

            }

            return null;
        }

        /// <summary>
        /// interprets input, calls splitRegEx to split input into commands,
        /// calls getSymbols to find list of symbols and keys, compares symbols
        /// to list to get keys for plain text interpretation, translates patterns
        /// without direct match into plain text, and returns plain text translation.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public JsonResult interpretRegEx(string input)
        {
            var message = string.Empty;
            var split = splitRegEx(input);
           

            foreach (var item in split)
            {
                var interpreted = replaceGenerics(item, getRawPattern(item));
                message = string.Concat(message, interpreted, " "); 
            }

            return Json(new { Interpreted = message });
        }

        /// <summary>
        /// interprets input, splitting it on keywords from a resource file, and attempts to parse
        /// it as regex, sending the results back to the page as a regex string for display in user-exp.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public JsonResult interpretPlainText(string input)
        {
            var expression = string.Empty;
            return Json(new { Interpreted = expression });
        }
        #endregion
    }
}