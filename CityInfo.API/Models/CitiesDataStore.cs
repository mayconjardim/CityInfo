namespace CityInfo.API.Models
{
    public class CitiesDataStore
    {

        public List<CityDto> Cities { get; set; } 

        public static CitiesDataStore Current {  get; set; } = new CitiesDataStore();

        public CitiesDataStore() 
        {

            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "Rio de Janeiro",
                    Description = "A cidade maravilhosa."
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "Niteroi",
                    Description = "Muitas praias e montanhas."
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "São Paulo",
                    Description = "A cidade que não para."
                }
            };

        
        }

    }
}
