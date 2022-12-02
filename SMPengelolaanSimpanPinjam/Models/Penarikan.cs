using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class Penarikan
    {
        [Key]
        public int KodePenarikan { get; set; }
        //[ForeignKey("Anggota")]
        //public string KodeAnggota { get; set; }
        [ForeignKey("Tabungan")]
        public int KodeTabungan { get; set; }
        public int BesarPenarikan { get; set; }
        public DateTime TglPenarikan { get; set; }

        //[JsonIgnore]
        //public Anggota? Anggota { get; set; }
        [JsonIgnore]
        public Tabungan? Tabungan { get; set; }
    }
}
