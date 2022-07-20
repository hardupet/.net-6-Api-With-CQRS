using MediatR;
using RestaurantSchedule.Library.DataAccess;
using RestaurantSchedule.Library.Models;
using RestaurantSchedule.Library.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSchedule.Library.Handlers
{
    public class GetScheduleHandler : IRequestHandler<GetScheduleQuery, object>
    {
        private readonly IDataAccess _dataAccess;

        public GetScheduleHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public  Task<object> Handle(GetScheduleQuery request,CancellationToken cancellationToken)
        {
            var cacheKey = "cacheShedule";
            var sch =  _dataAccess.GetSchedule(cacheKey);
            return Task.FromResult(sch);

        }
    }
}
