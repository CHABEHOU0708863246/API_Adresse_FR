using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Adresse_FR.Domain.DTO
{
    public class AddressDTO
    {
        public string Postcode { get; set; }
        public string City { get; set; }
        public string Label { get; set; }
        public string Name { get; set; }
        public string Context { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
    }
}
