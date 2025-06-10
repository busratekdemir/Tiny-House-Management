// TinyHouse.Business\Services\AuthService.cs
using System;
using TinyHouse.Data.Models;
using TinyHouse.Data.Repositories;
using BCrypt.Net; // NuGet: BCrypt.Net-Next

namespace TinyHouse.Business.Services
{
    public class AuthService
    {
        private readonly UserRepository _userRepo;

        public AuthService()
        {
            _userRepo = new UserRepository();
        }

        /// <summary>
        /// Kullanıcının e-posta ve düz şifresini alır. 
        /// Şifreyi BCrypt ile doğrular. 
        /// Eğer kullanıcı yoksa veya pasifse ya da şifre yanlışsa null döner.
        /// Başarılıysa UserModel döner.
        /// </summary>
        public UserModel Authenticate(string email, string plainPassword)
        {
            var user = _userRepo.GetByEmail(email);
            if (user == null || !user.IsActive)
                return null;

            // BCrypt ile hash doğrulaması:
            bool valid = BCrypt.Net.BCrypt.Verify(plainPassword, user.PasswordHash);
            return valid ? user : null;
        }
    }
}
