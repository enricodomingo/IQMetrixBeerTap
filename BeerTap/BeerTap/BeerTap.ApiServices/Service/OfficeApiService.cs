using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BeerTap.ApiServices.Interface;
using BeerTap.Model;
using IQ.Platform.Framework.WebApi;
using BeerTap.Facade.Controller;
using IQ.Platform.Framework.Common.Mapping;
using IQ.Platform.Framework.WebApi.Services.Mapping;
using EF = BeerTap.Facade.Model.Office;

namespace BeerTap.ApiServices.Service
{
    public class OfficeApiService : IOfficeApiService
    {

        //private readonly IApiUserProvider<BeerTapApiUser> _userProvider;
        private readonly IOfficeService _officeservice;
        private readonly IMapper<EF, Office> _toResourceMapper;
        private readonly IMapper<Office, EF> _toTransportMapper;

        public OfficeApiService(IOfficeService officeService,IMapperFactory mapperFactory)
        {
            _officeservice = officeService;
            _toResourceMapper = mapperFactory.Create<EF, Office>();
            _toTransportMapper = mapperFactory.Create<Office, EF>();
        }

        public Task<ResourceCreationResult<Office, int>> CreateAsync(Office resource, IRequestContext context, CancellationToken cancellation)
        {
            var newOffice = _officeservice.Add(_toTransportMapper.Map(resource));
            return Task.FromResult(new ResourceCreationResult<Model.Office, int>(_toResourceMapper.Map(newOffice)));
        }

        public Task<Office> UpdateAsync(Office resource, IRequestContext context, CancellationToken cancellation)
        {
            var originalEmployee = _toResourceMapper.Map(_officeservice.GetOfficeById(resource.Id).Result);
            var resultEmployee = context.MergeResource(resource, originalEmployee);
            _officeservice.Update(_toTransportMapper.Map(resultEmployee));
            return Task.FromResult(resource);
        }

        public async Task<Office> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            return
                _toResourceMapper.Map(
                    await _officeservice.GetOfficeById(id));
        }

        public IEnumerable<Office> GetMany(IRequestContext context)
        {
            return _officeservice.GetAll()
                .Select(_toResourceMapper.Map);
        }
    }
}
