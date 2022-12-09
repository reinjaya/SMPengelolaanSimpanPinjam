let money = Intl.NumberFormat('en-US');
let besarAngsuran1;

$(document).ready(function () {
    let bunga = [];
    let maksPinjaman = [];
    let lamaAngsuran = [];
    let idUserAnggotaPage = sessionStorage.getItem("idUser");
    $.ajax({
        url: `https://localhost:7189/api/User/${idUserAnggotaPage}`,
        type: "GET",
        //headers: {
        //    'Authorization': "Bearer " + sessionStorage.getItem("token")
        //}
    }).done((res) => {
        $("input[name='kode_anggota']").val(res.data.nomorAnggota);
        $("input[name='nama_anggota']").val(res.data.nama);
        $("input[name='pekerjaan']").val(res.data.pekerjaan);
    });

    $.ajax({
        url: `https://localhost:7189/api/JenisPinjaman`,
        type: "GET",
        //headers: {
        //    'Authorization': "Bearer " + sessionStorage.getItem("token")
        //}
    }).done((res) => {

        $.each(res.data, function (i, item) {
            $('#id_jenis_pinjaman').append($('<option>', {
                value: item.idJenisPinjaman,
                text: item.namaPinjaman
            }));
            bunga[i + 1] = item.bunga;
            maksPinjaman[i + 1] = item.maksPinjaman;
            lamaAngsuran[i + 1] = item.lamaAngsuran;
        });

        $("input[name='lama_angsuran']").val(lamaAngsuran[1]);
        $("input[name='maks_pinjam']").val(money.format(maksPinjaman[1]));
        $("input[name='besar_bunga']").val(bunga[1] * 100);
    });

    $('#id_jenis_pinjaman').on('change', function () {
        let val = $("#id_jenis_pinjaman option:selected").val();
        $("input[name='lama_angsuran']").val(lamaAngsuran[val]);
        $("input[name='maks_pinjam']").val(money.format(maksPinjaman[val]));
        $("input[name='besar_bunga']").val(bunga[val] * 100);

        besarAngsuran();
    });

    $("input[name='besar_pinjaman']").on('input', function () {
        besarAngsuran();
    });

    function besarAngsuran() {
        let val = $("#id_jenis_pinjaman option:selected").val();
        let besarPinjaman = $("input[name='besar_pinjaman']").val();
        besarAngsuran1 = Math.round((besarPinjaman * Math.pow((1 + bunga[val]), lamaAngsuran[val])) / lamaAngsuran[val])

        $("input[name='besar_angsuran']").val(money.format(besarAngsuran1));
    }

});

function tambahPengajuanAnggotaPage() {
    let val1 = $("#id_jenis_pinjaman option:selected").val();
    let besarPinjam1 = $("input[name='besar_pinjaman']").val();
    let idUserAnggotaPage = sessionStorage.getItem("idUser")


    let data3 = {
        "idPengajuan": 0,
        "tglPengajuan": "2022-12-08T09:37:23.859Z",
        "idUser": sessionStorage.getItem("idUser"),
        "idJenisPinjaman": val1,
        "besarPinjaman": besarPinjam1,
        "besarAngsuran": 0,
        "tglAcc": "2022-12-08T09:37:23.859Z",
        "status": "string"
    }

    $.ajax({
        url: `https://localhost:7189/api/Pengajuan/TambahPengajuan`,
        type: 'POST',
        data: JSON.stringify(data3),
        dataType: 'json',
        headers: {
            'Content-Type': 'application/json'
        },
        success: function (data) {
            if (data.response == 1) {
                Swal.fire(data.message, '', 'error').then((result) => {
                    backPinjaman();
                });
            }
            else {
                if (data.response == 2) {
                    Swal.fire(data.message, '', 'success').then((result) => {
                        backPinjaman();
                    });
                }
            }
        }
    });
}

