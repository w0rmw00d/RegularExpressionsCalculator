﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RegularExpressionsCalculator.App_Data {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class OverlayContent {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal OverlayContent() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("RegularExpressionsCalculator.App_Data.OverlayContent", typeof(OverlayContent).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to About Me;bio goes here.
        /// </summary>
        public static string AboutMe {
            get {
                return ResourceManager.GetString("AboutMe", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to $&apos; or \&apos;;After Matched String: This pattern allows the ability to insert a given sequence after the matched pattern..
        /// </summary>
        public static string AfterReplace {
            get {
                return ResourceManager.GetString("AfterReplace", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Anchors;These patterns are used to indicate search boundaries, whether for words, lines, or their negations. .
        /// </summary>
        public static string Anchors {
            get {
                return ResourceManager.GetString("Anchors", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Assertions;These patterns are called assertions because they instruct the regex engine to forget everything but whether or not a match was found for the pattern..
        /// </summary>
        public static string Assert {
            get {
                return ResourceManager.GetString("Assert", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {5, };At Least: These symbols represent a minimum number of matches that the pattern in front of it should try to match. Any matches above the minimum are also counted.  It can also be greedy or lazy, depending on the quantifiers following it..
        /// </summary>
        public static string AtLeast {
            get {
                return ResourceManager.GetString("AtLeast", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to $` or \`;Before Matched String: This pattern allows the ability to insert a given sequence before the matched pattern..
        /// </summary>
        public static string BeforeReplace {
            get {
                return ResourceManager.GetString("BeforeReplace", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \Q;Begin Literal Sequence: This pattern is used to signal the beginning of a sequence that should be interpreted literally, not as a part of a pattern or special instructions to the regular expressions engine..
        /// </summary>
        public static string BeginLiteral {
            get {
                return ResourceManager.GetString("BeginLiteral", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \b;Word Boundary: This pattern signals an empty string that isn&apos;t at the beginning or end of a word..
        /// </summary>
        public static string BoundaryAnchor {
            get {
                return ResourceManager.GetString("BoundaryAnchor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [abc];Bracket Range: These symbols represent a range between the characters inside the brackets which includes all characters in sequence between and including the two characters at each end of the range..
        /// </summary>
        public static string BracketRange {
            get {
                return ResourceManager.GetString("BracketRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ^;Start of String/Line: The caret signals the start of string or multiline pattern..
        /// </summary>
        public static string CaretAnchor {
            get {
                return ResourceManager.GetString("CaretAnchor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Character Classes;These patterns are used to represent special characters and indicate the type of characters for the pattern..
        /// </summary>
        public static string Character {
            get {
                return ResourceManager.GetString("Character", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ?#;Comment: This pattern signals that the following sequence is a comment, and should be ignored by the regular expressions engine.
        /// </summary>
        public static string Comment {
            get {
                return ResourceManager.GetString("Comment", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \c;Control Character: This pattern represents the control button, and can be paired with other characters to signal the effect of pressing both the control button and the button represented by the character following it..
        /// </summary>
        public static string ControlChar {
            get {
                return ResourceManager.GetString("ControlChar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \d;Digit Character: This pattern represents any digit 0-9, as well as digit characters from Unicode, which may include digits from other languages.  .
        /// </summary>
        public static string DigitChar {
            get {
                return ResourceManager.GetString("DigitChar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to $;End of String: The dollar sign signals the end of a string or a line in a multiline pattern..
        /// </summary>
        public static string DollarAnchor {
            get {
                return ResourceManager.GetString("DollarAnchor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \E;End Literal Sequence: This pattern is used to signal the end of a sequence that should be interpreted literally, not as a part of a pattern or special instructions to the regular expressions engine..
        /// </summary>
        public static string EndLiteral {
            get {
                return ResourceManager.GetString("EndLiteral", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to $&amp; or \&amp;;Entire Matched String: This pattern allows the ability to insert a given pattern and replace the entire match or matches..
        /// </summary>
        public static string EntireReplacement {
            get {
                return ResourceManager.GetString("EntireReplacement", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Escape Characters;These patterns are used to indicate that the symbols contained within or just following one of these characters are to be treated literally, instead of as special or reserved characters..
        /// </summary>
        public static string Escape {
            get {
                return ResourceManager.GetString("Escape", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {5};Exact Match: These symbols represent an exact limiter on how many matches should be found. It can also be greedy or lazy, depending on the quantifiers following it..
        /// </summary>
        public static string Exact {
            get {
                return ResourceManager.GetString("Exact", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {5};Exact Range: These symbols represent an exact number of times the pattern is to be matched..
        /// </summary>
        public static string ExactRangeQuant {
            get {
                return ResourceManager.GetString("ExactRangeQuant", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \f;Form Feed: This pattern represents the form feed, or page break character..
        /// </summary>
        public static string FeedChar {
            get {
                return ResourceManager.GetString("FeedChar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to $1 or \1;First Replacement: This pattern allows the ability to replace a given sequence with another in a pattern that has repeating elements..
        /// </summary>
        public static string FirstReplacement {
            get {
                return ResourceManager.GetString("FirstReplacement", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \g;Global Match: This pattern allows a search of all the items  in the given section for matching patterns..
        /// </summary>
        public static string GlobalPattern {
            get {
                return ResourceManager.GetString("GlobalPattern", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to +;Greedy One Match: This symbol represents a match of one or more times, and follows the character or pattern it is meant to find. It is called greedy because it will continue matching through the whole sequence instead of stopping after it finds a match. .
        /// </summary>
        public static string GreedyOne {
            get {
                return ResourceManager.GetString("GreedyOne", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to *;Greedy Zero Match: This symbol represents a match of zero or more times, and follows the character or pattern it is meant to find. It is called greedy because it will continue matching through the whole sequence instead of stopping after it finds a match. This may result in it finding only one match when there are actually many matches because it waits until the end of the sequence to declare a match..
        /// </summary>
        public static string GreedyZero {
            get {
                return ResourceManager.GetString("GreedyZero", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Groups and Ranges;These patterns are used to indicate a group or range for a pattern, rather than a word. Ranges are inclusive and sequential..
        /// </summary>
        public static string Group {
            get {
                return ResourceManager.GetString("Group", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to (...);Group: These symbols represent a grouping, or a collection that has to be considered together for the purposes of matching a pattern..
        /// </summary>
        public static string GroupRange {
            get {
                return ResourceManager.GetString("GroupRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Why isn&apos;t it doing anything?;If there&apos;s an error in your pattern, a popup should appear that tells you what&apos;s wrong. If this does not occur, please contact me..
        /// </summary>
        public static string HelpCalcAnything {
            get {
                return ResourceManager.GetString("HelpCalcAnything", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to What do I do?;Enter any regular expression you wish to test into the input field and press calculate to see what patterns it matches in the sample text..
        /// </summary>
        public static string HelpCalcDo {
            get {
                return ResourceManager.GetString("HelpCalcDo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to I need more help than this.;Toggle the option &apos;Plain Text&apos; on the page beneath the forms..
        /// </summary>
        public static string HelpCalcMore {
            get {
                return ResourceManager.GetString("HelpCalcMore", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Why a regular expressions calculator?;Regular expressions are a necessary part of understanding how to parse text efficiently, but they can be very difficult to understand. This calculator can help you learn them..
        /// </summary>
        public static string HelpCalcWhy {
            get {
                return ResourceManager.GetString("HelpCalcWhy", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to What happens if I enter something wrong?;If you enter a pattern that won&apos;t resolve, a popup will tell you what&apos;s wrong..
        /// </summary>
        public static string HelpCalcWrong {
            get {
                return ResourceManager.GetString("HelpCalcWrong", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \xhh;Hexadecimal Characters: This pattern represents a grouping of hexadecimal characters..
        /// </summary>
        public static string HexStrChar {
            get {
                return ResourceManager.GetString("HexStrChar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ?();If-Then: This pattern looks for a match conditionally, such that if the first condition is met, the second condition is searched for..
        /// </summary>
        public static string IfThen {
            get {
                return ResourceManager.GetString("IfThen", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ?()|;If-Then-Else: This pattern looks for a match conditionally, such that if the first condition is met, the second will be attempted. If it is not able to be matched, the last condition will be attempted..
        /// </summary>
        public static string IfThenElse {
            get {
                return ResourceManager.GetString("IfThenElse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to $+ or \+;Last Matched String: This pattern allows the ability to insert a given pattern and replace the last match..
        /// </summary>
        public static string LastReplacement {
            get {
                return ResourceManager.GetString("LastReplacement", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ?;Lazy Quantifier: This symbol represents a match of only zero or one times, and can be used in tandem with other qualifiers, in addition to on its own, to force matching to stop after the first match is found. It follows either the character or pattern it is meant to match or the quantifier it is meant to restrict..
        /// </summary>
        public static string Lazy {
            get {
                return ResourceManager.GetString("Lazy", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \;Escape the Following: This character represents the request to treat the following character as a literal character, instead of as a part of a special character..
        /// </summary>
        public static string Literal {
            get {
                return ResourceManager.GetString("Literal", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ?=;Lookahead: This pattern looks for a match and returns a true/false result for matching, leaving the engine at the beginning of the match..
        /// </summary>
        public static string Lookahead {
            get {
                return ResourceManager.GetString("Lookahead", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ?&lt;=;Lookbehind: This pattern looks for a match and returns a true/false result for matching, leaving the engine at the end of the match..
        /// </summary>
        public static string Lookbehind {
            get {
                return ResourceManager.GetString("Lookbehind", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Pattern Modifiers;These patterns are used to indicate the extent of matching, or how long the engine should search..
        /// </summary>
        public static string Mod {
            get {
                return ResourceManager.GetString("Mod", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ?!;Negative Lookahead: This pattern looks for a match and returns a true/false result for matching, leaving the engine at the beginning of a sequence that is not the pattern..
        /// </summary>
        public static string NegLookahead {
            get {
                return ResourceManager.GetString("NegLookahead", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ?!= or ?&lt;!;Negative Lookbehind: This pattern looks for a match and returns a true/false result, leaving the engine at the end of a subsequence that is not the requested pattern..
        /// </summary>
        public static string NegLookbehind {
            get {
                return ResourceManager.GetString("NegLookbehind", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \n;New Line: This pattern represents the command to start a new line..
        /// </summary>
        public static string NewLine {
            get {
                return ResourceManager.GetString("NewLine", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \D;Non-Digit Character: This pattern represents any non-digit character..
        /// </summary>
        public static string NonDigit {
            get {
                return ResourceManager.GetString("NonDigit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [^abc];Non-Or Range: These symbols represent a range which are excluded from pattern matching..
        /// </summary>
        public static string NonOr {
            get {
                return ResourceManager.GetString("NonOr", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [^a-q];Non-Range: These symbols represent a range between the characters inside the bracket, up to and including both ends of the range, which are excluded from matching..
        /// </summary>
        public static string NonRange {
            get {
                return ResourceManager.GetString("NonRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \W;Non-Word Characters: This pattern represents any non-word characters..
        /// </summary>
        public static string NonWord {
            get {
                return ResourceManager.GetString("NonWord", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \S;Non-White Space: This pattern represents white space that is not the spacebar, tab, return, or the form feed..
        /// </summary>
        public static string NotSpace {
            get {
                return ResourceManager.GetString("NotSpace", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \B; Non-Word Boundary: This pattern represents any character that is not a word boundary..
        /// </summary>
        public static string NotWordBoundary {
            get {
                return ResourceManager.GetString("NotWordBoundary", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to $n or \n;Nth Non-Passive Replacement: This pattern allows the ability to dictate how many non-passive groups are matched and replaced..
        /// </summary>
        public static string NthReplacement {
            get {
                return ResourceManager.GetString("NthReplacement", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \O;Octal Character: This pattern represents any grouping of digits that represent an octal value..
        /// </summary>
        public static string OctalChar {
            get {
                return ResourceManager.GetString("OctalChar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \xxx;Octal Digits: This pattern represents a grouping of octal characters..
        /// </summary>
        public static string OctalStr {
            get {
                return ResourceManager.GetString("OctalStr", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ?&gt;;Once-Only Subexpression: This pattern looks for a match and returns a true/false result, leaving the engine at the only match for the pattern in the sequence..
        /// </summary>
        public static string OnceOnly {
            get {
                return ResourceManager.GetString("OnceOnly", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [abc];Or Range: These symbols represent a range between the characters inside the brackets such that any of the character or all of them may be matched (exclusive or)..
        /// </summary>
        public static string OrBracket {
            get {
                return ResourceManager.GetString("OrBracket", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to (a|b);Or: These symbols represent an or statement, in which at least one of the alternatives have to be true for the pattern to match..
        /// </summary>
        public static string OrRange {
            get {
                return ResourceManager.GetString("OrRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to (?:...);Passive Range: These symbols represent a grouping which the regex engine doesn&apos;t have to remember--it can be used to match and discarded..
        /// </summary>
        public static string PassiveRange {
            get {
                return ResourceManager.GetString("PassiveRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .;Match Any: This character represents a match of any character except the new line character (\n)..
        /// </summary>
        public static string PeriodRange {
            get {
                return ResourceManager.GetString("PeriodRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Quantifiers;These patterns are used to indicate a frequency for matches, allowing repeated characters or words to be matched according to the number of times specified..
        /// </summary>
        public static string Quant {
            get {
                return ResourceManager.GetString("Quant", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {5,7};Quantity Range: These symbols represent a range of number of matches that the pattern should try to find. It is inclusive, allowing anything including the minimum and up to and including the maximum number of matches.  It can also be greedy or lazy, depending on the quantifiers following it..
        /// </summary>
        public static string RangeQuant {
            get {
                return ResourceManager.GetString("RangeQuant", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to String Replacement;These patterns are used to locate and replace strings and portions of strings..
        /// </summary>
        public static string Replace {
            get {
                return ResourceManager.GetString("Replace", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \r;Return Character: This pattern represents the use of the return button..
        /// </summary>
        public static string ReturnChar {
            get {
                return ResourceManager.GetString("ReturnChar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to $2 or \2;Second Replacement: This pattern allows the ability to replace a given sequence with another in a pattern that does not repeat. .
        /// </summary>
        public static string SecondReplacement {
            get {
                return ResourceManager.GetString("SecondReplacement", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \s;White Space Character: This pattern represents white space created by the spacebar or the use of the tab..
        /// </summary>
        public static string SpaceChar {
            get {
                return ResourceManager.GetString("SpaceChar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Special Characters;These patterns are reserved characters, used to indicate non-digit or letter characters which can be included in strings..
        /// </summary>
        public static string Special {
            get {
                return ResourceManager.GetString("Special", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \A;Start of String: This pattern signals the start of a string..
        /// </summary>
        public static string StringBegin {
            get {
                return ResourceManager.GetString("StringBegin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \Z;End of String: This pattern signals the end of a string..
        /// </summary>
        public static string StringEnd {
            get {
                return ResourceManager.GetString("StringEnd", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \x;Subpattern: This pattern represents a subpattern of the amount &quot;x&quot;..
        /// </summary>
        public static string SubpatternNum {
            get {
                return ResourceManager.GetString("SubpatternNum", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \t;Tab Character: This pattern represents the use of the tab button..
        /// </summary>
        public static string TabChar {
            get {
                return ResourceManager.GetString("TabChar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \v;Vertical Tab Character: This pattern represents the use of a vertical tab..
        /// </summary>
        public static string VertTabChar {
            get {
                return ResourceManager.GetString("VertTabChar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \w;Word Character: This pattern represents a word, defined as any grouping of one or more characters designated word characters, separated by any spacing character. Examples may include hyphens, brackets, and digits..
        /// </summary>
        public static string WordChar {
            get {
                return ResourceManager.GetString("WordChar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \&gt;;End of Word: This pattern signals the end of a word..
        /// </summary>
        public static string WordEnd {
            get {
                return ResourceManager.GetString("WordEnd", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \&lt;;Start of Word: This pattern signals the start of a word..
        /// </summary>
        public static string WordStart {
            get {
                return ResourceManager.GetString("WordStart", resourceCulture);
            }
        }
    }
}
