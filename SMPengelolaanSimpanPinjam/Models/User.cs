using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class User
    {
        [Key]
        public string KodeUser { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Nama { get; set; }
        public DateTime TglEntry { get; set; }
        public string Level { get; set; }
    }
}
