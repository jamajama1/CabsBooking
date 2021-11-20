using ApplicationCore.Entities;

namespace ApplicationCore.Models
{
    public class LocationHistoryRequestModel
    {        
        public string? PickupAddress { get; set; }
        public string? DropoffAddress { get; set; }
        public string? Landmark { get; set; }
    }
}