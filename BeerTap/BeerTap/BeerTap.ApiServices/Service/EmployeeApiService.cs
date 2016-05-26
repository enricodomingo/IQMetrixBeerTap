using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BeerTap.ApiServices.Interface;
using BeerTap.Facade.Controller;
using BeerTap.Model;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.Common.Mapping;
using IQ.Platform.Framework.WebApi;
using IQ.Platform.Framework.WebApi.Services.Mapping;
using EF = BeerTap.Facade.Model.Employee;
namespace BeerTap.ApiServices.Service
{
    public class EmployeeApiService : IEmployeeApiService
    {
        private readonly IEmployeeService  _employeeService;
        private readonly IMapper<EF, Employee> _toResourceMapper;

        public EmployeeApiService(IEmployeeService employeeService, IMapperFactory mapperFactory)
        {
            _employeeService = employeeService;
            _toResourceMapper = mapperFactory.Create<EF, Employee>();
        }
        public Task<ResourceCreationResult<Employee, int>> CreateAsync(Employee resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            var officeId = context.UriParameters.GetByName<int>("OfficeID").EnsureValue();
            var linkParameter = new EmployeeLinkParameter(officeId);
            context.LinkParameters.Set(linkParameter);

            return
            _toResourceMapper.Map(
                await _employeeService.GetEmployeeById(id, officeId));
        }

        public IEnumerable<Employee> GetMany(IRequestContext context)
        {
            var officeId = context.UriParameters.GetByName<int>("OfficeID").EnsureValue();
            var linkParameter = new EmployeeLinkParameter(officeId);
            context.LinkParameters.Set(linkParameter);

            return _employeeService.GetAll(officeId)
                .Select(_toResourceMapper.Map);
        }

        public Task<Employee> UpdateAsync(Employee resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
