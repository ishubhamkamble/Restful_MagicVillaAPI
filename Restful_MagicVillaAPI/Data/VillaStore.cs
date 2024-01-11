using Restful_MagicVillaAPI.Models.DTO;

namespace Restful_MagicVillaAPI.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO> {
            new VillaDTO{ Id=1, Name="Pool Villa"},
            new VillaDTO{ Id=2, Name="Beach Villa"},
            new VillaDTO{ Id=3, Name="Duplex Villa"},
            new VillaDTO{ Id=4, Name="AllInOne Villa"}
            };
    }
}
