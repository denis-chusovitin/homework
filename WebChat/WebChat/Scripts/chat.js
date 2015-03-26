$(document).ready(function () {
    $('#txtUsername').keydown(function (e) {
        if (e.keyCode == 13) {
            e.preventDefault();
            $("#btnLogin").click();
        }
    });

    $("#btnLogin").click(function () {
        var username = $("#txtUsername").val();
        if (username) {
            var href = "/Home?user=" + encodeURIComponent(username);
            href = href + "&logOn=true";
            $("#LoginButton").attr("href", href).click();

            $("#Username").text(username);
        }
    });
});

function LoginOn(result) {

    setTimeout("Refresh();", 5000);

    $('#txtMessage').keydown(function (e) {
        if (e.keyCode == 13) {
            e.preventDefault();
            $("#btnMessage").click();
        }
    });

    $("#btnMessage").click(function () {
        var text = $("#txtMessage").val();
        if (text) {
            var href = "/Home?user=" + encodeURIComponent($("#Username").text());
            href = href + "&message=" + encodeURIComponent(text);
            $("#ActionLink").attr("href", href).click();
        }
    });
}

function Refresh() {
    var href = "/Home?user=" + encodeURIComponent($("#Username").text());

    $("#ActionLink").attr("href", href).click();
    setTimeout("Refresh();", 5000);
}
