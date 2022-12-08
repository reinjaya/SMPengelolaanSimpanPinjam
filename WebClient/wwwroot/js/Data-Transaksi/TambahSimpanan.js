$(document).ready(function () {
    let idUser1 = url.searchParams.get('user');

    $.ajax({
        url: `https://localhost:7189/api/User/${idUser1}`,
        type: "GET",
        //headers: {
        //    'Authorization': "Bearer " + sessionStorage.getItem("token")
        //}
    }).done((res) => {
        $("input[name='kode_anggota']").val(res.data.nomorAnggota);
        $("input[name='nama_anggota']").val(res.data.nama);
        $("input[name='pekerjaan']").val(res.data.pekerjaan);
        console.log(res)
    });

    $.ajax({
        url: `https://localhost:7189/api/JenisSimpanan`,
        type: "GET",
        //headers: {
        //    'Authorization': "Bearer " + sessionStorage.getItem("token")
        //}
    }).done((res) => {

        $.each(res.data, function (i, item) {
            if ( i != 0) {
                $('#id_jenis_simpan').append($('<option>', {
                    value: item.besarSimpanan,
                    text: item.namaSimpanan
                }));
            }
    });
    });

    $('#id_jenis_simpan').on('change', function () {
        console.log($("#id_jenis_simpan option:selected").text())

        if ($("#id_jenis_simpan option:selected").text() == "Sukarela") {
            $("input[name='besar_simpanan']").val($("#id_jenis_simpan").val());
            $("input[name='besar_simpanan']").removeAttr("readonly")
        }
        else {
            $("input[name='besar_simpanan']").attr("readonly", true)
            $("input[name='besar_simpanan']").val($("#id_jenis_simpan").val());
        } 
    });

});


function tambahSimpananAnggota() {

    let idUser1 = url.searchParams.get('user');

    let jumlahUang = $("input[name='besar_simpanan']").val();
    console.log("MASUK FUNGSI SIMPAN")
    console.log(jumlahUang)
    console.log(idUser1)

    let data1 = {
        "idUser": idUser1,
        "userEntry": "Admin"
    }


    if ($("#id_jenis_simpan option:selected").text() == 'Sukarela') {

        $.ajax({
            url: `https://localhost:7189/api/Simpanan/TambahSimpananSukarela?idUser=${idUser1}&jumlahUang=${jumlahUang}&userEntry=Admin'`,
            type: 'POST',
            data: JSON.stringify(data1),
            headers: {
               
            },
            success: function (data) {
                console.log("MASUK FUNGSI SUKARELA")
                if (data.response == 1) {
                    Swal.fire(data.message, '', 'error').then((result) => {
                    });
                }
                else {
                    if (data.response == 2) {
                        Swal.fire(data.message, '', 'success').then((result) => {
                            let loc = window.location.href;
                            var lastIndex = loc.lastIndexOf("/");
                            var path = loc.substring(0, lastIndex);
                            var new_path = path + "/Simpanan";
                            let urlParams = new URL(new_path);
                            urlParams.searchParams.append("user", idUser1);
                            location.href = urlParams.href;
                        });
                    }
                }
            }
        });
    }

    else {
        $.ajax({
            url: `https://localhost:7189/api/Simpanan/TambahSimpananWajib?idUser=${idUser1}&userEntry=Admin`,
            type: 'POST',
            data: JSON.stringify(data1),
            headers: {
            },
            success: function (data) {
                if (data.response == 1) {
                    Swal.fire(data.message, '', 'error').then((result) => {
                    });
                }
                else {
                    if (data.response == 2) {
                        let loc = window.location.href;
                        var lastIndex = loc.lastIndexOf("/");
                        var path = loc.substring(0, lastIndex);
                        var new_path = path + "/Simpanan";
                        let urlParams = new URL(new_path);
                        urlParams.searchParams.append("user", idUser1);
                        location.href = urlParams.href;
                    }
                }
            }
        });
    }

}

