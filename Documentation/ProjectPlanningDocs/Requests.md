### Get

**Country**

/Countries/   :heavy_check_mark:

/Countries/name = \<name> || <id>   :heavy_check_mark:

/Countries/name = \<name> & includeCities = \<bool>  :heavy_check_mark:

/Countries/name = \<name> & includeTravelRestrictions = \<bool> :heavy_check_mark:

/Countries/name = \<name> & includeAttractions = \<bool> **HATEOAS?**

/Countries/name = \<name> & includeAttractions = \<bool> & minRating = int (1-5) || maxRating = int (1-5) **HATEOAS?**

/Countries/rightHandTraffic = \<bool> ​​

/Countries/language = \<language>  ​​

Include CountryInfo via HATEOAS



**City**

/Cities/ :heavy_check_mark:

/Cities/name = \<name> || <id>  

/Cities/name = \<name> & includeAttractions = \<bool> **HATEOAS?**

/Cities/name = \<name> & includeAttractions = \<bool> & minRating = int (1-5) || maxRating = int (1-5) **HATEOAS?**

/Cities/name = \<name> & minPopulation = <int> & maxPopulation = <int>



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


