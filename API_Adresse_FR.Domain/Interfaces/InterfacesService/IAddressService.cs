using API_Adresse_FR.Domain.DTO;
using API_Adresse_FR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Adresse_FR.Domain.Interfaces.InterfacesService
{
    public interface IAddressService
    {
        Task<IEnumerable<AddressDTO>> SearchAddressesAsync(string query);
    }
}
