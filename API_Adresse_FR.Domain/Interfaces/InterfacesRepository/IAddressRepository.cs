using API_Adresse_FR.Domain.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Adresse_FR.Domain.Interfaces.InterfacesRepository
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAllAsync();
        Task<IEnumerable<Address>> SearchAsync(FilterDefinition<Address> filter);
    }
}
