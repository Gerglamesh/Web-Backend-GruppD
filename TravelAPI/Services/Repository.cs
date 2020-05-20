using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAPI.Services
{
    public class Repository : IRepository
    {
        protected readonly TravelAPIContext _travelAPIContext;
        protected readonly ILogger<Repository> _logger;

        public Repository(TravelAPIContext context, ILogger<Repository> logger)
        {
            _travelAPIContext = context;
            _logger = logger;
        }

        public void Add<T>(T entity) where T : class
        {
            _logger.LogInformation($"Adding object of type {entity.GetType()}");
            _travelAPIContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _logger.LogInformation($"Deleting object of type {entity.GetType()}");
            _travelAPIContext.Remove(entity);
        }

        public async Task<bool> Save()
        {
            _logger.LogInformation("Saving changes");
            return (await _travelAPIContext.SaveChangesAsync()) >= 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _logger.LogInformation($"Updating object of type {entity.GetType()}");
            _travelAPIContext.Update(entity);
        }
    }
}
