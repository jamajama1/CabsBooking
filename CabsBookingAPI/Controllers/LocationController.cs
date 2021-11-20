using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace locationsBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        [Route("add")]
        public async Task<IActionResult> AddLocation()
        {
            var LocationResponse = new LocationResponseModel();
            return Ok(LocationResponse);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddLocation([FromBody] LocationRequestModel requestModel)
        {
            var addedLocation = await _locationService.Add(requestModel);

            if (addedLocation != null)
                return Ok(addedLocation);

            return null;
        }

        [HttpGet]
        [Route("GetAllLocations")]
        public async Task<IActionResult> GetAllLocations()
        {
            var locations = await _locationService.GetAll();
            return Ok(locations);
        }

        [HttpGet]
        [Route("update")]
        public async Task<IActionResult> updateLocation(int id)
        {
            var location = await _locationService.GetById(id);

            if (location != null)
                return Ok(location);

            return null;
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> updateLocation([FromBody] LocationRequestModel requestModel)
        {
            var location = await _locationService.Update(requestModel);
            return Ok(location);
        }

        [HttpGet]
        [Route("delete")]
        public async Task<IActionResult> deleteLocation(int id)
        {
            var location = await _locationService.GetById(id);

            if (location != null)
                return Ok(location);

            return null;
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> deleteLocation([FromBody] LocationRequestModel requestModel)
        {
            await _locationService.Delete(requestModel);
            return Ok();
        }
    }
}
