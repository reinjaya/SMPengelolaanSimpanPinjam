using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class JenisPinjaman
    {
        [Key]
        public int IdJenisPinjaman { get; set; }
        public string NamaPinjaman { get; set; }
        public int LamaAngsuran { get; set; }
        public double MaksPinjaman { get; set; }
        public double Bunga { get; set; }
        public string UserEntry { get; set; }
        public DateTime TglEntry { get; set; }
    }
}
