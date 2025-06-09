using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TinyHouse.Data/Models/UserModel.cs
namespace TinyHouse.Data.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; } // Şifre hash’li olarak saklanacak
        public string Role { get; set; }
        public bool IsActive { get; set; }
   
          
    }
}
