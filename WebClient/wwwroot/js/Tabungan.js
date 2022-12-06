var dataSetTabungan = [
    ['1', '10', 'A0001', 'Faris Fadiila', 'Rp.100.000'],
    ['2', '11', 'A0002', 'Tamara Gunawan','Rp.80.000'],
    ['3', '12', 'A0003', 'Ian Pramana', 'Rp.60.000'],
    ['4', '13', 'A0004', 'Rio Ferrizko', 'Rp.40.000'],
    ['5', '14', 'A0005', 'Lisa Manoban', 'Rp.20.000']
];

$(document).ready(function () {

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
                    return data.id;
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
                dataSetTabungan: null,
                "render": function (data, type, row, meta) {
                    return `
                    <a onclick="ambilUang()" href="/Tabungan/Penarikan" title="Ambil Uang" class="btn btn-primary btn-sm"><i class="fa fa-money-bill-wave"></i></a>
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