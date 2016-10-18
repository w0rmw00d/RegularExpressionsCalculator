/************************************************
 * Scripts for the calculator page. Functionality
 * includes parsing user-entered regex or plain 
 * text approximations of regex expressions, toggles 
 * type of parsing applied to user entry and sample
 * text, displays error messages, and ajax calls.
 * NOTE: calculation done client-side where possible.
 ************************************************/
// flag for type of parse applied to user expression. false = regex parse. true = plain text parse.
var parse = false;

// SECTION: ACTION LISTENERS
// attaches action listener to user-exp. calls interpret method based on current value of flag.
$('#user-exp').on('input', function () {
    if (!parse) interpretRegEx();
    else interpretPlainText();
});

// attaches action listener to calc. calls parse methods based on current value of flag and prevents default form submission.
$('#calc').on('click', function (event) {
    event.preventDefault();
    if (!parse) parseRegEx();
    else if (parse) parseText();
});

// attaches action listener to parse-toggle. calls parseToggle and prevents default form submission.
$('#parse-toggle').on('click', function (event) {
    event.preventDefault();
    parseToggle();
});

// SECTION: METHODS
// toggles type of parse applied to user expressions. changes label text for user input, 
// toggles flag value, changes label text and read only value for interpretation field.
function parseToggle() {
    if (!parse) {
        $('#exp-label').text("Enter your plain text:");
        $('#text-label').text("Regex Expression:");
        document.getElementById("exp-text").readOnly = false;
        parse = true;
    }
    else {
        $('#exp-label').text("Enter your expression:");
        $('#text-label').text("What it means:");
        document.getElementById("exp-text").readOnly = true;
        parse = false;
    }
}

// attempts to parse regex expression. calls parseExp on user-entered expression, creates 
// highlight if matches found, or calls displayErrorMessage if error present. 
function parseInput() {
    var testElem = document.getElementById("text-analyze").textContent;
    var engine, matchArray, parsedExp;
    // assigning parsedExp to parsed value of user-exp or exp-text based on flag value
    if (!parse) parsedExp = parseExp(document.getElementById("user-exp").textContent);
    else parsedExp = parseExp(document.getElementById("exp-text").textContent);
    // assigning engine based on presence of flags in parsedExp
    if (parsedExp.flags) engine = new RegExp(parsedExp.exp, parsedExp.flags);
    else engine = new RegExp(parsedExp.exp);

    try {
        // if the global flag is not enabled, this method will cause an infinite loop
        if (parsedExp.flags.includes('g')) {
            while((matchArray = engine.exec(testElem)) !== null) {
                testElem = testElem.replace(matchArray[0], "<span class='highlight'>" + matchArray[0] + "</span>");
            }
        }
        else {
            var match = engine.exec(testElem);
            testElem = testElem.replace(matchArray[0], "<span class='highlight'>" + matchArray[0] + "</span>");
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

// parses out flags from regex expression, if any, and returns array containing expression and flags.
function parseExp(expression) {
    var parse = expression.split('/g', '/i', '/m', '/y');
    var exp;
    var flags = [];
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

// interprets regex as plain text via ajax call. called by action listener on user-exp. fills exp-text based on value of user-exp.
function interpretRegEx() {
    var userStr = document.getElementById("user-exp");
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