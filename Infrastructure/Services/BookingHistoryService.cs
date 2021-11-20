using ApplicationCore;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class BookingHistoryService : IBookingHistoryService
    {
        private readonly IBookingHistoryRepository _bookingHistoryRepository;
        private readonly ILocationHistoryRepository _locationHistoryRepository;
        public BookingHistoryService(IBookingHistoryRepository bookingHistoryRepository, ILocationHistoryRepository locationHistoryRepository)
        {
            _bookingHistoryRepository = bookingHistoryRepository;
            _locationHistoryRepository = locationHistoryRepository;
        }

        public async Task<int> Add(BookingsRequestModel requestModel)
        {
            var booking = new BookingsHistory
            {
                BookingDate = requestModel.BookingDate,
                BookingTime = requestModel.BookingTime,
                PickupDate = requestModel.PickupDate,
                PickupTime = requestModel.PickupTime,
                Email = requestModel.Email,
                ContactNo = requestModel.ContactNo,
                Status = requestModel.Status,
                CabTypesId = requestModel.CabTypesId
            };

            await _bookingHistoryRepository.Add(booking);

            return booking.Id;
        }

        public async Task Delete(BookingsHistory BookingsHistory)
        {
            await _bookingHistoryRepository.Delete(BookingsHistory);
        }

        public async Task<List<BookingsHistoryResponseModel>> GetAll()
        {
            var bookingHistory = await _bookingHistoryRepository.GetAll();
            var bookingResponse = bookingHistory.Select(b => new BookingsHistoryResponseModel
            {
                Id = b.Id,
                BookingDate = b.BookingDate,
                BookingTime = b.BookingTime,
                Charge = (decimal?)10.99,
                Email = b.Email,
                ContactNo = b.ContactNo,
                Comp_time = "30min",
                Feedback = "smooth ride home",
                PickupDate = b.PickupDate,
                PickupTime = b.PickupTime,
                Status = b.Status,
                CabTypesId = b.CabTypesId               
            }).ToList();
            return bookingResponse;
        }

        public async Task<BookingsHistory> GetById(int id)
        {
            var booking = await _bookingHistoryRepository.GetById(id);
            return booking;
        }

        public Task<BookingsHistoryResponseModel> Update(BookingsHistory BookingsHistory)
        {
            throw new NotImplementedException();
        }
    }
}
