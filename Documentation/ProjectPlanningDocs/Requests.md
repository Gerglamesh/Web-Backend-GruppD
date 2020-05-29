### Get

**Country**

| Method | Usage                                                        | Returns   |
| ------ | ------------------------------------------------------------ | --------- |
| GET    | /api/v1.0/Countries                                          | countries |
| GET    | /api/v1.0/countries/?includeCities=true                      | countries |
| GET    | /api/v1.0/countries/?includeTravelRestrictions=true          | countries |
| GET    | /api/v1.0/countries/?isRightHandTraffic=true                 | countries |
| GET    | /api/v1.0/countries/?isLeftHandTraffic=true                  | countries |
| GET    | /api/v1.0/countries/?language={language}                     | countries |
| GET    | /api/v1.0/countries/search={name}                            | country   |
| GET    | /api/v1.0/countries/search={name}?includeCities=true         | country   |
| GET    | /api/v1.0/countries/search={name}?includeTravelRestrictions=true | country   |
| GET    | /api/v1.0/countries/{id}                                     | country   |
| GET    | /api/v1.0/countries/{id}?includeCities=true                  | country   |
| GET    | /api/v1.0/countries/{id}?includeTravelRestrictions=true      | country   |

/Countries/name = \<name> & includeAttractions = \<bool>

/Countries/name = \<name> & includeAttractions = \<bool> & minRating = int (1-5) || maxRating = int 



**City** Base URL: http://localhost:50615/api/v1.0/cities

| Method | EndPoint                         | Usage                                        | Returns           |
| ------ | -------------------------------- | -------------------------------------------- | ----------------- |
| GET    | /v1.0/cities                     | Gets all cities                              | cities            |
| GET    | /v1.0/cities/{id}                | Gets a city by ID                            | city              |
| GET    | /v1.0/cities/{name}              | Gets a city by Name                          | city              |
| GET    | /v1.0/cities/minpopulation={int} | Gets all cities with minimum population      | cities            |
| GET    | /v1.0/cities/maxpopulation={int} | Gets all cities with maximum population      | cities            |
| GET    | /v1.0/cities/?includecountry     | Gets all cities with from a specific country | cities            |
| GET    | /v1.0/cities/search={string}     | Gets all cities with name containing string  | cities            |
| PUT    | /v1.0/cities/{id}                | Change the values of a specific city         | 204 NoContent     |
| POST   | /v1.0/cities/                    | Adds a new city                              | endpoint for city |
| DELETE | /v1.0/cities/{id}                | Delete a specific city                       | 204 NoContent     |
|        |                                  |                                              |                   |
|        |                                  |                                              |                   |
|        |                                  |                                              |                   |
|        |                                  |                                              |                   |



/Cities/name = \<name> & includeAttractions = \<bool> **HATEOAS?**

/Cities/name = \<name> & includeAttractions = \<bool> & minRating = int (1-5) || maxRating = int (1-5) **HATEOAS?**



**Attraction **

/Attractions/

/Attractions/name = \<name> || <id>

/Attractions/childFriendly = \<bool>

/Attractions/rating = \<int> 

/Attractions/minRating = \<int> & maxRating = \<int> 



**CountryInfo** 

/Countries/Info/   (Get All)

/Countries/Info/id = <id>



**TravelRestriction**

Travel restriction information only fetched when coupled with country. Therefor never needed to be fetched independently. This is because restrictions aren't that interesting by themselves.



### Post

/Countries/  :heavy_check_mark:

/Cities/ :heavy_check_mark:

/Attraction/  :heavy_check_mark:

CountryInfo should only be part of posting a new Country, not a separate post.

/TravelRestriction/ :heavy_check_mark:

### Put

/Countries/id

/Cities/id

/Attraction/id  ​​

/CountryInfo/id

/TravelRestriction/id ​​

### Delete


