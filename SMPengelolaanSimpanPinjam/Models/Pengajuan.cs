using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class Pengajuan
    {
        [Key]
        public int KodePengajuan { get; set; }
        public DateTime TglPengajuan { get; set; }
        [ForeignKey("Anggota")]
        public string KodeAnggota { get; set; }
        [ForeignKey("JenisPinjaman")]
        public string KodeJenisPinjaman { get; set; }
        public int BesarPinjaman { get; set; }
        public DateTime TglAcc { get; set; }
        public string Status { get; set; }
        [JsonIgnore]
        public Anggota? Anggota { get; set; }
        [JsonIgnore]
        public JenisPinjaman? JenisPinjaman { get; set; }
    }
}
