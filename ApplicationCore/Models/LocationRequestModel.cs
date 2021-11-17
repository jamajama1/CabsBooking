using ApplicationCore.Entities;

namespace ApplicationCore.Models
{
    public class LocationRequestModel
    {
        public string? PickupAddress { get; set; }
        public int? DropoffAddress { get; set; }
        public string? Landmark { get; set; }
    }
}