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

**Attraction**

| Method | Usage                                                        | Returns    |
| ------ | ------------------------------------------------------------ | ---------- |
| GET    | /api/v1.0/attractions                                        | attraction |
| GET    | /api/v1.0/attractions/name=<name>                            | attraction |
| GET    | /api/v1.0/attractions/childFriendly = <bool>                 | attraction |
| GET    | /api/v1.0/attraction/minrating=<int>                         | attraction |
| GET    | /api/v1.0/attraction/minrating=<int>&maxrating=<int>         | attraction |
| GET    | /api/v1.0/attraction/maxrating=<int>                         | attraction |
| GET    | /api/v1.0/attraction/minrating=<int>&maxrating=<int>         | attraction |
| GET    | /api/v1.0/Attractions?includeCities=<bool>                   | attraction |
| GET    | /api/v1.0/Attractions?isChildFriendly=<bool>                 | attraction |
| GET    | /api/v1.0/Attractions?includeCities=<bool>&isChildFriendly=<bool> | attraction |
| GET    | /api/v1.0/Attractions?minRating=<int>&maxRating=<int>&includeCities=<bool>&isChildFriendly=<bool> | attraction |
| PUT    | /api/v1.0/Attractions/<int>                                  | attraction |
| DELETE | /api/v1.0/Attractions/<int>                                  | attraction |
| POST   | /api/v1.0/Attractions                                        | attraction |



**CountryInfo** 

| Method | EndPoint                   | Usage                                     | Returns          |
| ------ | -------------------------- | ----------------------------------------- | ---------------- |
| GET    | api/v1.0/Country/Info      | Gets all Country Info                     | All Country Info |
| GET    | api/v1.0/Country/Info/{id} | Gets a Country Info by ID                 | Country Info     |
| POST   | api/v1.0/Country/Info      | Adds new Country Info                     |                  |
| PUT    | api/v1.0/Country/Info/{id} | Changes values to a specific Country Info | 204 NoContent    |



**TravelRestriction**
Travel restriction information only fetched when coupled with country. Therefor never needed to be fetched independently. This is because restrictions aren't that interesting by themselves.