using ApplicationCore;
using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookingsBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IBookingHistoryService _bookingHistoryService;
        private readonly ILocationHistoryService _locationHistoryService;


        public BookingController(IBookingService bookingService, IBookingHistoryService bookingHistoryService, ILocationHistoryService locationHistoryService)
        {
            _bookingService = bookingService;
            _bookingHistoryService = bookingHistoryService;
            _locationHistoryService = locationHistoryService;
        }

        [HttpGet]
        [Route("add")]
        public async Task<IActionResult> AddBooking()
        {
            var bookingResponse = new BookingsResponseModel();
            return Ok(bookingResponse);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddBooking([FromBody] BookingsRequestModel requestModel)
        {
            requestModel.BookingDate = DateTime.Now;
            requestModel.PickupDate = DateTime.Now;
            var addedBooking = await _bookingService.Add(requestModel);
            requestModel.CabTypesId = addedBooking.CabTypesId;
            var bookingId = await _bookingHistoryService.Add(requestModel);
            requestModel.Id = bookingId;
            await _locationHistoryService.Add(requestModel);
            if (addedBooking != null)
                return Ok(addedBooking);

            return null;
        }

        [HttpGet]
        [Route("GetAllBookings")]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _bookingService.GetAll();
            return Ok(bookings);
        }

        [HttpGet]
        [Route("update")]
        public async Task<IActionResult> updatebooking(int id)
        {
            var booking = await _bookingService.GetById(id);

            if (booking != null)
                return Ok(booking);

            return null;
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> updatebooking([FromBody] UpdateBookingsRequestModel requestModel)
        {
            var booking = await _bookingService.Update(requestModel);
            return Ok(booking);
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> delete([FromBody] BookingsDetailsRequestModel requestModel)
        {
            await _bookingService.Delete(requestModel.Id);
            return Ok();
        }
    }
}
