using EngineClasses;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using TravelAPI.Models;

namespace TravelAPI
{
    public class TravelAPIContext : DbContext
    {
        //TODO: Do we need to change our setup to take advantage of this? 
        //We have another solution going right now (See line 32)
        private readonly IConfiguration _travelConfig;

        public TravelAPIContext() {}

        public TravelAPIContext (IConfiguration config, DbContextOptions options) : base(options)
        {
            _travelConfig = config;
        }

        public virtual DbSet<CountryModel> Countries { get; set; }
        public virtual DbSet<CountryInfoModel> CountryInfo { get; set; }
        public virtual DbSet<AttractionModel> Attractions { get; set; }
        public virtual DbSet<CityModel> Cities { get; set; }
        public virtual DbSet<TravelRestrictionModel> TravelRestrictions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionSetup.GetConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryModel>()
            .HasData(new
            {
                CountryId = 1,
                Name = "Afghanistan",
                CountryInfoId = 1,
                TravelRestrictionId = 1
            },

            new
            {
                CountryId = 2,
                Name = "Serbia",
                CountryInfoId = 2,
                TravelRestrictionId = 2
            },

            new
            {
                CountryId = 3,
                Name = "Japan",
                CountryInfoId = 3,
                TravelRestrictionId = 3
            },

            new
            {
                CountryId = 4,
                Name = "Uganda",
                CountryInfoId = 4,
                TravelRestrictionId = 4
            },

            new
            {
                CountryId = 5,
                Name = "Barbados",
                CountryInfoId = 5,
                TravelRestrictionId = 5
            },

            new
            {
                CountryId = 6,
                Name = "Canada",
                CountryInfoId = 6,
                TravelRestrictionId = 6
            },

            new
            {
                CountryId = 7,
                Name = "Brazil",
                CountryInfoId = 7,
                TravelRestrictionId = 7
            },

            new
            {
                CountryId = 8,
                Name = "New Zealand",
                CountryInfoId = 8,
                TravelRestrictionId = 8
            });

            modelBuilder.Entity<TravelRestrictionModel>()
            .HasData(new
            {
                TravelRestrictionId = 1,
                IsWorkTravelAllowed = true,
                IsTourismAllowed = false,
                IsImmigrationAllowed = true,
                IsCitizenshipAllowed = true,
                IsFamilyVisitAllowed = true,
                IsVisaNeeded = true,
                RiskLevel = 4
            },
            new
            {
                TravelRestrictionId = 2,
                IsWorkTravelAllowed = false,
                IsTourismAllowed = false,
                IsImmigrationAllowed = false,
                IsCitizenshipAllowed = false,
                IsFamilyVisitAllowed = false,
                IsVisaNeeded = true,
                RiskLevel = 4
            },
            new
            {
                TravelRestrictionId = 3,
                IsWorkTravelAllowed = false,
                IsTourismAllowed = false,
                IsImmigrationAllowed = false,
                IsCitizenshipAllowed = false,
                IsFamilyVisitAllowed = false,
                IsVisaNeeded = false,
                RiskLevel = 3
            },
            new
            {
                TravelRestrictionId = 4,
                IsWorkTravelAllowed = false,
                IsTourismAllowed = false,
                IsImmigrationAllowed = true,
                IsCitizenshipAllowed = false,
                IsFamilyVisitAllowed = false,
                IsVisaNeeded = true,
                RiskLevel = 2
            },
            new
            {
                TravelRestrictionId = 5,
                IsWorkTravelAllowed = true,
                IsTourismAllowed = true,
                IsImmigrationAllowed = true,
                IsCitizenshipAllowed = true,
                IsFamilyVisitAllowed = true,
                IsVisaNeeded = true,
                RiskLevel = 1
            },
            new
            {
                TravelRestrictionId = 6,
                IsWorkTravelAllowed = true,
                IsTourismAllowed = true,
                IsImmigrationAllowed = true,
                IsCitizenshipAllowed = true,
                IsFamilyVisitAllowed = true,
                IsVisaNeeded = true,
                RiskLevel = 3
            },
            new
            {
                TravelRestrictionId = 7,
                IsWorkTravelAllowed = true,
                IsTourismAllowed = true,
                IsImmigrationAllowed = true,
                IsCitizenshipAllowed = true,
                IsFamilyVisitAllowed = true,
                IsVisaNeeded = true,
                RiskLevel = 5
            },
            new
            {
                TravelRestrictionId = 8,
                IsWorkTravelAllowed = true,
                IsTourismAllowed = true,
                IsImmigrationAllowed = false,
                IsCitizenshipAllowed = true,
                IsFamilyVisitAllowed = false,
                IsVisaNeeded = false,
                RiskLevel = 2
            });

