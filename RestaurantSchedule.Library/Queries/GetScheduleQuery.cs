using MediatR;
using RestaurantSchedule.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSchedule.Library.Queries
{
    public record GetScheduleQuery() : IRequest<object>;
   
}
