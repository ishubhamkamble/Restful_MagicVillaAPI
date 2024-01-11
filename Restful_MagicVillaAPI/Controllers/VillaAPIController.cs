using Microsoft.AspNetCore.Mvc;
using Restful_MagicVillaAPI.Data;
using Restful_MagicVillaAPI.Models;
using Restful_MagicVillaAPI.Models.DTO;

namespace Restful_MagicVillaAPI.Controllers
{
    //We can also fetch ControllerName in Route
    //[Route("api/[controller]")]
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<VillaDTO> GetVillas()
        {
            return VillaStore.villaList;
        }

        [HttpGet("{id:int}")]
        public VillaDTO GetVilla(int id)
        {
            return VillaStore.villaList.FirstOrDefault(u => u.Id == id);
        }

        [HttpGet("name")]
        public VillaDTO GetVilla(string name)
        {
            return VillaStore.villaList.FirstOrDefault(u => u.Name == name);
        }

    }
}
