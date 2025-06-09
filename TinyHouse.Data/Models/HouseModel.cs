using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyHouse.Data.Models
{
    public class HouseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoUrls { get; set; }  
        public DateTime? AvailableFrom { get; set; } 
        public DateTime? AvailableTo { get; set; } 
        public bool IsActive { get; set; }
        public decimal PricePerNight { get; set; }
        public string Location { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; } // join ile çekecez
    }
}