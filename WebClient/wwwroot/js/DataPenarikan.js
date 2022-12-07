let url = new URL(window.location);
let idUser = url.searchParams.get('user');
let idTabungan = url.searchParams.get('tabungan');
let namaAnggota = url.searchParams.get('nama');

$(document).ready(function () {
    $.ajax({
        url: `https://localhost:7189/api/Tabungan/TabunganById?tabunganId=${idTabungan}`,
        type: "GET",
        //headers: {
        //    'Authorization': "Bearer " + sessionStorage.getItem("token")
        //}
    }).done((res) => {
        $("#txt1").val(res.data.besarTabungan);
        $("#namaAnggotaPenarikan").html(namaAnggota);
        $("#namaAnggotaRiwayatPenarikan").html(namaAnggota);
    });

    $('#TablePenarikan').DataTable({
        ajax: {
            url: `https://localhost:7189/api/Tabungan/RiwayatPenarikan?idUser=${idUser}`,
            dataSrc: 'data',
            //headers: {
            //    'Authorization': "Bearer " + sessionStorage.getItem("token")
            //},
        },
        columns: [
            {
                data: null,
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            {
                data: 'idPenarikan', 
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return data.idTabungan;
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return data.besarPenarikan;
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return new Date(data.tglPenarikan).toISOString().substring(0, 10);
                }
            }

        ],
        columnDefs: [
            // Center align the header content of column 1
            { className: "dt-head-center", targets: "_all" },
            // Center align the body content of columns 2, 3, & 4
            { className: "dt-body-center", targets: "_all" }
        ]
    })
});

function penarikanUang() {

    let jumlahPenarikan = document.getElementById('txt2').value

    data = {
        "idUser": idUser,
        "jumlahPenarikan": jumlahPenarikan
    };

    $.ajax({
        url: `https://localhost:7189/api/Tabungan/Penarikan?idUser=${idUser}&jumlahPenarikan=${jumlahPenarikan}`,
        type: 'PUT',
        data: JSON.stringify(data),
        dataType: 'json',
        headers: {
            'Content-Type': 'application/json'
        },
        success: function (data) {
            if (data.response == 1) {
                Swal.fire(data.message, '', 'error').then((result) => {
                });
            }
            else  {
                if (data.response == 2) {
                    Swal.fire(data.message, '', 'success').then((result) => {
                        // Reload the Page
                        location.reload();
                    });
                }
            }
        }
    });
}

function sum() {
    let txtFirstNumberValue = document.getElementById('txt1').value;
    let txtSecondNumberValue = document.getElementById('txt2').value;
    let result = parseInt(txtFirstNumberValue) - parseInt(txtSecondNumberValue);

    if (!isNaN(result)) {
        document.getElementById('txt3').value = result;
    }
    else {
        document.getElementById('txt3').value = txtFirstNumberValue;
    }
}

function isNumberKey(evt) {
    let charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))

        return false;
    return true;
}