            modelBuilder.Entity<CountryInfoModel>()
            .HasData(new
            {
                CountryInfoId = 1,
                Population = 50000,
                Governance = "Islamic Republic",
                CapitalCity = "Kabul",
                BNP = 19360,
                Area = 65200,
                TimeZone = "GMT+4:30",
                NationalDay = "19/08",
                Language = "Dari/Pashtu/Iranian",
                RightHandTraffic = true
            },

            new
            {
                CountryInfoId = 2,
                Population = 80000,
                Governance = "Parliamentary Republic",
                CapitalCity = "Belgrad",
                BNP = 7246,
                Area = 88361,
                TimeZone = "GMT+2",
                NationalDay = "15/02",
                Language = "Serbian",
                RightHandTraffic = true
            },

            new
            {
                CountryInfoId = 3,
                Population = 126244,
                Governance = "Constitutional Monarch",
                CapitalCity = "Tokyo",
                BNP = 39289,
                Area = 377918,
                TimeZone = "GMT+9",
                NationalDay = "11/02",
                Language = "Japanese/Ryukyuan/Ainu/Orok/Evenki/Nivkh",
                RightHandTraffic = false
            },

            new
            {
                CountryInfoId = 4,
                Population = 4272,
                Governance = "Democratic State",
                CapitalCity = "Kampala",
                BNP = 2746,
                Area = 241037,
                TimeZone = "GMT+3",
                NationalDay = "18/05",
                Language = "Bantu/Nilotic/Central Sudanic",
                RightHandTraffic = false
            },

            new
            {
                CountryInfoId = 5,
                Population = 286641,
                Governance = "Monarch",
                CapitalCity = "Bridgetown",
                BNP = 5145,
                Area = 431,
                TimeZone = "GMT-4",
                NationalDay = "30/11",
                Language = "English/Bajan Dialect",
                RightHandTraffic = false
            },

            new
            {
                CountryInfoId = 6,
                Population = 3759,
                Governance = "Constitutional Monarchy",
                CapitalCity = "Ottawa",
                BNP = 1713,
                Area = 9985000,
                TimeZone = "GMT-4",
                NationalDay = "01/07",
                Language = "French/English",
                RightHandTraffic = true
            },

            new
            {
                CountryInfoId = 7,
                Population = 2095,
                Governance = "Democratic Federal Republic",
                CapitalCity = "Brasília",
                BNP = 1869,
                Area = 8516000,
                TimeZone = "GMT-3",
                NationalDay = "07/09",
                Language = "Portuguese",
                RightHandTraffic = true
            },

            new
            {
                CountryInfoId = 8,
                Population = 4886,
                Governance = "Unitary parliamentary constitutional monarchy",
                CapitalCity = "Wellington",
                BNP = 2049,
                Area = 268021,
                TimeZone = "GMT+12",
                NationalDay = "06/02",
                Language = "Maori/English",
                RightHandTraffic = false
            });

