let urlDetailPinjaman = new URL(window.location);
let idUserAngsuran = url.searchParams.get('user');
let idDetailPinjaman = url.searchParams.get('pinjam');
let namaAnggotaPinjaman = url.searchParams.get('nama');

$(document).ready(function () {
    let namaAnggotaPinjaman = url.searchParams.get('nama');
    console.log(namaAnggotaPinjaman)
    $("#namaAnggotaAngsuran1").val(namaAnggotaPinjaman); 
    $('#TableRiwayatAngsuran').DataTable({
        ajax: {
            url: `https://localhost:7189/api/Angsuran/RiwayatAngsuran?idPinjaman=${idDetailPinjaman}`,
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
                    return data.idAngsuran;
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return data.idPinjaman;
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return new Date(data.tglEntry).toISOString().substring(0, 10);;
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return data.angsuranKe;
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return data.besarAngsuran;
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return data.denda;
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

function backPinjamanAnggota() {
    let loc = window.location.href;
    var lastIndex = loc.lastIndexOf("/");
    var path = loc.substring(0, lastIndex);
    var new_path = path + "/Pinjaman";
    let urlParams = new URL(new_path);
    urlParams.searchParams.append("user", idUser);
    urlParams.searchParams.append("nama", namaAnggota);
    location.href = urlParams.href;
}