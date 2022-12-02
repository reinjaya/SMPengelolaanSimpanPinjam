using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class Tabungan
    {
        [Key]
        public int IdTabungan { get; set; }
        [ForeignKey("User")]
        public int IdUser { get; set; }
        public DateTime TglMulai { get; set; }
        public double BesarTabungan { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
    }
}
