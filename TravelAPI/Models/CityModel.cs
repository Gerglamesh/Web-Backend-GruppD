using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace TravelAPI.Models
{
    public class CityModel
    {
        [Key]
        public int CityId { get; set; }
        public string Name { get; private set; }

        public int CountryId { get; set; }
        public CountryModel Country { get; private set; }
        public ICollection<AttractionModel> Attractions { get; private set; }


    }
}
