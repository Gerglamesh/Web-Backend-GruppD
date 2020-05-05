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

        public CountryInfoModel(int population, string governance, int bnp, string capitalcity, int area, DateTime timeZone, DateTime nationalDay, bool rightHandTraffic, string language)
        {
            this.Population = population;
            this.Governance = governance;
            this.BNP = bnp;
            this.CapitalCity = capitalcity;
            this.Area = area;
            this.TimeZone = timeZone;
            this.NationalDay = nationalDay;
            this.RightHandTraffic = rightHandTraffic;
            this.Language = language;
        }
    }
}
