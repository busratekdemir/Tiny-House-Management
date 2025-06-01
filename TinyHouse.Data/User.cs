using System.ComponentModel.DataAnnotations;

namespace TinyHouse.Data
{
    public class User
    {
        public int Id { get; set; }

        [Required]  // NULL olamaz
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
