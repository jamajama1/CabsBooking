﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class PlaceResponseModel
    {
        public int Id { get; set; }
        public int? PlaceName { get; set; }
        List<LocationResponseModel> locations { get; set; }
        List<LocationHistoryResponseModel> locationHistories { get; set; }
    }
}
