using System.Text.Json;
using System.Text.Json.Serialization;

public static class JsonFileUtils
{
    private static readonly JsonSerializerOptions _options =
        new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

    public static void SimpleWrite(object obj, string fileName)
    {
        var jsonString = JsonSerializer.Serialize(obj, _options);
        File.WriteAllText(fileName, jsonString);
    }

    public static void Utf8BytesWrite(object obj, string fileName)
    {
        var utf8Bytes = JsonSerializer.SerializeToUtf8Bytes(obj, _options);
        File.WriteAllBytes(fileName, utf8Bytes);
    }

    public static void StreamWrite(object obj, string fileName)
    {
        using var fileStream = File.Create(fileName);
        using var utf8JsonWriter = new Utf8JsonWriter(fileStream);
        JsonSerializer.Serialize(utf8JsonWriter, obj, _options);
    }
}

