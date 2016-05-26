using BeerTap.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTap.WebApi.Hypermedia
{
    public class BeerStateProvider : ResourceStateProviderBase<Model.Beer, BeerStatus>
    {

        public override BeerStatus GetFor(Model.Beer resource)
        {
            return resource.Status;
        }
        public override IEnumerable<BeerStatus> All
        {
            get { return EnumEx.GetValuesFor<BeerStatus>(); }
        }

        protected override IDictionary<BeerStatus, IEnumerable<BeerStatus>> GetTransitions()
        {
            return new Dictionary<BeerStatus, IEnumerable<BeerStatus>>
            {
                {
                    BeerStatus.New, new[]
                    {
                        BeerStatus.GoinDown,
                        BeerStatus.AlmostEmpty, 
                        BeerStatus.ShelsDryMate
                    }
                },
                {
                    BeerStatus.GoinDown, new[]
                    {
                        BeerStatus.AlmostEmpty,
                        BeerStatus.New, 
                        BeerStatus.ShelsDryMate, 
                    }
                },
                {
                    BeerStatus.AlmostEmpty, new[]
                    {
                        BeerStatus.New
                    }
                },
                {
                    BeerStatus.ShelsDryMate, new[]
                    {
                        BeerStatus.New
                    }
                }
            };
        }
    }
}