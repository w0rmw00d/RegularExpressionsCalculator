/************************************************************************************
 * Scripts for the layout page, overlay partial, and shared functions. Functionality 
 * includes navigation, email, script utilities, opening/closing overlay, get/set 
 * overlay content, clean overlay, and toggled visibility for side nav.
 * NOTE: The overlay is used by three different kinds of events: primary (contains links), 
 * secondary (no links, contains keywords), and help (contains neither links nor keywords.)
 * Primary links are those hosted in the navs. Secondary links are hosted in the overlay.
 ************************************************************************************/
// SECTION: GLOBAL VARS
// references to urls calculated in _Layout. work around to allow the use of html helpers in separate js files.
var linkUrl = $("#linkURL").val();
var contentUrl = $("#contentURL").val();
var keyUrl = $("#keyURL").val();
// reference to the overlay, used all over the place
var overlay = document.getElementById("overlay");

// SECTION: PAGE LOAD, EVENT LISTENERS
// called on page load. attaches event listeners to layout elements and fills help menu and side nav.
$().ready(function () {
    // hides overlay on load
    overlay.hidden = true;

    fillSideNav($("title").text());
    fillHelpMenu("HelpCalc");

    // event listener for overlay close button. toggles overlay visibility via toggleOverlay.
    $("#overlay-close").on("click", function (event) {
        cleanOverlay();
        toggleOverlay();
    });

    // event handler for popover events
    $("[data-toggle='popover']").popover({ trigger: "hover focus" });

    // event listener for logo. toggles side nav visibility via toggleSideNav.
    $("#calc-logo").on("click", function (event) {
        toggleSideNav();
    });

    // event listener for navigation link in top nav menu. sets page location to the RegularEngine page.
    $('#engine-link').on('click', function (event) {
        location.href = '/RegularEngine';
    });

    // event listener for navigation link in top nav menu. sets page location to the Calculator page.
    $('#calc-link').on('click', function (event) {
        location.href = '/Calculator';
    });

    // event listener for navigation link in top nav menu. sets page location to the RegularLang page.
    $('#lang-link').on('click', function (event) {
        location.href = '/RegularLang';
    });

    // event listener for navigation link in top nav menu. sets page location to Cheatography cheat sheet for regular expressions.
    $('#cheat-link').on('click', function () {
        window.open("https://www.cheatography.com/davechild/cheat-sheets/regular-expressions/", "_blank");
    });

    // event listener for navigation link in top nav menu. sets page location to regular-expressions.info
    $('#info-link').click(null, function () {
        window.open("http://www.regular-expressions.info/tutorial.html", "_blank");
    });

    // event listener for navigation link in top nav menu. sets page location to RexEgg.
    $('#egg-link').click(null, function () {
        window.open("http://www.rexegg.com/", "_blank");
    });

    // event listener for navigation link in top nav menu. opens new dialog for email, subject set to regular expressions calculator.
    $('#mail-link').click(null, function () {
        window.open("mailto:g33kycarrie@gmail.com?Subject=Regular%20Expressions%20Calculator", "_blank");
    });

    // event listener for navigation link in top nav menu. sets page location to my github.
    $('#git-link').click(null, function () {
        window.location.href="https://github.com/w0rmw00d";
    });

    // event listener for navigation link in top nav menu. opens overlay with about-me content.
    $('#about-link').click(null, function () {
        toggleOverlay("AboutMe", "help");
    });
});

// SECTION: FUNCTIONS
// toggles visibility of side nav via class. called by event listener for logo in top nav.
function toggleSideNav() {
    var nav = document.getElementById("side-nav");
    if (nav.hidden) {
        nav.hidden = false;
        document.getElementById("body").className = "body-content";
    }
    else {
        nav.hidden = true;
        document.getElementById("body").className = "body-content-minimized";
    }
}

// trivial caller for populating the links in side nav. called on page load.
function fillSideNav(title) {
    setSideTitle(title);
    getLinks(title, "side-list");
}

