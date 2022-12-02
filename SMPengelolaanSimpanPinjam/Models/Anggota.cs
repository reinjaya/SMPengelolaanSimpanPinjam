using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Anggota
    {
        [Key]
        public string KodeAnggota { get; set; }
        public string Password {get; set; }
        public string AlamatAnggota { get; set; }
        public string JenisKelamin { get; set; }
        public string Pekerjaan { get; set; }
        public DateTime TglMasuk { get; set; }
        public string Telepon { get; set; }
        public string TempatLahir { get; set; }
        public DateTime TglLahir { get; set;  }
        public string Status { get; set; }
        public string UserEntry { get; set; }
        public DateTime TglEntry { get; set; }

    }
}
