$(document).ready(function () {

    $('#TablePengajuan').DataTable({
        ajax: {
            url: 'https://localhost:7189/api/Pengajuan/GetDaftarPengajuan',
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
                    return data.idPengajuan;
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
                    return new Date(data.tglPengajuan).toISOString().substring(0, 10);
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return "Rp. " + data.besarPinjam;
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return data.jenisPinjam;
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
                    return new Date(data.tglTerima).toISOString().substring(0, 10);
                }
            },
            {
                data: null,
                "render": function (data, type, row, meta) {

                    if (data.status == 'Menunggu') {
                        return `
                    <div class="btn-group align-items-center" role="group">
					 <a title="Terima Pengajuan" onclick="prosesPengajuan(${data.idPengajuan}, ${true})" class="btn btn-success btn-sm"><i class="fas fa-check"></i></a>
                     <a title="Tolak Pengajuan" onclick="prosesPengajuan(${data.idPengajuan}, ${false})" class="btn btn-danger btn-sm"><i class="fas fa-trash"></i></a>
					</div>`;
                    } else {
                        return `
                    <span class='badge badge-secondary'>Tidak Tersedia</span>
                    `;
                    }
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

function prosesPengajuan(idPengajuan, respon) {
    data = {
        "idPengajuan": idPengajuan,
        "terimaPengajuan": respon
    };

    console.log(data)

    $.ajax({
        url: `https://localhost:7189/api/Pengajuan/ProsesPengajuan?idPengajuan=${idPengajuan}&terimaPengajuan=${respon}`,
        type: 'PUT',
        data: JSON.stringify(data),
        dataType: 'json',
        headers: {
            'Content-Type': 'application/json'
        },
        success: function (data) {
            if (data.response == 0) {
                Swal.fire(data.message, '', 'error').then((result) => {
                });
            }
            else {
                Swal.fire(data.message, '', 'success').then((result) => {
                    // Reload the Page
                    location.reload();
                });
            }
        }
    });
}