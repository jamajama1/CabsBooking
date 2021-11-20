using System;
using System.Collections.Generic;

namespace ApplicationCore.Models
{
    public class BookingsDetailsResponseModel
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public DateTime? BookingDate { get; set; }
        public string? BookingTime { get; set; }
        public DateTime? PickupDate { get; set; }
        public string? PickupTime { get; set; }
        public string? ContactNo { get; set; }
        public string? Status { get; set; }
        public int? CabTypesId { get; set; }
        public LocationResponseModel locationRequest { get; set; }
        public CabResponseModel cabResponseModel { get; set; }
    }
}