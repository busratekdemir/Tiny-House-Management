using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using TinyHouse.Data.Models;
using TinyHouse.Data.Utilities;

namespace TinyHouse.Data.Repositories
{
    public class HouseRepository
    {
        private readonly string _connStr;

        // Varsayılan ctor: DbHelper’dan çeker
        public HouseRepository()
        {
            _connStr = DbHelper.GetConnectionString();
        }

        // Overload ctor: dışarıdan da connection string alabilirsin
        public HouseRepository(string connStr)
        {
            _connStr = connStr;
        }

        public List<HouseModel> GetAll()
        {
            var list = new List<HouseModel>();
            using var conn = new SqlConnection(_connStr);
            conn.Open();
            using var cmd = new SqlCommand(@"
                SELECT h.Id,h.Title,h.PricePerNight,h.OwnerId,
                       u.FullName AS OwnerName, h.IsActive,
                       h.Description, h.PhotoUrls,
                       h.AvailableFrom, h.AvailableTo, h.Location
                  FROM Houses h
                  JOIN Users u ON h.OwnerId = u.Id", conn);
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(new HouseModel
                {
                    Id = Convert.ToInt32(r["Id"]),
                    Title = r["Title"].ToString(),
                    PricePerNight = Convert.ToDecimal(r["PricePerNight"]),
                    OwnerId = Convert.ToInt32(r["OwnerId"]),
                    OwnerName = r["OwnerName"].ToString(),
                    IsActive = Convert.ToBoolean(r["IsActive"]),
                    Description = r["Description"].ToString(),
                    PhotoUrls = r["PhotoUrls"].ToString(),
                    AvailableFrom = r["AvailableFrom"] as DateTime?,
                    AvailableTo = r["AvailableTo"] as DateTime?,
                    Location = r["Location"].ToString()
                });
            }
            return list;
        }

