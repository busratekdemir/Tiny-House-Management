using System;
using System.Collections.Generic;
using TinyHouse.Data.Models;
using TinyHouse.Data.Repositories;
using TinyHouse.Data.Utilities;

namespace TinyHouse.Business.Services
{
    public class ReservationService
    {
        private readonly ReservationRepository _repo;
        private readonly HouseRepository _houseRepo;

        public ReservationService()
        {
            // App.config’ten connection string’i oku
            var connStr = DbHelper.GetConnectionString();
            _repo = new ReservationRepository(connStr);
            _houseRepo = new HouseRepository(connStr);
        }

        /// Kiracıdan gelen rezervasyon talebi.
        /// </summary>
        /// <returns>
        /// true = talep alındı (pending), false = tarih çakışması var.
        /// </returns>
        public bool AddReservation(int userId, int houseId,
                                   DateTime startDate, DateTime endDate,
                                   decimal totalPrice)
        {
            // Eğer onaylı (Confirmed) rezervasyonla çakışıyorsa reddet
            if (_repo.IsHouseBooked(houseId, startDate, endDate))
                return false;

            var r = new ReservationModel
            {
                UserId = userId,
                TinyHouseId = houseId,
                StartDate = startDate,
                EndDate = endDate,
                TotalPrice = totalPrice,
                Status = ReservationStatus.Pending
            };

            // SP_RezervasyonEkle return: 0 = başarılı (pending), -1 = conflict
            int code = _repo.Add(r);
            return code == 0;
        }

        /// Kiracı kendi talebini iptal ettiğinde çağrılır.
        public bool CancelReservation(int reservationId) =>
            _repo.UpdateReservationStatus(reservationId, (int)ReservationStatus.Cancelled) > 0;


        /// Ev sahibi bir pending talebi onayladı
        public bool ApproveRequest(int reservationId) =>
            _repo.UpdateReservationStatus(reservationId, (int)ReservationStatus.Confirmed) > 0;


        /// Ev sahibi bir pending talebi reddetti.

        public bool RejectRequest(int reservationId) =>
            _repo.UpdateReservationStatus(reservationId, (int)ReservationStatus.Cancelled) > 0;

        /// Kiracıya ait tüm rezervasyonlar (her durumdaki).
        public List<ReservationModel> GetReservationsByUser(int userId) =>
            _repo.GetByUser(userId);

        /// Ev sahibine gelen “bekleyen” rezervasyon talepleri.
        public List<ReservationModel> GetRequestsByOwner(int ownerId) =>
            _repo.GetRequestsByOwnerAndStatus(ownerId, (int)ReservationStatus.Pending);


        /// Admin’in görebileceği tüm rezervasyonlar (detaylı).
        public List<ReservationModel> GetAllReservations() =>
            _repo.GetAllWithDetails();

        /// Ev sahibinin onaylanmış rezervasyonlarından elde ettiği toplam gelir.
        public decimal GetOwnerIncome(int ownerId)
        {
            decimal total = 0;
            foreach (var r in _repo.GetAllWithDetails())
            {
                if (r.Status == ReservationStatus.Confirmed)
                {
                    var house = _houseRepo.GetById(r.TinyHouseId);
                    if (house != null && house.OwnerId == ownerId)
                        total += r.TotalPrice;
                }
            }
            return total;
        }
    }
}
