
// This will close the collapse menu (hamburger menu) when clicked on an item or outside the menu.
jQuery('body').bind('click', function (e) {
    if (jQuery(e.target).closest('.navbar').length == 0) {
        // click happened outside of .navbar, so hide
        var opened = jQuery('.navbar-collapse').hasClass('collapse in');
        if (opened === true) {
            jQuery('.navbar-collapse').collapse('hide');
        }
    }
});

$(document).on('click', '.navbar-collapse.collapse.in a:not(.dropdown-toggle)',
    function ()
    {
        if ($(window).width() < 768) $(".navbar-collapse").collapse('hide');

    }
    );
