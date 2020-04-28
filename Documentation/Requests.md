### Get

**Country**

/Countries/

/Countries/?name = \<name>

/Countries/?name= \<name> & includeCountryInformation = \<bool>

/Countries/?name = \<name> & includeCities = \<bool>

/Countries/?name = \<name> & includeTravelRestrictions = \<bool>

/Countries/?name = \<name> & includeAttractions = \<bool>

/Countries/?name = \<name> & includeAttractions = \<bool> **<u>(Of a specific rating)</u>**

/Countries/?name = \<name> & includeAttractions = \<bool> **<u>(Within a rating interwall)</u>**

/Countries/?rightHandTraffic = \<bool>

/Countries/?language = \<language> 



**City**

/Cities/

/Cities/?name = \<name> 

/Cities/?name = \<name> & includeAttractions = \<bool>

/Cities/?name = \<name> & includeAttractions = \<bool> **<u>(Of a specific rating)</u>**

/Cities/?name = \<name> & includeAttractions = \<bool> **<u>(Within a rating interwall)</u>**

/Cities/?name = \<name> & includeInformation = \<bool> 



**Attraction**

/Attractions/

/Attractions/?name = \<name> 

/Attractions/?name = \<name> & includeLocation =  \<bool>

/Attractions/?childFriendly = \<bool>

/Attractions/?rating = \<rating> 

/Attractions/?minRating >= \<minRating> & maxRating <= \<maxRating> 



**CountryInfo** 

/Countries/?minPopulation =  \<minPopulation>

/Countries/?governance = \<governance> (Hard to implement search)

/Countries/?BNP = \<BNP> (irrelevant?)

/Country/?capitalCity = \<capitalCity> (Might be relevant?)

/Country/?area = \<area> (irrelevant?)

/Country/?timeZone = \<timeZone>  (maybe useful?)

/Country/?nationalDay = \<NationalDay> (irrelevant to search for!)

/Country/?rightHandTraffic = \<bool> (good criteria)

/Country/?language = \<language>  (good criteria)



**TravelRestriction**

/TravelRestriction/workTravel = \<bool>

/TravelRestriction/tourism = \<bool>

/TravelRestriction/immigration = \<bool>

/TravelRestriction/citizenship = \<bool>

/TravelRestriction/familyVisit = \<bool>

/TravelRestriction/isVisaNeeded = \<bool>

/TravelRestriction/riskLevel = \<riskLevel>

/TravelRestriction/minRiskLevel >= \<riskLevel> & maxRiskLevel <= \<maxRiskLevel>



### Post



### Put



### Delete





