$(document).ready(function () {

    $('#TableJenisSimpanan').DataTable({
        ajax: {
            url: `https://localhost:7189/api/JenisSimpanan`,
            dataSrc: `data`,
            "headers": {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            "type": "GET"

        },
        columns: [
            //{
            //    data: null,
            //    render: function (data, type, row, meta) {
            //        return meta.row + meta.settings._iDisplayStart + 1;
            //    }
            //},
            { data: 'idJenisSimpanan', },
            { data: 'namaSimpanan', },
            { data: 'besarSimpanan', },
            { data: 'userEntry', },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return new Date(data.tglEntry).toISOString().substring(0, 10);
                }
            },
            {
                data: null,
                "render": function (data, type, row, meta) {
                    return `
					<a title="Edit Data" class="btn btn-warning btn-sm" onclick="editJenisSimpanan('${data.idJenisSimpanan}')" data-toggle="modal" data-target="#editModalSimpanan"><i class="fa fa-edit"></i></a>
                    `;
                }
            }

        ],
        columnDefs: [
            { className: "dt-head-center", targets: "_all" },
        ]
    });

    $('#TableJenisPinjaman').DataTable({
        ajax: {
            url: `https://localhost:7189/api/JenisPinjaman`,
            dataSrc: `data`,
            "headers": {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            "type": "GET"

        },
        columns: [
            { data: 'idJenisPinjaman', },
            { data: 'namaPinjaman', },
            { data: 'lamaAngsuran', },
            { data: 'maksPinjaman', },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return data.bunga * 100;
                }
            },
            { data: 'userEntry', },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return new Date(data.tglEntry).toISOString().substring(0, 10);
                }
            },
            {
                data: null,
                "render": function (data, type, row, meta) {
                    return `
					<a title="Edit Data" class="btn btn-warning btn-sm" onclick="editJenisPinjaman('${data.idJenisPinjaman}')" data-toggle="modal" data-target="#editModalPinjaman"><i class="fa fa-edit"></i></a>			
                    `;
                }
            }

        ],
        columnDefs: [
            { className: "dt-head-center", targets: "_all" },
        ]
    });
});

function editJenisSimpanan(idJenisSimpanan) {
    $.ajax({
        url: `https://localhost:7189/api/JenisSimpanan/${idJenisSimpanan}`,
        type: "GET"
    }).done((res) => {
        let temp = "";
        temp += `
              <div class="row">
					<div class="form-group col-md-6">
						<label class="font-weight-bold">Kode Simpanan</label>
						<input autocomplete="off" type="text" id="kode_jenis_simpan" value="${res.data.idJenisSimpanan}" readonly required class="form-control" />
					</div>

					<div class="form-group col-md-6">
						<label class="font-weight-bold">Jenis Simpanan</label>
						<input autocomplete="off" type="text" id="nama_simpanan" value="${res.data.namaSimpanan}" required class="form-control" />
					</div>

					<div class="form-group col-md-6">
						<label class="font-weight-bold">Besar Simpanan</label>
						<input autocomplete="off" type="number" id="besar_simpanan" value="${res.data.besarSimpanan}" required class="form-control" />
					</div>

					<div class="form-group col-md-6">
						<label class="font-weight-bold">User Entri</label>
						<input autocomplete="off" type="text" id="u_entry_jenis_simpanan" value="${res.data.userEntry}" readonly required class="form-control" />
					</div>

					<div class="form-group col-md-6">
						<label class="font-weight-bold">Tanggal Entri</label>
						<input autocomplete="off" type="text" value="${new Date().toLocaleDateString()}" id="tgl_entry_jenis_simpanan" readonly required class="form-control" />
					</div>
				</div>

			</div>
			<div class="modal-footer">
				<button type="button" class="btn btn-primary" onclick="saveEditJenisSimpanan(${res.data.idJenisSimpanan})"><i class="fa fa-save"></i> Update</button>
				<button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-times"></i> Tutup</button>
			</div>
            `;

        $("#editDataJenisSimpanan").html(temp);


    }).fail((err) => {
        console.log(err);
    });
}

