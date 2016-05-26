using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using BeerTap.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using System.Collections.Generic;
using BeerTap.ApiServices;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTap.WebApi.Hypermedia
{
    public class EmployeeSpec : SingleStateResourceSpec<Employee,int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({OfficeId})/Employee({Id})");

        protected override IEnumerable<ResourceLinkTemplate<Employee>> Links()
        {
            yield return
                CreateLinkTemplate<EmployeeLinkParameter>(CommonLinkRelations.Self, Uri, c => c.Parameters.OfficeId,
                                                          c => c.Resource.Id);
        }
    }
}