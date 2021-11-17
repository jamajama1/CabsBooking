using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IBookingService
    {
        public Task Add(Bookings Bookings);
        public Task GetAll();
        public Task GetById(int id);
        public Task Update(Bookings Bookings);
        public Task Delete(Bookings Bookings);
    }
}
