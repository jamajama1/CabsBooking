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
    public class CabContoller : ControllerBase
    {
        private readonly ICabService _cabService;
        public CabContoller(ICabService cabService)
        {
            _cabService = cabService;
        }

        [HttpGet]
        [Route("add")]
        public async Task<IActionResult> AddCab()
        {
            var CabResponse = new CabResponseModel();
            return Ok(CabResponse);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddCab([FromBody] CabRequestModel requestModel)
        {
            var addedCab = await _cabService.Add(requestModel);

            if(addedCab != null)
                return Ok(addedCab);

            return null;
        }
    }
}
