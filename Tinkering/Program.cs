#nullable enable
using Spectre.Console.Json.Syntax;
using System.Text.Json;
using System.Text.Json.Serialization;
using Tinkering.Classes;
using Tinkering.JsonConverters;
using Tinkering.Models;

// ReSharper disable InterpolatedStringExpressionIsNotIFormattable

namespace Tinkering;
internal partial class Program
{
    // ...

    static async Task Main(string[] args)
    {
        await Setup();
        //AppSettingExample();

        string json =
            """
            [
              {
                "Id": 1,
                "FirstName": "jose",
                "LastName": "fernandez",
                "BirthDate": "1985-01-01"
              },
              {
                "Id": 2,
                "FirstName": "Miguel",
                "LastName": "lopez",
                "BirthDate": "1970-12-04"
              },
              {
                "Id": 3,
                "FirstName": "angel",
                "LastName": "perez",
                "BirthDate": "1980-09-11"
              }
            ]
            """;
        var people = JsonSerializer.Deserialize<List<Person>>(json, Options);



        Console.ReadLine();

    }

    private static JsonSerializerOptions Options =>
        new()
        {
            WriteIndented = true
        };

    private static void DayLight()
    {
        var (localTime, isDaylightSaving) = DisplayDateTimeWithDaylightSavingCheck();

        Console.WriteLine($"{localTime:dddd, MMMM dd, yyyy h:mm:ss tt} " +
                          $"(DST: {isDaylightSaving.ToYesNo()})");

        //SerializeAndDeserializeItems();
    }

    private static void SerializeAndDeserializeItems()
    {
        List<Item> items =
        [
            new() { Id = 1,Name  = "100"},
            new() { Id = 2,Name  = "100"},
            new() { Id = 3,Name  = "100" }
        ];

        string json = JsonSerializer.Serialize(items, Options1);

        PresentJson(json);

        Console.WriteLine();
        int myInt = JsonSerializer.Deserialize<int>(@"""1""", Options1);

        var options = new JsonSerializerOptions
        {
            Converters =
            {
                new ForgivingStringConverter(),
                new NullToEmptyStringConverter()
            },
        };
        //var result = JsonSerializer.Deserialize<MyPoco>("""{ "Value" : "12" }""", options);
        var test = new AnotherItem();
        var json1 = JsonSerializer.Serialize(test, Options2);
        PresentJson(json1);
        Console.WriteLine();
        var result1 = JsonSerializer.Deserialize<AnotherItem>(json1, Options2);
        //Console.WriteLine(result.Value);
    }

    private static JsonSerializerOptions Options1 =>
        new()
        {
            WriteIndented = true, 
            Converters =
            {
                new IntToStringConverter()
            }
        };
    private static JsonSerializerOptions Options2 =>
        new()
        {
            Converters =
            {
                new ForgivingStringConverter(),
                new NullToEmptyStringConverter()
            },
        };

    private static void Parenthesized<T>(T value)
    {
        if (value is not (float or double)) return;
        Console.WriteLine(value);
    }

    private static void AppSettingExample()
    {
        AnsiConsole.MarkupLine($"[{Color.Aqua}]GetLogOptions().Use[/]: {AppSettings.GetLogOptions().Use}");
        AnsiConsole.MarkupLine($"[{Color.Aqua}]AppSettings.GetLogOptions().Destination[/]: {AppSettings.GetLogOptions().Destination}");
    }
}

    public class Item
    {
        [JsonConverter(typeof(IntToStringConverter))]
        public int Id { set; get; }
        public string? Name { set; get; }
    }

    public class AnotherItem
    {
        public string? Value { get; set; }
    }
