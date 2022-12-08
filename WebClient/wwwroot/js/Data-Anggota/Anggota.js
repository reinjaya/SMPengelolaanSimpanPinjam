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
            },
            {
                data: null,
                "render": function (data, type, row, meta) {

                    if (row.status == 'Aktif') {
                        return `
                    <div class="btn-group align-items-center" role="group">
					<a title="Edit Data" onclick="editAnggota('${data.idUser}')" class="btn btn-warning btn-sm" data-toggle="modal" data-target="#editModalAnggota"><i class="fa fa-edit"></i></a>
                    <a title="Keluarkan Anggota" onclick="keluarAnggota('${data.idUser}')" class="btn btn-primary btn-sm"><i class="fa fa-sign-out-alt"></i></a>	
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
        ]
    });
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
    let tgl_masuk = new Date($('#tgl_masuk').val()).toJSON();
    let idRole = 3;
    let telpon = $('#telpon_anggota').val();
    let lahir = $('#tmp_lahir').val();
    let tgl_lahir = new Date($('#tgl_lahir').val()).toJSON();
    let status = "";
    let u_entry = $('#u_entry').val();
    let tgl_entry = new Date($('#tgl_entry').val()).toJSON();

    data = {
        "idUser": id,
        "nomorAnggota": nomor_anggota,
        "nama": nama,
        "email": email,
        "userName": username,
        "password": password,
        "alamat": alamat,
        "jenisKelamin": jk,
        "pekerjaan": pekerjaan,
        "tglMasuk": tgl_masuk,
        "idRole": idRole,
        "telepon": telpon,
        "tempatLahir": lahir,
        "tglLahir": tgl_lahir,
        "status": status,
        "userEntry": u_entry,
        "tglEntry": tgl_entry
    };

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
                text: 'Berhasil menambahkan data anggota.',
                showConfirmButton: false,
                timer: 1500
            });
            setTimeout(function () {
                location.reload();
            }, 1500);
        }
    });
}

function editAnggota(idUser) {
    $.ajax({
        url: `https://localhost:7189/api/User/${idUser}`,
        type: "GET"
    }).done((res) => {
        let temp = "";
        temp += `
            <div class="row">
            <input type="hidden" class="form-control" id="id_role1" value="${res.data.idRole}" readonly>
            <input type="hidden" class="form-control" id="tgl_masuk1" value="${res.data.tglMasuk}" readonly>
            <input type="hidden" class="form-control" id="username_anggota1" value="${res.data.userName}" readonly>
            <input type="hidden" class="form-control" id="status1" value="${res.data.status}" readonly>
            <input type="hidden" class="form-control" id="password1" value="${res.data.password}" readonly>
				<div class="form-group col-md-6">
					<label class="font-weight-bold">Nomor Anggota</label>
					<input autocomplete="off" type="text" id="nomor_anggota1" value="${res.data.nomorAnggota}" required class="form-control" readonly="readonly"/>
				</div>
    		<div class="form-group col-md-6">
			    <label class="font-weight-bold">Nama Lengkap</label>
			    <input autocomplete="off" type="text" id="nama_anggota1" value="${res.data.nama}" required class="form-control"/>
			</div>
		    <div class="form-group col-md-6">
			    <label class="font-weight-bold">Email</label>
				<input autocomplete="off" type="email" id="email_anggota1" value="${res.data.email}" required class="form-control" />
			</div>
				<div class="form-group col-md-6">
					<label class="font-weight-bold">Alamat</label>
					<input autocomplete="off" type="text" id="alamat_anggota1" value="${res.data.alamat}" required class="form-control"/>
				</div>
				<div class="form-group col-md-6">
					<label class="font-weight-bold">Jenis Kelamin</label>
					<select id="jenis_kelamin1" class="form-control" required>
						<option value="${res.data.jenisKelamin}">${res.data.jenisKelamin}</option>
						<option value="Laki-laki">Laki-laki</option>
						<option value="Perempuan">Perempuan</option>
					</select>
				</div>
				<div class="form-group col-md-6">
					<label class="font-weight-bold">Pekerjaan</label>
					<input autocomplete="off" type="text" id="pekerjaan_anggota1" value="${res.data.pekerjaan}" required class="form-control"/>
				</div>
				<div class="form-group col-md-6">
					<label class="font-weight-bold">Telpon</label>
					<input autocomplete="off" type="text" id="telpon_anggota1" value="${res.data.telepon}" required class="form-control" />
				</div>
				
				<div class="form-group col-md-6">
					<label class="font-weight-bold">Tempat Lahir</label>
					<input autocomplete="off" type="text" id="tmp_lahir1" value="${res.data.tempatLahir}" required class="form-control"/>
				</div>
				
				<div class="form-group col-md-6">
					<label class="font-weight-bold">Tanggal Lahir</label>
					<input autocomplete="off" type="date" id="tgl_lahir1" value="${new Date(res.data.tglLahir).toISOString().substring(0, 10)}" required class="form-control"/>
				</div>
				
				<div class="form-group col-md-6">
					<label class="font-weight-bold">User Entri</label>
					<input autocomplete="off" type="text" id="u_entry1" required class="form-control" value="Admin" readonly="readonly"/>
				</div>
				<div class="form-group col-md-6">
					<label class="font-weight-bold">Tanggal Entri</label>
					<input autocomplete="off" id="tgl_entry1" value="${new Date().toLocaleDateString()}" readonly required class="form-control" />
				</div>
            </div>
 
            	<div class="modal-footer">
                    <button type="button" class="btn btn-primary" onclick="saveEditAnggota(${res.data.idUser})"><i class="fa fa-save"></i> Update</button>
				    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-times"></i> Tutup</button>
                </div>
            `;

        $("#editDataAnggota").html(temp);


    }).fail((err) => {
        console.log(err);
    });
}

