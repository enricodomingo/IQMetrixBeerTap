
using System;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;
using System.Collections.Generic;
using System.Linq;

namespace BeerTap.Model
{
    public class ReplaceKeg : IStatelessResource, IIdentifiable<int>, IContainDynamicLinks
    {
        public int Id { get; set; }
        public int OfficeId { get; set; }
        private readonly IEnumerable<ResourceLink> _additionalLinks;
        public ReplaceKeg() : this (Enumerable.Empty<ResourceLink>())
	    {
        }

        public ReplaceKeg(IEnumerable<ResourceLink> additionalLinks) : this(additionalLinks.ToArray())
	    {
        }

        public ReplaceKeg(params ResourceLink[] addtionalLinks)
        {
            if (addtionalLinks == null) throw new ArgumentNullException("addtionalLinks");

            _additionalLinks = addtionalLinks;
        }
        public IEnumerable<ResourceLink> GetDynamicLinks()
        {
            return _additionalLinks;
        }
    }
}
