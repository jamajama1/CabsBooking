using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IBookingService
    {
        public Task<BookingsDetailsResponseModel> Add(BookingsRequestModel requestModel);
        public Task<List<BookingsResponseModel>> GetAll();
        public Task<BookingsResponseModel> GetById(int id);
        public Task<BookingsDetailsResponseModel> Update(UpdateBookingsRequestModel requestModel);
        public Task Delete(int id);
    }
}
