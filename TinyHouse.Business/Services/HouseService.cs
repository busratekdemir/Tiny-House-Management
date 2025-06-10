// TinyHouse.Business/Services/HouseService.cs
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

        public HouseService()
        {
            var connStr = DbHelper.GetConnectionString();
            _houseRepo = new HouseRepository(connStr);
            _reservationRepo = new ReservationRepository(connStr);
        }

        // Tüm ilanlar
        public List<HouseModel> GetAllHouses()
            => _houseRepo.GetAll();

        // Tekil ilan
        public HouseModel GetHouseById(int houseId)
            => _houseRepo.GetById(houseId);

        // Yeni ilan ekle
        public int AddHouse(HouseModel house)
            => _houseRepo.Create(house);
        public int AddHouse(int ownerId, string title, string desc, string photos,
                            DateTime? from, DateTime? to, bool isActive,
                            decimal pricePerNight, string location)
        
            {
                var h = new HouseModel
                {
                    OwnerId = ownerId,
                    Title = title,
                    Description = desc,
                    PhotoUrls = photos,
                    AvailableFrom = from,
                    AvailableTo = to,
                    IsActive = isActive,
                    PricePerNight = pricePerNight,
                    Location = location
                };
                return _houseRepo.Create(h);
            }

        // Mevcut ilanı güncelle
        public bool UpdateHouse(HouseModel house)
            => _houseRepo.Update(house);

        // İlanı sil (aktif rezervasyon yoksa)
        public bool DeleteHouse(int houseId)
        {
            if (!_reservationRepo.HasActiveReservations(houseId))
                return _houseRepo.Delete(houseId);

            // Aktif rezervasyon var, silme işlemi başarısız olsun
            return false;
        }

        // Aktif/Pasif durumunu ters çevir
        public bool ToggleHouseStatus(int houseId)
            => _houseRepo.ToggleStatus(houseId);

        // Sahibe göre listele
        public List<HouseModel> GetHousesByOwner(int ownerId)
            => _houseRepo.GetByOwner(ownerId);

        // Tarih aralığında müsait ilanlar
        public List<HouseModel> GetAvailableHouses(DateTime from, DateTime to)
            => _houseRepo.GetAvailableHouses(from, to);

        // Sadece rezervasyon kontrolü
        public bool HasActiveReservations(int houseId)
            => _reservationRepo.HasActiveReservations(houseId);
    }
}
