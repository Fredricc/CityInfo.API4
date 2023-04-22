using AutoMapper;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
     [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase

    {

        private readonly ICityInfoRespository _cityInfoRespository;
        private readonly IMapper _mapper;

        public CitiesController(ICityInfoRespository cityInfoRespository,
            IMapper mapper)
    {
            this._cityInfoRespository = cityInfoRespository ?? throw new ArgumentNullException(nameof(cityInfoRespository));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityWithoutPointsOfInterestDto>>> GetCities()
        {
            var cityEntities = await _cityInfoRespository.GetCitiesAsync();

                return Ok(_mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities));
        }

        //[HttpGet("{id}")]
        //public ActionResult<CityDto> GetCity(int id)
        //{
        //    //find city
        //    var cityToReturn = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == id);

        //    if (cityToReturn == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(cityToReturn);
        //}
    }
}
