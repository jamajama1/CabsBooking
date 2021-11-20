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
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<LocationResponseModel> Add(LocationRequestModel requestModel)
        {
            var location = new Location 
            {
                Id = requestModel.Id,
                PickupAddress = requestModel.PickupAddress,
                DropoffAddress = requestModel.DropoffAddress,
                Landmark = requestModel.Landmark,
                PlacesId = requestModel.placeIdRequestModel.Id,
                BookingsId = (int)requestModel.BookingsId
            };
            
            var addlocation = await _locationRepository.Add(location);

            var locationResponse = new LocationResponseModel
            {
                Id = addlocation.Id,
                PickupAddress = addlocation.PickupAddress,
                DropoffAddress = addlocation.DropoffAddress,
                Landmark = addlocation.Landmark,
                PlacesId = addlocation.PlacesId,
                BookingsId = addlocation.BookingsId
            };


            if (addlocation != null)
            {
                return locationResponse;
            }

            return null;
        }

        public async Task Delete(LocationRequestModel requestModel)
        {
            var location = await _locationRepository.GetById(requestModel.Id);
            await _locationRepository.Delete(location);
        }

        public async Task<List<LocationResponseModel>> GetAll()
        {
            var locationList = new List<LocationResponseModel>();
            var alllocations = await _locationRepository.GetAll();

            locationList = alllocations.Select(l => new LocationResponseModel
            {
                Id = l.Id,
                BookingsId = l.BookingsId,
                PickupAddress = l.PickupAddress,
                DropoffAddress = l.DropoffAddress,
                Landmark = l.Landmark,
                PlacesId = l.PlacesId
            }).ToList();

            return (locationList);
        }

        public async Task<LocationResponseModel> GetById(int id)
        {
            var location = await _locationRepository.GetById(id);
            var locationResponse = new LocationResponseModel
            {
                Id = location.Id,
                PickupAddress = location.PickupAddress,
                DropoffAddress = location.DropoffAddress,
                Landmark = location.Landmark,
                PlacesId = location.PlacesId
            };

            return locationResponse;
        }

        public async Task<LocationResponseModel> Update(LocationRequestModel requestModel)
        {
            var location = await _locationRepository.GetById((int)requestModel.Id);
            location.PickupAddress = requestModel.PickupAddress;
            location.DropoffAddress = requestModel.DropoffAddress;
            location.Landmark = requestModel.Landmark;
            location.PlacesId = requestModel.placeIdRequestModel.Id;
            location.BookingsId = (int)requestModel.BookingsId;
            var updatedlocation = await _locationRepository.Update(location);
            var locationResponse = new LocationResponseModel
            {
                Id = updatedlocation.Id,
                PickupAddress = updatedlocation.PickupAddress,
                DropoffAddress = updatedlocation.DropoffAddress,
                Landmark = updatedlocation.Landmark,
                PlacesId = updatedlocation.PlacesId,
                BookingsId = updatedlocation.BookingsId
            };

            return locationResponse;
        }

        public async Task<LocationResponseModel> Update(UpdateBookingsRequestModel requestModel)
        {
            var updateLocation = new Location
            {
                Id = requestModel.locationRequest.Id,
                PickupAddress = requestModel.locationRequest.PickupAddress,
                DropoffAddress = requestModel.locationRequest.DropoffAddress,
                Landmark = requestModel.locationRequest.Landmark,
                PlacesId = requestModel.locationRequest.placeIdRequestModel.Id,
                BookingsId = requestModel.Id
            };

            var updatedLocation = await _locationRepository.Update(updateLocation);

            return null;
        }
    }
}
