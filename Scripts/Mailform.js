
//CALLS DOUCMENT WHEN PAGE FINISHED LOADING!
$(document).ready(function () {

    $("#submitbutton").click(imClicked);

});

var printError = function( req, status, err ) {
    $("#callbackmessage").css("color", "green");
    $("#callbackmessage").text(msg);
};
function imClicked(e) {
    e.preventDefault();
    var messageObj = 
   {
       "name": "",
       "email": "",
       "phone": "",
       "message": "",
       
   };
    messageObj.name = $("#name").val();
    messageObj.email = $("#email").val();
    messageObj.phone = $("#phone").val();
    messageObj.message = $("#message").val();

    $.ajax({
        dataType: "json",
        contentType: 'application/json',
        type: 'POST',
        url: '/Contact/AjaxMailer',
        data: JSON.stringify(messageObj),
        error: printError,
        success: mailsent

    });
};



var mailsent = function MailSent(msg) {
    $("#callbackmessage").css("color", "green");
    $("#callbackmessage").text(msg);
    $("#name").val("");
    $("#email").val("");
    $("#phone").val("");
    $("#message").val("");
  

};