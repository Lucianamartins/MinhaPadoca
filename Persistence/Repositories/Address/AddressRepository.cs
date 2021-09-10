using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaPadoca.Persistence.Repositories.Address
{
    public class AddressRepository : IAddressRepository
    {
        private readonly MinhaPadocaDbContext _dbContext;

        public AddressRepository(MinhaPadocaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(Models.Address address)
        {
            _dbContext.Addresses.Add(address);
            _dbContext.SaveChanges();
        }

        public void Delete(int padariaId, int id)
        {
            throw new NotImplementedException();
        }

        public Models.Address GetBakeryId(int padariaId)
        {
            return _dbContext.Addresses.FirstOrDefault(a => a.BakeryId == padariaId);
        }

        public Models.Address GetById(int padariaId, int id)
        {
            throw new NotImplementedException();
        }

        public Models.Address Update(int padariaId, Models.Address address)
        {
            _dbContext.Addresses.Update(address);
            _dbContext.SaveChanges();
            return address;
        }
    }
}
