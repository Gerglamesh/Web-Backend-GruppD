using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey ("CityId")]
        public int CityId { get; set; }
        public CityModel City { get; set; }
    }
}