function saveEditAnggota(idUser) {
    var Id = idUser;
    var nomor_anggota = $('#nomor_anggota1').val();
    var nama = $('#nama_anggota1').val();
    var email = $('#email_anggota1').val();
    var username = $('#username_anggota1').val();
    var password = $('#password1').val();
    var alamat = $('#alamat_anggota1').val();
    var jk = $('#jenis_kelamin1').val();
    var pekerjaan = $('#pekerjaan_anggota1').val();
    var tgl_masuk = new Date($('#tgl_masuk1').val()).toISOString();
    var idRole = parseInt($('#id_role1').val());
    var telpon = $('#telpon_anggota1').val();
    var lahir = $('#tmp_lahir1').val();
    var tgl_lahir = new Date($('#tgl_lahir1').val()).toISOString();
    var status = $('#status1').val();;
    var u_entry = $('#u_entry1').val();
    var tgl_entry = new Date($('#tgl_entry1').val()).toISOString();

    /* var res = {Id, nomor_anggota, nama, email, username, password, alamat, jk, pekerjaan, tgl_masuk, idRole, telpon, lahir, tgl_lahir, status, u_entry, tgl_entry};*/
    let res = {

        "idUser": Id,
        "nomorAnggota": nomor_anggota,
        "nama": nama,
        "email": email,
        "userName": username,
        "password": password,
        "alamat": alamat,
        "jenisKelamin": jk,
        "pekerjaan": pekerjaan,
        "tglMasuk": tgl_masuk,
        "idRole": idRole,
        "telepon": telpon,
        "tempatLahir": lahir,
        "tglLahir": tgl_lahir,
        "status": status,
        "userEntry": u_entry,
        "tglEntry": tgl_entry

    };
    $.ajax({
        url: `https://localhost:7189/api/User/GantiDataAnggota`,
        type: "PUT",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(res),
        success: function () {
            Swal.fire({
                icon: 'success',
                title: 'Update!',
                text: 'Data anggota berhasil diupdate.',
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

function keluarAnggota(id) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, do it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: `https://localhost:7189/api/User/Keluarkan?id=${id}&keluarkan=${true}`,
                type: "PUT",
                contentType: "application/json",
                success: function () {
                    Swal.fire({
                        icon: 'success',
                        title: 'Keluar!',
                        text: 'Anggota berhasil dikeluarkan.',
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