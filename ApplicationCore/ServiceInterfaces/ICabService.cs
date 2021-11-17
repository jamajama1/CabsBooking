using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface ICabService
    {
        public Task<CabResponseModel> Add(CabRequestModel requestModel);
        public Task<List<CabResponseModel>> GetAll();
        public Task<CabResponseModel> GetById(int id);
        public Task<CabResponseModel> Update(CabRequestModel requestModel);
        public Task<Boolean> Delete(CabTypes cabTypes);
    }
}
