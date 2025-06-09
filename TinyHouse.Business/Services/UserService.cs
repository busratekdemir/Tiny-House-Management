// TinyHouse.Business/Services/UserService.cs
using System.Collections.Generic;
using TinyHouse.Data.Models;
using TinyHouse.Data.Repositories;

namespace TinyHouse.Business.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepo;
        public UserService() => _userRepo = new UserRepository();

        public List<UserModel> GetAllUsers() => _userRepo.GetAll();
        public UserModel GetByEmail(string email) => _userRepo.GetByEmail(email);
        public int Create(string fullName, string email, string passwordHash, string role)
            => _userRepo.Create(new UserModel
            {
                FullName = fullName,
                Email = email,
                PasswordHash = passwordHash,
                Role = role,
                IsActive = true
            });
        public bool Deactivate(int userId)
        {
            return _userRepo.Deactivate(userId);
        }
        public bool Update(UserModel user) => _userRepo.Update(user);
        public bool DeleteUser(int userId) => _userRepo.Delete(userId);
        public bool ToggleUserStatus(int userId) => _userRepo.ToggleStatus(userId);

    }

}
