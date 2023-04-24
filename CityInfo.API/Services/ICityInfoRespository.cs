﻿using CityInfo.API.Entities;

namespace CityInfo.API.Services
{
    public interface ICityInfoRespository
    {
        Task<IEnumerable<City>> GetCitiesAsync();
        Task<City?> GetCityAsync(int cityId, bool includePointsOfInterest);
        Task<bool> CityExistAsync(int cityId);
        Task<IEnumerable<PointOfInterest>> GetPointsOfInterestForCityAsync( int cityId);
        Task<PointOfInterest?> GetPointOfInterestForCityAsync( int cityId,
            int pointOfInterestId);
        Task AddPointOfInterestForCityAsync(int cityId, PointOfInterest pointOfInterest);
        Task<bool> SaveChangesAsync();

    }
}