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

        [HttpGet]
        [Route("GetAllCabs")]
        public async Task<IActionResult> GetAll()
        {
            var cabs = await _cabService.GetAll();
            return Ok(cabs);
        }

        [HttpGet]
        [Route("update")]
        public async Task<IActionResult> updateCab(int id)
        {
            var cab = await _cabService.GetById(id);

            if (cab != null)
                return Ok(cab);

            return null;
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> updateCab([FromBody] CabRequestModel requestModel)
        {
            var cab = await _cabService.Update(requestModel);
            return Ok(cab);
        }

        [HttpGet]
        [Route("delete")]
        public async Task<IActionResult> deleteCab(int id)
        {
            var cab = await _cabService.GetById(id);

            if (cab != null)
                return Ok(cab);

            return null;
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> deleteCab([FromBody] CabRequestModel requestModel)
        {
            await _cabService.Delete(requestModel);
            return Ok();
        }
    }
}
