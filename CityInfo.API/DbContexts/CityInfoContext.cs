using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.DbContexts
{
    public class CityInfoContext: DbContext
    {
        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<PointOfInterest> PointsOfInterest { get; set; } = null!;

        public CityInfoContext(DbContextOptions<CityInfoContext> options)
                : base(options)
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<City>()
                .HasData(
               new City("New York")
               {
                   Id = 1,
                   Description = "The one with that big park"
               },
               new City("Antwerp")
               {
                Id = 2,
                   Description = "The one with the cathedral that was never really finished"
               },
               new City("Nakuru")
               {
                Id = 3,
                   Description = "The only city inside rift valley"
               },
               new City("Eldoret")
               {
                Id = 4,
                   Description = "The city for cargo flight in Kenya and Uganda."
               });

            modelBuilder.Entity<PointOfInterest>()
                .HasData(
                new PointOfInterest("Central Park")
                {
                    Id = 1,
                    CityId = 1,
                    Description = "The most visited urban park in United States."
                },
                 new PointOfInterest("Empire State Building")
                 {
                     Id = 2,
                     CityId = 1,
                     Description = "The 102-story skyscraper located in mid-town Manhattan."
                 },
                  new PointOfInterest("The Louvre")
                  {
                      Id = 3,
                      CityId = 2,
                      Description = "The world's largest museum."
                  },
                   new PointOfInterest("Eiffel Tower")
                   {
                       Id = 4,
                       CityId = 2,
                       Description = "The wrought iron lattice tower on champ de mars."
                   },
                    new PointOfInterest("Lake Elmenteita")
                    {
                        Id = 5,
                        CityId = 3,
                        Description = "A soda lake, in the Great Rift Valley, about 120 km northwest of Nairobi, Kenya."
                    },
                     new PointOfInterest("Lake Nakuru National Park")
                     {
                         Id = 6,
                         CityId = 3,
                         Description = "On the floor of the Great Rift Valley, surrounded by wooded and bushy grassland"
                     },
                      new PointOfInterest("Eldoret International Airport")
                      {
                          Id = 7,
                          CityId = 4,
                          Description = "Cargo flight landing zone in Kenya"
                      },
                       new PointOfInterest("Uasin Gishu Plateau.")
                       {
                           Id = 8,
                           CityId = 4,
                           Description = "west of the Great Rift Valley (in the East African Rift System."
                       }
                );
        }
    }
}
