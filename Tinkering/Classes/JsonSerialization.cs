#nullable enable
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
namespace Tinkering.Classes;

/// <summary>
/// Provides methods for serializing and deserializing objects to and from JSON format.
/// Base code from David McCarter
/// https://github.com/RealDotNetDave/dotNetTips.Spargine/blob/main/source/6/dotNetTips.Spargine.6.Core/Serialization/JsonSerialization.cs
/// </summary>
public static class JsonSerialization
{
    /// <summary>
    /// Converts a file name to a <see cref="FileInfo"/> object.
    /// </summary>
    /// <param name="fileName">The name of the file to convert.</param>
    /// <returns>A <see cref="FileInfo"/> object representing the specified file name.</returns>
    public static FileInfo ToFileInfo(string fileName) => new(fileName);

    /// <summary>
    /// Serializes the specified object to a JSON file.
    /// </summary>
    /// <param name="obj">The object to serialize. This parameter cannot be null.</param>
    /// <param name="file">The path of the file where the JSON representation of the object will be saved. This parameter cannot be null.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="obj"/> or <paramref name="file"/> is null.</exception>
    /// <exception cref="IOException">Thrown when an I/O error occurs while writing to the file.</exception>
    /// <remarks>
    /// If the directory specified in the <paramref name="file"/> path does not exist, it will be created.
    /// </remarks>
    public static void SerializeToFile([NotNull] object obj, [NotNull] string file)
    {
        var fileInfo = ToFileInfo(file);

        if (fileInfo.Directory?.Exists == false)
        {
            fileInfo.Directory?.Create();
        }

        File.WriteAllText(fileInfo.FullName, JsonSerializer.Serialize(obj));

    }

    /// <summary>
    /// Serializes the specified object to a JSON file.
    /// </summary>
    /// <param name="obj">The object to serialize. This parameter cannot be null.</param>
    /// <param name="file">The <see cref="FileInfo"/> object representing the file where the JSON representation of the object will be saved. This parameter cannot be null.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="obj"/> or <paramref name="file"/> is null.</exception>
    /// <exception cref="IOException">Thrown when an I/O error occurs while writing to the file.</exception>
    /// <remarks>
    /// If the directory specified in the <paramref name="file"/> path does not exist, it will be created.
    /// </remarks>
    public static void SerializeToFile([NotNull] object obj, [NotNull] FileInfo file)
    {
        
        if (file.Directory?.Exists == false)
        {
            file.Directory?.Create();
        }

        File.WriteAllText(file.FullName, JsonSerializer.Serialize(obj));
    }

    /// <summary>
    /// Deserializes an object of type <typeparamref name="T"/> from a JSON file.
    /// </summary>
    /// <typeparam name="T">The type of the object to deserialize. This type must be a reference type.</typeparam>
    /// <param name="fileName">The name of the file containing the JSON representation of the object. This parameter cannot be null.</param>
    /// <returns>An instance of type <typeparamref name="T"/> deserialized from the JSON file.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="fileName"/> is null.</exception>
    /// <exception cref="FileNotFoundException">Thrown when the specified file does not exist.</exception>
    /// <exception cref="JsonException">Thrown when the JSON is invalid or cannot be deserialized to an instance of type <typeparamref name="T"/>.</exception>
    /// <exception cref="IOException">Thrown when an I/O error occurs while reading the file.</exception>
    public static T DeserializeFromFile<T>([NotNull] string fileName) where T : class
    {
        var jsonString = File.ReadAllText(fileName);
        return JsonSerializer.Deserialize<T>(jsonString)!;
    }
}