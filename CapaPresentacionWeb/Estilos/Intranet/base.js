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

var arry = [];
function fn_message(type, message, typeOrder) {
    var result = '';
    switch (type) {
        case "s":
            result = '<div class="myForm1_alert"><span class="icon_acceptcheckconfirmedgogreenokpositiveyes"></span><p class="alert alert-success">' + ((message == undefined) ? "Saved successfully!" : message) + '</p></div>'
            break;
        case "e":
            result = '<div class="myForm1_alert"><span class="icon_alert_blockcanceldeleteapprove"></span><p class="alert alert-danger">' + ((message == undefined) ? "An error occurred while saving" : message) + '</p></div>';
            break;
        case "i":
            result = result = '<div class="myForm1_alert"><span class="icon__alert_information"></span><p class="alert alert-warning">' + ((message == undefined) ? "Warning!" : message) + '</p></div>';
            break;
        case "c":
            result = '<div class="myForm1_alert"><span class="icon_alert_blockcanceldeleteapprove"></span><p class="style_alert">' + ((message == undefined) ? "An error occurred while sending Email, Please Re-Send Email" : message) + '</p><div><input type="button" value="Send Email" onclick="fn_resend(\'' + typeOrder + '\');"/></div></div>';
            break;
        default:
            result = '<div class="myForm1_alert"><span class="icon__alert_information"></span><p class="alert ">Warning!</p></div>';
            break;
    }


    //alert($('div[id$=message_row]').length);
    //if ($('div[id$=message_row]').length <= 0) {
    $('div[id$=message_row]').empty().fadeIn().append(result);
    $('div[id$=message_row]').delay("6000").fadeOut();
    $('html, body').animate({ scrollTop: $('div[id$=message_row]').offset().top - 300 }, 'fast');
    //$('div[id$=message_row]').delay("6000").fadeOut();
    //$('html, body').animate({ scrollTop: $('div[id$=message_row]').offset().top }, 'fast');
    //alert($('div[id$=message_row]').length);
    //}
    //else {
    //arry.push(result);
    //setTimeout(fn_queuemessage, 6000);
    //}

    //$('div[id$=message_row]').empty().fadeIn().append(result);
    //setTimeout(function () { $('div[id$=message_row]').fadeOut(); }, 6000)
}