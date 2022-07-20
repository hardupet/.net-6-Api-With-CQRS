using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using RestaurantSchedule.Library.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSchedule.Library.DataAccess
{
    public class DataAccess : IDataAccess
    {
        private readonly IMemoryCache _memoryCache;

        public DataAccess(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public WeeklyScheduleResponse AddSchedule(WeeklySchedule weeklySchedule)
        {

            WeeklyScheduleResponse weeklyScheduleResponse = new WeeklyScheduleResponse();
            weeklyScheduleResponse.Monday = GetDaySchedule(weeklySchedule, "Monday", weeklyScheduleResponse);
            weeklyScheduleResponse.Tuesday = GetDaySchedule(weeklySchedule, "Tuesday", weeklyScheduleResponse);
            weeklyScheduleResponse.Wednesday = GetDaySchedule(weeklySchedule, "Wednesday", weeklyScheduleResponse);
            weeklyScheduleResponse.Thursday = GetDaySchedule(weeklySchedule, "Thursday", weeklyScheduleResponse);
            weeklyScheduleResponse.Friday = GetDaySchedule(weeklySchedule, "Friday", weeklyScheduleResponse);
            weeklyScheduleResponse.Saturday = GetDaySchedule(weeklySchedule, "Saturday", weeklyScheduleResponse);
            weeklyScheduleResponse.Sunday = GetDaySchedule(weeklySchedule, "Sunday", weeklyScheduleResponse);

            var cacheKey = "cacheShedule";
            var cacheExpiryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddDays(7),
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromDays(7)
            };
            _memoryCache.Set(cacheKey, weeklyScheduleResponse, cacheExpiryOptions);

            return weeklyScheduleResponse;
        }

        public object GetSchedule(string cacheKey)
        {
            
            if (_memoryCache.Get<WeeklyScheduleResponse>(cacheKey) == null)
            {
                return "Please add a valid Resturant Schedule before you can get the Schedule";
            }
            var result = _memoryCache.Get<WeeklyScheduleResponse>(cacheKey);
            return result;
        }

        public DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }

        public string GetDaySchedule(WeeklySchedule schedule, string day, WeeklyScheduleResponse weeklyScheduleResponse)
        {
            string result = "";
            switch (day)
            {
                case "Monday":
                    if (schedule?.monday?.Count > 0)
                    {
                        var count = 0;
                        foreach (var monday in schedule.monday)
                        {
                            var date = UnixTimeStampToDateTime(monday.value);
                            if (count == 0 && monday.type == "close")
                            {
                                weeklyScheduleResponse.Sunday = weeklyScheduleResponse.Sunday + "-" + date.ToString("hh", CultureInfo.InvariantCulture) + date.ToString("tt", CultureInfo.InvariantCulture);
                            }
                            else
                            {
                                if (monday.type == "open")
                                {

                                    result = result + " " + date.ToString("hh", CultureInfo.InvariantCulture) + date.ToString("tt", CultureInfo.InvariantCulture);
                                }
                                else
                                {
                                    result = result + "-" + date.ToString("hh", CultureInfo.InvariantCulture) + date.ToString("tt", CultureInfo.InvariantCulture);
                                }
                            }   
                            count++;
                        };
                    }
                    else
                    {
                        result = result + "Closed";
                    }
                    break;
                case "Tuesday":
                    if (schedule?.tuesday?.Count > 0)
                    {
                        var count = 0;
                        foreach (var tuesday in schedule.tuesday)
                        {
                            var date = UnixTimeStampToDateTime(tuesday.value);
                            if (count == 0 && tuesday.type == "close")
                            {
                                weeklyScheduleResponse.Monday = weeklyScheduleResponse.Monday + "-" + date.ToString("hh", CultureInfo.InvariantCulture) + date.ToString("tt", CultureInfo.InvariantCulture);
                            }
                            else
                            {
                                if (tuesday.type == "open")
                                {

                                    result = result + " " + date.ToString("hh", CultureInfo.InvariantCulture) + date.ToString("tt", CultureInfo.InvariantCulture);
                                }
                                else
                                {
                                    result = result + "-" + date.ToString("hh", CultureInfo.InvariantCulture) + date.ToString("tt", CultureInfo.InvariantCulture);
                                }
                            }
                            count++;
                        };
                    }
                    else
                    {
                        result = result + "Closed";
                    }
                    break;
                case "Wednesday":
                    if (schedule?.wednesday?.Count > 0)
                    {
                        var count = 0;
                        foreach (var wednesday in schedule.wednesday)
                        {
                            var date = UnixTimeStampToDateTime(wednesday.value);
                            if (count == 0 && wednesday.type == "close")
                            {
                                weeklyScheduleResponse.Tuesday = weeklyScheduleResponse.Tuesday + "-" + date.ToString("hh", CultureInfo.InvariantCulture) + date.ToString("tt", CultureInfo.InvariantCulture);
                            }
                            else
                            {
                                if (wednesday.type == "open")
                                {

                                    result = result + " " + date.ToString("hh", CultureInfo.InvariantCulture) + date.ToString("tt", CultureInfo.InvariantCulture);
                                }
                                else
                                {
                                    result = result + "-" + date.ToString("hh", CultureInfo.InvariantCulture) + date.ToString("tt", CultureInfo.InvariantCulture);
                                }
                            }
                            count++;
                        };
                    }
                    else
                    {
                        result = result + "Closed";
                    }
                    break;
                case "Thursday":
                    if (schedule?.thursday?.Count > 0)
                    {
                        var count = 0;
                        foreach (var thursday in schedule.thursday)
                        {
                            var date = UnixTimeStampToDateTime(thursday.value);
                            if (count == 0 && thursday.type == "close")
                            {
                                weeklyScheduleResponse.Wednesday = weeklyScheduleResponse.Wednesday + "-" + date.ToString("hh", CultureInfo.InvariantCulture) + date.ToString("tt", CultureInfo.InvariantCulture);
                            }
                            else
                            {
                                if (thursday.type == "open")
                                {

                                    result = result + " " + date.ToString("hh", CultureInfo.InvariantCulture) + date.ToString("tt", CultureInfo.InvariantCulture);
                                }
                                else
                                {
                                    result = result + "-" + date.ToString("hh", CultureInfo.InvariantCulture) + date.ToString("tt", CultureInfo.InvariantCulture);
                                }
                            }
                            count++;
                        };
                    }
                    else
                    {
                        result = result + "Closed";
                    }
                    break;
                case "Friday":
                    if (schedule?.friday?.Count > 0)
                    {
                        var count = 0;
                        foreach (var friday in schedule.friday)
                        {
                            var date = UnixTimeStampToDateTime(friday.value);
                            if (count == 0 && friday.type == "close")
                            {
                                weeklyScheduleResponse.Thursday = weeklyScheduleResponse.Thursday + "-" + date.ToString("hh", CultureInfo.InvariantCulture) + date.ToString("tt", CultureInfo.InvariantCulture);
                            }
                            else
                            {
                                if (friday.type == "open")
                                {

                                    result = result + " " + date.ToString("hh", CultureInfo.InvariantCulture) + date.ToString("tt", CultureInfo.InvariantCulture);
                                }
                                else
                                {
                                    result = result + "-" + date.ToString("hh", CultureInfo.InvariantCulture) + date.ToString("tt", CultureInfo.InvariantCulture);
                                }
                            }
                            count++;
                        };
                    }
                    else
                    {
                        result = result + "Closed";
                    }
                    break;
                case "Saturday":
                    if (schedule?.saturday?.Count > 0)
                    {
                        var count = 0;
                        foreach (var saturday in schedule.saturday)
                        {
                            var date = UnixTimeStampToDateTime(saturday.value);
                            if (count == 0 && saturday.type == "close")
                            {
                                weeklyScheduleResponse.Friday = weeklyScheduleResponse.Friday + "-" + date.ToString("hh", CultureInfo.InvariantCulture) + date.ToString("tt", CultureInfo.InvariantCulture);
                            }
                            else
                            {
                                if (saturday.type == "open")
                                {

                                    result = result + " " + date.ToString("hh", CultureInfo.InvariantCulture) + date.ToString("tt", CultureInfo.InvariantCulture);
                                }
                                else
                                {
                                    result = result + "-" + date.ToString("hh", CultureInfo.InvariantCulture) + date.ToString("tt", CultureInfo.InvariantCulture);
                                }
                            }
                            count++;
                        };
                    }
                    else
                    {
                        result = result + "Closed";
                    }
                    break;
                case "Sunday":
                    if (schedule?.sunday?.Count > 0)
                    {
                        var count = 0;
                        foreach (var sunday in schedule.sunday)
                        {
                            var date = UnixTimeStampToDateTime(sunday.value);
                            if (count == 0 && sunday.type == "close")
                            {
                                weeklyScheduleResponse.Saturday = weeklyScheduleResponse.Saturday + "-" + date.ToString("hh", CultureInfo.InvariantCulture) + date.ToString("tt", CultureInfo.InvariantCulture);
                            }
                            else
                            {
                                if (sunday.type == "open")
                                {

                                    result = result + " " + date.ToString("hh", CultureInfo.InvariantCulture) + date.ToString("tt", CultureInfo.InvariantCulture);
                                }
                                else
                                {
                                    result = result + "-" + date.ToString("hh", CultureInfo.InvariantCulture) + date.ToString("tt", CultureInfo.InvariantCulture);
                                }
                            }
                            count++;
                        };
                    }
                    else
                    {
                        result = result + "Closed";
                    }
                    break;

                default:
                    break;

            }
            return result;
        }
    }
}
