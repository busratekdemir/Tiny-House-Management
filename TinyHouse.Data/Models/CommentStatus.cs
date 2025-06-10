using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyHouse.Data.Models
{
    public enum CommentStatus : byte
    {
        Pending = 0,  // Onay bekliyor
        Approved = 1,  // Onaylandı
        Rejected = 2   // Reddedildi (isteğe bağlı)
    }
}
