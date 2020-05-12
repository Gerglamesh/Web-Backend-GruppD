using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAPI.Models
{
    public class TravelRestrictionModel
    {
        
        [Key]
        public int TravelRestrictionId { get; private set; }
        public bool IsWorkTravelAllowed { get; private set; }
        public bool IsTourismAllowed { get; private set; }
        public bool IsImmigrationAllowed { get; private set; }
        public bool IsCitizenshipAllowed { get; private set; }
        public bool IsFamilyVisitAllowed { get; private set; }
        public bool IsVisaNeeded { get; private set; }
        public int RiskLevel { get; private set; }

        public CountryModel Country { get; set; }
    }
}
