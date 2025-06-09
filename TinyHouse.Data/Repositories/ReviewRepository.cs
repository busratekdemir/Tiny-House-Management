using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using TinyHouse.Data.Models;
using TinyHouse.Data.Utilities;

namespace TinyHouse.Data.Repositories
{
    public class ReviewRepository
    {
        // Bağlantı dizesini saklıyoruz
        private readonly string _connStr;

        // Repository'i bağlantı dizesi ile başlatıyoruz
        public ReviewRepository(string connStr) => _connStr = connStr;
        public ReviewRepository() : this(DbHelper.GetConnectionString()) { }

        // Yeni yorumu ekle ve eklenen kaydın ID'sini döndür
        public int Add(ReviewModel review)
        {
            const string sql = @"
                INSERT INTO dbo.Reviews
                    (HouseId, UserId, Rating, Text, CreatedAt, Status)
                VALUES
                    (@h, @u, @r, @t, GETDATE(), @s);
                SELECT SCOPE_IDENTITY();";
            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@h", review.HouseId);
            cmd.Parameters.AddWithValue("@u", review.UserId);
            cmd.Parameters.AddWithValue("@r", review.Rating);
            cmd.Parameters.AddWithValue("@t", (object)review.Text ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@s", (byte)review.Status);
            conn.Open();
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        // Belirli bir ilanın yorumlarını getir
        // 4.2 Mevcut: Belirli Ev Yorumları
        public List<ReviewModel> GetByHouseId(int houseId)
        {
            var list = new List<ReviewModel>();
            const string sql = "SELECT * FROM Reviews WHERE HouseId = @h";
            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@h", houseId);
            conn.Open();
            using var rd = cmd.ExecuteReader();
            while (rd.Read())
                list.Add(new ReviewModel
                {
                    Id = (int)rd["Id"],
                    HouseId = (int)rd["HouseId"],
                    UserId = (int)rd["UserId"],
                    Rating = (int)rd["Rating"],
                    Text = rd["Text"] as string,
                    CreatedAt = (DateTime)rd["CreatedAt"],
                    Status = (CommentStatus)(byte)rd["Status"]
                });
            return list;
        }
        // 4.3 YENİ: Tüm Yorumları (Admin)
        public List<ReviewModel> GetAllReviews()
        {
            var list = new List<ReviewModel>();
            const string sql = "SELECT * FROM Reviews";
            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand(sql, conn);
            conn.Open();
            using var rd = cmd.ExecuteReader();
            while (rd.Read())
                list.Add(new ReviewModel
                {
                    Id = (int)rd["Id"],
                    HouseId = (int)rd["HouseId"],
                    UserId = (int)rd["UserId"],
                    Rating = (int)rd["Rating"],
                    Text = rd["Text"] as string,
                    CreatedAt = (DateTime)rd["CreatedAt"],
                    Status = (CommentStatus)(byte)rd["Status"]
                });
            return list;
        }
        //  Yorum Durumu Güncelle (Onayla/Reddet)
        public bool UpdateReviewStatus(int reviewId, CommentStatus newStatus)
        {
            const string sql = @"
                UPDATE Reviews
                   SET Status = @s
                 WHERE Id     = @i";
            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@s", (byte)newStatus);
            cmd.Parameters.AddWithValue("@i", reviewId);
            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }
        //  Yorumu Sil
        public bool Delete(int reviewId)
        {
            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand("DELETE FROM Reviews WHERE Id = @i", conn);
            cmd.Parameters.AddWithValue("@i", reviewId);
            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

    }
}
