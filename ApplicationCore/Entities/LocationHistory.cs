using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class LocationHistory
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
