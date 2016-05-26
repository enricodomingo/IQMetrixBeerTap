using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using MongoDB.Bson.IO;
using BeerTap.ApiServices;
using BeerTap.Model;
using IQ.Platform.Framework.WebApi.CacheControl;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;
using BeerTap = BeerTap.Model.Beer;

namespace BeerTap.WebApi.Hypermedia
{
    public class EmployeeTapSpec : SingleStateResourceSpec<EmployeeTap, int>
    {
        public static ResourceUriTemplate Uri =
            ResourceUriTemplate.Create(BeerTapSpec.Uri.Value + "/EmployeeTap");

        public override string EntrypointRelation
        {
            get { return null; }
        }

        public override IResourceStateSpec<EmployeeTap, NullState, int> StateSpec
        {
            get
            {
                return new SingleStateSpec<EmployeeTap, int>
                {
                    Operations = new StateSpecOperationsSource<EmployeeTap, int>
                    {
                        Post = ServiceOperations.Update
                    }
                };
            }
        }

        protected override IEnumerable<ResourceLinkTemplate<EmployeeTap>> Links()
        {
            yield return
                CreateLinkTemplate<EmployeeTapLinkParameter>(CommonLinkRelations.Self, EmployeeTapSpec.Uri,
                    c => c.Parameters.OfficeId,
                    c => c.Parameters.BeerId);
        }
    }
}