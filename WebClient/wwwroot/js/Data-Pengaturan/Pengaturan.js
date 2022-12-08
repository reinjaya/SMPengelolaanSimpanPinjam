var dataSetSimpan = [
    ['1', 'Pokok', 'Rp. 10.000', 'Admin', '3 Desember 2022'],
    ['2', 'Wajib', 'Rp. 70.000', 'Admin', '3 Desember 2022'],
    ['3', 'Sukarela', 'Rp. 0', 'Admin', '3 Desember 2022']
];

var dataSetPinjam = [
    ['1', 'Biasa', '4 Bulan', 'Rp. 2.000.000', '2%', 'Admin', '3 Desember 2022'],
    ['2', 'Menengah', '8 Bulan', 'Rp. 3.000.000', '4%', 'Admin', '3 Desember 2022'],
    ['3', 'Full', '12 Bulan', 'Rp. 4.000.000', '10%', 'Admin', '3 Desember 2022']
];

$(document).ready(function () {

    $('#TableJenisSimpanan').DataTable({
        data: dataSetSimpan,
        columns: [
            { dataSetSimpan: null, },
            { dataSetSimpan: null, },
            { dataSetSimpan: null, },
            { dataSetSimpan: null, },
            { dataSetSimpan: null, },
            {
                dataSetSimpan: null,
                "render": function (data, type, row, meta) {
                    return `
                    <div class="btn-group align-items-center" role="group">
					<a href="#editModalSimpanan" title="Edit Data" class="btn btn-warning btn-sm" data-toggle="modal" data-target="#editModalSimpanan"><i class="fa fa-edit"></i></a>
								
					<a title="Hapus Data" class="btn btn-danger btn-sm"><i class="fa fa-trash"></i></a>
					</div>
                    `;
                }
            }

        ],
        columnDefs: [
            // Center align the header content of column 1
            { className: "dt-head-center", targets: "_all" },
            // Center align the body content of columns 2, 3, & 4
            { className: "dt-body-center", targets: "_all" }
        ]
    });

    $('#TableJenisPinjaman').DataTable({
        data: dataSetPinjam,
        columns: [
            { dataSetPinjam: null, },
            { dataSetPinjam: null, },
            { dataSetPinjam: null, },
            { dataSetPinjam: null, },
            { dataSetPinjam: null, },
            { dataSetPinjam: null, },
            { dataSetPinjam: null, },
            {
                dataSetPinjam: null,
                "render": function (data, type, row, meta) {
                    return `
                    <div class="btn-group align-items-center" role="group">
					<a href="#editModalPinjaman" title="Edit Data" class="btn btn-warning btn-sm" data-toggle="modal" data-target="#editModalPinjaman"><i class="fa fa-edit"></i></a>
								
					<a title="Hapus Data" class="btn btn-danger btn-sm"><i class="fa fa-trash"></i></a>
					</div>
                    `;
                }
            }

        ],
        columnDefs: [
            // Center align the header content of column 1
            { className: "dt-head-center", targets: "_all" },
            // Center align the body content of columns 2, 3, & 4
            { className: "dt-body-center", targets: "_all" }
        ]
    });
});