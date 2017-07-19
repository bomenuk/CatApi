using CatApi.Contracts;

namespace CatApi.Contracts
{
    public interface IApiClient
    {
        ICatApiService CatApiService { get; }
    }
}