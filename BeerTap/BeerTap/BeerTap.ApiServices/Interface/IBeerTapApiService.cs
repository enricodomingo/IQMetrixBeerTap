
using IQ.Platform.Framework.WebApi;
using BeerTap.Model;

namespace BeerTap.ApiServices.Interface
{
    public interface IBeerTapApiService :
        IGetAResourceAsync<Model.Beer, int>,
        IGetManyOfAResource<Model.Beer, int>,
        ICreateAResourceAsync<Model.Beer, int>,
        IUpdateAResourceAsync<Model.Beer, int>
    {
      
    }
}
