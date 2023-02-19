// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    $("#alertButton").click(function () {
        var location = $("#location").val();
        var startDate = $("#startDate").val();
        var endDate = $("#endDate").val();

        $.post("/Home/GetAlerts", { location: location, startDate: startDate, endDate: endDate }, function (data) {
            $("#alertsDiv").empty();
            if (data.length == 0) {
                $("#alertsDiv").append("<h2>No alerts found.</h2>");
            } else {
                $("#alertsDiv").append("<h2>Possible closing days!!!</h2>")
                $("#alertsDiv").append("<ul>")
                for (var i = 0; i < data.length; i++) {
                    $("#alertsDiv").append("<li>" + new Date(data[i].item2[0]).toLocaleDateString() + ", " + new Date(data[i].item2[1]).toLocaleDateString() + ", " + new Date(data[i].item2[2]).toLocaleDateString() + " : " + data[i].item1 + "</li>");
                }
                $("#alertsDiv").append("</ul>")
            }
        });
    });
});
