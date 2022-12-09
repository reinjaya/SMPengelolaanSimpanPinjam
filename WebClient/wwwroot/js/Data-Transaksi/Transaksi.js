$(document).ready(function () {

    $('#TableTransaksi').DataTable({
        ajax: {
            url: 'https://localhost:7189/api/User/GetAnggotaAktif',
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
                    return data.nomorAnggota;
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return data.nama;
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return data.pekerjaan;
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return new Date(data.tglMasuk).toISOString().substring(0, 10);
                }
            },
            {
                data: null,
                "render": function (data, type, row, meta) {
                    return `
                    <div class="btn-group align-items-center" role="group">
					 <a onclick="transaksiSimpanan(${data.idUser},'${data.nama}')" title="Transaksi Simpanan" class="btn btn-success btn-sm"><i class="fa fa-money-bill-wave"></i></a>
                     <a onclick="transaksiPinjaman(${data.idUser},'${data.nama}')" title="Transaksi Pinjaman" class="btn btn-primary btn-sm"><i class="fa fa-money-bill-wave"></i></a>
					</div>`;
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

function transaksiSimpanan(idUser, namaAnggota, nomorAnggota) {
    let url = window.location + '/Simpanan'
    let urlParams = new URL(url);
    urlParams.searchParams.append("user", idUser);
    urlParams.searchParams.append("nama", namaAnggota);
    location.href = urlParams.href;
}

function transaksiPinjaman(idUser, namaAnggota, nomorAnggota) {
    let url = window.location + '/Pinjaman'
    let urlParams = new URL(url);
    urlParams.searchParams.append("user", idUser);
    urlParams.searchParams.append("nama", namaAnggota);
    location.href = urlParams.href;
}