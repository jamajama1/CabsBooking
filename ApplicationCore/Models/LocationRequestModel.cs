using ApplicationCore.Entities;

namespace ApplicationCore.Models
{
    public class LocationRequestModel
    {
        public int Id { get; set; }
        public string? PickupAddress { get; set; }
        public string? DropoffAddress { get; set; }
        public string? Landmark { get; set; }
        public int? BookingsId { get; set; }
        public PlaceIdRequestModel placeIdRequestModel { get; set; }
    }
}