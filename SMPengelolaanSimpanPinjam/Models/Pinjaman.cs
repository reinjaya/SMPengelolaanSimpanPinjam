using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class Pinjaman
    {
        [Key]
        public int KodePinjaman { get; set; }
        //[ForeignKey("Anggota")]
        //public string KodeAnggota { get; set; }
        [ForeignKey("JenisPinjaman")]
        public string KodeJenisPinjaman { get; set; }
        public double BesarPinjaman { get; set; }
        public double BesarAngsuran { get; set; }
        public int LamaAngsuran { get; set; }
        public int SisaAngsuran { get; set; }
        public double SisaPinjaman { get; set; }
        public string UserEntry { get; set; }
        public DateTime TglEntry { get; set; }
        public DateTime TglTempo { get; set; }
        public string status { get; set; }
        //[JsonIgnore]
        //public Anggota? Anggota { get; set; }
        [JsonIgnore]
        public JenisPinjaman? JenisPinjaman { get; set; }
    }
}
