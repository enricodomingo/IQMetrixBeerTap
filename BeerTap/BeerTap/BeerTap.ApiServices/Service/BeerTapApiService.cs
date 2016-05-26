using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BeerTap.ApiServices.Interface;
using BeerTap.Facade.Controller;
using IQ.Platform.Framework.WebApi;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.Common.Mapping;
using IQ.Platform.Framework.WebApi.Services.Mapping;
using EF = BeerTap.Facade.Model.Beer;
using BeerTap.Model;

namespace BeerTap.ApiServices.Service
{
    public class BeerTapApiService : IBeerTapApiService
    {
        private readonly IBeerService _beerService;
        private readonly IMapper<EF, Model.Beer> _toResourceMapper;
        private readonly IMapper<Model.Beer, EF> _toTransportMapper;

        public Task<ResourceCreationResult<Model.Beer, int>> CreateAsync(Model.Beer resource, IRequestContext context, CancellationToken cancellation)
        {
            var officeId = context.UriParameters.GetByName<int>("OfficeID").EnsureValue();
            var linkParameter = new BeerLinkParameter(officeId);
            resource.OfficeID = officeId;
            context.LinkParameters.Set(linkParameter);

            var newBeer = _beerService.Add(_toTransportMapper.Map(resource));
            return Task.FromResult(new ResourceCreationResult<Model.Beer, int>(_toResourceMapper.Map(newBeer)));
        }

        public BeerTapApiService(IBeerService beerService, IMapper<EF, Model.Beer> toResourceMapper,IMapperFactory mapperFactory)
        {
            _beerService = beerService;
            _toResourceMapper = toResourceMapper;
            _toTransportMapper = mapperFactory.Create<Model.Beer, EF>();
        }

        public Task<Model.Beer> UpdateAsync(Model.Beer resource, IRequestContext context, CancellationToken cancellation)
        {
            var officeId = context.UriParameters.GetByName<int>("OfficeID").EnsureValue();
            var linkParameter = new BeerLinkParameter(officeId);
            resource.OfficeID = officeId;
            context.LinkParameters.Set(linkParameter);

            var originalBeer = _toResourceMapper.Map(_beerService.GetBeerById(resource.Id, officeId).Result);
            var resultBeer = context.MergeResource(resource, originalBeer);
            _beerService.Update(_toTransportMapper.Map(resultBeer));
            return Task.FromResult(resource);
        }

        public IEnumerable<Model.Beer> GetMany(IRequestContext context)
        {
            var officeId = context.UriParameters.GetByName<int>("OfficeID").EnsureValue();
            var linkParameter = new BeerLinkParameter(officeId);
            context.LinkParameters.Set(linkParameter);

            return _beerService.GetAll(officeId)
                .Select(_toResourceMapper.Map);
        }

        public async Task<Model.Beer> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            var officeId = context.UriParameters.GetByName<int>("OfficeID").EnsureValue();
            var linkParameter = new BeerLinkParameter(officeId);
            context.LinkParameters.Set(linkParameter);

            return
            _toResourceMapper.Map(
                await _beerService.GetBeerById(id, officeId));
        }
    }
}