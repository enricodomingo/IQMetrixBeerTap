using BeerTap.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;
using System.Collections.Generic;
using BeerTap.ApiServices;
using System;
using IQ.Platform.Framework.WebApi.CacheControl;

namespace BeerTap.WebApi.Hypermedia
{
    public class BeerTapSpec : ResourceSpec<Model.Beer, BeerStatus, int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({OfficeId})/BeerTap({Id})");
        protected override IEnumerable<ResourceLinkTemplate<Model.Beer>> Links()
        {
            yield return CreateLinkTemplate<BeerLinkParameter>(CommonLinkRelations.Self, Uri, c => c.Parameters.OfficeId, c => c.Resource.Id);
        }
        protected override IEnumerable<IResourceStateSpec<Model.Beer, BeerStatus, int>> GetStateSpecs()
        {
            yield return new ResourceStateSpec<Model.Beer, BeerStatus, int>(BeerStatus.New)
            {
                Links =
                {
                    CreateLinkTemplate<BeerLinkParameter>(LinkRelations.Offices.EmployeeTap, EmployeeTapSpec.Uri, c => c.Parameters.OfficeId,
                        c => c.Resource.Id)
                },
                Operations =
                {
                    InitialPost = ServiceOperations.Create,
                    Get = ServiceOperations.Get,
                    Post = ServiceOperations.Update,
                    Put = ServiceOperations.Update,
                    Delete = ServiceOperations.Delete
                }
            };
            yield return new ResourceStateSpec<Model.Beer, BeerStatus, int>(BeerStatus.ShelsDryMate)
            {
                Links =
                {
                    CreateLinkTemplate<BeerLinkParameter>(LinkRelations.Offices.ReplaceKeg, ReplaceKegSpec.Uri, c => c.Parameters.OfficeId,
                        c => c.Resource.Id)
                },
                Operations =
                {
                    Post = ServiceOperations.Update
                }
            };
            yield return new ResourceStateSpec<Model.Beer, BeerStatus, int>(BeerStatus.AlmostEmpty)
            {
                Links =
                {
                    CreateLinkTemplate<BeerLinkParameter>(LinkRelations.Offices.ReplaceKeg, ReplaceKegSpec.Uri, c => c.Parameters.OfficeId,
                        c => c.Resource.Id)
                },
                Operations =
                {
                    Post = ServiceOperations.Update
                }
            };
            yield return new ResourceStateSpec<Model.Beer, BeerStatus, int>(BeerStatus.GoinDown)
            {
                Links =
                {
                    CreateLinkTemplate<BeerLinkParameter>(LinkRelations.Offices.EmployeeTap, EmployeeTapSpec.Uri, c => c.Parameters.OfficeId,
                        c => c.Resource.Id)
                },
                Operations =
                {
                    InitialPost = ServiceOperations.Create,
                    Get = ServiceOperations.Get,
                    Post = ServiceOperations.Update,
                    Put = ServiceOperations.Update,
                    Delete = ServiceOperations.Delete
                }
            };
        }

    }
}