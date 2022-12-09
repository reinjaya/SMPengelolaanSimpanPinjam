$(document).ready(function () {

    let role = sessionStorage.getItem("role")
    let nama = sessionStorage.getItem("nama");
    let location = window.location.pathname
    if (location != '/Login') {
        if (role == null) {
            window.location.replace("../Login");
        }
    }

});

function login() {

    let data = new Object();
    data.username = $('#usernameLogin').val();
    data.password = $('#passwordLogin').val();

    $.ajax({
        url: `https://localhost:7189/api/Account/Login`,
        method: 'POST',
        data: JSON.stringify(data),
        dataType: 'json',
        headers: {
            'Content-Type': 'application/json'
        },
        success: function (d) {
            sessionStorage.setItem("idUser", d.data.id);
            sessionStorage.setItem("token", d.token);
            sessionStorage.setItem("role", d.data.roleName);
            sessionStorage.setItem("nama", d.data.name);

            if (d.data.roleName == 'Anggota') {
                window.location.replace("../Anggota");
            }

            if (d.data.roleName == 'Admin') {
                window.location.replace("../DataAnggota");
            }


        }
    });

}