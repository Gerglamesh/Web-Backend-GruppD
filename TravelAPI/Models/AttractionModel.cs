using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TravelAPI.Models
{
    public class AttractionModel
    {
        //Props
        [Key]
        public int AttractionId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public bool IsChildFriendly { get; set; }
        public string Information { get; set; }
        public int Rating { get; set; }

        //Relationships
        public CityModel City { get; set; }
    }
}
