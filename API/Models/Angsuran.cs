using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class Angsuran
    {
        [Key]
        public int IdAngsuran { get; set; }
        [ForeignKey("Pinjaman")]
        public int IdPinjaman { get; set; }
        public int AngsuranKe { get; set; }
        public double BesarAngsuran { get; set; }
        public double Denda { get; set; }
        public double SisaPinjaman { get; set; }
        public string UserEntry { get; set; }
        public DateTime TglEntry { get; set; }

        [JsonIgnore]
        public Pinjaman? Pinjaman { get; set; }
    }
}
