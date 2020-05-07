using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TravelAPI.Models
{
    public class AttractionModel
    {
        [Key]
        public string Name { get; set; }
        public string Location { get; set; }
        public bool IsChildfriendly { get; set; }
        public string Information { get; set; }
        public int Rating { get; set; }

        public CityModel City { get; private set; }
    }
}
