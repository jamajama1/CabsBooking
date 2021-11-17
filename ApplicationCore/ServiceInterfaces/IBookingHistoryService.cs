using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IBookingHistoryService
    {
        public Task Add(BookingsHistory BookingsHistory);
        public Task GetAll();
        public Task GetById(int id);
        public Task Update(BookingsHistory BookingsHistory);
        public Task Delete(BookingsHistory BookingsHistory);
    }
}
