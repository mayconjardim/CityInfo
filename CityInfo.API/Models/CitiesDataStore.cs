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
                    Description = "A cidade maravilhosa.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id= 5,
                            Name = "Cristo Redentor",
                            Description = "Uma das 7 maravilhas do mundo!"
                        }
                    }
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "Niteroi",
                    Description = "Muitas praias e montanhas.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id= 6,
                            Name = "Camboinhas",
                            Description = "Uma otima praia para banho!"
                        },
                          new PointOfInterestDto()
                        {
                            Id= 7,
                            Name = "Trilha do Elefante",
                            Description = "Uma otima caminhada pra quem gosta de exercicios!"
                        }
                    }

                },
                new CityDto()
                {
                    Id = 3,
                    Name = "São Paulo",
                    Description = "A cidade que não para.",
                     PointsOfInterest = new List<PointOfInterestDto>()
                     {
                        new PointOfInterestDto()
                        {
                            Id= 8,
                            Name = "Praça da Sé",
                            Description = "Uma otima praça para passear!"
                        }
                     
                }    }
            };

        
        }

    }
}
