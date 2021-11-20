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

        public async Task Delete(CabRequestModel requestModel)
        {
            var cab = new CabTypes
            {
                Id = (int)requestModel.Id,
                CabTypeName = requestModel.CabTypeName
            };
            await _cabRepository.Delete(cab);
        }

        public async Task<List<CabResponseModel>> GetAll()
        {
            var cabList = new List<CabResponseModel>();
            var allCabs = await _cabRepository.GetAll();

            cabList = allCabs.Select(c => new CabResponseModel { 
                Id = c.Id,
                CabTypeName = c.CabTypeName
            }).ToList();

            return (cabList);
        }

        public async Task<CabResponseModel> GetById(int id)
        {
            var cab = await _cabRepository.GetById(id);
            var cabResponse = new CabResponseModel
            {
                Id = cab.Id,
                CabTypeName = cab.CabTypeName
            };

            return cabResponse;
        }

        public async Task<CabResponseModel> Update(CabRequestModel requestModel)
        {
            var cab = await _cabRepository.GetById((int)requestModel.Id);
            cab.CabTypeName = requestModel.CabTypeName;
            var updatedCab = await _cabRepository.Update(cab);
            var cabResponse = new CabResponseModel
            {
                Id = updatedCab.Id,
                CabTypeName = updatedCab.CabTypeName
            };

            return cabResponse;
        }
    }
}
