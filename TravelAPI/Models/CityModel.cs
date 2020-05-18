using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAPI.Models
{
    public class CityModel
    {
        [Key]
        public int CityId { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public CountryModel Country { get; set; }
        public ICollection<AttractionModel> Attractions { get; set; }
    }
}
