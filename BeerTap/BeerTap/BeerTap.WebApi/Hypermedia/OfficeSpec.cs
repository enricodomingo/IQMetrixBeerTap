using BeerTap.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTap.WebApi.Hypermedia
{
    public class OfficeSpec : SingleStateResourceSpec<Office, int>
    {

        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({id})");

        public override string EntrypointRelation
        {
            get { return LinkRelations.Office; }
        }

        public override IResourceStateSpec<Office, NullState, int> StateSpec
        {
            get
            {
                return
                    new SingleStateSpec<Office, int>
                    {
                        Links =
                        {
                            CreateLinkTemplate("BeerTap",
                                ResourceUriTemplate.Create("Offices({OfficeId})/BeerTap"), r => r.Id),
                                CreateLinkTemplate("Employee",
                                ResourceUriTemplate.Create("Offices({OfficeId})/Employee"), r => r.Id)
                        },
                        Operations = new StateSpecOperationsSource<Office, int>
                        {
                            Get = ServiceOperations.Get,
                            InitialPost = ServiceOperations.Create,
                            Post = ServiceOperations.Update,
                            Delete = ServiceOperations.Delete
                        }
                    };
            }
        }
    }
}