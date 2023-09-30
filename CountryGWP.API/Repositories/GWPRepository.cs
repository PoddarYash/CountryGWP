using CountryGWP.API.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;

namespace CountryGWP.API.Repositories
{
    public class GWPRepository : IGWPRepository
    {
        private readonly ApplicationDbContext _DbContext;

        private static readonly ConcurrentDictionary<string, decimal> _cache = new();
        private static readonly object _cacheLock = new();

        public GWPRepository(ApplicationDbContext dbContext) 
        {
            _DbContext = dbContext;
        }

        public async Task<Dictionary<string, decimal>> GetAverageGwpAsync(string country, List<string> lobs)
        {
            var results = new Dictionary<string, decimal>();

            foreach(var lob in lobs)
            {
                var key = $"{country}_{lob}";

                // Check if the item is in the cache
                if (_cache.TryGetValue(key, out var cachedEntity))
                {
                    results.Add(lob, cachedEntity);
                }
            }

            lobs.RemoveAll(_ => results.Keys.Contains(_));

            if (!lobs.Any())
                return results;

            // If not in cache, fetch it from the database or data source
            decimal defaultValue = 0;

            var remainingResults = await _DbContext.GWPsByCountry
                .Where(_ => _.Country == country && lobs.Contains(_.LineOfBusiness))
                .ToDictionaryAsync(
                    _ => _.LineOfBusiness,
                    _ => (_.Y2008 ?? defaultValue + _.Y2009 ?? defaultValue + _.Y2010 ?? defaultValue + _.Y2011 ?? defaultValue + _.Y2012 ?? defaultValue + _.Y2013 ?? defaultValue + _.Y2014 ?? defaultValue + _.Y2015 ?? defaultValue) / 8
                );

            // Cache the fetched item for future requests
            if (remainingResults.Any())
            {
                lock (_cacheLock)
                {
                    foreach(var (lob, value) in remainingResults)
                    {
                        var key = $"{country}_{lob}";

                        if (!_cache.ContainsKey(key)) // Double-check to prevent race conditions
                        {
                            _cache.TryAdd(key, value);
                        }
                    }
                }

                foreach(var item in remainingResults)
                {
                    results.Add(item.Key, item.Value);
                }
            }            

            return results;
        }
    }
}
