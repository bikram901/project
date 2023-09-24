$(document).ready(function () {
    $("#btns").click(function () {
        var data = {
            username:$("#txtun").val()
        };
        $.ajax({
            type: "POST",
            url: "/Profile/Modified",
            data: data,
            success: function (data) {
                alert("The User Has Been Deleted");
                window.location.href = '/AllUser/Alluser';
            },
            error: function () {
                alert("Something Went Wrong");
            }
        })
    })
})