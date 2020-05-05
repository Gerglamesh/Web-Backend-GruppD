using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAPI.Models
{
    public class CountryModel
    {
        //Props
        [Key]
        public int CountryId { get; private set; }
        public string Name { get; private set; }

        //Relationships
        public List<CityModel> Cities { get; set; }
        public virtual CountryInfoModel CountryInfo { get; set; }

    }
}
