/***************************************************************************
 * Scripts for the layout page and shared functions. Functionality includes
 * navigation, email, script utilities, and toggled visibility for side nav. 
 ***************************************************************************/
// SECTION: PAGE LOAD
// called on page load. populates side nav and help menu in top nav depending on page title.
$().ready(function () {
    fillSideNav($("title").text());
});

// SECTION: EVENT LISTENERS
// event listener for logo. toggles side nav visibility via toggleSideNav.
$('logo').click(null, function () {
    toggleSideNav();
});

// event listener for navigation link in top nav menu. sets page location to the RegularEngine page.
$('engine-link').click(null, function () {
    location.href = '/RegularEngine';
});

// event listener for navigation link in top nav menu. sets page location to the Calculator page.
$('calc-link').click(null, function () {
    location.href = '/Calculator';
});

// event listener for navigation link in top nav menu. sets page location to the RegularLang page.
$('lang-link').click(null, function () {
    location.href = '/RegularLang';
});

// event listener for navigation link in top nav menu. sets page location to Cheatography cheat sheet for regular expressions.
$('cheat-link').click(null, function () {
    window.open = "https://www.cheatography.com/davechild/cheat-sheets/regular-expressions/";
});

// event listener for navigation link in top nav menu. sets page location to regular-expressions.info
$('info-link').click(null, function () {
    window.open="http://www.regular-expressions.info/tutorial.html";
});

// event listener for navigation link in top nav menu. sets page location to RexEgg.
$('egg-link').click(null, function () {
    window.open="http://www.rexegg.com/";
});

// event listener for navigation link in top nav menu. opens new dialog for email, subject set to regular expressions calculator.
$('mail-link').click(null, function () {
    href = "mailto:g33kycarrie@gmail.com?Subject=Regular%20Expressions%20Calculator";
    target = "_blank";
});

// event listener for navigation link in top nav menu. sets page location to my github.
$('git-link').click(null, function () {
    location.href="https://github.com/w0rmw00d";
});

// event listener for navigation link in top nav menu. opens overlay with about-me content.
$('about-link').click(null, function () {
    toggleOverlay("AboutMe", "help");
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
    getLinks(title);
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

// removes children and event listener from page elements by name. used by all other page script files.
function cleanElements(name) {
    var item = document.getElementById(name);
    while (item.firstChild) {
        item.removeChild(item.firstChild);
    }
    item.removeEventListener();
}

// creates and adds links via ajax call to RootController. page element filled
// depends on key (name), and element (element to be filled). will not fill
// element or assign listener if children exist. used by all other page script files.
function getLinks(name, element) {
    $.ajax({
        method: 'POST',
        url: '@Url.Action("getLinks", "Root")',
        data: { key: name },
        success: function (result) {
            var elem = document.getElementById(element);
            if (elem.childNodes.length == 0) {
                var length = result.Links.length;
                for (var a = 0; a < length; a++) {
                    var item = document.createElement("li");
                    var link = document.createElement("a");
                    link.text = result.Links[a];
                    link.id = result.Links[a];
                    item.appendChild(link);
                    elem.appendChild(item);
                }
                elem.addEventListener("click", function (event) {
                    if (element == "overlay-links") {
                        openOverlay(event.target.id, "secondary");
                    }
                    else {
                        openOverlay(event.target.id, "primary");
                    }
                });
            }
        }
    });
}

// creates and adds title and content elements after ajax call to RootController. 
// page element filled depends on key (name), and element (element to be filled).
// will not fill elements if children exist. used by all other page script files.
function getContent(name, element) {
    $.ajax({
        method: 'POST',
        url: '@Url.Action("getContent", "Root")',
        data: { key: name },
        success: function (result) {
            if (element == "overlay")
            {
                var titleDiv = document.getElementById("overlay-title");
                var contentDiv = document.getElementById("overlay-content");
                if (titleDiv.childNodes.length == 0) {
                    var title = document.createTextNode(result.Title);
                    titleDiv.appendChild(title);
                }
                if (contentDiv.childNodes.length == 0) {
                    var content = document.createTextNode(result.Content);
                    contentDiv.appendChild(content);
                }
            }
        }
    });
}

// creates and adds keyword element after ajax call to RootController. page element 
// filled depends on key (name), and element (element to be filled). will not fill 
// element if child exists. used by all other page script files.
function getKeywords(name, element) {
    $.ajax({
        method: 'POST',
        url: '@Url.Action("getKeywords", "Root")',
        data: { key: name },
        success: function (result) {
            var elem = document.getElementById(element);
            if (links.childNodes.length == 0) {
                var content = document.createTextNode("KEYWORDS: " + result.KeyWords);
                elem.appendChild(content);
            }
        }
    });
}