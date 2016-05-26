using System;
using System.Threading;
using System.Threading.Tasks;
using BeerTap.ApiServices.Interface;
using BeerTap.Facade.Controller;
using BeerTap.Model;
using IQ.Platform.Framework.WebApi;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.Common.Mapping;
using EF = BeerTap.Facade.Model.Beer;
using System.Collections.Generic;

namespace BeerTap.ApiServices.Service
{
    public class EmployeeTapApiService : IEmployeeTapApiService
    {
        private readonly IEmployeeTapService _iEmployeeTapService;
       // private readonly IMapper<EF, Model.BeerTap> _toResourceMapper;

        public EmployeeTapApiService(IEmployeeTapService iEmployeeTapService)
        {
            _iEmployeeTapService = iEmployeeTapService;
           // _toResourceMapper = toResourceMapper;
        }

        public Task<EmployeeTap> UpdateAsync(EmployeeTap resource, IRequestContext context, CancellationToken cancellation)
        {
            var officeId = context.UriParameters.GetByName<int>("OfficeID").EnsureValue();
            var beerId = context.UriParameters.GetByName<int>("Id").EnsureValue();

            var employeeId = resource.EmployeeId;
            resource.OfficeId = officeId;
            
            var linkParameter = new EmployeeTapLinkParameter(officeId, beerId);
            context.LinkParameters.Set(linkParameter);

             _iEmployeeTapService.UpdateTap(officeId, beerId, employeeId);

            return Task.FromResult(resource);
        }
    }
}
