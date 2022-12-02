using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class Tabungan
    {
        [Key]
        public int KodeTabungan { get; set; }
        [ForeignKey("Anggota")]
        public string KodeAnggota { get; set; }
        public DateTime TglMulai { get; set; }
        public double BesarTabungan { get; set; }
        [JsonIgnore]
        public Anggota? Anggota { get; set; }
    }
}
