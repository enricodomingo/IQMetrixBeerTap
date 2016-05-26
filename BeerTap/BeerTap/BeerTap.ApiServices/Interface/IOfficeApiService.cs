using BeerTap.Model;
using IQ.Platform.Framework.WebApi;

namespace BeerTap.ApiServices.Interface
{
    public interface IOfficeApiService :
        IGetAResourceAsync<Office, int>,
        IGetManyOfAResource<Office, int>,
        ICreateAResourceAsync<Office, int>,
        IUpdateAResourceAsync<Office, int>
    {
    }
}
