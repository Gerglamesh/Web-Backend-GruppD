using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAPI.Migrations
{
    public partial class Add_More_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Attractions",
                columns: new[] { "AttractionId", "CityId", "Information", "IsChildFriendly", "Location", "Name", "Rating" },
                values: new object[,]
                {
                    { 3, 2, "The Sultan of the Seljuq dynasty, Ahmed Sanjar, built the first known shrine at this location. It was destroyed or hidden under earthen embankment during the invasion of Genghis Khan around 1220. In the 15th century, Timurid Sultan Husayn Bayqarah Mirza built the current Blue Mosque here. It is by far the most important landmark in Mazar-i-Sharif and it is believed that the name of city (Noble Shrine, Grave of Hazrat-i-Ali Sharif) originates from this shrine. ", true, "Balkh", "Blue Mosque", 4 },
                    { 24, 24, "Join a wildlife adventure to remember at the Zealandia Wildlife Sanctuary in Wellington. This guided hike is a great way to see some of New Zealand's most extraordinary wildlife, including rare birds such as takahe, cake bush parrots and green geckos. You don't have to worry about the trip being overcrowded - the small group tour has a limit of 10 people for a more personal experience.", true, "Wellington", "Eco Wildlife Tour on Zealandia", 5 },
                    { 23, 23, "Pre-order admission to Christchurch Gondola so you can skip the ticket lines for the best views in Christchurch. This stunning attraction, rebuilt since the 2011 earthquake, overlooks the city, Lyttelton Harbor and Canterbury Plains. This tour also offers an upgrade option to include other activities in Christchurch for an extensive experience.", true, "Christchurch", "Christchurch Gondola Ride Ticket", 4 },
                    { 22, 22, "Visit two of New Zealand's top attractions on a combination trip from Auckland. Explore Shire's hobbies and have a drink at the Green Dragon Inn on a Hobbiton Movie Set tour - a favorite of 'Lord of the Rings' fans - and then listen to Maori legends on a boat ride through the fascinating Waitomo Glowworm Caves. Along the way, walk through some of the most beautiful scenery in the North Island.", true, "Auckland", "Hobbiton Movie Set och Waitomo Glowworm Caves Dagstur från Auckland", 5 },
                    { 21, 21, "We fly every day with great joy and care, as if it was always the first time, so we enjoy every flight with the same enthusiasm and superior quality in the pictures offered.", false, "Rio de Janeiro", "Hanggliding & Paragliding med Beto Rotor", 5 },
                    { 20, 20, "A visit to the Futebol Museum, inside the Paulo Machado de Carvalho Municipal Stadium in São Paulo, Brazil, shows you how much Brazilians love football (called futebol in Portuguese). Use the English audio guide, watch videos and enjoy interactive screens. Fans and non-fans delve deeper into Brazilian culture by understanding the history and heritage of football in Brazil.", true, "São Paulo", "Football museum", 5 },
                    { 19, 19, "Utforska Brasilias naturliga sida i denna halvdagstur genom att komma genom nationalparken, Brasilias zoo och botaniska trädgården. Omgiven av en utökad flora och fauna kan du komma i kontakt med naturen och förvåna dig över denna otroliga upplevelse.", true, "Brasilia", "Brasilia: Green Brasilia with lunch", 2 },
                    { 18, 18, "Discover Quebec wine country on a small group tasting tour of vineyards and vineyards in the rolling mountains of the Quebec countryside. With half-day and full-day measures, a wine tasting is a great way to experience the Quebec wine while exploring the scenic landscape that is just outside Montreal's city limits and all wine tasting is included.", false, "Montreal", "Small group Quebec wine tour from Montreal", 5 },
                    { 16, 16, "Canada's various wonders are on display at the National Natural History Museum. Such a large country requires a large museum and the Canadian Natural Museum supplies. Explore five floors full of galleries that showcase geology, history and climate in Canada. Hands-on and interactive displays help all ages learn more about Canada and nature.", true, "Ottawa", "Canadian Museum of Nature Entrance", 5 },
                    { 15, 15, "Tour begins in the south coast fishing village of Oistins and cruises east along the coastline with stunning views along the way as well as the historic South Point Lighthouse. Off-road trails lead to the cliffs of the southeast coast which reveal hidden coves, secluded beaches and fantastic picture opportunities in unspoilt coast. On the way back to base, we meet the uniqueness of Chancery Lane Wetlands, a layover for migratory birds arriving in and out of North America, as well as the mysterious Christ Church Parish Church and ending at Oistins Bay for some good old fashioned Bajan room punch to finish this one-of -a-kind scenic experience.", false, "Oistins", "eBike Island Adventures: The Great Adventure Tour", 5 },
                    { 14, 14, "Get a comprehensive overview of Barbados on this full-day tour that takes travelers from coast to coast. Listen to comments from a guide on Barbados history and culture as you travel across the island. Since all transport is available, this trip eliminates the problem of renting a car and confuses directions. Highlights include Speightstown, Holetown, North Point, Bathsheba and a buffet lunch at the Sunbury Great House.", true, "Speightstown", "Barbados all day coast to coastal tour", 5 },
                    { 17, 17, "Explore Niagara Falls on a stress-free day trip from Toronto, which also includes wine tasting at a local winery. Explore the cases at your own pace for about three hours of leisure time and upgrade to include a cruise up the Niagara River into the pool in the Canadian Horse Falls for extra close-ups.", true, "Toronto", "Niagara Falls Day Tour from Toronto", 5 },
                    { 12, 12, "Indian, Fusion", true, "Kira", "Kati Kati Africa Restaurant", 5 },
                    { 4, 4, "Kalemegdan is the most popular park among Belgraders and for many tourists visiting Belgrade because of the park's numerous winding walking paths, shaded benches, picturesque fountains, statues, historical architecture and scenic river views (Sahat kula – the clock tower; closed in 2007 for the reconstruction, reopened in April 2014,[6] Zindan kapija – Zindan gate, etc). The former canal which was used for city supplying in the Middle Ages is completely covered by earth but the idea of recreating it resurfaced in the early 2000s. Belgrade Fortress is known for its kilometers-long tunnels, underground corridors and catacombs, which are still largely unexplored. In the true sense, fortress is today the green oasis in the Belgrade's urban area. ", true, "Belgrad", "Kalemegdan Fortress", 5 },
                    { 13, 13, "Sail the Caribbean waters of the West Coast of Barbados aboard the El Tigre schooner on this fun half-day cruise, by shuttle. Enjoy free-flow cocktails, including rum, beer and juice, and a light snack as you inhale views of palm trees, the beach and the ocean. Stop for guided snorkeling at a reef known for turtle sighting and a shipwreck that is a lively marine habitat. Upgrade for a longer adventure, with lunch.", true, "Bridgetown", "Barbados Catamaran Snorkling Cruise", 5 },
                    { 6, 6, "The Skull Tower was every bit as grim as the name suggests, and was constructed to warn the local Serbs against another rebellion. The tower was built in 1809 using the skulls of 952 fallen Serbian rebels, but less than 100 of the heads remain today.", true, "Niš", "Grimace at the grisly Skull Tower", 4 },
                    { 7, 7, "The Tokyo Imperial Palace (Kökyo, literally Imperial Residence) is the primary residence of the Emperor of Japan. It is a large park-like area located in the Chiyoda ward of Tokyo and contains buildings including the main palace (Kyuden), the private residences of the Imperial Family, an archive, museums and administrative offices.It is built on the site of the old Edo Castle.The total area including the gardens is 1.15 square kilometres. During the height of the 1980s Japanese property bubble,the palace grounds were valued by some to be more than the value of all of the real estate in the state of California.", true, "Tokyo", "The Imperial Palace", 4 },
                    { 5, 5, "THE CLOCK TOWER is at the upper town of the fortress. On this site, it used to be an older one which was demolished in 18th century. The radius of the clock is more than two metres long, the four clock faces are directed toward all four cardinal directions, numbers are in roman numerals and the main characteristics of this clock is that the longer hand tells the hours and shorter tells the minutes. This type of a clock needs daily winding up. On the top of the tower there are a vane and a compass. Near the clock tower is, so called, the long barrack i.e. two storey building from the second half of 18th century. At this building, in 1926 was the Aviation NCO school of Kingdom of Serbs, Croats and Slovenians. The bestknown pupil was Franjo Kluz, the aviation pioneer in WWII. One of the most prominent buildings of the upper town is the Leopold’s gate with baroque foreground and suspension bridge, but also with a coat of arms and a motto of the Habsburg monarchy ‘’Viribusunitis’’(by the united forces).", true, "Novi Sad", "Petrovaradin Clock Tower", 5 },
                    { 9, 9, "Universal Studios Japan (USJ) was the first theme park under the Universal Studios brand to be built in Asia. Opened in March 2001 in the Osaka Bay Area, the theme park occupies an area of 39 hectares and is the most visited amusement park in Japan after Tokyo Disney Resort.", true, "Osaka", "Universal Studios Japan", 4 },
                    { 10, 10, "As you drive quietly through Uganda's beautiful countryside, and stop sipping on a white sandy beach and chat with locals, you may forget that the movement in Kampala is just 30 minutes away over Lake Victoria. This bike ride leaves the city behind and covers 12 miles (20 kilometers) of quiet island roads and offers a tour that really gets you off the beaten path.", false, "Kampala", "Lake Victoria Island Biketour", 5 },
                    { 11, 11, "Could not find any Information about Nansana", false, "Nansana", "Nothing at all", 1 },
                    { 8, 8, "The Hakkeijima Sea Paradise is an amusement park located on a small island just off shore, about 30 minutes by train south of downtown Yokohama. It is one of the most visited amusement parks in Japan and houses quite an impressive aquarium.", true, "Yokohama", "Hakkeijima Sea Paradise", 3 }
                });

            migrationBuilder.InsertData(
                table: "TravelRestrictions",
                columns: new[] { "TravelRestrictionId", "IsCitizenshipAllowed", "IsFamilyVisitAllowed", "IsImmigrationAllowed", "IsTourismAllowed", "IsVisaNeeded", "IsWorkTravelAllowed", "RiskLevel" },
                values: new object[,]
                {
                    { 7, true, true, true, true, true, true, 5 },
                    { 2, false, false, false, false, true, false, 4 },
                    { 3, false, false, false, false, false, false, 3 },
                    { 4, false, false, true, false, true, false, 2 },
                    { 5, true, true, true, true, true, true, 1 },
                    { 6, true, true, true, true, true, true, 3 },
                    { 8, true, false, false, true, false, true, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 2,
                column: "TravelRestrictionId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 3,
                column: "TravelRestrictionId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 4,
                column: "TravelRestrictionId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 5,
                column: "TravelRestrictionId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 6,
                column: "TravelRestrictionId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 7,
                column: "TravelRestrictionId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 8,
                column: "TravelRestrictionId",
                value: 8);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "AttractionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "AttractionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "AttractionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "AttractionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "AttractionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "AttractionId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "AttractionId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "AttractionId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "AttractionId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "AttractionId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "AttractionId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "AttractionId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "AttractionId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "AttractionId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "AttractionId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "AttractionId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "AttractionId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "AttractionId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "AttractionId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "AttractionId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "AttractionId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "AttractionId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TravelRestrictions",
                keyColumn: "TravelRestrictionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TravelRestrictions",
                keyColumn: "TravelRestrictionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TravelRestrictions",
                keyColumn: "TravelRestrictionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TravelRestrictions",
                keyColumn: "TravelRestrictionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TravelRestrictions",
                keyColumn: "TravelRestrictionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TravelRestrictions",
                keyColumn: "TravelRestrictionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TravelRestrictions",
                keyColumn: "TravelRestrictionId",
                keyValue: 8);

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryInfoId", "Name", "TravelRestrictionId" },
                values: new object[,]
                {
                    { 3, 3, "Japan", 1 },
                    { 2, 2, "Serbia", 1 },
                    { 8, 8, "New Zealand", 1 },
                    { 7, 7, "Brazil", 1 },
                    { 6, 6, "Canada", 1 },
                    { 5, 5, "Barbados", 1 },
                    { 4, 4, "Uganda", 1 }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CountryId", "Name", "Population" },
                values: new object[,]
                {
                    { 9, 3, "Osaka", 2691000 },
                    { 12, 4, "Kira", 317157 },
                    { 13, 5, "Bridgetown", 110000 },
                    { 14, 5, "Speightstown", 3634 },
                    { 15, 5, "Oistins", 2285 },
                    { 16, 6, "Ottawa", 994837 },
                    { 17, 6, "Toronto", 2930000 },
                    { 18, 6, "Montreal", 1780000 },
                    { 19, 7, "Brasilia", 4645943 },
                    { 11, 4, "Nansana", 365124 },
                    { 20, 7, "São Paulo", 21846507 },
                    { 23, 8, "Christchurch", 381500 },
                    { 24, 8, "Wellington", 212700 },
                    { 22, 8, "Auckland", 1657000 },
                    { 4, 2, "Belgrade", 1397939 },
                    { 5, 2, "Novi Sad", 289128 },
                    { 6, 2, "Niš", 185987 },
                    { 7, 3, "Tokyo", 37435191 },
                    { 8, 3, "Yokohama", 3725000 },
                    { 21, 7, "Rio de Janeiro", 13458075 },
                    { 10, 4, "Kampala", 1680600 }
                });
        }
    }
}
