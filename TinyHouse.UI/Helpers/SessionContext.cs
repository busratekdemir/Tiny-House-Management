using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyHouse.UI.Helpers
{
    public static class SessionContext
    {
        public static int CurrentUserId { get; set; }
        public static UserRole CurrentUserRole { get; set; }
        public static string CurrentUserFullName { get; set; }
    }
}
