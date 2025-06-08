using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TinyHouse.Data.Models
{
    public enum ReservationStatus : byte
    {
        Pending = 0,
        Confirmed = 1,
        Cancelled = 2
    }

    public class ReservationModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TinyHouseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalPrice { get; set; }
        public ReservationStatus Status { get; set; }
        public string TenantName { get; set; }
        public string HouseTitle { get; set; }
        public int HouseId { get; set; }
    }
}

