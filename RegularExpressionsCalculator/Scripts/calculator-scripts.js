/************************************************
 * Scripts for the calculator page. Functionality
 * includes parsing user-entered regex or plain 
 * text approximations of regex expressions, toggles 
 * type of parsing applied to user entry and sample
 * text, displays error messages, and ajax calls.
 * NOTE: calculation done client-side where possible.
 ************************************************/
// SECTION: FLAGS
// flag for type of parse applied to user expression. false = regex parse. true = plain text parse.
var parse = false;

// SECTION: EVENT LISTENERS
// event listener for user-exp. calls interpret method based on current value of flag.
$('#user-input').on('input', function () {
    if (!parse) interpretRegEx();
    else interpretPlainText();
});

// event listener for calc-button. calls parseInput and prevents default form submission.
$('#calculate-button').on('click', function (event) {
    event.preventDefault();
    parseInput();
});

// event listener for parse-toggle. calls parseToggle and prevents default form submission.
$('#parse-toggle').on('click', function (event) {
    event.preventDefault();
    parseToggle();
});

// SECTION: METHODS
// changes label text for user input and translated input, toggles 
// flag (parse) value. called by event listener for parse-toggle.
function parseToggle() {
    var inputLabel = document.getElementById("input-label");
    var transLabel = document.getElementById("translated-label");
    
    if (!parse) {
        inputLabel.textContent = "Enter your plain text:";
        transLabel.textContent = "Regex Expression:";
        parse = true;
    }
    else {
        inputLabel.textContent = "Enter your expression:";
        transLabel.textContent = "What it means:";
        parse = false;
    }
}

// attempts to parse regex expression. calls parseExp on input or translation 
// based on value of flag (parse), adds highlight if matches found, and/or
// calls displayErrorMessage. called by event listener for calculate-button.
// NOTE: if flags are present in the user-entered expression and have
// not been parsed out, running the engine will cause an infinite loop.
function parseInput() {
    var sample = document.getElementById("sample-text").textContent;
    var engine, matches, parsed, input;
    // assigning input based on value of flag
    if (!parse) input = document.getElementById("translated-input").textContent;
    else input = document.getElementById("user-input").textContent;
    // assigning parsed to parsed value of user-input
    parsed = parseFlags(input);
    // assigning engine to instantiation of regex engine based on presence of flags in parsed
    if (parsed.flags.length > 0) engine = new RegExp(parsed.exp, parsed.flags);
    else engine = new RegExp(parsed.exp);
    // attempt to execute engine on sample analysis text
    try {
        // if global flag exists, run engine until all matches are found
        if (parsed.flags.includes('g')) {
            while((matches = engine.exec(testElem)) !== null) {
                sample = sample.replace(matches[0], "<span class='highlight'>" + matches[0] + "</span>");
            }
        }
        else {
            var match = engine.exec(sampleTxt);
            sampleTxt = sample.replace(matches[0], "<span class='highlight'>" + matches[0] + "</span>");
        }
    }
    catch (error) {
        displayError();
    }
}

// displays error message if user-entered expression is unable to be parsed. called by parseRegEx and parseText.
function displayError() {
    alert("Write me a better error method, ya lazy code monkey.");
}

// parses out flags from input and returns array containing expression and flags.
function parseFlags(input) {
    var parse = input.split('/g', '/i', '/m', '/y');
    var exp, flags;
    for (var a = 0; a < parse.length; a++) {
        if (parse[a] != '/g' || parse[a] != '/i' || parse[a] != '/m' || parse[a] != '/y') {
            exp += parse[a];
        }
        else {
            flags.push(parse[a].split('/')[1]);
        }
    }
    return { "exp" : exp, "flags" : flags };
}

// interprets regex as plain text via ajax call to CalculatorController. called by
// event listener on user-input. fills translated-input based on value of user-input.
function interpretRegEx() {
    var userStr = document.getElementById("user-input");
    $.ajax({
        method: 'POST',
        url: '@Url.Action("interpretRegEx", "Calculator")',
        data: {input: userStr.textContent},
        success: function (result) {
            var exp = document.getElementById("exp-text");
            exp.textContent = result.interpreted;
        }
    });
}

// interprets plain text as regex via ajax call. called by action listener on user-exp. fills exp-text based on value of user-exp.
function interpretPlainText() {
    var userStr = document.getElementById("user-exp").textContent;
    $.ajax({
        method: 'POST',
        url: '@Url.Action("interpretPlainText", "Calculator")',
        data: { input: userStr.textContent },
        success: function (result) {
            var exp = document.getElementById("exp-text");
            exp.textContent = result.interpreted;
        }
    });
}