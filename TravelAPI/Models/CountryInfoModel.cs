using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAPI.Models
{
    public class CountryInfoModel
    {
        [Key]
        public int CountryInfoModelID { get; set; }
        public int Population { get; set; }
        public string Governance { get; set; }
        public int BNP { get; set; }
        public string CapitalCity { get; set; }
        public int Area { get; set; }
        public DateTime TimeZone { get; set; }
        public DateTime NationalDay { get; set; }
        public bool RightHandTraffic { get; set; }
        public string Language { get; set; }
    }
}
