using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Data.SqlClient;
using TinyHouse.Data.Models;
using TinyHouse.Data.Utilities;

namespace TinyHouse.Data.Repositories
{
    public class HouseRepository
    {
        private readonly string _connStr;

        public HouseRepository()
        {
            _connStr = DbHelper.GetConnectionString();
        }
        public HouseRepository(string connStr)
        {
            _connStr = connStr;
        }

        public int Add(HouseModel house)
        {
            using var conn = new SqlConnection(_connStr);
            conn.Open();
            using var cmd = new SqlCommand(@"
        INSERT INTO TinyHouses
          (Title, Description, PhotoUrls, AvailableFrom, AvailableTo, IsActive, PricePerNight, Location, OwnerId)
        VALUES
          (@Title, @Description, @PhotoUrls, @AvailableFrom, @AvailableTo, @IsActive, @PricePerNight, @Location, @OwnerId);
        SELECT SCOPE_IDENTITY();", conn);

            cmd.Parameters.AddWithValue("@Title", house.Title);
            cmd.Parameters.AddWithValue("@Description", house.Description);
            cmd.Parameters.AddWithValue("@PhotoUrls", (object)house.PhotoUrls ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@AvailableFrom", (object)house.AvailableFrom ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@AvailableTo", (object)house.AvailableTo ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@IsActive", house.IsActive ? 1 : 0);
            cmd.Parameters.AddWithValue("@PricePerNight", house.PricePerNight);
            cmd.Parameters.AddWithValue("@Location", house.Location);
            cmd.Parameters.AddWithValue("@OwnerId", house.OwnerId);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }


        public bool Update(HouseModel house)
        {
            const string sql = @"
      UPDATE TinyHouses
         SET Title          = @Title,
             Description    = @Description,
             PhotoUrls      = @PhotoUrls,
             AvailableFrom  = @AvailableFrom,
             AvailableTo    = @AvailableTo,
             IsActive       = @IsActive,
             PricePerNight  = @PricePerNight,
             Location       = @Location
       WHERE Id = @Id";
            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Title", house.Title);
            cmd.Parameters.AddWithValue("@Description", house.Description);
            cmd.Parameters.AddWithValue("@PhotoUrls", house.PhotoUrls ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@AvailableFrom", (object)house.AvailableFrom ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@AvailableTo", (object)house.AvailableTo ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@IsActive", house.IsActive);
            cmd.Parameters.AddWithValue("@PricePerNight", house.PricePerNight);
            cmd.Parameters.AddWithValue("@Location", house.Location);
            cmd.Parameters.AddWithValue("@Id", house.Id);
            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }



        public bool Delete(int houseId)
        {
            using var conn = new SqlConnection(_connStr);
            conn.Open();

            // A) Rezervasyon var mı kontrolü
            using (var checkCmd = new SqlCommand(
                "SELECT COUNT(*) FROM Reservations WHERE TinyHouseId = @hid", conn))
            {
                checkCmd.Parameters.AddWithValue("@hid", houseId);
                int count = (int)checkCmd.ExecuteScalar();
                if (count > 0)
                    return false;   // İlişkili rezervasyon var → silme başarısız
            }

            // B) Rezervasyon yoksa sil
            using var delCmd = new SqlCommand(
                "DELETE FROM TinyHouses WHERE Id = @hid", conn);
            delCmd.Parameters.AddWithValue("@hid", houseId);
            return delCmd.ExecuteNonQuery() > 0;
        }


        public HouseModel GetById(int id)
        {
            using var conn = new SqlConnection(_connStr);
            conn.Open();
            using var cmd = new SqlCommand(@"
        SELECT 
          Id, Title, Description,
          PhotoUrls, AvailableFrom, AvailableTo, IsActive,
          PricePerNight, Location, OwnerId
        FROM TinyHouses
        WHERE Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;

            return new HouseModel
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Title = reader.GetString(reader.GetOrdinal("Title")),
                Description = reader.GetString(reader.GetOrdinal("Description")),
                PhotoUrls = reader.IsDBNull(reader.GetOrdinal("PhotoUrls")) ? null
                                : reader.GetString(reader.GetOrdinal("PhotoUrls")),
                AvailableFrom = reader.IsDBNull(reader.GetOrdinal("AvailableFrom")) ? (DateTime?)null
                                : reader.GetDateTime(reader.GetOrdinal("AvailableFrom")),
                AvailableTo = reader.IsDBNull(reader.GetOrdinal("AvailableTo")) ? (DateTime?)null
                                : reader.GetDateTime(reader.GetOrdinal("AvailableTo")),
                IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive")),
                PricePerNight = reader.GetDecimal(reader.GetOrdinal("PricePerNight")),
                Location = reader.GetString(reader.GetOrdinal("Location")),
                OwnerId = reader.GetInt32(reader.GetOrdinal("OwnerId"))
            };
        }


        public List<HouseModel> GetAll()
    => ReadList("SELECT * FROM TinyHouses", null);

        public List<HouseModel> GetByOwner(int ownerId)
            => ReadList("SELECT * FROM TinyHouses WHERE OwnerId = @OwnerId",
                        new SqlParameter[] { new SqlParameter("@OwnerId", ownerId) });

        // ortak okuma:
        private List<HouseModel> ReadList(string sql, SqlParameter[] pars)
        {
            var list = new List<HouseModel>();
            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand(sql, conn);
            if (pars != null) cmd.Parameters.AddRange(pars);
            conn.Open();

            using var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                list.Add(new HouseModel
                {
                    Id = rd.GetInt32(rd.GetOrdinal("Id")),
                    Title = rd.GetString(rd.GetOrdinal("Title")),
                    Description = rd.GetString(rd.GetOrdinal("Description")),
                    PhotoUrls = rd.IsDBNull(rd.GetOrdinal("PhotoUrls")) ? null
                                    : rd.GetString(rd.GetOrdinal("PhotoUrls")),
                    AvailableFrom = rd.IsDBNull(rd.GetOrdinal("AvailableFrom")) ? (DateTime?)null
                                    : rd.GetDateTime(rd.GetOrdinal("AvailableFrom")),
                    AvailableTo = rd.IsDBNull(rd.GetOrdinal("AvailableTo")) ? (DateTime?)null
                                    : rd.GetDateTime(rd.GetOrdinal("AvailableTo")),
                    IsActive = rd.GetBoolean(rd.GetOrdinal("IsActive")),
                    PricePerNight = rd.GetDecimal(rd.GetOrdinal("PricePerNight")),
                    Location = rd.GetString(rd.GetOrdinal("Location")),
                    OwnerId = rd.GetInt32(rd.GetOrdinal("OwnerId"))
                });
            }
            return list;
        }
    }
}
