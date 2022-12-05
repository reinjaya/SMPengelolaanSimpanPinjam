using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class Pinjaman
    {
        [Key]
        public int IdPinjaman { get; set; }
        [ForeignKey("User")]
        public int IdUser { get; set; }
        [ForeignKey("JenisPinjaman")]
        public int IdJenisPinjaman { get; set; }
        public double BesarPinjaman { get; set; }
        public double BesarAngsuran { get; set; }
        public int LamaAngsuran { get; set; }
        public int SisaAngsuran { get; set; }
        public double SisaPinjaman { get; set; }
        public string UserEntry { get; set; }
        public DateTime TglEntry { get; set; }
        public DateTime TglTempo { get; set; }
        public string Status { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
        [JsonIgnore]
        public JenisPinjaman? JenisPinjaman { get; set; }
    }
}
