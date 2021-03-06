﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using TravelAPI.Models;

namespace TravelAPI.Services
{
    public class CountryRepo : Repository, ICountryRepo
    {
        public CountryRepo(TravelAPIContext travelAPIContext, ILogger<CountryRepo> logger) : base (travelAPIContext, logger)
        {}

        private static IQueryable<CountryModel> CountryQuery(IQueryable<CountryModel> query, bool includeCities, bool includeTravelRestrictions, bool isRightHandTraffic = false, bool isLeftHandTraffic = false)
        {
             if (includeCities)
            {
                query = query.Include(c => c.Cities);
            }

            if (includeTravelRestrictions)
            {
                query = query.Include(c => c.TravelRestriction);
            }

            if (isRightHandTraffic)
            {
                query = query.Where(c => c.CountryInfo.RightHandTraffic == true);
            }

            else if (isLeftHandTraffic)
            {
                query = query.Where(c => c.CountryInfo.RightHandTraffic == false);
            }

            else
            {
                return query;
            }

            return query;
        }

        public async Task<CountryModel[]> GetCountries(
            bool includeCities = false,
            bool includeTravelRestrictions = false,
            bool isRightHandTraffic = false,
            bool isLeftHandTraffic = false,
            string language = "")
        {
            _logger.LogInformation("Getting Countries");

            IQueryable<CountryModel> query = _travelAPIContext
                .Countries.Where(c => c.CountryInfo.Language.Contains(language))
                .Include(i => i.CountryInfo);

            query = CountryQuery(query, includeCities, includeTravelRestrictions, isRightHandTraffic, isLeftHandTraffic);

            query = query.OrderBy(c => c.Name);
            return await query.ToArrayAsync();
        }

        public async Task<CountryModel[]> GetCountryByName(
            string name, 
            bool includeCities = false,
            bool includeTravelRestrictions = false)
        {
            _logger.LogInformation($"Getting Country named '{name}'");

            IQueryable<CountryModel> query = _travelAPIContext
                .Countries.Where(c => c.Name.Contains(name))
                .Include(i => i.CountryInfo);

            query = CountryQuery(query, includeCities, includeTravelRestrictions);

            return await query.ToArrayAsync();
        }

        public async Task<CountryModel> GetCountryById(
            int id, 
            bool includeCities = false,
            bool includeTravelRestrictions = false)
        {
            _logger.LogInformation($"Getting Country with ID {id}");

            IQueryable<CountryModel> query = _travelAPIContext
                .Countries.Where(c => c.CountryId == id)
                .Include(i => i.CountryInfo);

            query = CountryQuery(query, includeCities, includeTravelRestrictions);

            return await query.SingleOrDefaultAsync();
        }
    }
}
