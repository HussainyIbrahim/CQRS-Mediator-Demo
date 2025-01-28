using System.Text.Json;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace CQRS_MidatR_API_Demo_DotNet5.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RedisController : ControllerBase
    {
        private readonly IDistributedCache _cache;
        public RedisController(IDistributedCache cache)
        {
            _cache = cache;
        }
        [HttpGet]
        public async Task<IActionResult> GetData(string id)
        {
            string cacheKey = $"data_{id}";
            string cachedData = await _cache.GetStringAsync(cacheKey);

            if (!string.IsNullOrEmpty(cachedData))
            {
                return Ok(new { Source = "Cache", Data = JsonSerializer.Deserialize<string>(cachedData) });
            }

            // Simulate data retrieval (e.g., from a database)
            string data = $"Data for ID {id} retrieved at {DateTime.UtcNow}";

            // Cache the data for 60 seconds
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60)
            };

            await _cache.SetStringAsync(cacheKey, JsonSerializer.Serialize(data), options);

            return Ok(new { Source = "Database", Data = data });
        }
        [HttpDelete]
        public async Task<IActionResult> ClearCache(string id)
        {
            string cacheKey = $"data_{id}";
            await _cache.RemoveAsync(cacheKey);

            return Ok(new { Message = $"Cache cleared for ID {id}" });
        }

    }
}
