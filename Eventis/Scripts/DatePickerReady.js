$(function () {
    var icons = {
        header: "ui-icon-circle-arrow-e",
        activeHeader: "ui-icon-circle-arrow-s"
    };
    $("#accordion").accordion({
        icons: icons
    });
    $("#toggle").button().on("click", function () {
        if ($("#accordion").accordion("option", "icons")) {
            $("#accordion").accordion("option", "icons", null);
        } else {
            $("#accordion").accordion("option", "icons", icons);
        }
    });
});

$(function () {
    $("#datepicker").datepicker();
});

$(document).ready(function () {
    $('input[type=datetime2(7)]').datepicker({
        dateFormat: "dd/MM/yyyy",
        changeMonth: true,
        changeYear: true,
        yearRange: "-60:+0"
    });
});