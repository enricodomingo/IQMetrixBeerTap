using System;
using System.Linq;
using IQ.Platform.Framework.Common.Collections;
using IQ.Platform.Framework.Common.Mapping;
using BeerTap.Facade.Model;
using Beer = BeerTap.Model.Beer;
using EF = BeerTap.Facade;
using BeerTap.Model;
using BeerStatus = BeerTap.Facade.Model.BeerStatus;

namespace BeerTap.ApiServices
{
    public class BeerTapMapper : IMapper<EF.Model.Beer, Beer>
    {

        public Beer Map(EF.Model.Beer source)
        {
            if (source != null)
            {
                var resource = new Beer
                {
                    Id = source.Id,
                    Status = MapStatus(source.Container, source.mL),
                    Container = source.Container,
                    OfficeID = source.OfficeId,
                    mL = source.mL
                };
                return resource;
            }
            return null;
        }

        static Model.BeerStatus MapStatus(decimal container,decimal mLTakout)
        {
            if (((mLTakout/container) * 100) == 100)
                return Model.BeerStatus.New;
            if ((((mLTakout / container) * 100) >= 50) && (((mLTakout / container) * 100) <= 100))
                return Model.BeerStatus.GoinDown;
            if ((((mLTakout / container) * 100) <= 50) && (((mLTakout / container) * 100) >= 25))
                return Model.BeerStatus.AlmostEmpty;
            if ((((mLTakout / container) * 100) <= 25) && (((mLTakout / container) * 100) > 0))
                return Model.BeerStatus.ShelsDryMate;
            if (((mLTakout / container) * 100) <= 0)
                return Model.BeerStatus.ShelsDryMate;

            return Model.BeerStatus.New;
        }
    }
}
