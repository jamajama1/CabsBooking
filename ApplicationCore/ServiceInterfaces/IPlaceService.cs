using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IPlaceService
    {
        public Task<PlaceResponseModel> Add(PlaceRequestModel requestModel);
        public Task<List<PlaceResponseModel>> GetAll();
        public Task<PlaceResponseModel> GetById(int id);
        public Task<PlaceResponseModel> Update(PlaceRequestModel requestModel);
        public Task Delete(PlaceRequestModel requestModel);
    }
}
