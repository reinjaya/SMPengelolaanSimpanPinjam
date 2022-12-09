$(document).ready(function () {
    $('#TableDataUser').DataTable({
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
                    return data.userName;
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return data.nama;
                }
            },
            {
                data: 'status',
                "render": function (data, type, row, meta) {
                    if (row.status == 'Aktif') {
                        return `
                    <span class='badge badge-success'>Aktif</span>
                    `;
                    }
                }
            },
            {
                data: null,
                "render": function (data, type, row, meta) {

                    if (row.status == 'Aktif') {
                        return `
                    <div class="btn-group align-items-center" role="group">
					<a title="Angkat Admin" onclick="angkatAdmin('${data.idUser}')" class="btn btn-warning btn-sm"><i class="fa fa-edit"></i></a>
                    <a title="Angkat Petugas" onclick="angkatPetugas('${data.idUser}')" class="btn btn-primary btn-sm"><i class="fa fa-sign-out-alt"></i></a>	
					</div>
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
    });
});

function angkatAdmin(id) {
    Swal.fire({
        title: 'Jadikan Admin?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, do it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: `https://localhost:7189/api/User/GantiRole?userId=${id}&idRole=${1}`,
                type: "PUT",
                contentType: "application/json",
                success: function () {
                    Swal.fire({
                        icon: 'success',
                        title: 'Tambah Data!',
                        text: 'Berhasil menambahkan admin.',
                        showConfirmButton: false,
                        timer: 1500
                    });
                    setTimeout(function () {
                        location.reload();
                    }, 1500);
                },
                error: function () {
                }
            });
        }
    });
}

function angkatPetugas(id) {
    Swal.fire({
        title: 'Jadikan Petugas?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, do it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: `https://localhost:7189/api/User/GantiRole?userId=${id}&idRole=${2}`,
                type: "PUT",
                contentType: "application/json",
                success: function () {
                    Swal.fire({
                        icon: 'success',
                        title: 'Tambah Data!',
                        text: 'Berhasil menambahkan petugas.',
                        showConfirmButton: false,
                        timer: 1500
                    });
                    setTimeout(function () {
                        location.reload();
                    }, 1500);
                },
                error: function () {
                }
            });
        }
    });
}