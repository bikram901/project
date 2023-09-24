$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: "/AllUser/Alluser1",
        success: function (data) {
            //alert(data[0].name);
            var tab = "<table class='table table-responsive'><tr><th class='text-center'>Name</th><th class='text-center'>Mobile</th><th class='text-center'>Email</th><th class='text-center'>Dob</th><th class='text-center'>UserName</th><th class='text-center'>Role</th><th class='text-center'>Operation</th></tr >";
            for (var i = 0; i < data.length; i++) {
                tab = tab + "<tr><td class='text-center'>" + data[i].name + "</td><td class='text-center'>" + data[i].mob + "</td><td class='text-center'>" + data[i].email + "</td><td>" + data[i].dob + "</td><td class='text-center'>" + data[i].username + "</td><td class='text-center'>" + data[i].userrole + "</td><td class='text-center'><a href='/Profile/UpdateData'><span id='edit' class='fa fa-edit'style='color:green';font-size:30px'></span></a>" + "                    " +"<a href='/Profile/ModifiedUsers'><span class='fa fa-trash'style='color:red';font-size:30px'></span></a></td></tr > ";
            }
            $("#alldata").html(tab);
            tab = tab + "</table>";
            //var tab = "";
            //for (var i = 0; i < data.length; i++) {
            //    tab = tab + "<tr>< td >" + data[i].name + "</td ><td>" + data[i].mob + "</td<td>" + data[i].email + "</td<td>" + data[i].dob + "</td<td>" + data[i].username + "</td<td>" + data[i].userrole + "</td</tr > ";
            //    $("#alldata").html(tab);
            //}
            
        },
        error: function () {
            alert("Something went Wrong");
        }
    })
    
})