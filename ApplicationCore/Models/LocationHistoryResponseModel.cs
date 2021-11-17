using ApplicationCore.Entities;

namespace ApplicationCore.Models
{
    public class LocationHistoryResponseModel
    {
        public int Id { get; set; }
        public string? PickupAddress { get; set; }
        public int? DropoffAddress { get; set; }
        public string? Landmark { get; set; }
        public int PlacesId { get; set; }
        public Places Places { get; set; }
        public int BookingsHistoryId { get; set; }
        public BookingsHistory BookingsHistory { get; set; }
    }
}