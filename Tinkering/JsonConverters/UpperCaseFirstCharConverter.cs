using System.Text.Json;
using System.Text.Json.Serialization;
using Tinkering.Classes;

namespace Tinkering.JsonConverters;


public class UpperCaseFirstCharConverter : JsonConverter<string>
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(string);
    }

    public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return (reader.GetString() ?? string.Empty).CapitalizeFirstLetter();
    }

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value ?? "Null");
    }
}