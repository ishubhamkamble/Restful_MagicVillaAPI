using Restful_MagicVillaAPI.Models.DTO;

namespace Restful_MagicVillaAPI.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO> {
            new VillaDTO{ Id=1, Name="Pool Villa", Occupacy = 6, Sqft = 600},
            new VillaDTO{ Id=2, Name="Beach Villa", Occupacy = 4, Sqft = 700},
            new VillaDTO{ Id=3, Name="Duplex Villa", Occupacy = 12, Sqft = 1000},
            new VillaDTO{ Id=4, Name="AllInOne Villa", Occupacy = 16, Sqft = 1500}
            };
    }
}
