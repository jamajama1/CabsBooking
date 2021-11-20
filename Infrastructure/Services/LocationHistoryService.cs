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
    public class LocationHistoryService : ILocationHistoryService
    {
        private readonly ILocationHistoryRepository _locationHistoryRepository;
        public LocationHistoryService(ILocationHistoryRepository locationHistoryRepository)
        {
            _locationHistoryRepository = locationHistoryRepository;
        }

        public async Task Add(BookingsRequestModel requestModel)
        {
            var location = new LocationHistory
            {
                PickupAddress = requestModel.locationRequest.PickupAddress,
                DropoffAddress = requestModel.locationRequest.DropoffAddress,
                Landmark = requestModel.locationRequest.Landmark,
                BookingsHistoryId = requestModel.Id,
                PlacesId = requestModel.locationRequest.placeIdRequestModel.Id,
            };

            await _locationHistoryRepository.Add(location);
        }

        public async Task Delete(LocationHistory locationHistory)
        {
            await _locationHistoryRepository.Delete(locationHistory);
        }

        public async Task<List<LocationHistoryResponseModel>> GetAll()
        {
            var locationHistory = await _locationHistoryRepository.GetAll();
            var locationResponse = locationHistory.Select(b => new LocationHistoryResponseModel
            {
                Id = b.Id,
                PickupAddress = b.PickupAddress,
                DropoffAddress = b.DropoffAddress,
                Landmark = b.Landmark,
                PlacesId = b.PlacesId,                
            }).ToList();
            return locationResponse;
        }

        public async Task<LocationHistory> GetById(int id)
        {
            var location = await _locationHistoryRepository.GetById(id);
            return location;
        }

        public Task<LocationHistoryResponseModel> Update(LocationHistory LocationHistory)
        {
            throw new NotImplementedException();
        }
    }
}
