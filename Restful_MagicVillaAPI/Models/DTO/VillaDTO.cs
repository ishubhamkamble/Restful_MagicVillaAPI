using System.ComponentModel.DataAnnotations;

namespace Restful_MagicVillaAPI.Models.DTO
{
    public class VillaDTO
    {
        public int Id { get; set; }
        //Data Annotations for validations
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
