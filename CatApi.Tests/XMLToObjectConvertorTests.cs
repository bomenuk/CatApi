using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CatApi.Business;
using CatApi.Contracts.ConvertibleObjects;
using System.Xml.Linq;
using System.Collections.Generic;

namespace CatApi.Tests
{
    [TestClass]
    public class XMLToObjectConvertorTests
    {
        private readonly string _categoryXml = @"<response><data><categories><category><id>1</id><name>hats</name></category></categories></data></response>";
        private readonly string _imageXml = "<response><data><images><image><url>http://image.jpg</url><id>5if</id><source_url>http://thecatapi.com/?id=5if</source_url></image>"
            + "<image><url>http://image2.jpg</url><id>3if</id><source_url>http://thecatapi.com/?id=3if</source_url></image></images></data></response>";

        [TestMethod]
        public void ConvertXMLToCategoryObject()
        {
            XMLToObjectConvertor convertor = new XMLToObjectConvertor();
            XDocument xDoc = XDocument.Parse(_categoryXml);

            List<category> categories = new List<category>();
            foreach(var xmlCategory in xDoc.Descendants("category"))
            {
                categories.Add(convertor.Deserialize<category>(xmlCategory.ToString()));
            }

            Assert.AreEqual(categories.Count, 1);
            Assert.AreEqual(categories[0].name, "hats");
        }

        [TestMethod]
        public void ConvertXMLToImageList()
        {
            XMLToObjectConvertor convertor = new XMLToObjectConvertor();
            XDocument xDoc = XDocument.Parse(_imageXml);

            List<image> images = new List<image>();
            foreach (var xmlImage in xDoc.Descendants("image"))
            {
                images.Add(convertor.Deserialize<image>(xmlImage.ToString()));
            }

            Assert.AreEqual(images.Count, 2);
            Assert.AreEqual(images[0].id, "5if");
            Assert.AreEqual(images[0].url, "http://image.jpg");
            Assert.AreEqual(images[0].source_url, "http://thecatapi.com/?id=5if");
            Assert.AreEqual(images[1].id, "3if");
            Assert.AreEqual(images[1].url, "http://image2.jpg");
            Assert.AreEqual(images[1].source_url, "http://thecatapi.com/?id=3if");
        }
    }
}
