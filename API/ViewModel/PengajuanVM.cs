namespace WebAPI.ViewModel
{
    public class PengajuanVM
    {
        public int IdPengajuan { get; set; }
        public string Nama { get; set; }
        public DateTime TglPengajuan { get; set; }
        public int BesarPinjam { get; set; }
        public string JenisPinjam { get; set; }
        public string Status { get; set; }
        public DateTime? TglTerima { get; set; }

    }
}
