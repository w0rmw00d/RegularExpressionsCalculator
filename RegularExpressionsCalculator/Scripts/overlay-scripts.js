/*****************************************************************************************
 * Scripts for the overlay partial view, used for all info and help events. Functionality 
 * includes opening/closing overlay, calls to functions in layout-scripts to get/set 
 * overlay content and clean overlay.
 * NOTE: The overlay is used by three different kinds of events: primary (contains links), 
 * secondary (no links, contains keywords), and help (contains neither links nor keywords.)
 ******************************************************************************************/

// opens/closes overlay. called by links in layout side nav and 'x' button in overlay.
// contents of overlay depend on the name of the calling element and type of overlay.
function toggleOverlay(name, type) {
    cleanOverlay();
    var overlay = document.getElementById("overlay");
    if (overlay.style.width == "0%") {
        fillOverlay(name, type);
        overlay.style.width = "25%";
    }
    else {
        overlay.style.width = "0%";
    }
}

// trivial caller for cleanElements in layout-scripts. cleans all overlay elements by name. called by toggleOverlay.
function cleanOverlay() {
    cleanElements("overlay-title");
    cleanElements("overlay-content");
    cleanElements("overlay-links");
    cleanElements("overlay-keywords");
}

// trivial caller for methods in layout-scripts used to fill overlay elements. depending on whether 
// type is primary, help, or secondary, different page elements will be filled. called by openOverlay.
function fillOverlay(name, type) {
    getContent(name, "overlay");
    if (type == "primary") {
        getLinks(name, "overlay-links");
    }
    else if (type == "secondary") {
        getKeywords(name, "overlay-keywords");
    }
}