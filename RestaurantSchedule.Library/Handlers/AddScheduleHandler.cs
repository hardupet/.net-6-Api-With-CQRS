using MediatR;
using Microsoft.Extensions.Caching.Memory;
using RestaurantSchedule.Library.Commands;
using RestaurantSchedule.Library.DataAccess;
using RestaurantSchedule.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RestaurantSchedule.Library.Commands.AddSchedule;

namespace RestaurantSchedule.Library.Handlers
{
    public class AddScheduleHandler : IRequestHandler<AddSchedule, WeeklyScheduleResponse>
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IDataAccess _dataAccess;

        public AddScheduleHandler(IDataAccess dataAccess, IMemoryCache memoryCache)
        {
            _dataAccess = dataAccess;
            _memoryCache = memoryCache;
        }
        public async Task<WeeklyScheduleResponse> Handle(AddSchedule request, CancellationToken cancellationToken)
        {
            //var cacheKey = "cacheShedule";
            //if (!_memoryCache.TryGetValue(cacheKey, out WeeklySchedule list))
            //{
            //    var cacheExpiryOptions = new MemoryCacheEntryOptions
            //    {
            //        AbsoluteExpiration = DateTime.Now.AddDays(7),
            //        Priority = CacheItemPriority.High,
            //        SlidingExpiration = TimeSpan.FromDays(7)
            //    };
            //    _memoryCache.Set(cacheKey, list, cacheExpiryOptions);
            //}

            var aa = _dataAccess.AddSchedule(request.WeeklySchedule);
            return await Task.FromResult(aa);
        }
    }
}
