using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        public string NomorAnggota { get; set; }
        public string Nama {get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password {get; set; }
        public string Alamat { get; set; }
        public string JenisKelamin { get; set; }
        public string Pekerjaan { get; set; }
        public DateTime TglMasuk { get; set; }
        [ForeignKey("Role")]
        public int IdRole { get; set; }
        public string Telepon { get; set; }
        public string TempatLahir { get; set; }
        public DateTime TglLahir { get; set;  }
        public string Status { get; set; }
        public string UserEntry { get; set; }
        public DateTime TglEntry { get; set; }
        [JsonIgnore]
        public Role? Role { get; set; }

    }
}
