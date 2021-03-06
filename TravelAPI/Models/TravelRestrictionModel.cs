﻿using System.ComponentModel.DataAnnotations;

namespace TravelAPI.Models
{
    public class TravelRestrictionModel
    {        
        [Key]
        public int TravelRestrictionId { get; set; }
        public bool IsWorkTravelAllowed { get; set; }
        public bool IsTourismAllowed { get; set; }
        public bool IsImmigrationAllowed { get; set; }
        public bool IsCitizenshipAllowed { get; set; }
        public bool IsFamilyVisitAllowed { get; set; }
        public bool IsVisaNeeded { get; set; }
        public int RiskLevel { get; set; }
    }
}
