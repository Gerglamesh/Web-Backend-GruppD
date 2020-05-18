using System.ComponentModel.DataAnnotations;

namespace TravelAPI.Models
{
    public class CountryInfoModel
    {
        [Key]
        public int CountryInfoId { get; set; }
        public int Population { get; set; }
        public string Governance { get; set; }
        public int BNP { get; set; }
        public string CapitalCity { get; set; }
        public int Area { get; set; }
        public string TimeZone { get; set; }
        public string NationalDay { get; set; }
        public bool RightHandTraffic { get; set; }
        public string Language { get; set; }
    }
}
