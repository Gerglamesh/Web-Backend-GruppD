using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAPI.DTO
{
    public class CountryInfoDto
    {
        [Required] public int CountryInfoId { get; set; }
        [Required] public int Population { get; set; } 
        [Required] public string Governance { get; set; }
        [Required] public int BNP { get; set; }
        [Required] public string CapitalCity { get; set; }
        [Required] public int Area { get; set; }
        [Required] public string TimeZone { get; set; }
        [Required] public string NationalDay { get; set; }
        [Required] public bool RightHandTraffic { get; set; }
        [Required] public string Language { get; set; }
    }
}