$(document).ready(function () {
    $("#btns").click(function ()
    {
        if (Validation()) {
            var data = {
                name: $("#txtname").val(),
                mob: $("#txtmob").val(),
                email: $("#txtemail").val(),
                dob: $("#txtdob").val(),
                username: $("#txtun").val(),
                password: $("#txtpwd").val(),
                userrole: $("#userrole").val()
            }


            //calling of method by using ajax
            $.ajax({
                type: "POST",
                url: "/SignUp/InsertRecord",
                data: data,
                success: function (data) {
                    alert("Data has been stored in the database");
                    $("#txtname").val("");
                    $("#txtmob").val("");
                    $("#txtemail").val("");
                    $("#txtdob").val("");
                    $("#txtun").val("");
                    $("#txtpwd").val("");
                    $("#userrole").val($("#def").val());
                    $("#txtcnpwd").val("")
                },
                error: function () {
                    alert("sometihng went wrong");
                }

            })
        }
        
       
    })
    function Validation() {
        var pwd = $("#txtpwd").val();
        var cnpwd = $("#txtcnpwd").val();
        if (pwd != cnpwd) {
            alert("Check Your Password");
            return false;
        }
        return true;

    }
})