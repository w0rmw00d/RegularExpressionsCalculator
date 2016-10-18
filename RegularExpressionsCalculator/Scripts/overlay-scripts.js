/***************************************************
 * Scripts for the overlay partial. Functionality 
 * includes adding and removing content from overlay
 * elements, open/close the overlay, and ajax calls. 
 ***************************************************/

// opens overlay. called by side nav in layout.
function openOverlay(name) {
    fillOverlay(name);
    document.getElementById('overlay').style.width = "25%";
}

// closes overlay. called by 'x' button in overlay.
function closeOverlay() {
    cleanOverlay();
    document.getElementById('overlay').style.width = "0%";
}

// removes current overlay elements. called by fillOverlay and closeOverlay.
function cleanOverlay() {
    var overlayDef = document.getElementById("overlay-content");
    var overlayTitle = document.getElementById("overlay-title");
    var overlayLinks = document.getElementById("overlay-links");

    while (overlayTitle.firstChild) {
        overlayTitle.removeChild(overlayTitle.firstChild);
    }
    while (overlayDef.firstChild) {
        overlayDef.removeChild(overlayDef.firstChild);
    }
    while (overlayLinks.firstChild) {
        overlayLinks.removeChild(overlayLinks.firstChild);
    }
}

// trivial caller for methods used to fill overlay elements. called by openOverlay.
function fillOverlay(name) {
    cleanOverlay();
    setOverlayTitle(name);
    setOverlayDef(name);
    setOverlayLinks(name);
}

// fills overlay title element after ajax call to calculator 
// controller. will not execute if child for element already exists.
function setOverlayTitle(name) {
    $.ajax({
        method: 'POST',
        url: '@Url.Action("GetOverlayTitle", "Calculator")',
        data: { key: name },
        success: function (result) {
            var titleDiv = document.getElementById('overlay-title');
            if (titleDiv.childNodes.length == 0) {
                var content = document.createTextNode(result.Title);
                titleDiv.appendChild(content);
            }
        }
    });
}

// fills overlay definition element after ajax call to calculator
// controller. will not execute if child for element already exists.
function setOverlayDef(name) {
    $.ajax({
        method: 'POST',
        url: '@Url.Action("GetOverlayDef", "Calculator")',
        data: { key: name },
        success: function (result) {
            var contentDiv = document.getElementById('overlay-content');
            if (contentDiv.childNodes.length == 0) {
                var content = document.createTextNode(result.Definition);
                contentDiv.appendChild(content);
            }
        }
    });
}

// fills overlay links element after ajax call to calculator 
// controller. assigns event listener to new links. will not 
// fill element or assign listener if children already exist.
function setOverlayLinks(name) {
    $.ajax({
        method: 'POST',
        url: '@Url.Action("GetOverlayLinks", "Calculator")',
        data: { key: name },
        success: function (result) {
            var links = document.getElementById('overlay-links');
            if (links.childNodes.length == 0) {
                var length = result.Links.length;
                for (var a = 0; a < length; a++) {
                    var item = document.createElement("li");
                    var link = document.createElement("a");
                    link.text = result.Links[a].Item2;
                    link.id = result.Links[a].Item1;
                    item.appendChild(link);
                    links.appendChild(item);
                }
                links.addEventListener("click", function (event) {
                    cleanOverlay();
                    SetOverlayTitle(event.target.id);
                    SetOverlayDef(event.target.id);
                });
            }
        }
    });
}