using System;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTap.Model
{
    public class Employee : IStatelessResource, IIdentifiable<int>
    {
        public int Id { get; set; }
        public int OfficeId { get; set; }
        public string Name { get; set; }

    }
}
