// TinyHouse.Business/Services/ReservationService.cs
using System;
using System.Collections.Generic;
using TinyHouse.Data.Models;
using TinyHouse.Data.Repositories;

namespace TinyHouse.Business.Services
{
    public class ReservationService
    {
        private readonly ReservationRepository _repo;


        public ReservationService()
        {
            _repo = new ReservationRepository();
        }

        /// <summary>
        /// Yeni rezervasyon ekler. 
        /// SP geriye 0 = pending, -1 = conflict dönüyor.
        /// </summary>
        public int AddReservation(int userId, int houseId, DateTime start, DateTime end, decimal totalPrice)
        {
            var model = new ReservationModel
            {
                UserId = userId,
                HouseId = houseId,
                StartDate = start,
                EndDate = end,
                TotalPrice = totalPrice,
                Status = ReservationStatus.Pending
            };
            return _repo.Add(model);
        }
        /// <summary>
        /// İki tarih aralığında çakışma var mı diye kontrol eder.
        /// </summary>
        public bool IsHouseBooked(int houseId, DateTime from, DateTime to)
            => _repo.IsHouseBooked(houseId, from, to);

        /// <summary>
        /// Rezervasyonun durumunu günceller (onay, reddet, iptal vb.).
        /// </summary>
        public bool UpdateReservationStatus(int reservationId, ReservationStatus newStatus)
            => _repo.UpdateReservationStatus(reservationId, newStatus);

        /// <summary>
        /// Rezervasyon onaylama işlemini kolaylaştırır.
        /// </summary>
        public bool ApproveRequest(int reservationId)
            => UpdateReservationStatus(reservationId, ReservationStatus.Confirmed);

        /// <summary>
        /// Rezervasyon reddetme işlemini kolaylaştırır.
        /// </summary>
        public bool RejectRequest(int reservationId)
            => UpdateReservationStatus(reservationId, ReservationStatus.Rejected);

        public bool CancelReservation(int reservationId)
    => UpdateReservationStatus(reservationId, ReservationStatus.Cancelled);

        /// <summary>
        /// Admin için tüm rezervasyonları detaylı olarak döner.
        /// </summary>
        public List<ReservationModel> GetAllReservations()
            => _repo.GetAllWithDetails();

        /// <summary>
        /// Kalıcı rezervasyon silme.
        /// </summary>
        public bool DeleteReservation(int reservationId)
            => _repo.Delete(reservationId);

        /// <summary>
        /// Bir evde onaylı (Confirmed) rezervasyon var mı diye kontrol eder.
        /// </summary>
        public bool HasActiveReservations(int houseId)
            => _repo.HasActiveReservations(houseId);

        /// <summary>
        /// Ev sahibine gelen rezervasyonları duruma göre filtreler.
        /// </summary>
        public List<ReservationModel> GetRequestsByOwner(int ownerId, ReservationStatus status)
            => _repo.GetRequestsByOwnerAndStatus(ownerId, (int)status);

        /// <summary>
        /// Ev sahibine gelen rezervasyonları, öntanımlı olarak Pending statüsüyle döner.
        /// </summary>
        public List<ReservationModel> GetRequestsByOwner(int ownerId)
            => GetRequestsByOwner(ownerId, ReservationStatus.Pending);

        /// <summary>
        /// Ev sahibinin toplam gelirini hesaplar.
        /// </summary>
        public decimal GetOwnerIncome(int ownerId)
            => _repo.GetOwnerIncome(ownerId);
    
    /// <summary>
    /// Oturum açmış kullanıcıya ait rezervasyonları döner.
    /// </summary>
    public List<ReservationModel> GetReservationsByUser(int userId)
        {
            return _repo.GetByUser(userId);
        }

    }
}
