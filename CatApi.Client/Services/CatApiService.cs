using CatApi.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CatApi.Client.Services
{
    public class CatApiService : ICatApiService
    {
        private readonly string _baseUri = "http://thecatapi.com/api/";
        private readonly string _catCategoryUri = "categories/list";
        private readonly string _catImageUri = "images/get?format=xml&results_per_page={0}&category={1}";

        private HttpClient client = new HttpClient();

        public CatApiService()
        {
            client.BaseAddress = new Uri(_baseUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
        }
        public XElement GetCategoryListXML()
        {
            XElement result = null;
            HttpResponseMessage response = client.GetAsync(_catCategoryUri).Result;
            if (response.IsSuccessStatusCode)
            {
                XDocument doc = XDocument.Load(response.Content.ReadAsStreamAsync().Result);
                result = doc.Root;
            }
            return result;
        }

        public XElement GetImageListXML(int pageCount, string categoryName)
        {
            XElement result = null;
            string uri = string.Format(_catImageUri, pageCount, categoryName);
            HttpResponseMessage response = client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                XDocument doc = XDocument.Load(response.Content.ReadAsStreamAsync().Result);
                result = doc.Root;
            }
            return result;
        }
    }
}
