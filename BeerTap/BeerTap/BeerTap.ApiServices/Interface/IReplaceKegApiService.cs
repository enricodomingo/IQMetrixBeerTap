using BeerTap.Model;
using IQ.Platform.Framework.WebApi;

namespace BeerTap.ApiServices.Interface
{
    public interface IReplaceKegApiService :
         IUpdateAResourceAsync<ReplaceKeg, int>
    {
    }
}
