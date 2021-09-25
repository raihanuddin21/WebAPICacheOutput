using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Http;
using WebApi.OutputCache.V2;
using WebAPICacheOutput.Models;

namespace WebAPICacheOutput.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        //https://github.com/filipw/Strathweb.CacheOutput

        [CacheOutput(ClientTimeSpan = 100, ServerTimeSpan = 100)]
        [HttpGet]
        [Route("GetUser/{id}/{age}")]
        public IHttpActionResult GetUser(int id, int age)
        {
            List<UserModel> users = new List<UserModel>();
            for (int i = 0; i < 100; i++)
            {
                var user = new UserModel()
                {
                    Id = new Guid().ToString(),
                    Name = new Guid().ToString(),
                    Address = new Guid().ToString()
                };
                users.Add(user);
            }
            return Ok(users);
        }
    }
}


/*

public class MemoryCacher
{
    public object GetValue(string key)
    {
        MemoryCache memoryCache = MemoryCache.Default;
        return memoryCache.Get(key);
    }

    public bool Add(string key, object value, DateTimeOffset absExpiration)
    {
        MemoryCache memoryCache = MemoryCache.Default;
        return memoryCache.Add(key, value, absExpiration);
    }

    public void Delete(string key)
    {
        MemoryCache memoryCache = MemoryCache.Default;
        if (memoryCache.Contains(key))
        {
            memoryCache.Remove(key);
        }
    }
}
------------------------------------------------------------------------
When you want to cache something:
memCacher.Add(token, userId, DateTimeOffset.UtcNow.AddHours(1));
------------------------------------------------------------------------
And to get something from the cache:
var result = memCacher.GetValue(token);
------------------------------------------------------------------------
var result = memCacher.GetValue(token);
if (result == null)
{
 // for example get token from database and put grabbed token
 // again in memCacher Cache
}
*/
