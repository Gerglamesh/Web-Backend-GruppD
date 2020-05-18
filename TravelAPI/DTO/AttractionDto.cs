using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TravelAPI.Models;

namespace TravelAPI.DTO
{
    public class AttractionDto
    {
        [Required] public int AttractionId { get; set; }
        [Required] public string Name { get; set; }        
        public string Location { get; set; }        
        public bool IsChildFriendly { get; set; }        
        public string Information { get; set; }       
        public int Rating { get; set; }

        //Relationships
        public CityModel City { get; set; }
    }
}
