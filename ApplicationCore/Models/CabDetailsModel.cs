using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class CabDetailsModel
    {
        public int Id { get; set; }
        public string? CabTypeName { get; set; }

        // Navigation property
        List<Bookings> bookings { get; set; }
    }
}
