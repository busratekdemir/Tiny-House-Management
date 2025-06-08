using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using TinyHouse.Data.Models;

namespace TinyHouse.Data.Repositories
{
    public class ReviewRepository
    {
        // Bağlantı dizesini saklıyoruz
        private readonly string _connStr;

        // Repository'i bağlantı dizesi ile başlatıyoruz
        public ReviewRepository(string connStr) => _connStr = connStr;

        // Yeni yorumu ekle ve eklenen kaydın ID'sini döndür
        public int Add(ReviewModel review)
        {
            using var conn = new SqlConnection(_connStr);
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                INSERT INTO dbo.Reviews
                    (HouseId, UserId, Rating, Text)
                VALUES
                    (@houseId, @userId, @rating, @text);
                SELECT SCOPE_IDENTITY();";

            cmd.Parameters.AddWithValue("@houseId", review.HouseId);
            cmd.Parameters.AddWithValue("@userId", review.UserId);
            cmd.Parameters.AddWithValue("@rating", review.Rating);
            cmd.Parameters.AddWithValue("@text", (object)review.Text ?? DBNull.Value);

            conn.Open();
            var result = cmd.ExecuteScalar();

            return Convert.ToInt32(result);
        }

        // Belirli bir ilanın yorumlarını getir
        public List<ReviewModel> GetByHouseId(int houseId)
        {
            var result = new List<ReviewModel>();
            using (var conn = new SqlConnection(_connStr))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Reviews WHERE HouseId = @houseId";
                cmd.Parameters.AddWithValue("@houseId", houseId);

                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        result.Add(new ReviewModel
                        {
                            Id = (int)rdr["Id"],
                            HouseId = (int)rdr["HouseId"],
                            UserId = (int)rdr["UserId"],
                            Rating = (int)rdr["Rating"],
                            Text = (string)rdr["Text"],
                            CreatedAt = (DateTime)rdr["CreatedAt"]
                        });
                    }
                }
            }
            return result;
        }
    }
}
