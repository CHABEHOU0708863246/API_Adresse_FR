using API_Adresse_FR.Domain.Interfaces.InterfacesRepository;
using API_Adresse_FR.Domain.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace API_Adresse_FR.Infrastructure.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IMongoCollection<Address> _address;

        public AddressRepository(IMongoDatabase database)
        {
            _address = database.GetCollection<Address>("Address");
        }

        #region Récupère tous les Address de manière asynchrone
        public async Task<IEnumerable<Address>> GetAllAsync()
        {
            return await _address.Find(_ => true).ToListAsync();
        }
        #endregion

        public async Task<IEnumerable<Address>> SearchAsync(FilterDefinition<Address> filter)
        {
            return await _address.Find(filter).ToListAsync();
        }

    }
}
