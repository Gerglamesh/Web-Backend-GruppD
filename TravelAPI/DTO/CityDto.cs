using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TravelAPI.Models;

namespace TravelAPI.DTO
{
    public class CityDto
    {
        [Required]
        public int CityId { get; set; }
       [Required]
        public string Name { get; set; }
        public int Population { get; set; }


        public CountryModel Country { get; set; }
        public ICollection<AttractionModel> Attractions { get; set; }
    }
}