        public HouseModel GetById(int id)
        {
            using var conn = new SqlConnection(_connStr);
            conn.Open();
            using var cmd = new SqlCommand(@"
                SELECT h.Id,h.Title,h.PricePerNight,h.OwnerId,
                       u.FullName AS OwnerName, h.IsActive,
                       h.Description, h.PhotoUrls,
                       h.AvailableFrom, h.AvailableTo, h.Location
                  FROM Houses h
                  JOIN Users u ON h.OwnerId = u.Id
                 WHERE h.Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            using var r = cmd.ExecuteReader();
            if (r.Read())
            {
                return new HouseModel
                {
                    Id = Convert.ToInt32(r["Id"]),
                    Title = r["Title"].ToString(),
                    PricePerNight = Convert.ToDecimal(r["PricePerNight"]),
                    OwnerId = Convert.ToInt32(r["OwnerId"]),
                    OwnerName = r["OwnerName"].ToString(),
                    IsActive = Convert.ToBoolean(r["IsActive"]),
                    Description = r["Description"].ToString(),
                    PhotoUrls = r["PhotoUrls"].ToString(),
                    AvailableFrom = r["AvailableFrom"] as DateTime?,
                    AvailableTo = r["AvailableTo"] as DateTime?,
                    Location = r["Location"].ToString()
                };
            }
            return null;
        }

        public int Create(HouseModel h)
        {
            using var conn = new SqlConnection(_connStr);
            conn.Open();
            using var cmd = new SqlCommand(@"
                INSERT INTO Houses 
                  (Title,PricePerNight,OwnerId,IsActive,
                   Description,PhotoUrls,AvailableFrom,AvailableTo,Location)
                VALUES
                  (@Title,@Price,@OwnerId,@IsActive,
                   @Desc,@Photos,@From,@To,@Loc);
                SELECT SCOPE_IDENTITY();", conn);
            cmd.Parameters.AddWithValue("@Title", h.Title);
            cmd.Parameters.AddWithValue("@Price", h.PricePerNight);
            cmd.Parameters.AddWithValue("@OwnerId", h.OwnerId);
            cmd.Parameters.AddWithValue("@IsActive", h.IsActive ? 1 : 0);
            cmd.Parameters.AddWithValue("@Desc", h.Description ?? "");
            cmd.Parameters.AddWithValue("@Photos", h.PhotoUrls ?? "");
            cmd.Parameters.AddWithValue("@From", (object)h.AvailableFrom ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@To", (object)h.AvailableTo ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Loc", h.Location ?? "");
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public bool Update(HouseModel h)
        {
            using var conn = new SqlConnection(_connStr);
            conn.Open();
            using var cmd = new SqlCommand(@"
                UPDATE Houses
                   SET Title          = @Title,
                       PricePerNight  = @Price,
                       OwnerId        = @OwnerId,
                       IsActive       = @IsActive,
                       Description    = @Desc,
                       PhotoUrls      = @Photos,
                       AvailableFrom  = @From,
                       AvailableTo    = @To,
                       Location       = @Loc
                 WHERE Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", h.Id);
            cmd.Parameters.AddWithValue("@Title", h.Title);
            cmd.Parameters.AddWithValue("@Price", h.PricePerNight);
            cmd.Parameters.AddWithValue("@OwnerId", h.OwnerId);
            cmd.Parameters.AddWithValue("@IsActive", h.IsActive ? 1 : 0);
            cmd.Parameters.AddWithValue("@Desc", h.Description ?? "");
            cmd.Parameters.AddWithValue("@Photos", h.PhotoUrls ?? "");
            cmd.Parameters.AddWithValue("@From", (object)h.AvailableFrom ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@To", (object)h.AvailableTo ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Loc", h.Location ?? "");
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(int id)
        {
            using var conn = new SqlConnection(_connStr);
            conn.Open();
            using var cmd = new SqlCommand("DELETE FROM Houses WHERE Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool ToggleStatus(int id)
        {
            using var conn = new SqlConnection(_connStr);
            conn.Open();
            using var cmd = new SqlCommand(@"
                UPDATE Houses
                   SET IsActive = CASE WHEN IsActive = 1 THEN 0 ELSE 1 END
                 WHERE Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            return cmd.ExecuteNonQuery() > 0;
        }

        // Yeni: Sahibine göre listeleme
        public List<HouseModel> GetByOwner(int ownerId)
        {
            var list = new List<HouseModel>();
            using var conn = new SqlConnection(_connStr);
            conn.Open();
            using var cmd = new SqlCommand(@"
                SELECT h.Id,h.Title,h.PricePerNight,h.OwnerId,
                       u.FullName AS OwnerName, h.IsActive,
                       h.Description, h.PhotoUrls,
                       h.AvailableFrom, h.AvailableTo, h.Location
                  FROM Houses h
                  JOIN Users u ON h.OwnerId = u.Id
                 WHERE h.OwnerId = @OwnerId", conn);
            cmd.Parameters.AddWithValue("@OwnerId", ownerId);
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(new HouseModel
                {
                    Id = Convert.ToInt32(r["Id"]),
                    Title = r["Title"].ToString(),
                    PricePerNight = Convert.ToDecimal(r["PricePerNight"]),
                    OwnerId = Convert.ToInt32(r["OwnerId"]),
                    OwnerName = r["OwnerName"].ToString(),
                    IsActive = Convert.ToBoolean(r["IsActive"]),
                    Description = r["Description"].ToString(),
                    PhotoUrls = r["PhotoUrls"].ToString(),
                    AvailableFrom = r["AvailableFrom"] as DateTime?,
                    AvailableTo = r["AvailableTo"] as DateTime?,
                    Location = r["Location"].ToString()
                });
            }
            return list;
        }

        // Yeni: Tarihe göre müsait ilanlar
        public List<HouseModel> GetAvailableHouses(DateTime from, DateTime to)
        {
            var list = new List<HouseModel>();
            using var conn = new SqlConnection(_connStr);
            conn.Open();
            using var cmd = new SqlCommand(@"
                SELECT h.Id,h.Title,h.PricePerNight,h.OwnerId,
                       u.FullName AS OwnerName, h.IsActive,
                       h.Description,h.PhotoUrls,
                       h.AvailableFrom,h.AvailableTo,h.Location
                  FROM Houses h
                  JOIN Users u ON h.OwnerId = u.Id
                 WHERE (@From IS NULL OR h.AvailableFrom <= @From)
                   AND (@To   IS NULL OR h.AvailableTo   >= @To)", conn);
            cmd.Parameters.AddWithValue("@From", (object)from ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@To", (object)to ?? DBNull.Value);
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(new HouseModel
                {
                    Id = Convert.ToInt32(r["Id"]),
                    Title = r["Title"].ToString(),
                    PricePerNight = Convert.ToDecimal(r["PricePerNight"]),
                    OwnerId = Convert.ToInt32(r["OwnerId"]),
                    OwnerName = r["OwnerName"].ToString(),
                    IsActive = Convert.ToBoolean(r["IsActive"]),
                    Description = r["Description"].ToString(),
                    PhotoUrls = r["PhotoUrls"].ToString(),
                    AvailableFrom = r["AvailableFrom"] as DateTime?,
                    AvailableTo = r["AvailableTo"] as DateTime?,
                    Location = r["Location"].ToString()
                });
            }
            return list;
        }
    }
}
