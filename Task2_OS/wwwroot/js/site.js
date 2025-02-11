// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('#navigation-explore').each(function () {
        var $toolip = $(this).Tooltip({
            html: true,
            title: $('#explore-title').html(),
            trigger: 'manual',
        }).on({
            mouseenter: function () {
                if ($('.tooltip').length == 0) //prevent tooltop from hiding when explore is hovered oer
                    $(this).tooltip('show'); //show tooltip over mouseenter
            },
            click: function (event) {
                if (event.pointerType === "touch") {
                    //ignore click event for touch
                    //explore button twice to work, due to  touch event
                    // calls both mouseenter and click one after the other 
                } else
                    $(this).tooltip('show'); //toggle tooltip on click
            }
        });
        
        $(document).on('click', function (event) {
            var search = $('.tooltip');
            if (search.length == 0) //tooltip doesn't exist 
                return;
            var $target = $(event.target);
            var isChildOfToolTip = search[0].contains($target[0]);
            if (!$target.is('#navigation-explore') && !isChildOfToolTip) {
                $tooltip.Tooltip('hide');
            }

        });
    });
});