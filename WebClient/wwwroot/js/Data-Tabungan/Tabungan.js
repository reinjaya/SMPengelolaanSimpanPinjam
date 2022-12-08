$(document).ready(function () {

    $.ajax({
        url: `https://localhost:7189/api/Tabungan/TotalTabungan`,
        type: "GET",
        //headers: {
        //    'Authorization': "Bearer " + sessionStorage.getItem("token")
        //}
    }).done((res) => {
        $("#totalSaldoTabungan").html(res.data);
    });


    $('#TableTabungan').DataTable({
        ajax: {
            url: 'https://localhost:7189/api/Tabungan/DaftarTabungan',
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
                    return data.idTabungan;
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return data.nomorAnggota;
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return data.namaAnggota;
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return data.jumlahSaldo;
                }
            },
            {
                data: null,
                "render": function (data, type, row, meta) {
                    return `
                    <a onclick="ambilUang(${data.idUser},${data.idTabungan},'${data.namaAnggota}')" title="Ambil Uang" class="btn btn-primary btn-sm"><i class="fa fa-money-bill-wave"></i></a>
                    `;
                }
            },

        ],
        columnDefs: [
            // Center align the header content of column 1
            { className: "dt-head-center", targets: "_all" },
            // Center align the body content of columns 2, 3, & 4
            { className: "dt-body-center", targets: "_all" }
        ]
    });
});


function ambilUang(id, idTabungan, namaAnggota) {
    let url = window.location + '/Penarikan'
    let urlParams = new URL(url);
    urlParams.searchParams.append("user", id);
    urlParams.searchParams.append("tabungan", idTabungan);
    urlParams.searchParams.append("nama", namaAnggota);
    location.href = urlParams.href;
}