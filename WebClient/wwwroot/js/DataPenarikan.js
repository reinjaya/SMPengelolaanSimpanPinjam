$(document).ready(function () {
    let id = window.location.hash.substring(1)
    console.log(id)
    $('#TablePenarikan').DataTable({
        ajax: {
            url: `https://localhost:7189/api/Tabungan/RiwayatPenarikan?idTabungan=${id}`,
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
                data: 'idPenarikan', 
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
                    return data.besarPenarikan;
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return new Date(data.tglPenarikan).toISOString().substring(0, 10)
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