using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabsBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationHistoryController : ControllerBase
    {
        private readonly ILocationHistoryService _locationHistoryService;

        public LocationHistoryController(ILocationHistoryService locationHistoryService)
        {
            _locationHistoryService = locationHistoryService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var locations = await _locationHistoryService.GetAll();
            return Ok(locations);
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> delete([FromBody] Identifier identifier)
        {
            var locations = await _locationHistoryService.GetById(identifier.Id);
            await _locationHistoryService.Delete(locations);
            return Ok(locations);
        }
    }
}
