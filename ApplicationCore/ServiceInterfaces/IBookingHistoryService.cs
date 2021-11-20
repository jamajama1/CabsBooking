using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IBookingHistoryService
    {
        public Task<int> Add(BookingsRequestModel requestModel);
        public Task<List<BookingsHistoryResponseModel>> GetAll();
        public Task<BookingsHistory> GetById(int id);
        public Task<BookingsHistoryResponseModel> Update(BookingsHistory BookingsHistory);
        public Task Delete(BookingsHistory BookingsHistory);
    }
}
