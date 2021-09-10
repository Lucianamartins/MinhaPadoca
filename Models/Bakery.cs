using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaPadoca.Models
{
    public class Bakery
    {
        public Bakery(string name, DateTime registeredAt)
        {
            Name = name;
            RegisteredAt = registeredAt;
        }
        public Bakery(string nome) { }

        public int Id { get; private set; }
        public string Name { get; set; }
        public DateTime RegisteredAt { get; set; }
        public Address Address { get; set; }

    }
}
