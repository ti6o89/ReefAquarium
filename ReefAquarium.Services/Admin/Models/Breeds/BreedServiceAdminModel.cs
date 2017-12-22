namespace ReefAquarium.Services.Admin.Models.Breeds
{
    using ReefAquarium.Common.Mapping;
    using ReefAquarium.Data.Models;

    public class BreedServiceAdminModel : IMapFrom<Breed>
    {
        public string Name { get; set; }
        
        public int MinTankSize { get; set; }
        
        public bool ReefCompatible { get; set; }
        
        public CareLevel CareLevel { get; set; }

        public Temperament Temperament { get; set; }
        
        public int MaxSize { get; set; }
        
        public string Diet { get; set; }
        
        public string ImageUrl { get; set; }
    }
}
