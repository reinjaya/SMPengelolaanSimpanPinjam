using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class Simpanan
    {
        [Key]
        public int KodeSimpanan { get; set; }
        [ForeignKey("JenisSimpanan")]
        public string KodeJenisSimpanan { get; set; }
        public double BesarSimpanan { get; set; }
        [ForeignKey("Anggota")]
        public string KodeAnggota { get; set; }
        public string UserEntry { get; set; }
        public DateTime TglMulai { get; set; }
        public DateTime TglEntry { get; set; }
        [JsonIgnore]
        public JenisPinjaman? JenisSimpanan { get; set; }
        [JsonIgnore]
        public Anggota? Anggota { get; set; }
    }
}
