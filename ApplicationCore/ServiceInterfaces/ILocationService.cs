using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
     public interface ILocationService
    {
        public Task<LocationResponseModel> Add(LocationRequestModel requestModel);
        public Task<List<LocationResponseModel>> GetAll();
        public Task<LocationResponseModel> GetById(int id);
        public Task<LocationResponseModel> Update(LocationRequestModel requestModel);
        public Task<LocationResponseModel> Update(UpdateBookingsRequestModel requestModel);
        public Task Delete(LocationRequestModel requestModel);    }
}
