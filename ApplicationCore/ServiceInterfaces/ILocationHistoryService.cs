using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface ILocationHistoryService
    {
        public Task Add(LocationHistory LocationHistory);
        public Task GetAll();
        public Task GetById(int id);
        public Task Update(LocationHistory LocationHistory);
        public Task Delete(LocationHistory LocationHistory);
    }
}
