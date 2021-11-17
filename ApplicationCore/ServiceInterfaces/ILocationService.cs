using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
     public interface ILocationService
    {
        public Task Add(Location Location);
        public Task GetAll();
        public Task GetById(int id);
        public Task Update(Location Location);
        public Task Delete(Location Location);    }
}
