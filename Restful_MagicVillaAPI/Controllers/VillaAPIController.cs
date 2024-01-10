using Microsoft.AspNetCore.Mvc;
using Restful_MagicVillaAPI.Models;

namespace Restful_MagicVillaAPI.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Villa> GetVillas()
        {
            return new List<Villa> {
            new Villa{ Id=1, Name="Pool Villa"},
            new Villa{ Id=1, Name="Beach Villa"}
            };
        }
    }
}
