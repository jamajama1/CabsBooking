using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class CabTypes
    {
        public int Id { get; set; }
        public string? CabTypeName { get; set; }

        // Navigation property
        List<BookingsHistory> bookingsHistories { get; set; }
        List<Bookings> bookings { get; set; }
    }
}
