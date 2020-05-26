using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

        private static IQueryable<CountryModel> CountryQuery(bool includeCities, bool includeTravelRestrictions, bool includeAttractions, int attractionsMinRating, int attractionsMaxRating, IQueryable<CountryModel> query)
        {
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
                        Name = c.Name,
                        Population = c.Population,
                        CountryId = c.CountryId,
                        Attractions = c.Attractions.Where
                        (
                            a => a.Rating <= attractionsMaxRating
                            && a.Rating >= attractionsMinRating
                        ).ToArray()
                    }).ToArray()
                });
            }

            return query;
        }

        public async Task<CountryModel[]> GetCountries(
            bool includeCities = false,
            bool includeTravelRestrictions = false,
            bool includeAttractions = false,
            int attractionsMinRating = 0,
            int attractionsMaxRating = 5)
        {
            _logger.LogInformation("Getting Countries");

            IQueryable<CountryModel> query = _travelAPIContext.Countries
                .Include(i => i.CountryInfo);

            query = CountryQuery(includeCities, includeTravelRestrictions, includeAttractions, attractionsMinRating, attractionsMaxRating, query);

            query = query.OrderBy(c => c.Name);
            return await query.ToArrayAsync();
        }

        public async Task<CountryModel> GetCountryByName(
            string name, 
            bool includeCities = false, 
            bool includeTravelRestrictions = false, 
            bool includeAttractions = false, 
            int attractionsMinRating = 0, 
            int attractionsMaxRating = 5)
        {
            _logger.LogInformation($"Getting Country named '{name}'");

            IQueryable<CountryModel> query = _travelAPIContext
                .Countries.Where(c => c.Name.Contains(name))
                .Include(i => i.CountryInfo);

            query = CountryQuery(includeCities, includeTravelRestrictions, includeAttractions, attractionsMinRating, attractionsMaxRating, query);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<CountryModel> GetCountryById(
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

            query = CountryQuery(includeCities, includeTravelRestrictions, includeAttractions, attractionsMinRating, attractionsMaxRating, query);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<CountryModel[]> GetCountriesByRightHandTraffic(
            bool isRightHandTraffic = false,
            bool includeCities = false,
            bool includeTravelRestrictions = false,
            bool includeAttractions = false,
            int attractionsMinRating = 0,
            int attractionsMaxRating = 5)
        {
            _logger.LogInformation($"Getting Countries based on rightHandTraffic: {isRightHandTraffic}");

            IQueryable<CountryModel> query = _travelAPIContext
                .Countries.Where(c => c.CountryInfo.RightHandTraffic == true)
                .Include(i => i.CountryInfo);

            query = CountryQuery(includeCities, includeTravelRestrictions, includeAttractions, attractionsMinRating, attractionsMaxRating, query);

            query = query.OrderBy(e => e.Name);
            return await query.ToArrayAsync();
        }

        public async Task<CountryModel[]> GetCountriesByLanguage(
            string language,
            bool includeCities = false,
            bool includeTravelRestrictions = false,
            bool includeAttractions = false,
            int attractionsMinRating = 0,
            int attractionsMaxRating = 5)
        {
            _logger.LogInformation($"Getting Countries based on language: {language}");

            IQueryable<CountryModel> query = _travelAPIContext
                .Countries.Where(c => c.CountryInfo.Language.Contains(language))
                .Include(i => i.CountryInfo);

            query = CountryQuery(includeCities, includeTravelRestrictions, includeAttractions, attractionsMinRating, attractionsMaxRating, query);

            query = query.OrderBy(e => e.Name);
            return await query.ToArrayAsync();
        }
    }
}
