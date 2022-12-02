using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class Angsuran
    {
        [Key]
        public int KodeAngsuran { get; set; }
        [ForeignKey("Pinjaman")]
        public int KodePinjaman { get; set; }
        public int BesarAngsuran { get; set; }
        public int Denda { get; set; }
        public int SisaPinjaman { get; set; }
        [ForeignKey("Anggota")]
        public string KodeAnggota { get; set; }
        public string UserEntry { get; set; }
        public DateTime TglEntry { get; set; }

        [JsonIgnore]
        public Pinjaman? Pinjaman { get; set; }
        [JsonIgnore]
        public Anggota? Anggota { get; set; }
    }
}
