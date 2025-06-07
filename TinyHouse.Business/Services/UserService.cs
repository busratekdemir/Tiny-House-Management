// TinyHouse.Business\Services\UserService.cs
using System.Collections.Generic;
using TinyHouse.Data.Models;
using TinyHouse.Data.Repositories;

namespace TinyHouse.Business.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepo;

        public UserService()
        {
            _userRepo = new UserRepository();
        }

        public UserModel GetByEmail(string email)
        {
            return _userRepo.GetByEmail(email);
        }

        public int Create(string fullName, string email, string passwordHash, string role)
        {
            var user = new UserModel
            {
                FullName = fullName,
                Email = email,
                PasswordHash = passwordHash,
                Role = role,
                IsActive = true
            };
            return _userRepo.Create(user);
        }

        public bool Deactivate(int userId)
        {
            return _userRepo.Deactivate(userId);
        }

        public List<UserModel> GetAllUsers()
        {
            return _userRepo.GetAll();
        }
    }
}
