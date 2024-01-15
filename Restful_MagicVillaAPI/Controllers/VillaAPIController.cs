using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Restful_MagicVillaAPI.Data;
using Restful_MagicVillaAPI.Models;
using Restful_MagicVillaAPI.Models.DTO;
using System.Xml.Linq;

namespace Restful_MagicVillaAPI.Controllers
{
    //We can also fetch ControllerName in Route
    //[Route("api/[controller]")]
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private readonly ILogger<VillaAPIController> _logger;

        public VillaAPIController(ILogger<VillaAPIController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            _logger.LogInformation("Getting all villas.");
            return Ok(VillaStore.villaList);
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        //ResponseType as ststus code...
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Get Villa with Error with id :" + id);
                return BadRequest();
            }
            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            if (villa == null)
            {
                _logger.LogError("Requested Villa Not found, id :" + id);
                return NotFound();
            }
            _logger.LogInformation("Requested Villa returned, id :" + id);
            return Ok(villa);
        }

        [HttpGet("name")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTO> GetVilla(string name)
        {
            if (name == null)
            {
                _logger.LogError("Get Villa with Error with name :" + name);
                return BadRequest(string.Empty);
            }
            var villa = VillaStore.villaList.FirstOrDefault(u => u.Name == name);
            if (villa == null)
            {
                _logger.LogError("Requested Villa Not found, id :" + name);
                return NotFound(string.Empty);
            }
            _logger.LogInformation("Requested Villa returned, id :" + name);
            return Ok(villa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villaDTO)
        {
            ///Implementing and accessing ModelState Validation if we comment [ApiController} from line#11
            //if (!ModelState.IsValid) {
            //    return BadRequest();
            //}

            //Implementing CustomError ModelState
            if (VillaStore.villaList.FirstOrDefault(u => u.Name.ToLower() == villaDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "Villa Already Exists");
                _logger.LogError("Bad Request");
                return BadRequest(ModelState);
            }
            if (villaDTO == null)
            {
                _logger.LogError("Bad Request");
                return BadRequest();
            }

            if (villaDTO.Id > 0)
            {
                _logger.LogError("Villa Id not found");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            villaDTO.Id = VillaStore.villaList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;

            VillaStore.villaList.Add(villaDTO);
            _logger.LogInformation("Villa Created with id :" + villaDTO.Id);
            return CreatedAtRoute("GetVilla", new { id = villaDTO.Id }, villaDTO);
        }

        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteVilla(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Requested villa is not found");
                return BadRequest();
            }
            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            if (villa == null)
            {
                _logger.LogError("Requested villa is not found");
                return NotFound();
            }
            VillaStore.villaList.Remove(villa);
            _logger.LogError("Requested villa is deleted");
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateVilla(int id, [FromBody] VillaDTO villaDTO)
        {
            if (villaDTO == null || id != villaDTO.Id)
            {
                _logger.LogError("Requested villa is found");
                return BadRequest();
            }

            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);

            villa.Name = villaDTO.Name;
            villa.Occupacy = villaDTO.Occupacy;
            villa.Sqft = villaDTO.Sqft;
            _logger.LogError("Requested villa is Updated");
            return NoContent();
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialVilla(int id, JsonPatchDocument<VillaDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                _logger.LogError("Requested villa is found");
                return BadRequest();
            }
            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            if (villa == null)
            {
                _logger.LogError("Requested villa is found");
                return BadRequest();
            }
            patchDTO.ApplyTo(villa, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _logger.LogError("Requested villa is Updated");
            return NoContent();
        }
    }
}
