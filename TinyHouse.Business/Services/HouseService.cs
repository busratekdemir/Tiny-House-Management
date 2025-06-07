using System;
using System.Collections.Generic;
using TinyHouse.Data.Models;
using TinyHouse.Data.Repositories;
using TinyHouse.Data.Utilities;

namespace TinyHouse.Business.Services
{
    public class HouseService
    {
        private readonly HouseRepository _repo;

        public HouseService()
        {
            // Bağlantı dizesini çekip repository'i başlatıyoruz
            var connStr = DbHelper.GetConnectionString();
            _repo = new HouseRepository(connStr);
        }

        /// <summary>
        /// Yeni bir ilan ekler.
        /// </summary>
        public int AddHouse(
            int ownerId,
            string title,
            string description,
            string photoUrls,
            DateTime? availableFrom,
            DateTime? availableTo,
            bool isActive,
            decimal pricePerNight,
            string location)
        {
            var h = new HouseModel
            {
                OwnerId = ownerId,
                Title = title,
                Description = description,
                PhotoUrls = photoUrls,
                AvailableFrom = availableFrom,
                AvailableTo = availableTo,
                IsActive = isActive,
                PricePerNight = pricePerNight,
                Location = location
            };
            return _repo.Add(h);
        }

        /// <summary>
        /// Mevcut bir ilanı günceller. (9 parametreli overload)
        /// </summary>
        public bool UpdateHouse(
            int id,
            string title,
            string description,
            string photoUrls,
            DateTime? availableFrom,
            DateTime? availableTo,
            bool isActive,
            decimal pricePerNight,
            string location)
        {
            var h = new HouseModel
            {
                Id = id,
                Title = title,
                Description = description,
                PhotoUrls = photoUrls,
                AvailableFrom = availableFrom,
                AvailableTo = availableTo,
                IsActive = isActive,
                PricePerNight = pricePerNight,
                Location = location
            };
            return _repo.Update(h);
        }

        /// <summary>
        /// Sahibe özel silme: sadece kendi ilanını silebilir.
        /// </summary>
        public bool DeleteHouse(int houseId)
        {
            return _repo.Delete(houseId);
        }


        /// <summary>
        /// Tek bir ilanın detaylarını getirir.
        /// </summary>
        public HouseModel GetHouseById(int id) =>
            _repo.GetById(id);

        /// <summary>
        /// Tüm aktif/pasif fark etmeksizin ilanları getirir.
        /// </summary>
        public List<HouseModel> GetAllHouses() =>
            _repo.GetAll();

        /// <summary>
        /// Belirli bir sahibin ilanlarını getirir.
        /// </summary>
        public List<HouseModel> GetHousesByOwner(int ownerId) =>
            _repo.GetByOwner(ownerId);
    }
}
