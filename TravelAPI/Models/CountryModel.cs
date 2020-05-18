using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAPI.Models
{    public class CountryModel
    {
        //Props
        [Key]
        public int CountryId { get; set; }
        public string Name { get; set; }

        //Relationships
        [ForeignKey("CountryInfoId")]
        public int CountryInfoId { get; set; }
        public CountryInfoModel CountryInfo { get; set; }        

        [ForeignKey("TravelRestrictionId")]
        public int TravelRestrictionId { get; set; }
        public TravelRestrictionModel TravelRestriction { get; set; }

        public ICollection<CityModel> Cities { get; set; }
    }
}
