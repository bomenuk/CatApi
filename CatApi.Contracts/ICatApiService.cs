using System.Xml.Linq;

namespace CatApi.Contracts
{
    public interface ICatApiService
    {
        XElement GetCategoryListXML();
        XElement GetImageListXML(int pageCount, string categoryName);
    }
}