using ApplicationCore.Entities;
using System;
using System.Collections.Generic;

namespace ApplicationCore.Models
{
    public class BookingsResponseModel
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public DateTime? BookingDate { get; set; }
        public string? BookingTime { get; set; }
        public DateTime? PickupDate { get; set; }
        public string? PickupTime { get; set; }
        public string? ContactNo { get; set; }
        public string? Status { get; set; }

        // Navigation property
        public int? CabTypesId { get; set; }
        public CabTypes CabTypes { get; set; }
        List<LocationRequestModel> Locations { get; set; }
    }
}