using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IPlaceService
    {
        public Task Add(Places Places);
        public Task GetAll();
        public Task GetById(int id);
        public Task Update(Places Places);
        public Task Delete(Places Places);
    }
}
