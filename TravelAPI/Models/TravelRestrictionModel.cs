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
        public int TravelRestrictionID { get; private set; }
        public bool WorkTravelAllowed { get; private set; }
        public bool TourismAllowed { get; private set; }
        public bool ImmigrationAllowed { get; private set; }
        public bool CitizenshipAllowed { get; private set; }
        public bool FamilyVisitAllowed { get; private set; }
        public bool IsVisaNeeded { get; private set; }
        public int RiskLevel { get; private set; }

        public CountryModel Country { get; set; }
    }
}
