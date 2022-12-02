using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class Simpanan
    {
        [Key]
        public int IdSimpanan { get; set; }
        [ForeignKey("JenisSimpanan")]
        public int IdJenisSimpanan { get; set; }
        public double BesarSimpanan { get; set; }
        [ForeignKey("User")]
        public int IdUser { get; set; }
        public string UserEntry { get; set; }
        public DateTime TglMulai { get; set; }
        public DateTime TglEntry { get; set; }
        [JsonIgnore]
        public JenisPinjaman? JenisSimpanan { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
    }
}
