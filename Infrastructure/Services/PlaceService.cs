using ApplicationCore.Entities;
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
        public Task Add(Places Places)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Places Places)
        {
            throw new NotImplementedException();
        }

        public Task GetAll()
        {
            throw new NotImplementedException();
        }

        public Task GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Places Places)
        {
            throw new NotImplementedException();
        }
    }
}
