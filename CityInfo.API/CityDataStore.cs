using CityInfo.API.Models;

namespace CityInfo.API
{
    public class CityDataStore
    {
        public List<CityDto> Cities { get; set; }

        public static CityDataStore Current { get;  } = new CityDataStore();

        public CityDataStore() 
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "New York City",
                    Description = "The one with that big park."
                },
                 new CityDto()
                {
                    Id = 2,
                    Name = "Antwerp",
                    Description = "The one with Cathedral that was never really finished."
                }, new CityDto()
                {
                    Id = 3,
                    Name = "Nakuru",
                    Description = "The newest city in Kenya that has national park with flamingos."
                }, new CityDto()
                {
                    Id = 4,
                    Name = "Eldoret",
                    Description = "The city were most of Kenya's Air cargo flight land."
                }
            };
        }
    }
}
