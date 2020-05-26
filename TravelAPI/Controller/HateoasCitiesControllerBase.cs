using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using TravelAPI.DTO;
using TravelAPI.HATEOAS;

namespace TravelAPI.Controllers
{
    public class HateoasCitiesControllerBase : ControllerBase
    {
        private readonly IReadOnlyList<ActionDescriptor> _routes;

        public HateoasCitiesControllerBase(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            _routes = actionDescriptorCollectionProvider.ActionDescriptors.Items;
        }

        internal Link UrlLink(string relation, string routeName, object values)
        {
            var route = _routes.FirstOrDefault(f => f.AttributeRouteInfo.Name == routeName);
            var method = route.ActionConstraints.OfType<HttpMethodActionConstraint>().First().HttpMethods.First();
            var url = Url.Link(routeName, values).ToLower();
            return new Link(url, relation, method);
        }

        /// <summary>
        /// Use this method for your mainlinks. Eg CRUD, just add
        /// more links to your CRUD methods inside
        /// Wollter
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        internal CityDto HateoasMainLinks(CityDto cityDto)
        {

            cityDto.Links.Add(UrlLink("all", "GetCities", null));
            cityDto.Links.Add(UrlLink("_self", "GetCityById", null));
            
            return cityDto;
        }

        /// <summary>
        /// Custom extention method
        /// Use this method for possible further implementation sidelinks the team come up with.
        /// Can also duplicate this method to new methods with tailored links to be grouped.
        /// Wollter
        /// </summary>
        /// <param name="actor"></param>
        /// <returns></returns>
        internal CityDto HateoasSideLinks(CityDto cityDto)
        {
            throw new System.NotImplementedException();

            //return actorDto;
        }
    }
}
