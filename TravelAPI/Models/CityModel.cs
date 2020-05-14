using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace TravelAPI.Models
{
    public class CityModel
    {
        [Key]
        public int CityId { get; set; }
        public string Name { get; set; }

        
        public CountryModel Country { get; set; }
        public ICollection<AttractionModel> Attractions { get; set; }
    }
}
