using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class BookingsHistory
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public DateTime? BookingDate { get; set; }
        public string? BookingTime { get; set; }
        public DateTime? PickupDate { get; set; }
        public string? PickupTime { get; set; }
        public string? ContactNo { get; set; }
        public string? Status { get; set; }
        public string? Comp_time { get; set; }
        public decimal? Charge { get; set; }
        public string? Feedback { get; set; }

        // Navigation property
        public int? CabTypesId { get; set; }
        public CabTypes CabTypes { get; set; }
        List<LocationHistory> locationHistories { get; set; }
    }
}