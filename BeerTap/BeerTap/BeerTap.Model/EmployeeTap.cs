using System;
using System.Collections.Generic;
using System.Linq;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;


namespace BeerTap.Model
{
    public class EmployeeTap : Employee, IContainDynamicLinks
    {
        public int EmployeeId { get; set; }

        private readonly IEnumerable<ResourceLink> _additionalLinks;
        public EmployeeTap() : this (Enumerable.Empty<ResourceLink>())
	    {
        }

        public EmployeeTap(IEnumerable<ResourceLink> additionalLinks) : this(additionalLinks.ToArray())
	    {
        }
        
        public EmployeeTap(params ResourceLink[] addtionalLinks)
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
