namespace Ninjato.Services;

public interface IObjectSerializer
{
    string Serialize<T>(T obj);
    T Deserialize<T>(string data);
}