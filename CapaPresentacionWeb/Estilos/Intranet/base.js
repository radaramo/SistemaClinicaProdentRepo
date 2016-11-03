function fn_custommessage(type, message, place) {
    var result = '';
    switch (type) {
        case "s":
            result = '<div class="myForm1_alert"><span class="icon_acceptcheckconfirmedgogreenokpositiveyes"></span><p class="alert alert-success">' + ((message == undefined) ? "Saved successfully!" : message) + '</p></div>'
            break;
        case "u":
            result = '<div class="myForm1_alert"><span class="icon_acceptcheckconfirmedgogreenokpositiveyes"></span><p class="alert alert-success">' + ((message == undefined) ? "Saved successfully!" : message) + '</p></div>'
            break;
        case "e":
            result = '<div class="myForm1_alert"><span class="icon_alert_blockcanceldeleteapprove"></span><p class="alert alert-danger">' + ((message == undefined) ? "An error occurred while saving" : message) + '</p></div>';
            break;
        case "i":
            result = '<div class="myForm1_alert"><span class="icon__alert_information"></span><p class="alert alert-warning">' + ((message == undefined) ? "Warning!" : message) + '</p></div>';
            break;
        default:
            result = '<div class="myForm1_alert"><span class="icon__alert_information"></span><p class="alert">Warning!</p></div>';
            break;
    }

    $('div[id$='+place+']').empty().fadeIn().append(result);
    //$('html, body').animate({ scrollTop: $('div[id$=' + place + ']').offset().top }, 'fast');
    $('div[id$=' + place + ']').delay("6000").fadeOut();
}