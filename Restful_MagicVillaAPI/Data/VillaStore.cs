using Restful_MagicVillaAPI.Models.DTO;

namespace Restful_MagicVillaAPI.Data
{
    public class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO> {
            new VillaDTO{ Id=1, Name="Pool Villa"},
            new VillaDTO{ Id=1, Name="Beach Villa"}
            };
    }
}
