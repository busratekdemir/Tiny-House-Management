// TinyHouse.Data/Repositories/UserRepository.cs
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using TinyHouse.Data.Models;
using TinyHouse.Data.Utilities;

namespace TinyHouse.Data.Repositories
{
    public class UserRepository
    {
        private readonly string _connStr;
        public UserRepository() => _connStr = DbHelper.GetConnectionString();

        public List<UserModel> GetAll()
        {
            var liste = new List<UserModel>();
            using var conn = new SqlConnection(_connStr);
            conn.Open();
            using var cmd = new SqlCommand(
                "SELECT Id, FullName, Email, Password, Role, IsActive FROM Users", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                liste.Add(new UserModel
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    FullName = reader["FullName"].ToString(),
                    Email = reader["Email"].ToString(),
                    PasswordHash = reader["Password"].ToString(),
                    Role = reader["Role"].ToString(),
                    IsActive = Convert.ToBoolean(reader["IsActive"])
                });
            }
            return liste;
        }
        public bool Deactivate(int userId)
        {
            using (var conn = new SqlConnection(_connStr))
            {
                conn.Open();
                var cmd = new SqlCommand("EXEC sp_KullaniciyiPasifYap @UserId", conn);
                cmd.Parameters.AddWithValue("@UserId", userId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public UserModel GetByEmail(string email)
        {
            using var conn = new SqlConnection(_connStr);
            conn.Open();
            using var cmd = new SqlCommand(
                "SELECT Id, FullName, Email, Password, Role, IsActive FROM Users WHERE Email = @Email", conn);
            cmd.Parameters.AddWithValue("@Email", email);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new UserModel
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    FullName = reader["FullName"].ToString(),
                    Email = reader["Email"].ToString(),
                    PasswordHash = reader["Password"].ToString(),
                    Role = reader["Role"].ToString(),
                    IsActive = Convert.ToBoolean(reader["IsActive"])
                };
            }
            return null;
        }

        public int Create(UserModel user)
        {
            using var conn = new SqlConnection(_connStr);
            conn.Open();
            using var cmd = new SqlCommand(@"
                INSERT INTO Users (FullName, Email, Password, Role, IsActive)
                VALUES (@FullName, @Email, @Password, @Role, @IsActive);
                SELECT SCOPE_IDENTITY();", conn);
            cmd.Parameters.AddWithValue("@FullName", user.FullName);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@Password", user.PasswordHash);
            cmd.Parameters.AddWithValue("@Role", user.Role);
            cmd.Parameters.AddWithValue("@IsActive", user.IsActive ? 1 : 0);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public bool Update(UserModel user)
        {
            using var conn = new SqlConnection(_connStr);
            conn.Open();
            using var cmd = new SqlCommand(@"
                UPDATE Users
                SET FullName = @FullName,
                    Email    = @Email,
                    Password = @Password,
                    Role     = @Role
                WHERE Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", user.Id);
            cmd.Parameters.AddWithValue("@FullName", user.FullName);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@Password", user.PasswordHash);
            cmd.Parameters.AddWithValue("@Role", user.Role);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(int userId)
        {
            using var conn = new SqlConnection(_connStr);
            conn.Open();
            using var cmd = new SqlCommand("DELETE FROM Users WHERE Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", userId);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool ToggleStatus(int userId)
        {
            using var conn = new SqlConnection(_connStr);
            conn.Open();
            using var cmd = new SqlCommand(@"
                UPDATE Users
                SET IsActive = CASE WHEN IsActive = 1 THEN 0 ELSE 1 END
                WHERE Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", userId);
            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
