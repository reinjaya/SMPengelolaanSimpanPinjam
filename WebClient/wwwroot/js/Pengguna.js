var dataSetPengguna = [
    ['1', 'U0001', 'Admin', 'Admin', 'Admin', 'admin'],
    ['2', 'U0002', 'Operator 1', 'Operator 1', 'Operator 1', 'operator1'],
    ['3', 'U0003', 'Operator 2', 'Operator 2', 'Operator 2', 'operator2'],
];

$(document).ready(function () {

    $('#TablePengguna').DataTable({
        data: dataSetPengguna,
        columns: [
            { dataSetPengguna: null, },
            { dataSetPengguna: null, },
            { dataSetPengguna: null, },
            { dataSetPengguna: null, },
            { dataSetPengguna: null, },
            { dataSetPengguna: null, },
            {
                dataSetPengguna: null,
                "render": function (data, type, row, meta) {
                    return `
                    <div class="btn-group align-items-center" role="group">
					<a href="#editModalPengguna" title="Edit Data" class="btn btn-warning btn-sm" data-toggle="modal" data-target="#editModalPengguna"><i class="fa fa-edit"></i></a>
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
    })
});