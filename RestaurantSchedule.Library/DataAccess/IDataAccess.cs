using RestaurantSchedule.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSchedule.Library.DataAccess
{
    public interface IDataAccess
    {
        object GetSchedule(string cacheKey);
        WeeklyScheduleResponse AddSchedule(WeeklySchedule weeklySchedule);

        DateTime UnixTimeStampToDateTime(double unixTimeStamp);
    }
}
