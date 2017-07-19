namespace CatApi.Contracts
{
    public interface IXMLToObjectConvertor
    {
        T Deserialize<T>(string input) where T : class;
    }
}