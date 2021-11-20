using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.ServiceInterfaces
{
    public interface ILocationHistoryService
    {
        public Task Add(BookingsRequestModel requestModel);
        public Task<List<LocationHistoryResponseModel>> GetAll();
        public Task<LocationHistory> GetById(int id);
        public Task<LocationHistoryResponseModel> Update(LocationHistory LocationHistory);
        public Task Delete(LocationHistory locationHistory);
    }
}
