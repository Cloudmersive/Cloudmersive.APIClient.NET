using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudmersiveClient.Validation
{
    public class GeolocateIPResponse
    {
        public string CountryCode;
        public string CountryName;
        public string City;
        public string RegionCode;
        public string RegionName;
        public string ZipCode;
        public string TimezoneStandardName;
        public decimal Latitude;
        public decimal Longitude;
    }
}
