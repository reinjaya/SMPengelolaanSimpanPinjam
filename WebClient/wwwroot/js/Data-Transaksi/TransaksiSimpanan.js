url = new URL(window.location);
idUser = url.searchParams.get('user');
namaAnggota = url.searchParams.get('nama');

$(document).ready(function () {
    $.ajax({
        url: `https://localhost:7189/api/Tabungan/TabunganById?tabunganId=${idUser}`,
        type: "GET",
        //headers: {
        //    'Authorization': "Bearer " + sessionStorage.getItem("token")
        //}
    }).done((res) => {
        $("#totalSaldoSimpanan").html(res.data.besarTabungan);
        $("#namaAnggotaSimpanan").html(namaAnggota);
    });

    $('#TableTransaksiSimpanan').DataTable({
        ajax: {
            url: `https://localhost:7189/api/Simpanan/DaftarSimpananAnggota?idUser=${idUser}`,
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
                data: null,
                render: function (data, type, row, meta) {
                    return new Date(data.tglSimpan).toISOString().substring(0, 10);
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return data.namaSimpanan;
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return data.besarSimpanan;
                }
            },

        ],
        columnDefs: [
            // Center align the header content of column 1
            { className: "dt-head-center", targets: "_all" },
            // Center align the body content of columns 2, 3, & 4
            { className: "dt-body-center", targets: "_all" }
        ]
    })
});

function wajibSimpanan() {
    let loc = window.location.href;
    var lastIndex = loc.lastIndexOf("/");
    var path = loc.substring(0, lastIndex);
    var new_path = path + "/TambahSimpanan";
    let urlParams = new URL(new_path);
    urlParams.searchParams.append("user", idUser);
    location.href = urlParams.href;
}

function back() {
    let loc = window.location.href;
    var lastIndex = loc.lastIndexOf("/");
    var path = loc.substring(0, lastIndex);
    var new_path = path + "/Simpanan";
    let urlParams = new URL(new_path);
    urlParams.searchParams.append("user", idUser);
    urlParams.searchParams.append("nama", namaAnggota);
    location.href = urlParams.href;
}