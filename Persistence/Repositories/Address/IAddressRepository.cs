using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaPadoca.Persistence.Repositories.Address
{
    public interface IAddressRepository
    {
        Models.Address GetBakeryId(int padariaId);
        Models.Address GetById(int padariaId, int id);
        void Create(Models.Address address);
        Models.Address Update(int padariaId, Models.Address address);
        void Delete(int padariaId, int id);
    }
}
