using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaPadoca.Models
{
    public class Address
    {
        public Address(string street, string city, int number, string neighborhood, string complement, int zipCode, string state, int bakeryId, DateTime? registeredAt)
        {
            Street = street;
            City = city;
            Number = number;
            Neighborhood = neighborhood;
            Complement = complement;
            ZipCode = zipCode;
            State = state;
            BakeryId = bakeryId;
            RegisteredAt = registeredAt;
        }
        public int Id { get; private set; }
        public string Street { get;  set; }
        [Required]
        public string City { get;  set; }
        [Required]
        public int Number { get;  set; }
        [Required]
        public string Neighborhood { get;  set; }
        public string Complement { get;  set; }
        [Required]
        public Int32 ZipCode { get;  set; }
        [Required]
        public string State { get;  set; }
        public DateTime? RegisteredAt { get;  set; }
        public  int BakeryId { get;  set; }
}
}
