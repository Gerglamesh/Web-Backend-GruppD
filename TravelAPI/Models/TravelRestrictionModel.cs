using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAPI.Models
{
    public class TravelRestrictionModel
    {
        public class CountryModel
        {
            [Key]
            public int CountryId { get; private set; }
            public bool WorkTravelAllowed { get; private set; }


            public ICollection<CityModel> Cities { get; set; }
            public CountryInfoModel CountryInfo { get; set; }
        }
    }
}
