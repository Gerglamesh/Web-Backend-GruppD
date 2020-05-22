using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAPI.Models;

namespace TravelAPI.Services
{
    public class CountryRepo : Repository, ICountryRepo
    {
        public CountryRepo(TravelAPIContext travelAPIContext, ILogger<CountryRepo> logger) : base (travelAPIContext, logger)
        {}

        public async Task<ICollection<CountryModel>> GetCountries(
            bool includeCities = false,
            bool includeTravelRestrictions = false,
            bool includeAttractions = false,
            int attractionsMinRating = 0,
            int attractionsMaxRating = 5)
        {
            _logger.LogInformation("Getting Countries");

            IQueryable<CountryModel> query = _travelAPIContext.Countries
                .Include(i => i.CountryInfo);

            if(includeCities)
            {
                query = query.Include(c => c.Cities);
            }
            if (includeTravelRestrictions)
            {
                query = query.Include(c => c.TravelRestriction);
            }
            if (includeAttractions)
            {
                query = query.Include(c => c.Cities)
                    .ThenInclude(c => c.Attractions);
            }
            if (includeAttractions)
            {
                query = query.Select(c => new CountryModel
                {
                    CountryId = c.CountryId,
                    Name = c.Name,
                    CountryInfoId = c.CountryInfoId,
                    CountryInfo = c.CountryInfo,
                    TravelRestrictionId = c.TravelRestrictionId,
                    TravelRestriction = c.TravelRestriction,
                    Cities = c.Cities.Select(c => new CityModel
                    {
                        CityId = c.CityId,
                        CountryId = c.CountryId,
                        Country = c.Country,
                        Name = c.Name,
                        Population = c.Population,
                        Attractions = c.Where(a => a)
                    }).ToArray()
                });


                if (attractionsMinRating < 0)
                {
                    attractionsMinRating = 0;
                }
                if (attractionsMaxRating > 5)
                {
                    attractionsMinRating = 5;
                }

                query = query.Include(c => c.Cities)
                    .ThenInclude(c => c.Attractions
                    .Where(r => r.Rating <= attractionsMaxRating &&
                                r.Rating >= attractionsMinRating));
            }

            query = query.OrderBy(c => c.Name);
            return await query.ToArrayAsync();
        }

        public async Task<CountryModel> GetCountry(
            string name, 
            bool includeCities = false, 
            bool includeTravelRestrictions = false, 
            bool includeAttractions = false, 
            int attractionsMinRating = 0, 
            int attractionsMaxRating = 5)
        {
            _logger.LogInformation($"Getting Country named '{name}'");

            IQueryable<CountryModel> query = _travelAPIContext
                .Countries.Where(c => c.Name == name)
                .Include(i => i.CountryInfo);

            if (includeCities)
            {
                query = query.Include(c => c.Cities);
            }
            if (includeTravelRestrictions)
            {
                query = query.Include(c => c.TravelRestriction);
            }
            if (includeAttractions)
            {
                if (attractionsMinRating < 0)
                {
                    attractionsMinRating = 0;
                }
                if (attractionsMaxRating > 5)
                {
                    attractionsMinRating = 5;
                }

                query = query.Include(c => c.Cities)
                    .ThenInclude(c => c.Attractions
                    .Where(r => r.Rating <= attractionsMaxRating &&
                                r.Rating >= attractionsMinRating));
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<CountryModel> GetCountry(
            int id, 
            bool includeCities = false, 
            bool includeTravelRestrictions = false, 
            bool includeAttractions = false, 
            int attractionsMinRating = 0, 
            int attractionsMaxRating = 5)
        {
            _logger.LogInformation($"Getting Country with ID {id}");

            IQueryable<CountryModel> query = _travelAPIContext
                .Countries.Where(c => c.CountryId == id)
                .Include(i => i.CountryInfo);

            if (includeCities)
            {
                query = query.Include(c => c.Cities);
            }
            if (includeTravelRestrictions)
            {
                query = query.Include(c => c.TravelRestriction);
            }
            if (includeAttractions)
            {
                if (attractionsMinRating < 0)
                {
                    attractionsMinRating = 0;
                }
                if (attractionsMaxRating > 5)
                {
                    attractionsMinRating = 5;
                }

                query = query.Include(c => c.Cities)
                    .ThenInclude(c => c.Attractions
                    .Where(r => r.Rating <= attractionsMaxRating &&
                                r.Rating >= attractionsMinRating));
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<ICollection<CountryModel>> GetRightHandTraffic(bool isRightHandTraffic)
        {
            _logger.LogInformation($"Getting Countries based on rightHandTraffic: {isRightHandTraffic}");

            IQueryable<CountryModel> query = _travelAPIContext
                .Countries.Where(c => c.CountryInfo.RightHandTraffic == true);

            query = query.OrderBy(e => e.Name);
            return await query.ToArrayAsync();
        }

        public async Task<ICollection<CountryModel>> GetCountriesByLanguage(string language)
        {
            _logger.LogInformation($"Getting Countries based on language: {language}");

            IQueryable<CountryModel> query = _travelAPIContext
                .Countries.Where(c => c.CountryInfo.Language.Contains(language))
                .Include(i => i.CountryInfo);

            query = query.OrderBy(e => e.Name);
            return await query.ToArrayAsync();
        }
    }
}
