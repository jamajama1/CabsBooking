using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class CabResponseModel
    {
        public int Id { get; set; }
        public string? CabTypeName { get; set; }

        // Navigation property
        List<BookingsHistoryResponseModel> bookingsHistories { get; set; }
        List<BookingsRequestModel> bookings { get; set; }
    }
}
