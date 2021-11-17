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
    public class LocationHistoryService : ILocationHistoryService
    {
        private readonly ILocationHistoryRepository _locationHistoryRepository;
        public LocationHistoryService(ILocationHistoryRepository locationHistoryRepository)
        {
            _locationHistoryRepository = locationHistoryRepository;
        }
        public Task Add(LocationHistory LocationHistory)
        {
            throw new NotImplementedException();
        }

        public Task Delete(LocationHistory LocationHistory)
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

        public Task Update(LocationHistory LocationHistory)
        {
            throw new NotImplementedException();
        }
    }
}
