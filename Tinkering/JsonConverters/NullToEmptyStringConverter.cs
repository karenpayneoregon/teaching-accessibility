﻿#nullable enable
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tinkering.JsonConverters;

// https://www.conradakunga.com/blog/handling-null-and-empty-strings-with-system-text-json/
public class NullToEmptyStringConverter : JsonConverter<string>
{
    // Override default null handling
    public override bool HandleNull => true;
    // Check the type
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(string);
    }

    public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
    // 
    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    {
        if (value == null)
            writer.WriteStringValue("Null");
        else
            writer.WriteStringValue(value);
    }
}