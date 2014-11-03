using fastJSON;

namespace Common.Lib.Json
{
  public class JsonHelper<T> where T : class
  {
    public string Serialize(T entity)
    {
      return JSON.ToJSON(entity);
    }

    public T Deserialize(string stringData)
    {
      return JSON.ToObject<T>(stringData);
    }
  }
}
