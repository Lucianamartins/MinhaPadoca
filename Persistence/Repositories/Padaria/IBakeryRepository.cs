using MinhaPadoca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaPadoca.Repositories.Padaria
{
    public interface IBakeryRepository
    {
        List<Models.Bakery> GetAll();
        Models.Bakery GetById(int? id);
        void Create(Bakery bakery);
        Bakery Update(Bakery padaria);
        void Delete(Bakery bakery);
        Bakery GetByName(string name); 
    }
} 
