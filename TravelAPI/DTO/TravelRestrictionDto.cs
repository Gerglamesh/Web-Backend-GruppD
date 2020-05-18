using System.ComponentModel.DataAnnotations;

namespace TravelAPI.DTO
{
    public class TravelRestrictionDto
    {
        [Required]
        public int TravelRestrictionId { get; set; }
        [Required]
        public bool IsWorkTravelAllowed { get; set; }
        [Required]
        public bool IsTourismAllowed { get; set; }
        [Required]
        public bool IsImmigrationAllowed { get; set; }
        [Required]
        public bool IsCitizenshipAllowed { get; set; }
        [Required]
        public bool IsFamilyVisitAllowed { get; set; }
        [Required]
        public bool IsVisaNeeded { get; set; }
        [Required]
        public int RiskLevel { get; set; }
    }
}
