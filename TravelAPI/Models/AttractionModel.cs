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
<<<<<<< Updated upstream
        public bool IsChildfriendly { get; set; }
=======
        public bool IsChildFriendly { get; set; }
        public string Information { get; set; }
>>>>>>> Stashed changes
        public int Rating { get; set; }
        public CityModel City { get; private set; }
    }
}
