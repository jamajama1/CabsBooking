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
    public class BookingHistoryController : ControllerBase
    {
        private readonly IBookingHistoryService _bookingHistoryService;
        public BookingHistoryController(IBookingHistoryService bookingHistoryService)
        {
            _bookingHistoryService = bookingHistoryService;
        }

        [HttpGet]
        [Route("GetAllBookings")]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _bookingHistoryService.GetAll();
            return Ok(bookings);
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> delete([FromBody] Identifier identifier)
        {
            var bookings = await _bookingHistoryService.GetById(identifier.Id);
            await _bookingHistoryService.Delete(bookings);
            return Ok(bookings);
        }
    }
}
