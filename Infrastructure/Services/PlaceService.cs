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
    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRespository _placeRepository;
        public PlaceService(IPlaceRespository placeRespository)
        {
            _placeRepository = placeRespository;
        }
        public async Task<PlaceResponseModel> Add(PlaceRequestModel requestModel)
        {
            var place = new Places();
            var placeResponse = new PlaceResponseModel();
            place.PlaceName = requestModel.PlaceName;            

            var addplace = await _placeRepository.Add(place);
            placeResponse.PlaceName = addplace.PlaceName;
            placeResponse.Id = addplace.Id;


            if (addplace != null)
            {
                return placeResponse;
            }

            return null;
        }

        public async Task Delete(PlaceRequestModel requestModel)
        {
            var cab = new Places
            {
                Id = (int)requestModel.Id,
                PlaceName = requestModel.PlaceName
            };
            await _placeRepository.Delete(cab);
        }

        public async Task<List<PlaceResponseModel>> GetAll()
        {
            var placeList = new List<PlaceResponseModel>();
            var allPlaces = await _placeRepository.GetAll();

            placeList = allPlaces.Select(p => new PlaceResponseModel
            {
                Id = p.Id,
                PlaceName = p.PlaceName
            }).ToList();

            return (placeList);
        }

        public Task<PlaceResponseModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PlaceResponseModel> Update(PlaceRequestModel requestModel)
        {
            var place = await _placeRepository.GetById((int)requestModel.Id);
            place.PlaceName = requestModel.PlaceName;
            var updatedCab = await _placeRepository.Update(place);
            var cabResponse = new PlaceResponseModel
            {
                Id = updatedCab.Id,
                PlaceName = updatedCab.PlaceName
            };

            return cabResponse;
        }
    }
}
