using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using TinyHouse.Data.Models;
using TinyHouse.Data.Utilities;

namespace TinyHouse.Data.Repositories
{
    public class HouseRepository
    {
        private readonly string _connStr;

        // ① Parametresiz ctor: DbHelper’dan çekecek
        public HouseRepository()
            : this(DbHelper.GetConnectionString())
        {
        }

        // ② Mevcut ctor
        public HouseRepository(string connStr)
        {
            _connStr = connStr;
        }

        public int Add(HouseModel house)
        {
            using var conn = new SqlConnection(_connStr);
            using var cmd = conn.CreateCommand();
            // Yeni bir ilan ekleyip, oluşturulan ID'yi döndürüyoruz
            cmd.CommandText = @"
                INSERT INTO Houses
                    (OwnerId, Title, Description, PhotoUrls, AvailableFrom, AvailableTo, IsActive, PricePerNight, Location)
                VALUES
                    (@ownerId, @title, @description, @photoUrls, @availableFrom, @availableTo, @isActive, @pricePerNight, @location);
                SELECT SCOPE_IDENTITY();";
            cmd.Parameters.AddWithValue("@ownerId", house.OwnerId);
            cmd.Parameters.AddWithValue("@title", house.Title);
            cmd.Parameters.AddWithValue("@description", house.Description);
            cmd.Parameters.AddWithValue("@photoUrls", house.PhotoUrls);
            cmd.Parameters.AddWithValue("@availableFrom", (object)house.AvailableFrom ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@availableTo", (object)house.AvailableTo ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@isActive", house.IsActive);
            cmd.Parameters.AddWithValue("@pricePerNight", house.PricePerNight);
            cmd.Parameters.AddWithValue("@location", house.Location);

            conn.Open();
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public bool Update(HouseModel house)
        {
            using var conn = new SqlConnection(_connStr);
            using var cmd = conn.CreateCommand();
            // Mevcut ilanı güncelliyoruz
            cmd.CommandText = @"
                UPDATE Houses SET
                    Title = @title,
                    Description = @description,
                    PhotoUrls = @photoUrls,
                    AvailableFrom = @availableFrom,
                    AvailableTo = @availableTo,
                    IsActive = @isActive,
                    PricePerNight = @pricePerNight,
                    Location = @location
                WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", house.Id);
            cmd.Parameters.AddWithValue("@title", house.Title);
            cmd.Parameters.AddWithValue("@description", house.Description);
            cmd.Parameters.AddWithValue("@photoUrls", house.PhotoUrls);
            cmd.Parameters.AddWithValue("@availableFrom", (object)house.AvailableFrom ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@availableTo", (object)house.AvailableTo ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@isActive", house.IsActive);
            cmd.Parameters.AddWithValue("@pricePerNight", house.PricePerNight);
            cmd.Parameters.AddWithValue("@location", house.Location);

            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(int id)
        {
            using var conn = new SqlConnection(_connStr);
            using var cmd = conn.CreateCommand();
            // İlanı sil
            cmd.CommandText = "DELETE FROM Houses WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", id);

            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        public HouseModel GetById(int id)
        {
            using var conn = new SqlConnection(_connStr);
            using var cmd = conn.CreateCommand();
            // Belirli ID'li ilanı getir
            cmd.CommandText = "SELECT * FROM Houses WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", id);

            conn.Open();
            using var rdr = cmd.ExecuteReader();
            if (rdr.Read())
                return MapHouse(rdr);
            return null;
        }

        public List<HouseModel> GetAll()
        {
            var list = new List<HouseModel>();
            using var conn = new SqlConnection(_connStr);
            using var cmd = conn.CreateCommand();
            // Tüm ilanları getir
            cmd.CommandText = "SELECT * FROM Houses";

            conn.Open();
            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
                list.Add(MapHouse(rdr));
            return list;
        }

        public List<HouseModel> GetByOwner(int ownerId)
        {
            var list = new List<HouseModel>();
            using var conn = new SqlConnection(_connStr);
            using var cmd = conn.CreateCommand();
            // Sahibe ait ilanları filtrele
            cmd.CommandText = "SELECT * FROM Houses WHERE OwnerId = @ownerId";
            cmd.Parameters.AddWithValue("@ownerId", ownerId);

            conn.Open();
            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
                list.Add(MapHouse(rdr));
            return list;
        }

        public List<HouseModel> GetAvailableHouses(DateTime from, DateTime to)
        {
            var list = new List<HouseModel>();
            using var conn = new SqlConnection(_connStr);
            using var cmd = conn.CreateCommand();
            // Verilen tarih aralığında boş ilanları getir
            cmd.CommandText = @"
                SELECT * FROM Houses h
                WHERE NOT EXISTS (
                  SELECT 1 FROM Reservations r
                  WHERE r.TinyHouseId = h.Id
                    AND r.Status = 1 -- Onaylandı
                    AND r.StartDate < @to
                    AND r.EndDate > @from
                )";
            cmd.Parameters.AddWithValue("@from", from);
            cmd.Parameters.AddWithValue("@to", to);

            conn.Open();
            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
                list.Add(MapHouse(rdr));
            return list;
        }

        private HouseModel MapHouse(SqlDataReader rdr)
        {
            // DataReader'dan HouseModel nesnesi oluşturuyoruz
            return new HouseModel
            {
                Id = (int)rdr["Id"],
                OwnerId = (int)rdr["OwnerId"],
                Title = (string)rdr["Title"],
                Description = (string)rdr["Description"],
                PhotoUrls = (string)rdr["PhotoUrls"],
                AvailableFrom = rdr["AvailableFrom"] == DBNull.Value ? (DateTime?)null : (DateTime)rdr["AvailableFrom"],
                AvailableTo = rdr["AvailableTo"] == DBNull.Value ? (DateTime?)null : (DateTime)rdr["AvailableTo"],
                IsActive = (bool)rdr["IsActive"],
                PricePerNight = (decimal)rdr["PricePerNight"],
                Location = (string)rdr["Location"]
            };
        }
    }
}
