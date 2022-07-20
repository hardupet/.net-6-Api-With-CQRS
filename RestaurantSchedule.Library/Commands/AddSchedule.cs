using MediatR;
using Microsoft.Extensions.Caching.Memory;
using RestaurantSchedule.Library.DataAccess;
using RestaurantSchedule.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSchedule.Library.Commands
{
  
        public record AddSchedule(WeeklySchedule WeeklySchedule) : IRequest<WeeklyScheduleResponse>;

        
    
}
