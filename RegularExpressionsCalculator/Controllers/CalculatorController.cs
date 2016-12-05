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
            ViewBag.SampleText = parseSample(getSampleText().Split('\n'));
            return View();
        }

        #region Helpers
        /// <summary>
        /// parses sample text into string containing raw HTML for sample-text div on the Calculator view.
        /// </summary>
        /// <param name="text"></param>
        /// <returns name="formatted"></returns>
        public string parseSample(string[] text)
        {
            var formatted = string.Empty;
            foreach (var item in text) formatted = string.Concat(formatted, item, "<br/>");
            return formatted;
        }

        /// <summary>
        /// fetches randomized text from resource file. calls getRandCharUpper in Root to get a  
        /// randomized digit in ASCII upper character range and interprets digit as character, then 
        /// compares it to the first letter of each resource key in SampleAnalysisText to select text.
        /// NOTE: due to few texts in SampleAnalysisText, this is designed to run until a match is found.
        /// Because it instantiates a random number generator each time, it may effect performance. 
        /// The range is designed to make it match faster to reduce repeat calls to Random.
        /// </summary>
        /// <returns name="text"></returns>
        public string getSampleText()
        {
            var text = string.Empty;
            var set = getResources("sample");

            while (string.IsNullOrEmpty(text))
            {
                var rand = (char) getRandCharUpper();
                foreach (DictionaryEntry entry in set)
                {
                    var firstChar = entry.Key.ToString().ToUpper().ToCharArray()[0];
                    if (firstChar + 5 <= rand || firstChar - 5 >= rand) text = entry.Value.ToString();
                }
            }
            return text;
        }

        /// <summary>
        /// fetches a list of keywords from the Keywords resource file with their associated key. called by 
        /// interpretPlainText and used while attempting to identify key words and phrases in plain text input. 
        /// NOTE: list generated may be greater than several hundred entries in length.
        /// </summary>
        /// <returns></returns>
        public List<Tuple<string, string>> getKeywordList()
        {
            var list = new List<Tuple<string, string>>();
            var set = getResources("keywords");
            foreach (DictionaryEntry entry in set)
            {
                var split = entry.Value.ToString().Split(',');
                foreach (var item in split) list.Add(Tuple.Create(entry.Key.ToString(), item));
            }
            return list;
        }

        /// <summary>
        /// parses out regex symbols from overlay content and creates list of symbols and their key. called by interpretRegEx.
        /// </summary>
        /// <returns></returns>
        public List<Tuple<string, string>> getSymbols()
        {
            var list = new List<Tuple<string, string>>();
            var set = getResources("overlay");
            foreach (DictionaryEntry entry in set)
            {
                var value = entry.Value.ToString().Split(';');
                list.Add(Tuple.Create(value[0], entry.Key.ToString()));
            }
            return list;
        }

        /// <summary>
        /// splits input string on metacharacters '\', '?', '^', ']', '}', ')', '}?', or '$'.
        /// NOTE: is designed to split on end brackets and after any sequence following a metacharacter.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string[] splitRegEx(string input)
        {
            // capture patterns for each of the metacharacters, followed by one or more non-metacharacters
            var patterns = @"?[^\\$]+" + @"\\[^\\]+" + @"$[^$]+" + @"\$" + @"]" + @"}?" + @"}" + @"]";
            return Regex.Split(input, patterns);
        }

        /// <summary>
        /// returns key for variety of range or group types based on contents of input subphrase.
        /// NOTE: since range or group contents vary wildly, this has to be parsed explicitly.
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

        /// <summary>
        /// scans input for exact matches to regex symbols and returns key.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string filterExactMatches(string input)
        {
            List<Tuple<string, string>> list = getSymbols();
            return list.FirstOrDefault(a => a.Item2.Contains(input)).Item2;
        }

        /// <summary>
        /// returns key for variety of special cases. Special cases include any pattern following a metacharacter.
        /// NOTE: since special cases vary wildly, this has to be parsed explicitly.
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
            else if (input.Contains(@"\"))
            {
                key = "Subpattern";
            }
            return key;
        }

        /// <summary>
        /// trivial caller for three methods used to find the key for a plain text interpretation of regex patterns.
        /// NOTE: methods are called in order of ease of matching.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string getRegexKey(string input)
        {
            var key = string.Empty;
            while(string.IsNullOrEmpty(key))
            {
                key = filterExactMatches(input);
                key = filterGroupsAndRanges(input);
                key = filterSpecialCases(input);
            }
            return key;
        }

        /// <summary>
        /// returns list of common metacharacters. called by getRawPattern and used to filter metacharacters from input.
        /// </summary>
        /// <returns></returns>
        public char[] getMetaChars()
        {
            return new char[] { '{', '}', '(', ')', '?', '|', '>', '<', '=', '!', '#', '^', '\\', '*', '+'};
        }

        /// <summary>
        /// locates pattern portion of input and removes special characters. used to isolate special case
        /// patterns, groups, and ranges, in order to provide the translation with the pattern.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<string> getRawPatternRegex(string input)
        {
            var patterns = new List<string>();
            var list = getSymbols().Select(a => a.Item1);
            var meta = getMetaChars();
            // in case of direct match, return nothing
            if (list.Contains(input)) return null;
            // in case of range, group, or special case, return pattern as list of strings
            else {
                var split = input.Split(meta.ToArray());
                foreach(var item in split)
                {
                    foreach(var metachar in meta)
                    {
                        if (!item.Contains(metachar)) patterns.Add(item);
                    }
                }
                return patterns;
            }
        }

        /// <summary>
        /// scans candidate for chars representing values outside octal range.
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns></returns>
        public bool isOctal(string candidate)
        {
            foreach(char c in candidate)
            {
                if (c <= '0' && c >= '7') return false;
            }
            return true;
        }

        /// <summary>
        /// returns string containing value with placeholders replaced by input patterns.
        /// called by interpretRegEx.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="patterns"></param>
        /// <returns></returns>
        public string replaceGenerics(string value, List<string> patterns)
        {
            foreach(var pattern in patterns)
            {
                var startIndex = value.IndexOf(" x");
                value = string.Concat(value.Substring(0, startIndex), " ", pattern, " ", value.Substring(startIndex + pattern.Length + 2, value.Length));
            }
            return value;
        }

        /// <summary>
        /// interprets input. calls splitRegEx to split input into subpatterns, locates
        /// generic interpretation of each subpattern, determines if subpattern contains
        /// patterns which are not a direct match. if subpatterns exist that are not a 
        /// direct match, pull substantive content and generic interpretation, then replace 
        /// placeholder values with content parsed from input subpatterns. returns 
        /// interpretation as message for display in translated-input div on Calculator view.
        /// called via JQuery from the Calculator view whenever input is entered into user-input div.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public JsonResult interpretRegEx(string input)
        {
            var message = string.Empty;
            var split = splitRegEx(input);
            
            foreach(var item in split)
            {
                var key = getRegexKey(item);
                if(!string.IsNullOrEmpty(key)) // if a key exists that corresponds to the current input
                {
                    var value = getResources("plaintext").GetString(key); // look up generic interpretation (value of key)
                    var pattern = getRawPatternRegex(item); // get pattern stripped of metachar, if any
                    if (pattern.Count < 1) message = string.Concat(message, value, " "); // no pattern remains after being stripped of metachar and direct pattern match
                    else // input pattern exists which is not a direct match
                    {
                        message = string.Concat(message, replaceGenerics(value, pattern), " "); // remove placeholders from value and concat to message
                    }
                }
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
            var expression = string.Empty; // placeholder for regex expression
            var substrings = splitPlainText(input); // substrings from input
            var symbols = getResources("overlay"); // symbol list

            foreach(var sub in substrings)
            {
                var key = getTextKey(sub); // key for pertinent symbol
                var symbol = symbols.GetString(key).Split(';')[0]; // symbol
                var pattern = getRawPatternPlainText(sub); // pattern from input, stripped of keywords and near-matches with keywords
                expression = string.Concat(expression, symbol);
                // if anything remains after removing near-matches to keywords, add it to the expression as a literal pattern
                if(pattern.Count > 1)
                {
                    foreach(var item in pattern) expression = string.Concat(expression, item);
                }
            }

            return Json(new { Interpreted = expression });
        }

        /// <summary>
        /// locates and removes patterns from plain text input via similarity to keywords.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<string> getRawPatternPlainText(string input)
        {
            var keys = getKeywordList().Select(a => a.Item2);
            var list = new List<string>();
            foreach(var key in keys)
            {
                foreach (var word in input.Split(' '))
                {
                    if (getLevenshteinDistanceRatio(word, key) < .6)
                    {
                        list.Add(word);
                    }
                }
            }
            return list;
        }
        
        /// <summary>
        /// locates and returns key for most likely match between input and keywords.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string getTextKey(string input)
        {
            var keywords = getKeywordList(); // keywords
            var keyMax = string.Empty; // placeholder for most likely key
            double ratioMax = 0;

            foreach (var key in keywords)
            {
                var ratio = getLevenshteinDistanceRatio(input, key.Item2);
                if (ratio > ratioMax) // if the current ratio is better than the max
                {
                    keyMax = key.Item1.ToString();
                }
            }
            return keyMax;
        }

        /// <summary>
        /// creates and returns list of indexes in input for words similar to keywords.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<int> getMatchIndexes(string input)
        {
            var keywords = getKeywordList(); // keywords from resource file
            var wordSplit = input.Split(' '); // split input on white space
            var indexes = new List<int>(); // list of start indexes for keyword matches
            
            foreach (var word in wordSplit)
            {
                foreach (var key in keywords)
                {
                    if (getLevenshteinDistanceRatio(word, key.Item2) > .6) // if the current input word matches a keyword at better than 60%
                    {
                        indexes.Add(Regex.Match(input, word).Index); // add the start index to the list
                    }
                }
            }
            return indexes;
        }

        /// <summary>
        /// splits incoming plain text into chunks based on presence of words similar to keywords.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<string> splitPlainText(string input)
        {
            var indexes = getMatchIndexes(input); // indexes of keyword matches in input
            var inputSplit = new List<string>(); // input after being split on keywords
            // split on start index for keywords located via their Levenshtein replacement cost
            while(!string.IsNullOrEmpty(input))
            {
                foreach(var item in indexes)
                {
                    var substring = input.Substring(0, item);
                    inputSplit.Add(substring);
                    input = input.Remove(0, substring.Length);
                }
            }
            return inputSplit;
        }

        /// <summary>
        /// implementation of the Levenshtein distance algorithm converted to ratio of string length, borrowed from dotnetpearls.com/levenshtein
        /// NOTE: calcuated as ratio on the input only, since the match is one-sided.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static double getLevenshteinDistanceRatio(string input, string keyword)
        {
            int inputLength = input.Length;
            int keywordLength = keyword.Length;
            int[,] similarityMatrix = new int[inputLength + 1, keywordLength + 1];

            // if either string is empty, return zero for no match
            if (inputLength == 0 || keywordLength == 0) return 0;
            // populating matrix according to string lengths
            for (int a = 0; a <= inputLength; similarityMatrix[a, 0] = a++) {}
            for (int a = 0; a <= keywordLength; similarityMatrix[0, a] = a++) {}
            // iterating through strings character by character, calcuating replacement costs, and inputing values into matrix for those costs
            for(int a = 1; a <= inputLength; a++)
            {
                for(int b = 1; b <= keywordLength; b++)
                {
                    int cost = (input[a-1] == keyword[b - 1]) ? 0 : 1; // if match is not found, add point to the cost (of replacement)
                    // the value at each node in the matrix is the minimum of the minimum of either the previous value + 1 or the previous value + the replacement cost
                    // NOTE: matching is calculated on the previous due to offset of one and to prevent access over the matrix size
                    similarityMatrix[a, b] = Math.Min(Math.Min(similarityMatrix[a-1, b] + 1, similarityMatrix[a, b-1] + 1), similarityMatrix[a - 1, b - 1] + cost);
                }
            }
            // returns ratio of similarity as relation from total replacement cost to input string length
            return (similarityMatrix[inputLength, keywordLength] / inputLength);
        }
        #endregion
    }
}