using System.ComponentModel.DataAnnotations;


namespace TravelAPI.Models
{
    public class CityModel
    {
        [Key]
        public string Name { get; private set; }
        public CountryModel Country { get; private set; }
        public  AttractionModel Attraction { get; private set; }


    }

        
}
