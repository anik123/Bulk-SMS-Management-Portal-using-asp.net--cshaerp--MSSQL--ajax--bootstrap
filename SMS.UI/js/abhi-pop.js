function popup(title, value,icon) {


    $.extend($.gritter.options, {
        //class_name: 'gritter-light', // for light notifications (can be added directly to $.gritter.add too)

        position: 'bottom-right', // possibilities: bottom-left, bottom-right, top-left, top-right
        time: 3000
        /*
        fade_in_speed: 100, // how fast notifications fade in (string or int)
        fade_out_speed: 100, // how fast the notices fade out
        time: 3000 // hang on the screen for.../// <reference path="../img/ok.png" />/// <reference path="../img/cancel.png" />



        */
    });
    $.gritter.add({
        // (string | mandatory) the heading of the notification
        title: title,
        // (string | mandatory) the text inside the notification
        text: value,
        // (string | optional) the image to display on the left
        image: icon,
        // (bool | optional) if you want it to fade out on its own or just sit there
        sticky: false,
        // (int | optional) the time you want it to be alive for before fading out
        time: ''
    });
}