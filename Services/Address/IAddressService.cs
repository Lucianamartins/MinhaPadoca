using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaPadoca.Services.Address
{
    public interface IAddressService
    {
        List<Models.Address> GetAll(int padariaId);
        Models.Address GetById(int padariaId,int id);
        void Create(int padariaId,Models.Address address);
        Models.Address Update(int padariaId, int id, Models.Address address);
        void Delete(int padariaId, int id);
    }
}
