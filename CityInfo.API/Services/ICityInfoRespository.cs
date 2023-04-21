using CityInfo.API.Entities;

namespace CityInfo.API.Services
{
    public interface ICityInfoRespository
    {
        Task<IEnumerable<City>> GetCitiesAsync();
    }
}
