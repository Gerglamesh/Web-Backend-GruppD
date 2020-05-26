using System;
using System.Collections.Generic;
using System.Text;
using TravelAPI.HATEOAS;

namespace TravelAPI.HATEOAS
{
    public abstract class HateoasLinkBase
    {
        public List<Link> Links { get; set; } = new List<Link>();
    }
}
