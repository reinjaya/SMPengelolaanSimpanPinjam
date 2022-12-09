$(document).ready(function () {
    let idUserPage12 = sessionStorage.getItem("idUser")
    $('#TablePengajuanAnggota').DataTable({
        ajax: {
            url: `https://localhost:7189/api/Pengajuan/DaftarPengajuanAnggota?idUser=${idUserPage12}`,
            dataSrc: `data`,
            "headers": {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            "type": "GET"

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
                    return data.idPengajuan;
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return new Date(data.tglPengajuan).toISOString().substring(0, 10);
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return "Rp. " + data.besarPinjaman;
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    if (data.status == 'Menunggu') {
                        return `<span class="badge badge-info">Menunggu</span>`;
                    }

                    else if (data.status == 'Ditolak') {
                        return `<span class="badge badge-danger">Ditolak</span>`;
                    }

                    else if (data.status == 'Diterima') {
                        return `<span class="badge badge-success">Diterima</span>`;
                    }
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    if (data.status == 'Menunggu') {
                        return "Tanggal tidak tersedia"
                    }
                    return new Date(data.tglAcc).toISOString().substring(0, 10);
                }
            },
        ],
        columnDefs: [
            //{
            //    targets: [5],
            //    render: $.fn.dataTable.render.moment('YYYY-MM-DDTHH:mm:ss.SSS', 'YYYY/MM/DD')
            //},
            // Center align the header content of column 1
            { className: "dt-head-center", targets: "_all" }
            // Center align the body content of columns 2, 3, & 4
        ]
    });
});

function tambahPinjamanAnggotaPage() {
    let loc = window.location.href;
    var lastIndex = loc.lastIndexOf("/");
    var path = loc.substring(0, lastIndex);
    var new_path = path + "/TambahPengajuan";
    let urlParams = new URL(new_path);
    location.href = urlParams.href;
}

function backPinjamanAnggotaPage() {
    let loc = window.location.href;
    var lastIndex = loc.lastIndexOf("/");
    var path = loc.substring(0, lastIndex);
    var new_path = path + "/Pengajuan";
    let urlParams = new URL(new_path);
    location.href = urlParams.href;
}