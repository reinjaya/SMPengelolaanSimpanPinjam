url = new URL(window.location);
idUser = url.searchParams.get('user');
namaAnggota = url.searchParams.get('nama');

$(document).ready(function () {
    $("#namaAnggotaPinjaman").html(namaAnggota);
    $('#TableTransaksiPinjaman').DataTable({
        ajax: {
            url: `https://localhost:7189/api/Pinjaman/DaftarPinjamanAnggota?idUser=${idUser}`,
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
                    return data.idPinjaman;
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return new Date(data.tglEntry).toISOString().substring(0, 10);
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return data.jenisPinjaman;
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return data.besarPinjaman;
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return data.besarAngsuran;
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return data.sisaAngsuran + " bulan dari " + data.lamaAngsuran + " bulan";
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return new Date(data.tglTempo).toISOString().substring(0, 10);
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    if (data.status == 'Lunas') {
						 return `<span class='badge badge-success'>Lunas</span>`;
                    }

                    else {
						 return `<span class='badge badge-danger'>Belum Lunas</span>`;
                    }
                }
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    if (data.status == 'Belum Lunas') {
                        return `
                            <div class="btn-group align-items-center" role="group">
					         <a onclick="toDetailPinjaman(${data.idPinjaman})" data-toggle="tooltip" data-placement="bottom" title="Detail Pinjaman" class="btn btn-success btn-sm"><i class="fa fa-eye"></i></a>
                             <a onclick="toBayarAngsuran(${data.idPinjaman})" data-toggle="tooltip" data-placement="bottom" title="Bayar Angsuran" class="btn btn-primary btn-sm"><i class="fa fa-check"></i></a>
					        </div>`;
                    }
                    else if (data.status == 'Lunas') {
                        return `
                            <div class="btn-group align-items-center" role="group">
					         <a onclick="toDetailPinjaman(${data.idPinjaman})" data-toggle="tooltip" data-placement="bottom" title="Detail Pinjaman" class="btn btn-success btn-sm"><i class="fa fa-eye"></i></a>
					        </div>`;
                    }
                }
            },


        ],
        columnDefs: [
            // Center align the header content of column 1
            { className: "dt-head-center", targets: "_all" },
            // Center align the body content of columns 2, 3, & 4
            { className: "dt-body-center", targets: "_all" }
        ]
    })
});

function wajibPinjaman() {
    let loc = window.location.href;
    var lastIndex = loc.lastIndexOf("/");
    var path = loc.substring(0, lastIndex);
    var new_path = path + "/TambahPinjaman";
    let urlParams = new URL(new_path);
    urlParams.searchParams.append("user", idUser);
    urlParams.searchParams.append("nama", namaAnggota);
    location.href = urlParams.href;
}

function backPinjamanAnggotaPage() {
    let loc = window.location.href;
    var lastIndex = loc.lastIndexOf("/");
    var path = loc.substring(0, lastIndex);
    var new_path = path + "/TambahPengajuan";
    let urlParams = new URL(new_path);
    urlParams.searchParams.append("user", idUser);
    urlParams.searchParams.append("nama", namaAnggota);
    location.href = urlParams.href;
}

function toDetailPinjaman(idPinjam) {
    let loc = window.location.href;
    var lastIndex = loc.lastIndexOf("/");
    var path = loc.substring(0, lastIndex);
    var new_path = path + "/DetailPinjaman";
    let urlParams = new URL(new_path);
    urlParams.searchParams.append("user", idUser);
    urlParams.searchParams.append("pinjam", idPinjam);
    urlParams.searchParams.append("nama", namaAnggota);
    location.href = urlParams.href;
}

function toBayarAngsuran(idPinjam) {
    let loc = window.location.href;
    var lastIndex = loc.lastIndexOf("/");
    var path = loc.substring(0, lastIndex);
    var new_path = path + "/BayarAngsuran";
    let urlParams = new URL(new_path);
    urlParams.searchParams.append("user", idUser);
    urlParams.searchParams.append("pinjam", idPinjam);
    urlParams.searchParams.append("nama", namaAnggota);
    location.href = urlParams.href;
}

