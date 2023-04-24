﻿using AutoMapper;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
        private readonly ILogger<PointsOfInterestController>_logger;
        private readonly IMailService _mailService;
        private readonly ICityInfoRespository _cityInfoRespository;
        private readonly IMapper _mapper;

        public PointsOfInterestController(ILogger<PointsOfInterestController> logger, IMailService mailService, 
            ICityInfoRespository cityInfoRespository,
            IMapper mapper) 
        {
            this._logger = logger ?? 
                throw new ArgumentNullException(nameof(logger));
            _mailService = mailService ?? 
                throw new ArgumentNullException(nameof(mailService));
            this._cityInfoRespository = cityInfoRespository ?? 
                throw new ArgumentNullException(nameof(cityInfoRespository));
            this._mapper = mapper ?? 
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PointOfInterestDto>>> GetPointsOfInterest(int  cityId)
        {
            if (!await _cityInfoRespository.CityExistAsync(cityId))
            {
                _logger.LogInformation(
                    $"City with id {cityId} wasn't found when accessing points of interest.");
                return NotFound();
            }

            var pointsOfInterestForCity = await _cityInfoRespository
                .GetPointsOfInterestForCityAsync(cityId);

            return Ok(_mapper.Map<IEnumerable<PointOfInterestDto>>(pointsOfInterestForCity));

        }

        [HttpGet("{pointofinterestid}", Name = "GetPointOfInterest")]
        public async Task<ActionResult<PointOfInterestDto>> GetPointOfInterest(
            int cityId , int pointOfInterestId)
        {
           if(!await _cityInfoRespository.CityExistAsync(cityId))
            {
                return NotFound();
            }

           var pointOfInterest = await _cityInfoRespository
                .GetPointOfInterestForCityAsync (cityId, pointOfInterestId);

            if(pointOfInterest == null)
            {
                return NotFound();
            }

           return (_mapper.Map<PointOfInterestDto>( pointOfInterest));
        }

        [HttpPost]
        public async Task<ActionResult<PointOfInterestDto>> CreatePointOfInterest(
                   int cityId,
                   PointOfInterestForCreationDto pointOfInterest)
        {
            if (!await _cityInfoRespository.CityExistAsync(cityId))
            {
                return NotFound();
            }

            var finalPointOfInterest = _mapper.Map<Entities.PointOfInterest>(pointOfInterest);

            await _cityInfoRespository.AddPointOfInterestForCityAsync(
                cityId, finalPointOfInterest);

            await _cityInfoRespository.SaveChangesAsync();
            
            var createdPointOfInterestToReturn =
               _mapper.Map<Models.PointOfInterestDto>(finalPointOfInterest);

            return CreatedAtRoute("GetPointOfInterest",
                 new
                 {
                     cityId = cityId,
                     pointOfInterestId = createdPointOfInterestToReturn.Id
                 },
                 createdPointOfInterestToReturn);
        }

        [HttpPut("{pointofinterestid}")]
        public async Task<ActionResult> UpdatePointOfInterest(int cityId, int pointOfInterestId,
                   PointOfInterestForUpdateDto pointOfInterest)
        {
            if (!await _cityInfoRespository.CityExistAsync(cityId))
            {
                return NotFound();
            }

            var pointOfInterestEntity = await _cityInfoRespository
                .GetPointOfInterestForCityAsync (cityId, pointOfInterestId);

            if (pointOfInterestEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(pointOfInterest, pointOfInterestEntity);

            await _cityInfoRespository.SaveChangesAsync ();

            return NoContent();

        }

        //[HttpPatch("{pointofinterestid}")]
        //public ActionResult PartiallyUpdatePointOfInterest(
        //    int cityId, int pointOfInterestId,
        //    JsonPatchDocument<PointOfInterestForUpdateDto> patchDocument)
        //{
        //    var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);
        //    if (city == null)
        //    {
        //        return NotFound();
        //    }

        //    //find point of interest
        //    var pointOfInterestFromStore = city.PointsOfInterest
        //        .FirstOrDefault(c => c.Id == pointOfInterestId);

        //    if (pointOfInterestFromStore == null)
        //    {
        //        return NotFound();
        //    }

        //    var pointOfInterestToPatch =
        //        new PointOfInterestForUpdateDto()
        //        {
        //            Name = pointOfInterestFromStore.Name,
        //            Description = pointOfInterestFromStore.Description
        //        };

        //    patchDocument.ApplyTo(pointOfInterestToPatch, ModelState);

        //    if(!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if(!TryValidateModel(pointOfInterestToPatch))
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    pointOfInterestFromStore.Name = pointOfInterestToPatch.Name;
        //    pointOfInterestFromStore.Description = pointOfInterestToPatch.Description;

        //    _mailService.Send("Point of interest updated.",
        //        $"point of interest {pointOfInterestFromStore.Name} with Id {pointOfInterestFromStore.Id} was updated. ");
        //    return NoContent() ;
        //}

        //[HttpDelete("{pointofinterestid}")]
        //public ActionResult DeletePointOfInterest(int cityId, int pointOfInterestId) 
        //{ 
        //    var city = _citiesDataStore.Cities
        //        .FirstOrDefault(c => c.Id == cityId);
        //    if (city == null) 
        //    {
        //        return NotFound();
        //    }
        //var pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(c  => c.Id == pointOfInterestId);
        //    if (pointOfInterestFromStore == null)
        //    {
        //        return NotFound();
        //    }

        //    city.PointsOfInterest.Remove(pointOfInterestFromStore);
        //    _mailService.Send("Point of interest deleted.",
        //        $"point of interest {pointOfInterestFromStore.Name} with Id {pointOfInterestFromStore.Id} was deleted. ");
        //    return NoContent() ;
        //}
    }
}
