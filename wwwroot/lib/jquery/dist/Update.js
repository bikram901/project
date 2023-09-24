$(document).ready(function () {
    $("#btns").click(function () {
        var data = {
            name: $("#txtname").val(),
            mob: $("#txtmob").val(),
            email: $("#txtemail").val(),
            dob: $("#txtdob").val(),
            username: $("#txtun").val(),
            password: $("#txtpwd").val()
        };
        $.ajax({
            type: "POST",
            url: "/Profile/UpdateData1",
            data: data,
            success: function () {
                alert("Data has been updated Successfully");
                window.location.href = '/AllUser/Alluser';
            },
            error: function(){
            alert("Something went Wrong");
            }
        })
    })
})