# HATEOAS relationship links	

### **Country**

**{**

​	Countries own props

​	**{**

​		"rel": "self"

​		"href": http://Selflink

​	**}**

​	**{**

​		"rel": "country_information"

​		"href": http://CountryInfoLink

​	**}**

​	**{**

​		"rel": "travel_restrictions"

​		"href": http://TravelRestrictionsLink

​	**}**

​	**{**	

​		"rel": "cities"

​		"href": http://CitiesLink

​	**}**

​	**{**	

​		"rel": "attractions"

​		"href": http://AttractionsLink

​	**}**

**}**



### Cities

**{**

​	Cities own props

​	**{**	

​		"rel": "self"

​		"href": http://SelfLink

​	**}**

​	**{**	

​		"rel": "country"

​		"href": http://CountryLink

​	**}**

​	**{**	

​		"rel": "attractions"

​		"href": http://AttractionsLink

​	**}**

**}**



### Attractions

**{**

​	Attractions own props

​	**{**	

​		"rel": "self"

​		"href": http://SelfLink

​	**}**

​	**{**	

​		"rel": "city"

​		"href": http://CityLink

​	**}**

​	**{**	

​		"rel": "country"

​		"href": http://CountryLink

​	**}**

**}**