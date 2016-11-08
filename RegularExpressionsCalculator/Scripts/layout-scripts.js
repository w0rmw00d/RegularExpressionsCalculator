/************************************************
 * Scripts for the layout page. Functionality
 * includes providing scripting for popup events,
 * email and new window open events, location change
 * events, and visibility toggle for the side nav. 
 ************************************************/

$('logo').click(null, function () {
    toggleSideNav();
});

$('engine-link').click(null, function () {
    location.href = '/RegularEngine';
});

$('calc-link').click(null, function () {
    location.href = '/Calculator';
});

$('lang-link').click(null, function () {
    location.href = '/RegularLang';
});

$('cheat-link').click(null, function () {
    window.open = "https://www.cheatography.com/davechild/cheat-sheets/regular-expressions/";
});

$('info-link').click(null, function () {
    window.open="http://www.regular-expressions.info/tutorial.html";
});

$('egg-link').click(null, function () {
    window.open="http://www.rexegg.com/";
});

$('mail-link').click(null, function () {
    href = "mailto:g33kycarrie@gmail.com?Subject=Regular%20Expressions%20Calculator";
    target = "_blank";
});

$('git-link').click(null, function () {
    location.href="https://github.com/w0rmw00d";
});

// allows side nav on layout to have its visibility toggled on and off via class. called via clicking logo in top navbar.
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

// toggles popover visibility
$(function () {
    $('[data-toggle="popover"]').popover();
});

// trivial caller for populating the links in side-nav
function fillSideNav(title) {
    setSideTitle(title);
    setSideLinks(title);
}

// sets text of nav-title element.
function setSideTitle(title) {
    var link = document.getElementById("nav-title");
    link.textContent = title;
}

// creates and adds links and event listener to side-nav after ajax call to
// RootController. will not add links if child elements exist for side-list.
function setSideLinks(title) {
    $.ajax({
        method: 'POST',
        url: '@Url.Action("getSideLinks", "Root")',
        data: { pageName: title },
        success: function (result) {
            var sideList = document.getElementById("side-list");
            if (sideList.childNodes.length == 0) {
                var length = result.Links.length;
                for (var a = 0; a < length; a++) {
                    var item = document.createElement("li");
                    var link = document.createElement("a");
                    link.text = result.Links[a];
                    link.id = result.Links[a];
                    item.appendChild(link);
                    sideTitle.appendChild(item);
                }
                sideList.addEventListener("click", function (event) {
                    openOverlay(event.target.id);
                });
            }
        }
    });
}

function cleanSideNav() {

}