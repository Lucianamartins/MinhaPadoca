using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhaPadoca.Services.Padaria
{
    public interface IBakeryService
    {
        List<Models.Bakery> GetAll();
        Models.Bakery GetById(int? id);
        Models.Bakery GetByName(string name);
        Models.Bakery Create(IFormCollection form);
        Models.Bakery Update(int id, IFormCollection collection);
        void Delete(Models.Bakery bakery);

    }
}
