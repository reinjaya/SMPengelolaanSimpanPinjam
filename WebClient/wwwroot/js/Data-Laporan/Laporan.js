$(document).ready(function () {

    $('#TableLaporanAnggota').DataTable({
        ajax: {
            url: `https://localhost:7189/api/User/GetAnggota`,
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
                    return new Date(data.tglLahir).toISOString().substring(0, 10);
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return data.alamat;
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return data.email;
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return data.jenisKelamin;
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
                data: 'status',
                "render": function (data, type, row, meta) {
                    if (row.status == 'Aktif') {
                        return `
                    <span class='badge badge-success'>Aktif</span>
                    `;
                    } else if (row.status == 'Keluar') {
                        return `
                    <span class='badge badge-danger'>Keluar</span>
                    `;
                    }
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return data.telepon;
                }
            },

        ],
        columnDefs: [

            // Center align the header content of column 1
            { className: "dt-head-center", targets: "_all" }
            // Center align the body content of columns 2, 3, & 4
        ],
        dom: 'Bfrtip',
        buttons: [
            'colvis',
            {
                extend: 'pdfHtml5',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 6, 7, 8, 9]
                }
            },
            {
                extend: 'excelHtml5',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 6, 7, 8, 9]
                }
            },

        ]
    });
});