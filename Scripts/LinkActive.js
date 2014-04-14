$(document).ready(function () {
    var currentLocation = window.location.href;
    if (currentLocation.indexOf("home") > -1) {
        $("#home").addClass("active");
    }
    else if (currentLocation.indexOf("Product") > -1) {
        $("#product").addClass("active");
    }
    else if (currentLocation.indexOf("Collections") > -1) {
        $("#collection").addClass("active");
    }
    else if (currentLocation.indexOf("News") > -1) {
        $("#news").addClass("active");
    }
    else if (currentLocation.indexOf("Wholesaler") > -1) {
        $("#wholesaler").addClass("active");
    }
    else if (currentLocation.indexOf("Contact") > -1) {
        $("#contact").addClass("active");
    }
    else {
        $("#home").addClass("active");
    }

});