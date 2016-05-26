using IQ.Platform.Framework.WebApi;
using BeerTap.Model;

namespace BeerTap.ApiServices.Interface
{
    public interface IEmployeeTapApiService :
         IUpdateAResourceAsync<EmployeeTap, int>
    {
    }
}
