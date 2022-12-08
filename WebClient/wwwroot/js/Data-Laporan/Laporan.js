$(document).ready(function () {

    $('#TableAnggota').DataTable({
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
            { data: 'nomorAnggota', },
            { data: 'nama', },
            { data: 'tglLahir', },
            { data: 'pekerjaan', },
            { data: 'tglMasuk', },
            {
                data: 'status',
                "render": function (data, type, row, meta) {
                    if (row.status == 'Aktif') {
                        return `
                    <span class='badge badge-success'>Aktif</span>
                    `;
                    } else {
                        return `
                    <span class='badge badge-danger'>Keluar</span>
                    `;
                    }

                }
            }

        ],
        columnDefs: [
            //{
            //    targets: [5],
            //    render: $.fn.dataTable.render.moment('YYYY-MM-DDTHH:mm:ss.SSS', 'YYYY/MM/DD')
            //},

            {
                targets: [3, 5],
                render: $.fn.dataTable.render.moment('YYYY-MM-DDTHH:mm:ss', 'YYYY/MM/DD')
            },
            // Center align the header content of column 1
            { className: "dt-head-center", targets: "_all" }
            // Center align the body content of columns 2, 3, & 4
        ],
        dom: 'Bfrtip',
        buttons: [
            'colvis',
            'excel',
            'print',
            'pdf'
        ]
    });
});
