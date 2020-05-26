using System;
using System.Collections.Generic;
using System.Text;

namespace TravelAPI.HATEOAS
{
    public class Link
    {
        public string Href { get; private set; }
        public string Rel { get; private set; }
        public string Type { get; private set; }

        public Link(string href, string rel, string type)
        {
            Href = href;
            Rel = rel;
            Type = type;
        }

        /// <summary>
        /// Possibly further implmentation the team can do with custom links
        /// without Rel & Type.
        /// Sometimes you just want a href link, without all the other fields.
        /// See Star Wars api for example.
        /// Wollter
        /// </summary>
        /// <param name="href"></param>
        public Link(string href)
        {
            Href = href;
            throw new System.NotImplementedException();
        }
    }
}
