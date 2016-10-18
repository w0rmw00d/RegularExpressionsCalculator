/************************************************
 * Scripts for the layout page. Functionality
 * includes providing scripting for popup events,
 * and toggle for side nav. 
 ************************************************/

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
$('[data-toggle="popover"]').popover();