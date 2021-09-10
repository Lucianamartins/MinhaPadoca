using Microsoft.EntityFrameworkCore;
using MinhaPadoca.Models;
using MinhaPadoca.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaPadoca.Repositories.Padaria
{
    public class BakeryRepository : IBakeryRepository
    {
        private readonly MinhaPadocaDbContext _dbContext;

        public BakeryRepository(MinhaPadocaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Bakery bakery)
        {
             _dbContext.Bakeries.Add(bakery);
            _dbContext.SaveChanges();
        }

        public void Delete(Bakery bakery)
        {
             _dbContext.Bakeries.Remove(bakery);
             _dbContext.SaveChanges();
        }

        public List<Bakery> GetAll()
        {
            var bakeries = _dbContext.Bakeries.ToList();
            return bakeries;
        }

        public Bakery GetById(int? id)
        {
            return  _dbContext.Bakeries.SingleOrDefault(p => p.Id == id);
        }

        public Bakery GetByName(string name)
        {
            var bakery = _dbContext.Bakeries.FirstOrDefault(n => n.Name == name);
            return bakery;
        }

        public Bakery Update(Bakery bakery)
        {
             _dbContext.Update(bakery);
             _dbContext.SaveChanges();
            return bakery;
        }
    }
}
