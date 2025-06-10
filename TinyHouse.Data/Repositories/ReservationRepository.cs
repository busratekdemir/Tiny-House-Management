// TinyHouse.Data/Repositories/ReservationRepository.cs
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using TinyHouse.Data.Models;
using TinyHouse.Data.Utilities;

namespace TinyHouse.Data.Repositories
{
    public class ReservationRepository
    {
        private readonly string _connStr;

        public ReservationRepository()
            : this(DbHelper.GetConnectionString())
        { }

        public ReservationRepository(string connStr)
        {
            _connStr = connStr;
        }

        /// <summary>
        /// Yeni rezervasyonu stored procedure ile ekler.
        /// SP geriye 0 = pending, -1 = conflict dönüyor.
        /// </summary>
        public int Add(ReservationModel r)
        {
            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand("sp_AddReservation", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@HouseId", r.HouseId);
            cmd.Parameters.AddWithValue("@UserId", r.UserId);
            cmd.Parameters.AddWithValue("@StartDate", r.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", r.EndDate);
            cmd.Parameters.AddWithValue("@TotalPrice", r.TotalPrice);

            var returnParam = new SqlParameter("@ReturnVal", SqlDbType.Int)
            {
                Direction = ParameterDirection.ReturnValue
            };
            cmd.Parameters.Add(returnParam);

            conn.Open();
            cmd.ExecuteNonQuery();
            return (int)returnParam.Value;
        }

        /// <summary>
        /// İki tarih aralığında çakışan Confirmed rezervasyon var mı?
        /// </summary>
        public bool IsHouseBooked(int houseId, DateTime from, DateTime to)
        {
            const string sql = @"
                SELECT COUNT(1)
                  FROM Reservations
                 WHERE TinyHouseId = @HouseId
                   AND Status       = @Confirmed
                   AND NOT (@To < StartDate OR @From > EndDate)";
            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@HouseId", houseId);
            cmd.Parameters.AddWithValue("@From", from);
            cmd.Parameters.AddWithValue("@To", to);
            cmd.Parameters.AddWithValue("@Confirmed", (byte)ReservationStatus.Confirmed);
            conn.Open();
            return (int)cmd.ExecuteScalar() > 0;
        }

        /// <summary>
        /// Bir evde onaylı (Confirmed) rezervasyon var mı diye basit kontrol.
        /// </summary>
        public bool HasActiveReservations(int houseId)
        {
            const string sql = @"
                SELECT COUNT(1)
                  FROM Reservations
                 WHERE TinyHouseId = @HouseId
                   AND Status       = @Confirmed";
            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@HouseId", houseId);
            cmd.Parameters.AddWithValue("@Confirmed", (byte)ReservationStatus.Confirmed);
            conn.Open();
            return (int)cmd.ExecuteScalar() > 0;
        }

        /// <summary>
        /// Admin için tüm rezervasyonları detaylarıyla döner.
        /// </summary>
        public List<ReservationModel> GetAllWithDetails()
        {
            const string sql = @"
                SELECT r.Id,
                       r.UserId,
                       u.FullName      AS TenantName,
                       r.TinyHouseId   AS HouseId,
                       h.Title         AS HouseTitle,
                       r.StartDate,
                       r.EndDate,
                       r.TotalPrice,
                       r.Status        AS ReservationStatus,
                       r.Status        AS PaymentStatus 
                  FROM Reservations r
                  JOIN Users  u ON r.UserId      = u.Id
                  JOIN Houses h ON r.TinyHouseId = h.Id";
            var list = new List<ReservationModel>();
            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand(sql, conn);
            conn.Open();
            using var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                list.Add(new ReservationModel
                {
                    Id = (int)rd["Id"],
                    UserId = (int)rd["UserId"],
                    TenantName = rd["TenantName"].ToString(),
                    HouseId = (int)rd["HouseId"],
                    HouseTitle = rd["HouseTitle"].ToString(),
                    StartDate = (DateTime)rd["StartDate"],
                    EndDate = (DateTime)rd["EndDate"],
                    TotalPrice = rd["TotalPrice"] == DBNull.Value ? 0 : (decimal)rd["TotalPrice"],
                    Status = rd["ReservationStatus"] == DBNull.Value ? ReservationStatus.Pending : (ReservationStatus)Convert.ToInt32(rd["ReservationStatus"]),
                    PaymentStatus = rd["PaymentStatus"].ToString()
                });
            }
            return list;
        }

        /// <summary>
        /// Ev sahibine gelen rezervasyonları durumuna göre filtreler.
        /// </summary>
        public List<ReservationModel> GetRequestsByOwnerAndStatus(int ownerId, int status)
        {
            const string sql = @"
                SELECT r.Id,
                       r.UserId,
                       u.FullName      AS TenantName,
                       r.TinyHouseId   AS HouseId,
                       h.Title         AS HouseTitle,
                       r.StartDate,
                       r.EndDate,
                       r.TotalPrice,
                       r.Status        AS ReservationStatus,
                       r.Status        AS PaymentStatus 
                  FROM Reservations r
                  JOIN Users  u ON r.UserId      = u.Id
                  JOIN Houses h ON r.TinyHouseId = h.Id
                 WHERE h.OwnerId      = @OwnerId
                   AND r.Status       = @Status";
            var list = new List<ReservationModel>();
            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@OwnerId", ownerId);
            cmd.Parameters.AddWithValue("@Status", status);
            conn.Open();
            using var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                list.Add(new ReservationModel
                {
                    Id = (int)rd["Id"],
                    UserId = (int)rd["UserId"],
                    TenantName = rd["TenantName"].ToString(),
                    HouseId = (int)rd["HouseId"],
                    HouseTitle = rd["HouseTitle"].ToString(),
                    StartDate = (DateTime)rd["StartDate"],
                    EndDate = (DateTime)rd["EndDate"],
                    TotalPrice = rd["TotalPrice"] == DBNull.Value ? 0 : (decimal)rd["TotalPrice"],
                    Status = rd["ReservationStatus"] == DBNull.Value ? ReservationStatus.Pending : (ReservationStatus)Convert.ToInt32(rd["ReservationStatus"]),
                    PaymentStatus = rd["PaymentStatus"].ToString()
                });
            }
            return list;
        }