// trivial caller for populating the help menu links in the top nav. called on page load.
function fillHelpMenu(title) {
    getLinks(title, "help-menu");
}

// sets text of nav-title element. called by fillSideNav.
function setSideTitle(title) {
    var link = document.getElementById("nav-title");
    if (title == "Calculator") link.textContent = "Regular Expressions";
    else if (title == "Engine") link.textContent = "Regular Engine";
    else link.textContent = "Regular Language";
}

// removes children from page elements by name.
function cleanElements(name) {
    var item = document.getElementById(name);
    while (item.firstChild) {
        item.removeChild(item.firstChild);
    }
}

// creates and adds links via ajax call to RootController. page element filled depends on key (name),
// and element (document element to be filled). will not fill element or assign listener if children exist.
function getLinks(name, element) {
    $.ajax({
        dataType: 'json',
        url: linkUrl,
        data: { key: name },
        success: function (result) {
            var elem = document.getElementById(element);
            if (elem.childNodes.length == 0) {
                for (var entry in result) {
                    var item = document.createElement("li");
                    var link = document.createElement("a");
                    if (elem.id == "help-menu") link.className = "top-nav";
                    link.text = result[entry].Value;
                    link.id = result[entry].Key;
                    item.appendChild(link);
                    elem.appendChild(item);
                }
                elem.addEventListener("click", function (event) {
                    if (element == "overlay-links") fillOverlay(event.target.id, "secondary");
                    else {
                        if(overlay.hidden) toggleOverlay();
                        fillOverlay(event.target.id, "primary");
                    }
                });
            }
        }
    });
}

// creates and adds title and content elements after ajax call to RootController. page element filled
// depends on key (name), and element (element to be filled). will not fill elements if children exist.
function getContent(name, element) {
    $.ajax({
        dataType: 'json',
        url: contentUrl,
        data: { key: name },
        success: function (result) {
            if (element == "overlay")
            {
                var titleDiv = document.getElementById("overlay-title");
                var contentDiv = document.getElementById("overlay-content");
                if (titleDiv.childNodes.length == 0) {
                    var title = document.createTextNode(result.Key);
                    titleDiv.appendChild(title);
                }
                if (contentDiv.childNodes.length == 0) {
                    var content = document.createTextNode(result.Value);
                    contentDiv.appendChild(content);
                }
            }
        }
    });
}

// creates and adds keyword element after ajax call to RootController. page element filled depends
// on key (name), and element (element to be filled). will not fill element if child exists.
function getKeywords(name, element) {
    $.ajax({
        dataType: 'json',
        url: keyUrl,
        data: { key: name },
        success: function (result) {
            var elem = document.getElementById(element);
            if (elem.childNodes.length == 0) {
                var title = document.createElement("a");
                var content = document.createTextNode(result);
                title.textContent = "KEYWORDS: ";
                elem.appendChild(title);
                elem.appendChild(content);
            }
        }
    });
}

// opens/closes overlay. called by links in layout side nav and 'x' button in overlay.
function toggleOverlay() {
    if (overlay.hidden) overlay.hidden = false;
    else overlay.hidden = true;
}

// trivial caller for cleanElements. cleans all overlay elements by name. called by toggleOverlay.
function cleanOverlay() {
    cleanElements("overlay-title");
    cleanElements("overlay-content");
    cleanElements("overlay-links");
    cleanElements("overlay-keywords");
}

// trivial caller for methods in layout-scripts used to fill overlay elements. depending on whether 
// type is primary or secondary, different overlay elements will be filled. called by openOverlay.
function fillOverlay(name, type) {
    alert("name: " + name + " type: " + type);
    cleanOverlay();
    getContent(name, "overlay");
    if (type == "primary") getLinks(name, "overlay-links");
    else if (type == "secondary") getKeywords(name, "overlay-keywords");
}


// performs ajax call to server to get error messages in the event of error
function getErrorMessages(error) {

}