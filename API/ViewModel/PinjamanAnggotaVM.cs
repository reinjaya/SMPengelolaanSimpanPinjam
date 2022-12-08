namespace WebAPI.ViewModel
{
	public class PinjamanAnggotaVM
	{
        public int IdPinjaman { get; set; }
        public double BesarPinjaman { get; set; }
        public double BesarAngsuran { get; set; }
        public string JenisPinjaman { get; set; }
        public int LamaAngsuran { get; set; }
        public int SisaAngsuran { get; set; }
        public double SisaPinjaman { get; set; }
        public DateTime TglEntry { get; set; }
        public DateTime TglTempo { get; set; }
        public string Status { get; set; }
    }
}
