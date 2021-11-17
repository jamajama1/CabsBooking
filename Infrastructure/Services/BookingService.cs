using ApplicationCore;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class BookingService : IBookingService
    {
        private readonly BookingRepository _bookingRepository;
        public BookingService(BookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public Task Add(Bookings Bookings)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Bookings Bookings)
        {
            throw new NotImplementedException();
        }

        public Task GetAll()
        {
            throw new NotImplementedException();
        }

        public Task GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Bookings Bookings)
        {
            throw new NotImplementedException();
        }
    }
}
