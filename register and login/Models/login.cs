using System.ComponentModel.DataAnnotations;

namespace register_and_login.Models
{
    public class login
    {
        [Key]
        public string email { get; set; }
        public string password { get; set; }

    }
}
