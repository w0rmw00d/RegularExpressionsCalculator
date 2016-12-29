/************************************************
 * Scripts for the calculator page. Functionality
 * includes parsing user-entered regex or plain 
 * text approximations of regex expressions, toggles 
 * type of parsing applied to user entry and sample
 * text, displays error messages, and ajax calls.
 * NOTE: calculation done client-side where possible.
 ************************************************/
// SECTION: GLOBAL VARS
// flag for type of parse applied to user expression. false = regex parse. true = plain text parse.
var parse = false;
// references to urls calculated in Calculator.cshtml. work around to allow the use of html helpers in separate js files
var regex = $("#interpretRegexURL").val();
var plain = $("#interpretPlainURL").val();

// SECTION: EVENT LISTENERS
// event listener for user-input. calls interpret method based on current value of flag.
$('#user-input').on('input', function (event) {
    var input = $(this).val();
    if (!parse) interpretRegex(input);
    else interpretPlain(input);
});

// event listener for calc-button. calls parseInput and prevents default form submission.
$('#calculate-button').on('click', function (event) {
    parseInput();
});

// event listener for parse-toggle. calls parseToggle.
$('#parse-toggle').on('click', function (event) {
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
    alert("input: " + input + " parsed.exp: " + parsed.exp + " parsed.flags: " + parsed.flags);
    // attempt to execute engine on sample analysis text
    try {
        // if global flag exists, run engine until all matches are found
        if (parsed.flags.includes('g')) {
            while((matches = engine.exec(testElem)) !== null) {
                sample = sample.replace(matches[0], "<span class='highlight'>" + matches[0] + "</span>");
            }
        }
        else {
            matches = engine.exec(sampleTxt);
            sampleTxt = sample.replace(matches[0], "<span class='highlight'>" + matches[0] + "</span>");
        }
    }
    catch (error) {
        displayError(error);
    }
}

// displays error message if user-entered expression is unable to be parsed. called by parseRegEx and parseText.
function displayError(error) {
    alert("Write me a better error method, ya lazy code monkey. error: " + error);
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
function interpretRegex(userStr) {
    $.ajax({
        dataType: 'json',
        url: regex,
        data: {input: userStr},
        success: function (result) {
            alert("result: " + result);
            var exp = document.getElementById("translated-input");
            exp.textContent = result;
        }
    });
}

// interprets plain text as regex via ajax call. called by action listener on user-exp. fills exp-text based on value of user-exp.
function interpretPlain(userStr) {
    $.ajax({
        dataType: 'json',
        url: plain,
        data: {input: userStr},
        success: function (result) {
            var exp = document.getElementById("translated-input");
            exp.textContent = result;
        }
    });
}