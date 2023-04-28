using AutoMapper;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CityInfo.API.Controllers
{
    [ApiController]
    //[Authorize]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]

    [Route("api/v{version:apiVersion}/cities")]
    public class CitiesController : ControllerBase

    {

        private readonly ICityInfoRepository _cityInfoRespository;
        private readonly IMapper _mapper;
        const int maxCitiesPageSize = 20;

        public CitiesController(ICityInfoRepository cityInfoRespository,
            IMapper mapper)
        {
            this._cityInfoRespository = cityInfoRespository ?? throw new ArgumentNullException(nameof(cityInfoRespository));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        /// <summary>
        /// Gets a list of cities and also uses pagination
        /// </summary>
        /// <param name="name">Filters a name of a city</param>
        /// <param name="searchQuery">Searches the name of the city of description </param>
        /// <param name="pageNumber">Sets the page number</param>
        /// <param name="pageSize">Sets the items listed in a single page</param>
        /// <returns>An IActionResult</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityWithoutPointsOfInterestDto>>> GetCities(string? name, string? searchQuery, int pageNumber = 1, int pageSize = 10)
        {
            if(pageSize > maxCitiesPageSize)
            {
                pageSize = maxCitiesPageSize;
            }

            var (cityEntities, paginationMetadata) = await _cityInfoRespository.GetCitiesAsync(
                name, searchQuery, pageNumber, pageSize);

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));

            return Ok(_mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities));
        }

        /// <summary>
        /// Get a city by id
        /// </summary>
        /// <param name="id">The id of the city to get</param>
        /// <param name="includePointsOfInterest">Whether or not include the points of interest </param>
        /// <returns>An IActionResult</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity(int id, bool includePointsOfInterest = false)
        {
            var city = await _cityInfoRespository.GetCityAsync(id, includePointsOfInterest);
            if (city == null)
            {
                return NotFound();
            }

            if (includePointsOfInterest)
            {
                return Ok(_mapper.Map<CityDto>(city));
            }

            return Ok(_mapper.Map<CityWithoutPointsOfInterestDto>(city));
        }
    }
}
