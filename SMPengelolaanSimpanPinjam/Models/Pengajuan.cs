using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class Pengajuan
    {
        [Key]
        public int IdPengajuan { get; set; }
        public DateTime TglPengajuan { get; set; }
        [ForeignKey("User")]
        public int IdUser { get; set; }
        [ForeignKey("JenisPinjaman")]
        public int IdJenisPinjaman { get; set; }
        public int BesarPinjaman { get; set; }
        public DateTime TglAcc { get; set; }
        public string Status { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
        [JsonIgnore]
        public JenisPinjaman? JenisPinjaman { get; set; }
    }
}
