using System;
using SQLite.Net.Attributes;

namespace OCR.Core.Models
{
    [Table("deviceLocations")]
    public class DeviceLocationModel : BaseModel
    {
        public double Altitude { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double Course { get; set; }
        public double Speed { get; set; }
        public DateTime ReportTime { get; set; }
        public string DataMessage { get; set; }
        public string TDID { get; set; }
    }
}