        /// <summary>
        /// Rezervasyon silme (kalıcı).
        /// </summary>
        public bool Delete(int reservationId)
        {
            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand("DELETE FROM Reservations WHERE Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", reservationId);
            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        /// <summary>
        /// Rezervasyon durumunu güncelleme (onay/reddet/iptal).
        /// </summary>
        public bool UpdateReservationStatus(int reservationId, ReservationStatus newStatus)
        {
            const string sql = @"
                UPDATE Reservations
                   SET Status = @Status
                 WHERE Id     = @Id";
            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Status", (byte)newStatus);
            cmd.Parameters.AddWithValue("@Id", reservationId);
            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        /// <summary>
        /// Ev sahibinin toplam gelirini hesaplar.
        /// </summary>
        public decimal GetOwnerIncome(int ownerId)
        {
            const string sql = @"
                SELECT COALESCE(SUM(r.TotalPrice), 0)
                  FROM Reservations r
                  JOIN Houses      h ON r.TinyHouseId = h.Id
                 WHERE h.OwnerId    = @OwnerId
                   AND r.Status     = @Confirmed";
            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@OwnerId", ownerId);
            cmd.Parameters.AddWithValue("@Confirmed", (byte)ReservationStatus.Confirmed);
            conn.Open();
            return (decimal)cmd.ExecuteScalar();
        }

        /// <summary>
        /// Bir evde herhangi bir rezervasyon var mı diye kontrol eder.
        /// </summary>
        public bool HasAnyReservations(int houseId)
        {
            const string sql = @"SELECT COUNT(1) FROM Reservations WHERE TinyHouseId = @HouseId";
            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@HouseId", houseId);
            conn.Open();
            return (int)cmd.ExecuteScalar() > 0;
        }
        /// <summary>
        /// Belirli bir kullanıcıya ait tüm rezervasyonları getirir.
        /// </summary>
        public List<ReservationModel> GetByUser(int userId)
        {
            const string sql = @"
        SELECT Id,
               UserId,
               TinyHouseId AS HouseId,
               StartDate,
               EndDate,
               TotalPrice,
               Status
          FROM Reservations
         WHERE UserId = @UserId";
            var list = new List<ReservationModel>();
            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@UserId", userId);
            conn.Open();
            using var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                list.Add(new ReservationModel
                {
                    Id = (int)rd["Id"],
                    UserId = (int)rd["UserId"],
                    HouseId = (int)rd["HouseId"],
                    StartDate = (DateTime)rd["StartDate"],
                    EndDate = (DateTime)rd["EndDate"],
                    TotalPrice = rd["TotalPrice"] == DBNull.Value
                                     ? 0
                                     : (decimal)rd["TotalPrice"],
                    Status = (ReservationStatus)Convert.ToInt32(rd["Status"])
                });
            }
            return list;
        }

    }
}
