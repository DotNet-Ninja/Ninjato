using YamlDotNet.Serialization;

namespace Ninjato.Services;

public class YamlObjectSerializer: IObjectSerializer
{
    private readonly ISerializer _serializer;
    private readonly IDeserializer _deserializer;

    public YamlObjectSerializer(ISerializer serializer, IDeserializer deserializer)
    {
        _serializer = serializer;
        _deserializer = deserializer;
    }

    public string Serialize<T>(T obj)
    {
        if(obj == null)
        {
            throw new ArgumentNullException(nameof(obj));
        }
        return _serializer.Serialize(obj);
    }

    public T Deserialize<T>(string data)
    {
        if(string.IsNullOrWhiteSpace(data))
        {
            throw new ArgumentNullException(nameof(data));
        }
        return _deserializer.Deserialize<T>(data);
    }
}