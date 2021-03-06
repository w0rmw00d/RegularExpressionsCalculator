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
    public class RegexSymbols {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal RegexSymbols() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("RegularExpressionsCalculator.App_Data.RegexSymbols", typeof(RegexSymbols).Assembly);
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
        ///   Looks up a localized string similar to This pattern allows the ability to insert a given sequence after the matched pattern..
        /// </summary>
        public static string AfterReplacement {
            get {
                return ResourceManager.GetString("AfterReplacement", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern allows comments and/or the inclusion of white space in patterns. This is a PCRE modifier..
        /// </summary>
        public static string AllowCommentSpacePattern {
            get {
                return ResourceManager.GetString("AllowCommentSpacePattern", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to These symbols represent a minimum number of matches that the pattern in front of it should try to match. Any matches above the minimum are also counted.  It can also be greedy or lazy, depending on the quantifiers following it..
        /// </summary>
        public static string AtLeastQuantifier {
            get {
                return ResourceManager.GetString("AtLeastQuantifier", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern allows the ability to insert a given sequence before the matched pattern..
        /// </summary>
        public static string BeforeReplacement {
            get {
                return ResourceManager.GetString("BeforeReplacement", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern is used to signal the beginning of a sequence that should be interpreted literally, not as a part of a pattern or special instructions to the regular expressions engine..
        /// </summary>
        public static string BeginLiteralEscape {
            get {
                return ResourceManager.GetString("BeginLiteralEscape", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern signals an empty string that isn&apos;t at the beginning or end of a word..
        /// </summary>
        public static string BoundaryAnchor {
            get {
                return ResourceManager.GetString("BoundaryAnchor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to These symbols represent a range between the characters inside the brackets which includes all characters in sequence between and including the two characters at each end of the range..
        /// </summary>
        public static string BracketRange {
            get {
                return ResourceManager.GetString("BracketRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The caret signals the start of string or multiline pattern..
        /// </summary>
        public static string CaretAnchor {
            get {
                return ResourceManager.GetString("CaretAnchor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern allows a search for matches that ignore upper or lower case. This is a PCRE modifier..
        /// </summary>
        public static string CaseInsensitivePattern {
            get {
                return ResourceManager.GetString("CaseInsensitivePattern", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern signals that the following sequence is a comment, and should be ignored by the regular expressions engine.
        /// </summary>
        public static string Comment {
            get {
                return ResourceManager.GetString("Comment", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to All of the following characters are commonly used to signal the start or end of instructions to the regular expressions engine, or to signal that the characters between them should not be interpreted literally..
        /// </summary>
        public static string CommonMetaChar {
            get {
                return ResourceManager.GetString("CommonMetaChar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern represents the control button, and can be paired with other characters to signal the effect of pressing both the control button and the button represented by the character following it..
        /// </summary>
        public static string ControlChar {
            get {
                return ResourceManager.GetString("ControlChar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern represents any digit 0-9, as well as digit characters from Unicode, which may include digits from other languages.  .
        /// </summary>
        public static string DigitChar {
            get {
                return ResourceManager.GetString("DigitChar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The dollar sign signals the end of a string or a line in a multiline pattern..
        /// </summary>
        public static string DollarAnchor {
            get {
                return ResourceManager.GetString("DollarAnchor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern is used to signal the end of a sequence that should be interpreted literally, not as a part of a pattern or special instructions to the regular expressions engine..
        /// </summary>
        public static string EndLiteralEscape {
            get {
                return ResourceManager.GetString("EndLiteralEscape", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern allows the ability to insert a given pattern and replace the entire match or matches..
        /// </summary>
        public static string EntireReplacement {
            get {
                return ResourceManager.GetString("EntireReplacement", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This character is commonly used to signal that the following character/s are to be interpreted differently, usually literally or otherwise not as a part of a pattern or instructions to the regular expressions engine..
        /// </summary>
        public static string EscapeCharacter {
            get {
                return ResourceManager.GetString("EscapeCharacter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern allows the evaulation of a replacement during pattern matching. This is a PCRE modifier..
        /// </summary>
        public static string EvaluatePattern {
            get {
                return ResourceManager.GetString("EvaluatePattern", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to These symbols represent an exact limiter on how many matches should be found. It can also be greedy or lazy, depending on the quantifiers following it..
        /// </summary>
        public static string ExactQuantifier {
            get {
                return ResourceManager.GetString("ExactQuantifier", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern represents the form feed, or page break character..
        /// </summary>
        public static string FeedChar {
            get {
                return ResourceManager.GetString("FeedChar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern allows the ability to replace a given sequence with another in a pattern that has repeating elements..
        /// </summary>
        public static string FirstReplacement {
            get {
                return ResourceManager.GetString("FirstReplacement", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern allows a search of all the items  in the given section for matching patterns..
        /// </summary>
        public static string GlobalPattern {
            get {
                return ResourceManager.GetString("GlobalPattern", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This symbol represents a match of one or more times, and follows the character or pattern it is meant to find. It is called greedy because it will continue matching through the whole sequence instead of stopping after it finds a match. .
        /// </summary>
        public static string GreedyOneQuantifier {
            get {
                return ResourceManager.GetString("GreedyOneQuantifier", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This symbol represents a match of zero or more times, and follows the character or pattern it is meant to find. It is called greedy because it will continue matching through the whole sequence instead of stopping after it finds a match. This may result in it finding only one match when there are actually many matches because it waits until the end of the sequence to declare a match..
        /// </summary>
        public static string GreedyZeroQuantifier {
            get {
                return ResourceManager.GetString("GreedyZeroQuantifier", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to These symbols represent a grouping, or a collection that has to be considered together for the purposes of matching a pattern..
        /// </summary>
        public static string GroupRange {
            get {
                return ResourceManager.GetString("GroupRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern represents any grouping of digits that represent a hexadecimal value..
        /// </summary>
        public static string HexaChar {
            get {
                return ResourceManager.GetString("HexaChar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern represents a grouping of hexadecimal characters..
        /// </summary>
        public static string HexStrChar {
            get {
                return ResourceManager.GetString("HexStrChar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern looks for a match conditionally, such that if the first condition is met, the second condition is searched for..
        /// </summary>
        public static string IfThenAssertion {
            get {
                return ResourceManager.GetString("IfThenAssertion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern looks for a match conditionally, such that if the first condition is met, the second will be attempted. If it is not able to be matched, the last condition will be attempted..
        /// </summary>
        public static string IfThenElseAssertion {
            get {
                return ResourceManager.GetString("IfThenElseAssertion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern allows the ability to insert a given pattern and replace the last match..
        /// </summary>
        public static string LastReplacement {
            get {
                return ResourceManager.GetString("LastReplacement", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This symbol represents a match of only zero or one times, and can be used in tandem with other qualifiers, in addition to on its own, to force matching to stop after the first match is found. It follows either the character or pattern it is meant to match or the quantifier it is meant to restrict..
        /// </summary>
        public static string LazyQuantifier {
            get {
                return ResourceManager.GetString("LazyQuantifier", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This character represents the request to treat the following character as a literal character, instead of as a part of a special character..
        /// </summary>
        public static string LiteralEscape {
            get {
                return ResourceManager.GetString("LiteralEscape", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern looks for a match and returns a true/false result for matching, leaving the engine at the beginning of the match..
        /// </summary>
        public static string LookaheadAssertion {
            get {
                return ResourceManager.GetString("LookaheadAssertion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern looks for a match and returns a true/false result for matching, leaving the engine at the end of the match..
        /// </summary>
        public static string LookbehindAssertion {
            get {
                return ResourceManager.GetString("LookbehindAssertion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern allows a search for matches that span multiple lines. This is a PCRE modifier..
        /// </summary>
        public static string MultipleLinePattern {
            get {
                return ResourceManager.GetString("MultipleLinePattern", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern looks for a match and returns a true/false result for matching, leaving the engine at the beginning of a sequence that is not the pattern..
        /// </summary>
        public static string NegativeLookAheadAssertion {
            get {
                return ResourceManager.GetString("NegativeLookAheadAssertion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern looks for a match and returns a true/false result, leaving the engine at the end of a subsequence that is not the requested pattern..
        /// </summary>
        public static string NegativeLookbehindAssertion {
            get {
                return ResourceManager.GetString("NegativeLookbehindAssertion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern represents the command to start a new line..
        /// </summary>
        public static string NewLineChar {
            get {
                return ResourceManager.GetString("NewLineChar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to These symbols represent a range between the characters inside the bracket, up to and including both ends of the range, which are excluded from matching..
        /// </summary>
        public static string NonBracketRange {
            get {
                return ResourceManager.GetString("NonBracketRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern represents any non-digit character..
        /// </summary>
        public static string NonDigitChar {
            get {
                return ResourceManager.GetString("NonDigitChar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to These symbols represent a range between the characters inside the brackets which are excluded from pattern matching..
        /// </summary>
        public static string NonOrBracketRange {
            get {
                return ResourceManager.GetString("NonOrBracketRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern represents any non-word characters..
        /// </summary>
        public static string NonWordChar {
            get {
                return ResourceManager.GetString("NonWordChar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern represents white space that is not the spacebar, tab, return, or the form feed..
        /// </summary>
        public static string NotSpaceChar {
            get {
                return ResourceManager.GetString("NotSpaceChar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern allows the ability to dictate how many non-passive groups are matched..
        /// </summary>
        public static string NthReplacement {
            get {
                return ResourceManager.GetString("NthReplacement", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern represents any grouping of digits that represent an octal value..
        /// </summary>
        public static string OctalChar {
            get {
                return ResourceManager.GetString("OctalChar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern represents a grouping of octal characters..
        /// </summary>
        public static string OctalStrChar {
            get {
                return ResourceManager.GetString("OctalStrChar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern looks for a match and returns a true/false result, leaving the engine at the only match for the pattern in the sequence..
        /// </summary>
        public static string OnceOnlyAssertion {
            get {
                return ResourceManager.GetString("OnceOnlyAssertion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to These symbols represent a range between the characters inside the brackets such that any of the character or all of them may be matched (exclusive or)..
        /// </summary>
        public static string OrBracketRange {
            get {
                return ResourceManager.GetString("OrBracketRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to These symbols represent an or statement, in which at least one of the alternatives have to be true for the pattern to match..
        /// </summary>
        public static string OrRange {
            get {
                return ResourceManager.GetString("OrRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to These symbols represent a grouping which the regex engine doesn&apos;t have to remember--it can be used to match and discarded..
        /// </summary>
        public static string PassiveGroupRange {
            get {
                return ResourceManager.GetString("PassiveGroupRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This character represents a match of any character except the new line character (\n)..
        /// </summary>
        public static string PeriodRange {
            get {
                return ResourceManager.GetString("PeriodRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern refers to all letter or digit characters..
        /// </summary>
        public static string POSIXAllChar {
            get {
                return ResourceManager.GetString("POSIXAllChar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern refers to all letter characters..
        /// </summary>
        public static string POSIXAlpha {
            get {
                return ResourceManager.GetString("POSIXAlpha", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern refers to the space or tab characters..
        /// </summary>
        public static string POSIXBlank {
            get {
                return ResourceManager.GetString("POSIXBlank", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern refers to control characters..
        /// </summary>
        public static string POSIXControl {
            get {
                return ResourceManager.GetString("POSIXControl", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern refers to all digit characters..
        /// </summary>
        public static string POSIXDigit {
            get {
                return ResourceManager.GetString("POSIXDigit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern refers to printed characters..
        /// </summary>
        public static string POSIXGraph {
            get {
                return ResourceManager.GetString("POSIXGraph", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern refers to hexadecimal characters..
        /// </summary>
        public static string POSIXHex {
            get {
                return ResourceManager.GetString("POSIXHex", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern refers to lower case letters..
        /// </summary>
        public static string POSIXLower {
            get {
                return ResourceManager.GetString("POSIXLower", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern refers to printed characters and spaces..
        /// </summary>
        public static string POSIXPrint {
            get {
                return ResourceManager.GetString("POSIXPrint", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern refers to all punctuation characters..
        /// </summary>
        public static string POSIXPunct {
            get {
                return ResourceManager.GetString("POSIXPunct", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern refers to upper case letters..
        /// </summary>
        public static string POSIXUpper {
            get {
                return ResourceManager.GetString("POSIXUpper", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern refers to all digits, letters, and underscore characters..
        /// </summary>
        public static string POSIXWord {
            get {
                return ResourceManager.GetString("POSIXWord", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to These symbols represent a range of number of matches that the pattern should try to find. It is inclusive, allowing anything including the minimum and up to and including the maximum number of matches.  It can also be greedy or lazy, depending on the quantifiers following it..
        /// </summary>
        public static string RangeQuantifier {
            get {
                return ResourceManager.GetString("RangeQuantifier", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern represents the use of the return button..
        /// </summary>
        public static string ReturnChar {
            get {
                return ResourceManager.GetString("ReturnChar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern allows the ability to replace a given sequence with another in a pattern that does not repeat. .
        /// </summary>
        public static string SecondReplacement {
            get {
                return ResourceManager.GetString("SecondReplacement", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to These symbols represent the end of the request to treat the previous sequence as literal, ignoring any special characters contained within it..
        /// </summary>
        public static string SequenceEndEscape {
            get {
                return ResourceManager.GetString("SequenceEndEscape", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to These symbols represent the request to treat the following sequence as literal, ignoring any special characters in it..
        /// </summary>
        public static string SequenceStartEscape {
            get {
                return ResourceManager.GetString("SequenceStartEscape", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern represents white space created by the spacebar or the use of the tab..
        /// </summary>
        public static string SpaceChar {
            get {
                return ResourceManager.GetString("SpaceChar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern allows a search that treats each string as a line. This is a PCRE modifier..
        /// </summary>
        public static string StringAsSinglePattern {
            get {
                return ResourceManager.GetString("StringAsSinglePattern", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern signals the start of a string..
        /// </summary>
        public static string StringBeginAnchor {
            get {
                return ResourceManager.GetString("StringBeginAnchor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern signals the end of a string..
        /// </summary>
        public static string StringEndAnchor {
            get {
                return ResourceManager.GetString("StringEndAnchor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern represents the use of the tab button..
        /// </summary>
        public static string TabChar {
            get {
                return ResourceManager.GetString("TabChar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern allows ungreedy matches. This is a PCRE modifier..
        /// </summary>
        public static string UngreedyPattern {
            get {
                return ResourceManager.GetString("UngreedyPattern", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern represents the use of a vertical tab..
        /// </summary>
        public static string VertTabChar {
            get {
                return ResourceManager.GetString("VertTabChar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern signals a word boundary..
        /// </summary>
        public static string WordBoundaryAnchor {
            get {
                return ResourceManager.GetString("WordBoundaryAnchor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern represents a word, defined as any grouping of one or more characters designated word characters, separated by any spacing character. Examples may include hyphens, brackets, and digits..
        /// </summary>
        public static string WordChar {
            get {
                return ResourceManager.GetString("WordChar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern signals the end of a word..
        /// </summary>
        public static string WordEndAnchor {
            get {
                return ResourceManager.GetString("WordEndAnchor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This pattern signals the start of a word..
        /// </summary>
        public static string WordStartAnchor {
            get {
                return ResourceManager.GetString("WordStartAnchor", resourceCulture);
            }
        }
    }
}
