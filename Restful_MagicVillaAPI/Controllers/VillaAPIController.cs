using Microsoft.AspNetCore.Mvc;
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
            return new List<VillaDTO> {
            new VillaDTO{ Id=1, Name="Pool Villa"},
            new VillaDTO{ Id=1, Name="Beach Villa"}
            };
        }
    }
}
