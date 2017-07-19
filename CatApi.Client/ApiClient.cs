using CatApi.Client.Services;
using CatApi.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatApi.Client
{
    public class ApiClient : IApiClient
    {
        private CatApiService _catApiService;

        public ICatApiService CatApiService { get { return _catApiService ?? (_catApiService = new CatApiService()); } }
    }
}
