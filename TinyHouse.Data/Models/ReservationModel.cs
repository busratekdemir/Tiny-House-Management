// TinyHouse.Data/Models/ReservationModel.cs
using System;

namespace TinyHouse.Data.Models
{
    public enum ReservationStatus : byte
    {
        Pending = 0,
        Confirmed = 1,
        Cancelled = 2,
        Rejected = 3
    }

    public class ReservationModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int HouseId { get; set; }   // r.TinyHouseId olarak geliyor
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalPrice { get; set; }
        public ReservationStatus Status { get; set; }
        public string PaymentStatus { get; set; }

        // Sadece detaylı listelerde
        public string TenantName { get; set; }
        public string HouseTitle { get; set; }
    }
}
