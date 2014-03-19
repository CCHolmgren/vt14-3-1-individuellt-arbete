$(function () {
    'use strict';

    //Remove the success message
    $('#successbutton').click(function () {
        $(this).parent().remove();
    });
    $('#errorbutton').click(function () {
        $(this).parent().remove();
    });
});