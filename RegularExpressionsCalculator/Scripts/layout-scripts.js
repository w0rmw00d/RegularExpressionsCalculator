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

$('anchor-link').click(null, function () {
    openOverlay("Anchor");
});

$('assert-link').click(null, function () {
    openOverlay("Assert");
});

$('char-link').click(null, function () {
    openOverlay("Character");
});

$('esc-link').click(null, function () {
    openOverlay("Escape");
});

$('group-link').click(null, function () {
    openOverlay("Group");
});

$('quant-link').click(null, function () {
    openOverlay("Quant");
});

$('mod-link').click(null, function () {
    openOverlay("Mod");
});

$('special-link').click(null, function () {
    openOverlay("Special");
});

$('replace-link').click(null, function () {
    openOverlay("Replace");
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