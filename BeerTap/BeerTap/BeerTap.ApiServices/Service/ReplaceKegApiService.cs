using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BeerTap.ApiServices.Interface;
using BeerTap.Facade.Controller;
using BeerTap.Model;
using IQ.Platform.Framework.WebApi;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.Common.Mapping;
using IQ.Platform.Framework.WebApi.Services.Mapping;
using EF = BeerTap.Facade.Model.Beer;


namespace BeerTap.ApiServices.Service
{
    public class ReplaceKegApiService : IReplaceKegApiService
    {
        private readonly IReplaceKegService _iReplaceKegService;
        private readonly IMapper<EF, Model.Beer> _toResourceMapper;

        public ReplaceKegApiService(IReplaceKegService replaceKegService, IMapper<EF, Model.Beer> toResourceMapper)
        {
            _iReplaceKegService = replaceKegService;
            _toResourceMapper = toResourceMapper;
        }

        public Task<ReplaceKeg> UpdateAsync(ReplaceKeg resource, IRequestContext context, CancellationToken cancellation)
        {
            var officeId = context.UriParameters.GetByName<int>("OfficeID").EnsureValue();
            var beerId = context.UriParameters.GetByName<int>("Id").EnsureValue();
            resource.OfficeId = officeId;

            var linkParameter = new ReplaceKegLinkParameter(officeId, beerId);
            context.LinkParameters.Set(linkParameter);

            _iReplaceKegService.ReplaceKeg(officeId, beerId);

            return Task.FromResult(resource);
        }
    }
}
