using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;


namespace BeerTap.Model
{
    public class Beer : IStatefulResource<BeerStatus>, IIdentifiable<int>
    {
        public int Id { get; set; }
        public decimal mL { get; set; }
        public int OfficeID { get; set; }
        public decimal Container { get; set; }
        public BeerStatus Status { get; set; }
    }
}