function saveEditJenisSimpanan(idJenisSimpanan) {
    var Id = idJenisSimpanan;
    var nama = $('#nama_simpanan').val();
    var besar = $('#besar_simpanan').val();
    var u_entry = $('#u_entry_jenis_simpanan').val();
    var tgl_entry = new Date($('#tgl_entry_jenis_simpanan').val()).toISOString();

    /* var res = {Id, nomor_anggota, nama, email, username, password, alamat, jk, pekerjaan, tgl_masuk, idRole, telpon, lahir, tgl_lahir, status, u_entry, tgl_entry};*/
    let res = {

        "idJenisSimpanan": Id,
        "namaSimpanan": nama,
        "besarSimpanan": besar,
        "userEntry": u_entry,
        "tglEntry": tgl_entry

    };
    $.ajax({
        url: `https://localhost:7189/api/JenisSimpanan`,
        type: "PUT",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(res),
        success: function () {
            Swal.fire({
                icon: 'success',
                title: 'Update!',
                text: 'Data jenis simpanan berhasil diupdate.',
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

function editJenisPinjaman(idJenisPinjaman) {
    $.ajax({
        url: `https://localhost:7189/api/JenisPinjaman/${idJenisPinjaman}`,
        type: "GET"
    }).done((res) => {
        let temp = "";
        temp += `
				<div class="row">
					<div class="form-group col-md-6">
						<label class="font-weight-bold">Kode Pinjaman</label>
						<input autocomplete="off" type="text" id="kode_jenis_pinjaman" value="${res.data.idJenisPinjaman}" readonly required class="form-control" />
					</div>

					<div class="form-group col-md-6">
						<label class="font-weight-bold">Jenis Pinjaman</label>
						<input autocomplete="off" type="text" id="nama_pinjaman" value="${res.data.namaPinjaman}" required class="form-control" />
					</div>

					<div class="form-group col-md-6">
						<label class="font-weight-bold">Lama Angsur (Bulan)</label>
						<input autocomplete="off" type="text" id="lama_angsuran" value="${res.data.lamaAngsuran}" required class="form-control" />
					</div>

					<div class="form-group col-md-6">
						<label class="font-weight-bold">Maksimal Pinjam</label>
						<input autocomplete="off" type="text" id="maks_pinjaman" value="${res.data.maksPinjaman}" required class="form-control" />
					</div>

					<div class="form-group col-md-6">
						<label class="font-weight-bold">Bunga (%)</label>
						<input autocomplete="off" type="text" id="bunga" value="${res.data.bunga * 100}" required class="form-control" />
					</div>

					<div class="form-group col-md-6">
						<label class="font-weight-bold">User Entri</label>
						<input autocomplete="off" type="text" id="u_entry3" value="${res.data.userEntry}" readonly required class="form-control" />
					</div>

					<div class="form-group col-md-6">
						<label class="font-weight-bold">Tanggal Entri</label>
						<input autocomplete="off" type="text" id="tgl_entry3" value="${new Date().toLocaleDateString()}" readonly required class="form-control" />
					</div>
				</div>
			<div class="modal-footer">
				<button type="button" class="btn btn-primary" onclick="saveEditJenisPinjaman(${res.data.idJenisPinjaman})"><i class="fa fa-save"></i> Update</button>
				<button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-times"></i> Tutup</button>
			</div>
            `;

        $("#editDataJenisPinjaman").html(temp);


    }).fail((err) => {
        console.log(err);
    });
}

function saveEditJenisPinjaman(idJenisPinjaman) {
    var Id = idJenisPinjaman;
    var nama_pinjaman = $('#nama_pinjaman').val();
    var lama = $('#lama_angsuran').val();
    var maks = parseInt($('#maks_pinjaman').val());
    let bunga = parseFloat($('#bunga').val()/100);
    var u_entry = $('#u_entry3').val();
    var tgl_entry = new Date($('#tgl_entry3').val()).toISOString();

    /* var res = {Id, nomor_anggota, nama, email, username, password, alamat, jk, pekerjaan, tgl_masuk, idRole, telpon, lahir, tgl_lahir, status, u_entry, tgl_entry};*/
    let res = {

        "idJenisPinjaman": Id,
        "namaPinjaman": nama_pinjaman,
        "lamaAngsuran": lama,
        "maksPinjaman": maks,
        "bunga": bunga,
        "userEntry": u_entry,
        "tglEntry": tgl_entry

    };

    console.log(res);
    $.ajax({
        url: `https://localhost:7189/api/JenisPinjaman`,
        type: "PUT",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(res),
        success: function () {
            Swal.fire({
                icon: 'success',
                title: 'Update!',
                text: 'Data jenis pinjaman berhasil diupdate.',
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

function addJenisPinjaman() {
    let id = 0;
    let jenis_pinjaman = $('#jenis_pinjaman').val();
    let lama = $('#lama_angsuran4').val();
    let maks = parseInt($('#maks_pinjaman4').val());;
    let bunga = parseFloat($('#bunga4').val()/100);
    let u_entry = $('#u_entry4').val();
    let tgl_entry = new Date($('#tgl_entry4').val()).toISOString();

    data = {
        "idJenisPinjaman": id,
        "namaPinjaman": jenis_pinjaman,
        "lamaAngsuran": lama,
        "maksPinjaman": maks,
        "bunga": bunga,
        "userEntry": u_entry,
        "tglEntry": tgl_entry
    };

    $.ajax({
        url: `https://localhost:7189/api/JenisPinjaman`,
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
                text: 'Berhasil menambahkan data jenis pinjaman.',
                showConfirmButton: false,
                timer: 1500
            });
            setTimeout(function () {
                location.reload();
            }, 1500);
        }
    });
}