using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSchedule.Library.Models
{
    public class WeeklySchedule
    {
        public List<Monday>? monday { get; set; }
        public List<Tuesday>? tuesday { get; set; }
        public List<Wednesday>? wednesday { get; set; }
        public List<Thursday>? thursday { get; set; }
        public List<Friday>? friday { get; set; }
        public List<Saturday>? saturday { get; set; }
        public List<Sunday>? sunday { get; set; }
    }

    public class Monday
    {
        public string type { get; set; }
        public int value { get; set; }
    }
    public class Tuesday
    {
        public string type { get; set; }
        public int value { get; set; }
    }
    public class Wednesday
    {
        public string type { get; set; }
        public int value { get; set; }
    }
    public class Thursday
    {
        public string type { get; set; }
        public int value { get; set; }
    }
    public class Friday
    {
        public string type { get; set; }
        public int value { get; set; }
    }
    public class Saturday
    {
        public string type { get; set; }
        public int value { get; set; }
    }
    public class Sunday
    {
        public string type { get; set; }
        public int value { get; set; }
    }
}


