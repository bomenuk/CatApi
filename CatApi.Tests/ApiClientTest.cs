using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CatApi.Client;
using System.Linq;

namespace CatApi.Tests
{
    [TestClass]
    public class ApiClientTest
    {
        [TestMethod]
        public void TestClientCanGetCategoryList()
        {
            ApiClient client = new ApiClient();
            var result = client.CatApiService.GetCategoryListXML();

            Assert.IsTrue(result.Descendants("category").Count() > 0);
        }

        [TestMethod]
        public void TestClientCanGetImageList()
        {
            ApiClient client = new ApiClient();
            var result = client.CatApiService.GetImageListXML(4, "hats");

            Assert.IsTrue(result.Descendants("image").Count() > 0);
        }
    }
}
