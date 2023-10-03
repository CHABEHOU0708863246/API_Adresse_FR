using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using API_Adresse_FR.Domain.DTO;
using API_Adresse_FR.Domain.Interfaces.InterfacesRepository;
using API_Adresse_FR.Domain.Interfaces.InterfacesService;
using API_Adresse_FR.Domain.Models;
using Newtonsoft.Json;

namespace API_Adresse_FR.Domain.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly HttpClient _httpClient;

        public AddressService(IAddressRepository addressRepository, HttpClient httpClient)
        {
            _addressRepository = addressRepository;
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<AddressDTO>> SearchAddressesAsync(string query)
        {
            // Appel à l'API externe
            var apiResponse = await _httpClient.GetStringAsync("https://api-adresse.data.gouv.fr/search/?q=" + query);

            // Désérialisation de la réponse JSON en modèle d'adresse
            var apiAddress = JsonConvert.DeserializeObject<Address>(apiResponse);

            // Vérification pour éviter les références null
            if (apiAddress?.Features?.Count > 0)
            {
                var propertiesList = apiAddress.Features.Select(feature => feature.Properties);

                // Mapping des données nécessaires vers des DTO
                var addressDTOs = propertiesList.Select(properties => new AddressDTO
                {
                    Postcode = properties.Postcode,
                    City = properties.City,
                    Label = properties.Label,
                    Name = properties.Name,
                    Context = properties.Context,
                    X = properties.X,
                    Y = properties.Y
                }).ToList();

                return addressDTOs;
            }

            return null; // Ou vous pouvez lancer une exception ou renvoyer une liste vide selon vos besoins.
        }
    }
}
