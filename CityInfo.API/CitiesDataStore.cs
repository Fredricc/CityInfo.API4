using CityInfo.API.Models;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }

        public static CitiesDataStore Current { get;  } = new CitiesDataStore();

        public CitiesDataStore() 
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "New York City",
                    Description = "The one with that big park.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id =1,
                            Name = "Central Park.",
                            Description = "The most visited urban park in the United States." },
                         new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "Empire State Building.",
                            Description = "A 102-story skyscraper located in Midtown Manhattan." },
                    }
                },
                 new CityDto()
                {
                    Id = 2,
                    Name = "Antwerp",
                    Description = "The one with Cathedral that was never really finished.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id =3,
                            Name = "Cathedral of our Lady.",
                            Description = "A Gothic style cathedral, conceived by architects Jan and Piete." },
                         new PointOfInterestDto()
                        {
                            Id = 4,
                            Name = "Antwerp Central Station.",
                            Description = "The most visited urban park in the United States." },
                    }
                }, new CityDto()
                {
                    Id = 3,
                    Name = "Nakuru",
                    Description = "The newest city in Kenya that has national park with flamingos.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id =5,
                            Name = "Lake Elmenteita.",
                            Description = " A soda lake, in the Great Rift Valley, about 120 km northwest of Nairobi, Kenya." },
                         new PointOfInterestDto()
                        {
                            Id = 6,
                            Name = "Lake Nakuru National Park",
                            Description = "On the floor of the Great Rift Valley, surrounded by wooded and bushy grassland" },
                    }
                }, new CityDto()
                {
                    Id = 4,
                    Name = "Eldoret",
                    Description = "The city were most of Kenya's Air cargo flight land.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id =7,
                            Name = "Eldoret International Airport.",
                            Description = "Cargo flight landing zone in Kenya." },
                         new PointOfInterestDto()
                        {
                            Id = 8,
                            Name = "Uasin Gishu Plateau.",
                            Description = "west of the Great Rift Valley (in the East African Rift System)." },
                    }
                }
            };
        }
    }
}
