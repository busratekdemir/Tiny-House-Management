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

        // Parametreli ctor
        public ReservationRepository(string connStr)
        {
            _connStr = connStr;
        }

        // Çakışma kontrolü
        public bool IsHouseBooked(int houseId, DateTime start, DateTime end)
        {
            const string sql = @"
                SELECT COUNT(*) FROM Reservations
                 WHERE TinyHouseId = @HouseId
                   AND Status      = @Confirmed
                   AND NOT (@End < StartDate OR @Start > EndDate)";
            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@HouseId", houseId);
            cmd.Parameters.AddWithValue("@Start", start);
            cmd.Parameters.AddWithValue("@End", end);
            cmd.Parameters.AddWithValue("@Confirmed", (int)ReservationStatus.Confirmed);
            conn.Open();
            return (int)cmd.ExecuteScalar() > 0;
        }

        // SP ile ekleme: 0 = pending, -1 = conflict
        public int Add(ReservationModel r)
        {
            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand("sp_RezervasyonEkle", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@UserId", r.UserId);
            cmd.Parameters.AddWithValue("@TinyHouseId", r.TinyHouseId);
            cmd.Parameters.AddWithValue("@StartDate", r.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", r.EndDate);
            cmd.Parameters.AddWithValue("@TotalPrice", r.TotalPrice);

            var ret = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            ret.Direction = ParameterDirection.ReturnValue;

            conn.Open();
            cmd.ExecuteNonQuery();
            return (int)ret.Value;
        }

        // Status güncelleme
        public int UpdateReservationStatus(int reservationId, int status)
        {
            const string sql = "UPDATE Reservations SET Status = @Status WHERE Id = @Id";
            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Status", status);
            cmd.Parameters.AddWithValue("@Id", reservationId);
            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        // Kiracıya ait tüm rezervasyonlar
        public List<ReservationModel> GetByUser(int userId)
        {
            const string sql = @"
                SELECT Id, UserId, TinyHouseId, StartDate, EndDate, TotalPrice, Status
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
                    TinyHouseId = (int)rd["TinyHouseId"],
                    StartDate = (DateTime)rd["StartDate"],
                    EndDate = (DateTime)rd["EndDate"],
                    TotalPrice = (decimal)rd["TotalPrice"],
                    Status = (ReservationStatus)Convert.ToInt32(rd["Status"])
                });
            }
            return list;
        }

        


        // Admin için tüm rezervasyonlar
        public List<ReservationModel> GetAllWithDetails()
        {
            const string sql = @"
                SELECT Id, UserId, TinyHouseId, StartDate, EndDate, TotalPrice, Status
                  FROM Reservations";
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
                    TinyHouseId = (int)rd["TinyHouseId"],
                    StartDate = (DateTime)rd["StartDate"],
                    EndDate = (DateTime)rd["EndDate"],
                    TotalPrice = (decimal)rd["TotalPrice"],
                    Status = (ReservationStatus)Convert.ToInt32(rd["Status"])
                });
            }
            return list;
        }
        public bool HasActiveReservations(int houseId)
        {
            const string sql = @"
        SELECT COUNT(*) FROM Reservations
        WHERE TinyHouseId = @houseId AND Status = @Confirmed";

            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@houseId", houseId);
            cmd.Parameters.AddWithValue("@Confirmed", (int)ReservationStatus.Confirmed);

            conn.Open();
            int count = (int)cmd.ExecuteScalar();
            return count > 0;
        }
        public List<ReservationModel> GetRequestsByOwnerAndStatus(int ownerId, int status)
        {
            const string sql = @"
        SELECT r.Id, r.UserId, r.TinyHouseId, r.StartDate, r.EndDate, r.TotalPrice, r.Status,
               u.Name AS TenantName, 
               t.Title AS HouseTitle
        FROM Reservations r
        JOIN Houses t ON r.TinyHouseId = t.Id
        JOIN Users u ON r.UserId = u.Id
        WHERE t.OwnerId = @OwnerId AND r.Status = @Status";

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
                    TinyHouseId = (int)rd["TinyHouseId"],
                    StartDate = (DateTime)rd["StartDate"],
                    EndDate = (DateTime)rd["EndDate"],
                    TotalPrice = (decimal)rd["TotalPrice"],
                    Status = (ReservationStatus)Convert.ToInt32(rd["Status"]),
                    TenantName = rd["TenantName"].ToString(),
                    HouseTitle = rd["HouseTitle"].ToString()
                });
            }
            return list;
        }






    }

}
