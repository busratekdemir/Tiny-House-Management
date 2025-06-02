using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TinyHouse.Data
{
    public class TinyHouse
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal PricePerNight { get; set; }

        [Required]
        public string Location { get; set; }

        [ForeignKey("Owner")]
        public int OwnerId { get; set; }

        public User Owner { get; set; }
    }
}