            modelBuilder.Entity<CityModel>()
            .HasData(new
            {
                CityId = 1,
                Name = "Kabul",
                Population = 4221532,
                CountryId = 1
            },

            new
            {
                CityId = 2,
                Name = "Balkh",
                Population = 1382200,
                CountryId = 1
            },
            new
            {
                CityId = 3,
                Name = "Kandahar",
                Population = 614118,
                CountryId = 1
            },

            new
            {
                CityId = 4,
                Name = "Belgrade",
                Population = 1397939,
                CountryId = 2
            },

            new
            {
                CityId = 5,
                Name = "Novi Sad",
                Population = 289128,
                CountryId = 2
            },

            new
            {
                CityId = 6,
                Name = "Niš",
                Population = 185987,
                CountryId = 2
            },

            new
            {
                CityId = 7,
                Name = "Tokyo",
                Population = 37435191,
                CountryId = 3
            },

            new
            {
                CityId = 8,
                Name = "Yokohama",
                Population = 3725000,
                CountryId = 3
            },

            new
            {
                CityId = 9,
                Name = "Osaka",
                Population = 2691000,
                CountryId = 3
            },

            new
            {
                CityId = 10,
                Name = "Kampala",
                Population = 1680600,
                CountryId = 4
            },

            new
            {
                CityId = 11,
                Name = "Nansana",
                Population = 365124,
                CountryId = 4
            },

            new
            {
                CityId = 12,
                Name = "Kira",
                Population = 317157,
                CountryId = 4
            },

            new
            {
                CityId = 13,
                Name = "Bridgetown",
                Population = 110000,
                CountryId = 5
            },

            new
            {
                CityId = 14,
                Name = "Speightstown",
                Population = 3634,
                CountryId = 5
            },

            new
            {
                CityId = 15,
                Name = "Oistins",
                Population = 2285,
                CountryId = 5
            },

            new
            {
                CityId = 16,
                Name = "Ottawa",
                Population = 994837,
                CountryId = 6
            },

            new
            {
                CityId = 17,
                Name = "Toronto",
                Population = 2930000,
                CountryId = 6
            },

            new
            {
                CityId = 18,
                Name = "Montreal",
                Population = 1780000,
                CountryId = 6
            },

            new
            {
                CityId = 19,
                Name = "Brasilia",
                Population = 4645943,
                CountryId = 7
            },

            new
            {
                CityId = 20,
                Name = "São Paulo",
                Population = 21846507,
                CountryId = 7
            },

            new
            {
                CityId = 21,
                Name = "Rio de Janeiro",
                Population = 13458075,
                CountryId = 7
            },

            new
            {
                CityId = 22,
                Name = "Auckland",
                Population = 1657000,
                CountryId = 8
            },

            new
            {
                CityId = 23,
                Name = "Christchurch",
                Population = 381500,
                CountryId = 8
            },

            new
            {
                CityId = 24,
                Name = "Wellington",
                Population = 212700,
                CountryId = 8
            });

