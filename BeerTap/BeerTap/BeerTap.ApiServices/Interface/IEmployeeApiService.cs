
using IQ.Platform.Framework.WebApi;
using BeerTap.Model;

namespace BeerTap.ApiServices.Interface
{
    public interface IEmployeeApiService :
        IGetAResourceAsync<Employee, int>,
        IGetManyOfAResource<Employee, int>,
        ICreateAResourceAsync<Employee, int>,
        IUpdateAResourceAsync<Employee, int>
    {

    }
}
