let urlBayarlAngsuran = new URL(window.location);
let idPinjam = url.searchParams.get('pinjam');

$(document).ready(function () {

    $.ajax({
        url: `https://localhost:7189/api/Angsuran/GetDataAngsuranPinjaman?idPinjaman=${idPinjam}`,
        type: "GET",
        //headers: {
        //    'Authorization': "Bearer " + sessionStorage.getItem("token")
        //}
    }).done((res) => {
        let tgl = new Date(res.data.tglPinjam).toISOString().substring(0, 10)
        $("input[name='kode_anggota']").val(res.data.nomorAnggota);
        $("input[name='nama_anggota']").val(res.data.namaAnggota);
        $("input[name='kode_pinjam']").val(res.data.idPinjam);
        $("input[name='tanggal_pinjam']").val(tgl);
        $("input[name='besar_pinjam']").val(res.data.besarPinjam);
        $("input[name='lama_angsur']").val(res.data.lamaAngsur);
        $("input[name='angsuran']").val(res.data.angsuran);
        $("input[name='angsuran_ke']").val(res.data.angsuranKe);
        $("input[name='denda']").val(res.data.denda);
    });

});

function tambahAngsuranAnggota() {
    $.ajax({
        url: `https://localhost:7189/api/Angsuran/TambahAngsuranPinjaman?idPinjaman=${idPinjam}&userEntry=Admin`,
        type: 'POST',
        dataType: 'json',
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

