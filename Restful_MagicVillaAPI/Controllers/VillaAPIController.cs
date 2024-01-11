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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            return Ok(VillaStore.villaList);
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        //ResponseType as ststus code...
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            if (id == 0) {  
                return BadRequest(); 
            }
            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            if (villa == null) { 
                return NotFound(); 
            }

            return Ok(villa);
        }

        [HttpGet("name")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTO> GetVilla(string name)
        {
            if (name == null) {
                return BadRequest(string.Empty);
            }
            var villa = VillaStore.villaList.FirstOrDefault(u => u.Name == name);
            if (villa == null) {
                return NotFound(string.Empty);
            }
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
            if (VillaStore.villaList.FirstOrDefault(u=>u.Name.ToLower() == villaDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "Villa Already Exists");
                return BadRequest(ModelState);
            }
            if (villaDTO == null) {
                return BadRequest(); 
            }

            if (villaDTO.Id > 0) {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            villaDTO.Id = VillaStore.villaList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;

            VillaStore.villaList.Add(villaDTO);
            return CreatedAtRoute("GetVilla", new { id = villaDTO.Id}, villaDTO);
        }
    }
}
