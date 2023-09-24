$(document).ready(function () {
    $("#btnlog").click(function ()
    {
        if (Validation()) {
            var data = {
                Username: $("#username").val(),
                Password: $("#password").val(),
            };
            $.ajax({
                type: "POST",
                url: '/UserLogin/UserLogin',
                data: data,
                dataType:'json',
                success: function(Status)
                {
                    console.log(Status);
                    if (Status.status == 200)
                    {
                        alert("Login Success");
                        window.location.href = '/Profile/UserDetails?username=' + Status.username + '';
                        //$.ajax({
                        //    type: "post",
                        //    url: '/profile/userdetails',
                        //    data: data,
                        //    success: function () {
                        //        console.log(data);
                        //        //window.location.href = '/profile/userdetails';
                        //    },
                        //    error: function () {
                        //        alert("data not found");
                        //    }
                        //})
                        
                    }
                    else if (Status.status == 10) {
                        alert("Invalid User!");
                        return false;
                    }
                    else if (Status.status == 20) {
                        alert("Wrong Password!");
                        return false;
                    }
                    else if (Status.status == 21) {
                        alert("Contact to Admin");
                        return false;
                    }
                    else {
                    alert("something went wrong!");
                        return false;
                     }
                  },
                error: function () {
                    alert("sometihng went wrong");
                }
            })
           
        }

    })
    
})


function BtnRefrsh() {
    window.location.reload();
}
//$(document).ready(function () {
//    $("#ref").click(function () {
//        alert("hello");
//    })
//})
function Validation() {
    var username = $("#username").val();
    if (username == "") {
        alert("please Enter the UserName");
        return false;
    }
    var password = $("#password").val();
    if (password == "") {
        alert("please Enter the Password");
        return false;
    }
    return true;
}