using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Places
    {
        public int Id { get; set; }
        public string? PlaceName { get; set; }

        // Navigation Property
        List<Location> locations { get; set; }
        List<LocationHistory> locationHistories { get; set; }
    }
}