            modelBuilder.Entity<AttractionModel>()
                .HasData(new
            {
                AttractionId = 1,
                Name = "Buddha Niches",
                Location = "Bamiyan Valley, west of Kabul",
                Information = "The empty niches of the Buddha statues dominate the Bamiyan valley. Carved in the 6th century, the two statues, standing 38m and 55m respectively, were the tallest standing statues of Buddha ever made.",
                IsChildFriendly = true,
                Rating = 4,
                CityId = 1
            },

            new
            {
                AttractionId = 2,
                Name = "Kabul Museum",
                Location = "Kabul",
                Information = "The Kabul Museum was once one of the greatest museums in the world. Its exhibits, ranging from Hellenistic gold coins to Buddhist statuary and Islamic bronzes, testified to Afghanistan’s location at the crossroads of Asia. After years of abuse during the civil war, help from the international community and the peerless dedication of its staff means the museum is slowly rising from the ashes. The museum opened in 1919, and was almost entirely stocked with items excavated in Afghanistan.",
                IsChildFriendly = true,
                Rating = 3,
                CityId = 1
            },
            
            new
            {
                AttractionId = 3,
                Name = "Blue Mosque",
                Location = "Balkh",
                Information = "The Sultan of the Seljuq dynasty, Ahmed Sanjar, built the first known shrine at this location. It was destroyed or hidden under earthen embankment during the invasion of Genghis Khan around 1220. In the 15th century, Timurid Sultan Husayn Bayqarah Mirza built the current Blue Mosque here. It is by far the most important landmark in Mazar-i-Sharif and it is believed that the name of city (Noble Shrine, Grave of Hazrat-i-Ali Sharif) originates from this shrine. ",
                IsChildFriendly = true,
                Rating = 4,
                CityId = 2
            },
            
            new
            { 
                AttractionId = 4,
                Name = "Kalemegdan Fortress",
                Location = "Belgrad",
                Information = "Kalemegdan is the most popular park among Belgraders and for many tourists visiting Belgrade because of the park's numerous winding walking paths, shaded benches, picturesque fountains, statues, historical architecture and scenic river views (Sahat kula – the clock tower; closed in 2007 for the reconstruction, reopened in April 2014,[6] Zindan kapija – Zindan gate, etc). The former canal which was used for city supplying in the Middle Ages is completely covered by earth but the idea of recreating it resurfaced in the early 2000s. Belgrade Fortress is known for its kilometers-long tunnels, underground corridors and catacombs, which are still largely unexplored. In the true sense, fortress is today the green oasis in the Belgrade's urban area. ",
                IsChildFriendly = true,
                Rating = 5,
                CityId = 4,
            },
            new
            { 
                AttractionId = 5,
                Name = "Petrovaradin Clock Tower",
                Location = "Novi Sad",
                Information = "THE CLOCK TOWER is at the upper town of the fortress. On this site, it used to be an older one which was demolished in 18th century. The radius of the clock is more than two metres long, the four clock faces are directed toward all four cardinal directions, numbers are in roman numerals and the main characteristics of this clock is that the longer hand tells the hours and shorter tells the minutes. This type of a clock needs daily winding up. On the top of the tower there are a vane and a compass. Near the clock tower is, so called, the long barrack i.e. two storey building from the second half of 18th century. At this building, in 1926 was the Aviation NCO school of Kingdom of Serbs, Croats and Slovenians. The bestknown pupil was Franjo Kluz, the aviation pioneer in WWII. One of the most prominent buildings of the upper town is the Leopold’s gate with baroque foreground and suspension bridge, but also with a coat of arms and a motto of the Habsburg monarchy ‘’Viribusunitis’’(by the united forces).",
                IsChildFriendly = true,
                Rating = 5,
                CityId = 5
            },
            new
            {
                AttractionId = 6,
                Name = "Grimace at the grisly Skull Tower",
                Location = "Niš",
                Information = "The Skull Tower was every bit as grim as the name suggests, and was constructed to warn the local Serbs against another rebellion. The tower was built in 1809 using the skulls of 952 fallen Serbian rebels, but less than 100 of the heads remain today.",
                IsChildFriendly = true,
                Rating = 4,
                CityId = 6
            },
            new
            {
                AttractionId = 7,
                Name = "The Imperial Palace",
                Location = "Tokyo",
                Information = "The Tokyo Imperial Palace (Kökyo, literally Imperial Residence) is the primary residence of the Emperor of Japan. It is a large park-like area located in the Chiyoda ward of Tokyo and contains buildings including the main palace (Kyuden), the private residences of the Imperial Family, an archive, museums and administrative offices.It is built on the site of the old Edo Castle.The total area including the gardens is 1.15 square kilometres. During the height of the 1980s Japanese property bubble,the palace grounds were valued by some to be more than the value of all of the real estate in the state of California.",
                IsChildFriendly = true,
                Rating = 4,
                CityId = 7
            },
            new
            {
                AttractionId = 8,
                Name = "Hakkeijima Sea Paradise",
                Location = "Yokohama",
                Information = "The Hakkeijima Sea Paradise is an amusement park located on a small island just off shore, about 30 minutes by train south of downtown Yokohama. It is one of the most visited amusement parks in Japan and houses quite an impressive aquarium.",
                IsChildFriendly = true,
                Rating = 3,
                CityId = 8
            },
            new
            {
                AttractionId = 9,
                Name = "Universal Studios Japan",
                Location = "Osaka",
                Information = "Universal Studios Japan (USJ) was the first theme park under the Universal Studios brand to be built in Asia. Opened in March 2001 in the Osaka Bay Area, the theme park occupies an area of 39 hectares and is the most visited amusement park in Japan after Tokyo Disney Resort.",
                IsChildFriendly = true,
                Rating = 4,
                CityId = 9
            },
            new
            {
                AttractionId = 10,
                Name = "Lake Victoria Island Biketour",
                Location = "Kampala",
                Information = "As you drive quietly through Uganda's beautiful countryside, and stop sipping on a white sandy beach and chat with locals, you may forget that the movement in Kampala is just 30 minutes away over Lake Victoria. This bike ride leaves the city behind and covers 12 miles (20 kilometers) of quiet island roads and offers a tour that really gets you off the beaten path.",
                IsChildFriendly = false,
                Rating = 5,
                CityId = 10
            },
            new
            {
                AttractionId = 11,
                Name = "Nothing at all",
                Location = "Nansana",
                Information = "Could not find any Information about Nansana",
                IsChildFriendly = false,
                Rating = 1,
                CityId = 11
            },
            new
            {
                AttractionId = 12,
                Name = "Kati Kati Africa Restaurant",
                Location = "Kira",
                Information = "Indian, Fusion",
                IsChildFriendly = true,
                Rating = 5,
                CityId = 12
            },
            new
            {
                AttractionId = 13,
                Name = "Barbados Catamaran Snorkling Cruise",
                Location = "Bridgetown",
                Information = "Sail the Caribbean waters of the West Coast of Barbados aboard the El Tigre schooner on this fun half-day cruise, by shuttle. Enjoy free-flow cocktails, including rum, beer and juice, and a light snack as you inhale views of palm trees, the beach and the ocean. Stop for guided snorkeling at a reef known for turtle sighting and a shipwreck that is a lively marine habitat. Upgrade for a longer adventure, with lunch.",
                IsChildFriendly = true,
                Rating = 5,
                CityId = 13
            },
            new
            {
                AttractionId = 14,
                Name = "Barbados all day coast to coastal tour",
                Location = "Speightstown",
                Information = "Get a comprehensive overview of Barbados on this full-day tour that takes travelers from coast to coast. Listen to comments from a guide on Barbados history and culture as you travel across the island. Since all transport is available, this trip eliminates the problem of renting a car and confuses directions. Highlights include Speightstown, Holetown, North Point, Bathsheba and a buffet lunch at the Sunbury Great House.",
                IsChildFriendly = true,
                Rating = 5,
                CityId = 14
            },
            new
            {
                AttractionId = 15,
                Name = "eBike Island Adventures: The Great Adventure Tour",
                Location = "Oistins",
                Information = "Tour begins in the south coast fishing village of Oistins and cruises east along the coastline with stunning views along the way as well as the historic South Point Lighthouse. Off-road trails lead to the cliffs of the southeast coast which reveal hidden coves, secluded beaches and fantastic picture opportunities in unspoilt coast. On the way back to base, we meet the uniqueness of Chancery Lane Wetlands, a layover for migratory birds arriving in and out of North America, as well as the mysterious Christ Church Parish Church and ending at Oistins Bay for some good old fashioned Bajan room punch to finish this one-of -a-kind scenic experience.",
                IsChildFriendly = false,
                Rating = 5,
                CityId = 15
            },
            new
            {
                AttractionId = 16,
                Name = "Canadian Museum of Nature Entrance",
                Location = "Ottawa",
                Information = "Canada's various wonders are on display at the National Natural History Museum. Such a large country requires a large museum and the Canadian Natural Museum supplies. Explore five floors full of galleries that showcase geology, history and climate in Canada. Hands-on and interactive displays help all ages learn more about Canada and nature.",
                IsChildFriendly = true,
                Rating = 5,
                CityId = 16
            },
            new
            {
                AttractionId = 17,
                Name = "Niagara Falls Day Tour from Toronto",
                Location = "Toronto",
                Information = "Explore Niagara Falls on a stress-free day trip from Toronto, which also includes wine tasting at a local winery. Explore the cases at your own pace for about three hours of leisure time and upgrade to include a cruise up the Niagara River into the pool in the Canadian Horse Falls for extra close-ups.",
                IsChildFriendly = true,
                Rating = 5,
                CityId = 17
            },
            new
            {
                AttractionId = 18,
                Name = "Small group Quebec wine tour from Montreal",
                Location = "Montreal",
                Information = "Discover Quebec wine country on a small group tasting tour of vineyards and vineyards in the rolling mountains of the Quebec countryside. With half-day and full-day measures, a wine tasting is a great way to experience the Quebec wine while exploring the scenic landscape that is just outside Montreal's city limits and all wine tasting is included.",
                IsChildFriendly = false,
                Rating = 5,
                CityId = 18
            },
            new
            {
                AttractionId = 19,
                Name = "Brasilia: Green Brasilia with lunch",
                Location = "Brasilia",
                Information = "Utforska Brasilias naturliga sida i denna halvdagstur genom att komma genom nationalparken, Brasilias zoo och botaniska trädgården. Omgiven av en utökad flora och fauna kan du komma i kontakt med naturen och förvåna dig över denna otroliga upplevelse.",
                IsChildFriendly = true,
                Rating = 2,
                CityId = 19
            },
            new
            {
                AttractionId = 20,
                Name = "Football museum",
                Location = "São Paulo",
                Information = "A visit to the Futebol Museum, inside the Paulo Machado de Carvalho Municipal Stadium in São Paulo, Brazil, shows you how much Brazilians love football (called futebol in Portuguese). Use the English audio guide, watch videos and enjoy interactive screens. Fans and non-fans delve deeper into Brazilian culture by understanding the history and heritage of football in Brazil.",
                IsChildFriendly = true,
                Rating = 5,
                CityId = 20
            }, 
            new
            {
                AttractionId = 21,
                Name = "Hanggliding & Paragliding med Beto Rotor",
                Location = "Rio de Janeiro",
                Information = "We fly every day with great joy and care, as if it was always the first time, so we enjoy every flight with the same enthusiasm and superior quality in the pictures offered.",
                IsChildFriendly = false,
                Rating = 5,
                CityId = 21
            },
            new
            {
                AttractionId = 22,
                Name = "Hobbiton Movie Set och Waitomo Glowworm Caves Dagstur från Auckland",
                Location = "Auckland",
                Information = "Visit two of New Zealand's top attractions on a combination trip from Auckland. Explore Shire's hobbies and have a drink at the Green Dragon Inn on a Hobbiton Movie Set tour - a favorite of 'Lord of the Rings' fans - and then listen to Maori legends on a boat ride through the fascinating Waitomo Glowworm Caves. Along the way, walk through some of the most beautiful scenery in the North Island.",
                IsChildFriendly = true,
                Rating = 5,
                CityId = 22
            },
            new
            {
                AttractionId = 23,
                Name = "Christchurch Gondola Ride Ticket",
                Location = "Christchurch",
                Information = "Pre-order admission to Christchurch Gondola so you can skip the ticket lines for the best views in Christchurch. This stunning attraction, rebuilt since the 2011 earthquake, overlooks the city, Lyttelton Harbor and Canterbury Plains. This tour also offers an upgrade option to include other activities in Christchurch for an extensive experience.",
                IsChildFriendly = true,
                Rating = 4,
                CityId = 23
            },
            new
            {
                AttractionId = 24,
                Name = "Eco Wildlife Tour on Zealandia",
                Location = "Wellington",
                Information = "Join a wildlife adventure to remember at the Zealandia Wildlife Sanctuary in Wellington. This guided hike is a great way to see some of New Zealand's most extraordinary wildlife, including rare birds such as takahe, cake bush parrots and green geckos. You don't have to worry about the trip being overcrowded - the small group tour has a limit of 10 people for a more personal experience.",
                IsChildFriendly = true,
                Rating = 5,
                CityId = 24
            });
        }
    }
}
