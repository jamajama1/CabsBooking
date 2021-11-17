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
    public class CabService: ICabService
    {
        private readonly ICabRepository _cabRepository;
        public CabService(ICabRepository cabRepository)
        {
            _cabRepository = cabRepository;
        }

        public Task Add(CabTypes cabTypes)
        {
            throw new NotImplementedException();
        }

        public Task Delete(CabTypes cabTypes)
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

        public Task Update(CabTypes cabTypes)
        {
            throw new NotImplementedException();
        }
    }
}
