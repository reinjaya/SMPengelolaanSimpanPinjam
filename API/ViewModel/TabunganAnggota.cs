namespace WebAPI.ViewModel
{
    public class TabunganAnggota
    {
        public int IdUser { get; set; }
        public int IdTabungan { get; set; }
        public string NomorAnggota { get; set; }
        public string NamaAnggota { get; set; }
        public DateTime TglMulai { get; set; }
        public double JumlahSaldo { get; set; }
    }
}
