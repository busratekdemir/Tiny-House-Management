using System;
using System.Collections.Generic;
using TinyHouse.Data.Models;
using TinyHouse.Data.Repositories;
using TinyHouse.Data.Utilities;

namespace TinyHouse.Business.Services
{
    public class HouseService
    {
        private readonly HouseRepository _houseRepo;
        private readonly ReservationRepository _reservationRepo;

        // Tek ve temiz constructor
        public HouseService()
        {
            var connStr = DbHelper.GetConnectionString();
            _houseRepo = new HouseRepository(connStr);
            _reservationRepo = new ReservationRepository(connStr);
        }

        public IEnumerable<HouseModel> GetAllHouses()
            => _houseRepo.GetAll();

        public HouseModel GetHouseById(int houseId)
            => _houseRepo.GetById(houseId);

        public int AddHouse(HouseModel house)
            => _houseRepo.Add(house);

        public bool UpdateHouse(HouseModel house)
            => _houseRepo.Update(house);

        public bool DeleteHouse(int houseId)
        {
            if (!_reservationRepo.HasActiveReservations(houseId))
                return _houseRepo.Delete(houseId);

            return false; // Aktif rezervasyon var, silme!
        }

        public IEnumerable<HouseModel> GetHousesByOwner(int ownerId)
            => _houseRepo.GetByOwner(ownerId);

        public IEnumerable<HouseModel> GetAvailableHouses(DateTime from, DateTime to)
            => _houseRepo.GetAvailableHouses(from, to);

        public bool HasActiveReservations(int houseId)
            => _reservationRepo.HasActiveReservations(houseId);

        // Bu metot henüz implement edilmediği için hata vermeye devam edebilir.
        public int AddHouse(int ownerId, string title, string desc, string photos, DateTime? from, DateTime? to, bool isActive, decimal price, string loc)
        {
            var house = new HouseModel
            {
                OwnerId = ownerId,
                Title = title,
                Description = desc,
                PhotoUrls = photos,
                AvailableFrom = from,
                AvailableTo = to,
                IsActive = isActive,
                PricePerNight = price,
                Location = loc
            };

            return _houseRepo.Add(house);
        }
    }
}
