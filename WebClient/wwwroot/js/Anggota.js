//var dataSetAnggota = [
//    ['1', 'A0001', 'Faris Fadiila', 'Karawang, 1999-08-23', 'Swasta', '2022-12-05'],
//    ['2', 'A0002', 'Tamara Gunawan', 'Jakarta, 2001-09-30', 'Swasta', '2022-12-05'],
//    ['3', 'A0003', 'Ian Pramana', 'Jakarta, 1998-05-11', 'Swasta', '2022-12-05'],
//    ['4', 'A0004', 'Rio Ferrizko', 'Jakarta, 1994-02-4', 'Swasta', '2022-12-05'],
//    ['5', 'A0005', 'Lisa Manoban', 'Medan, 1999-09-10', 'Penyanyi', '2022-12-05']
//];

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
            {
                data: 'tglLahir', /*render: $.fn.dataTable.render.moment( 'M/D/YYYY' )*/
                //"render": function (data, type, row, meta) {

                //    return `<p>${data.format('D-MM-YYYY')}</p>`;
                //}  
            },
            { data: 'pekerjaan', },
            { data: 'tglEntry', },
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
            },
            {
                data: null,
                "render": function (data, type, row, meta) {

                    if (row.status == 'Aktif') {
                    return `
                    <div class="btn-group align-items-center" role="group">
					<a href="#editModalAnggota" title="Edit Data" class="btn btn-warning btn-sm" data-toggle="modal" data-target="#editModalAnggota"><i class="fa fa-edit"></i></a>
                    <a title="Keluarkan Anggota" href="#" class="btn btn-primary btn-sm"><i class="fa fa-sign-out-alt"></i></a>	
					</div>
                    `;
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

function addAnggota() {
    let data = new Object();
    let id = 0;
    let nomor_anggota = "";
    let nama = $('#nama_anggota').val();
    let email = $('#email_anggota').val();
    let username = $('#username_anggota').val();
    let password = "";
    let alamat = $('#alamat_anggota').val();
    let jk = $('#jenis_kelamin').val();
    let pekerjaan = $('#pekerjaan_anggota').val();
    let tgl_masuk = $('#tgl_masuk').val();
    let idRole = 3;
    let telpon = $('#telpon_anggota').val();
    let lahir = $('#tmp_lahir').val();
    let tgl_lahir = new Date($('#tgl_lahir').val()).toLocaleDateString() + " 02:26:42";
    let status = "";
    let u_entry = $('#u_entry').val();
    let tgl_entry = $('#tgl_entry').val();

    data.idUser = id;
    data.nomorAnggota = nomor_anggota;
    data.nama = nama;
    data.email = email;
    data.userName = username;
    data.password = password;
    data.alamat = alamat;
    data.jenisKelamin = jk;
    data.pekerjaan = pekerjaan;
    data.tglMasuk = tgl_masuk;
    data.idRole = idRole;
    data.telepon = telpon;
    data.tempatLahir = lahir;
    data.tglLahir = tgl_lahir;
    data.status = status;
    data.userEntry = u_entry;
    data.tglEntry = tgl_entry;


    //data = {
    //    "idUser": id,
    //    "nomorAnggota": nomor_anggota,
    //    "nama": nama,
    //    "email": email,
    //    "userName": username,
    //    "password": password,
    //    "alamat": alamat,
    //    "jenisKelamin": jk,
    //    "pekerjaan": pekerjaan,
    //    "tglMasuk": tgl_masuk,
    //    "idRole": idRole,
    //    "telepon": telpon,
    //    "tempatLahir": lahir,
    //    "tglLahir": tgl_lahir,
    //    "status": status,
    //    "userEntry": u_entry,
    //    "tglEntry": tgl_entry
    //};
    console.log(data);
    $.ajax({
        url: `https://localhost:7189/api/User`,
        type: 'POST',
        data: JSON.stringify(data),
        dataType: 'json',
        headers: {
            'Content-Type': 'application/json'
        },
        success: function () {
            Swal.fire({
                icon: 'success',
                title: 'Data Berhasil Ditambahkan',
                showConfirmButton: false,
                timer: 1500
            });
            setTimeout(function () {
                location.reload();
            }, 1500);
        }
    });
}