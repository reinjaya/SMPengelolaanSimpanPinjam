using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Role
    {
        [Key]
        public int IdRole { get; set; }
        public DateTime TglEntry { get; set; }
        public string RoleName { get; set; }
    }
}
