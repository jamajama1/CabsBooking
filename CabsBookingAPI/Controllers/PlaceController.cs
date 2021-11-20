using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace placesBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceService _placeService;

        public PlaceController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        [HttpGet]
        [Route("add")]
        public async Task<IActionResult> AddPlace()
        {
            var placeResponse = new PlaceResponseModel();
            return Ok(placeResponse);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddPlace([FromBody] PlaceRequestModel requestModel)
        {
            var addedPlace = await _placeService.Add(requestModel);

            if (addedPlace != null)
                return Ok(addedPlace);

            return null;
        }

        [HttpGet]
        [Route("GetAllPlaces")]
        public async Task<IActionResult> GetAll()
        {
            var places = await _placeService.GetAll();
            return Ok(places);
        }

        [HttpGet]
        [Route("update")]
        public async Task<IActionResult> updatePlace(int id)
        {
            var place = await _placeService.GetById(id);

            if (place != null)
                return Ok(place);

            return null;
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> updatePlace([FromBody] PlaceRequestModel requestModel)
        {
            await _placeService.Update(requestModel);
            return Ok();
        }

        [HttpGet]
        [Route("delete")]
        public async Task<IActionResult> deletePlace(int id)
        {
            var place = await _placeService.GetById(id);

            if (place != null)
                return Ok(place);

            return null;
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> deletePlace([FromBody] PlaceRequestModel requestModel)
        {
            await _placeService.Delete(requestModel);
            return Ok();
        }
    }
}
