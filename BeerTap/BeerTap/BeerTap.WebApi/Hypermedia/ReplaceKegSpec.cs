using BeerTap.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;
using System.Collections.Generic;
using BeerTap.ApiServices;
using System;
namespace BeerTap.WebApi.Hypermedia
{
    public class ReplaceKegSpec : SingleStateResourceSpec<ReplaceKeg, int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create(BeerTapSpec.Uri.Value + "/ReplaceKeg");

        public override IResourceStateSpec<ReplaceKeg, NullState, int> StateSpec
        {
            get
            {
                return new SingleStateSpec<ReplaceKeg, int>
                {
                    Operations = new StateSpecOperationsSource<ReplaceKeg, int>
                    {
                        Post = ServiceOperations.Update
                    }
                };
            }
        }
        protected override IEnumerable<ResourceLinkTemplate<ReplaceKeg>> Links()
        {
            yield return
                CreateLinkTemplate<ReplaceKegLinkParameter>(CommonLinkRelations.Self, ReplaceKegSpec.Uri,
                    c => c.Parameters.OfficeId,
                    c => c.Parameters.BeerId);
        }
    }
}