using Microsoft.AspNetCore.Http;
using MinhaPadoca.Models;
using MinhaPadoca.Persistence.Repositories.Address;
using MinhaPadoca.Repositories.Padaria;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhaPadoca.Services.Padaria
{
    public class BakeryService : IBakeryService
    {
        private readonly IBakeryRepository _bakeryRepository;
        private readonly IAddressRepository _addressRepository;
        public BakeryService(IBakeryRepository bakeryRepository, IAddressRepository addressRepository)
        {
            _bakeryRepository = bakeryRepository;
            _addressRepository = addressRepository;
        }

        public object Details { get; private set; }

        public Bakery Create(IFormCollection form)
        {
            var bakery = new Bakery(form["Name"], DateTime.Now);
                _bakeryRepository.Create(bakery);

                var address = new Models.Address(
                    form["Address.Street"],
                    form["Address.City"],
                    Convert.ToInt32(form["Address.Number"]),
                    form["Address.Neighborhood"],
                    form["Address.Complement"],
                    Convert.ToInt32(form["Address.ZipCode"]),
                    form["Address.State"],
                    bakery.Id,
                    DateTime.Now
                    );
                _addressRepository.Create(address);
            return bakery;
            
        }

        public void Delete(Bakery bakery)
        {
            _bakeryRepository.Delete(bakery);
        }

        public List<Bakery> GetAll()
        {
            return  _bakeryRepository.GetAll();
        }

        public Bakery GetById(int? id)
        {
            var bakery = _bakeryRepository.GetById(id);
            bakery.Address = _addressRepository.GetBakeryId(bakery.Id);
           
            return bakery;
        }

        public Bakery GetByName(string name)
        {
            return _bakeryRepository.GetByName(name);
        }

        public Bakery Update(int id, IFormCollection collection)
        {
            var bakery = _bakeryRepository.GetById(id);

            var address = _addressRepository.GetBakeryId(bakery.Id);

            address.Street = collection["Address.Street"];
            address.City = collection["Address.City"];
            address.Number = Convert.ToInt32(collection["Address.Number"]);
            address.Neighborhood = collection["Address.Neighborhood"];
            address.Complement = collection["Address.Complement"];
            address.ZipCode = Convert.ToInt32(collection["Address.ZipCode"]);
            address.State = collection["Address.State"];

           _addressRepository.Update(bakery.Id,address);


            return _bakeryRepository.Update(bakery);
        }
    }
}