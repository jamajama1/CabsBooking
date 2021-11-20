using ApplicationCore.Entities;

namespace ApplicationCore.Models
{
    public class LocationResponseModel
    {
        public PlaceIdRequestModel placeIdRequestModel;

        public int Id { get; set; }
        public string? PickupAddress { get; set; }
        public string? DropoffAddress { get; set; }
        public string? Landmark { get; set; }
        public int PlacesId { get; set; }
        public Places places { get; set; }
        public int BookingsId { get; set; }
        public Bookings bookings { get; set; }
    }
}