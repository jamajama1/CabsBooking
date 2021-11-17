using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface ICabService
    {
        public Task Add(CabTypes cabTypes);
        public Task GetAll();
        public Task GetById(int id);
        public Task Update(CabTypes cabTypes);
        public Task Delete(CabTypes cabTypes);
    }
}
