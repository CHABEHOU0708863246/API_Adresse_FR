using API_Adresse_FR.Domain.DTO;
using API_Adresse_FR.Domain.Interfaces.InterfacesService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API_Adresse_FR.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchAddresses([FromQuery] string query)
        {
            try
            {
                var addressDTO = await _addressService.SearchAddressesAsync(query);

                if (addressDTO != null)
                    return Ok(addressDTO);
                else
                    return NotFound("Aucune adresse trouvée."); 
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Une erreur s'est produite lors de la recherche des adresses.");
            }
        }
    }
}
