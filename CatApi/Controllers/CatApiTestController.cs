using CatApi.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CatApi.Contracts.ConvertibleObjects;

namespace CatApi.Controllers
{
    public class CatApiTestController : Controller
    {
        private readonly IXMLToObjectConvertor _xmlToObjectConvertor;
        private readonly IApiClient _apiClient;

        public CatApiTestController(IXMLToObjectConvertor xmlToObjectConvertor, IApiClient apiClient)
        {
            _xmlToObjectConvertor = xmlToObjectConvertor;
            _apiClient = apiClient;
        }

        public ActionResult Index()
        {
            var categories = new List<category>();

            foreach(var tempCategory in _apiClient.CatApiService.GetCategoryListXML().Descendants("category"))
            {
                categories.Add(_xmlToObjectConvertor.Deserialize<category>(tempCategory.ToString()));
            }            

            return View(categories);
        }

        public ActionResult GetImagesViaCategory(category category)
        { 
            var images = new List<image>();

            foreach(var tempImage in _apiClient.CatApiService.GetImageListXML(3, category.name).Descendants("image"))
            {
                images.Add(_xmlToObjectConvertor.Deserialize<image>(tempImage.ToString()));
            }    

            return View(images);
        }
    }
}