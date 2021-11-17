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
    public class CabService: ICabService
    {
        private readonly ICabRepository _cabRepository;
        public CabService(ICabRepository cabRepository)
        {
            _cabRepository = cabRepository;
        }

        public async Task<CabResponseModel> Add(CabRequestModel requestModel)
        {
            var cab = new CabTypes();
            var cabResponse = new CabResponseModel();
            cab.CabTypeName = requestModel.CabTypeName;            

            var addCab = await _cabRepository.Add(cab);
            cabResponse.CabTypeName = addCab.CabTypeName;
            cabResponse.Id = addCab.Id;


            if (addCab != null)
            {
                return cabResponse;
            }

            return null;
        }

        public Task<bool> Delete(CabTypes cabTypes)
        {
            throw new NotImplementedException();
        }

        public Task<List<CabResponseModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CabResponseModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CabResponseModel> Update(CabRequestModel requestModel)
        {
            throw new NotImplementedException();
        }
    }
}
