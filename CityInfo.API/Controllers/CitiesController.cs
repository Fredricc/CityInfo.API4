using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
        [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetCities()
        {
             return new JsonResult(CityDataStore.Current.Cities);
        }

        [HttpGet("{id}")]
        public JsonResult GetCity(int id)
        {
            return new JsonResult(
                CityDataStore.Current.Cities.FirstOrDefault(c => c.Id == id));
        }
    }
}
