using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyHouse.Business.Enums
{
    public enum ReservationStatus { Pending = 0, Confirmed = 1, Cancelled = 2 }

    public enum UserRole
    {
        Admin = 0,
        EvSahibi = 1,
        Kiraci = 2
    }
}
