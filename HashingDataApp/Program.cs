
using HashingDataApp.Classes;
using System.Text.Json;

namespace HashingDataApp;
internal partial class Program
{
    static async Task Main(string[] args)
    {
        await Setup();

        // The user enters their username and password
        var userEnteredName = "John";
        var password = "!john@Coffee*Today";

        var user = MockedData.Deserialize().FirstOrDefault(x => x.Username == userEnteredName);
        if (user != null)
        {
            var isAuthenticated = BC.EnhancedVerify(password, user.HashedPassword);
            Console.WriteLine(isAuthenticated ? "Authenticated" : "Not authenticated");
        }
        else
        {
            Console.WriteLine("User does not exist");
        }
  

        ExitPrompt();
    }

    private static void HashAndVerifyPassword1()
    {
        string password = "Secret Password";
        string passwordHash = BC.EnhancedHashPassword(password, 13);

        Console.WriteLine(BC.EnhancedVerify("Secret Password", passwordHash));
    }

    private static void HashAndVerifyPassword3()
    {
        const string mockedPassword = "!duke@Coffee*Today";
        var passwordHash = BC.HashPassword(mockedPassword);
        var verified = BC.Verify(mockedPassword, passwordHash);

        Console.WriteLine(verified ? "Verified" : "Not verified");
    }
}

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string HashedPassword { get; set; }
}

public class MockedData
{
    public static List<User> Users =>
    [
        new User { Username = "Duke", Password = "!duke@Coffee*Today" },
        new User { Username = "John", Password = "!john@Coffee*Today" },
        new User { Username = "Jane", Password = "!jane@Coffee*Today" }
    ];

    public static List<User> Secure()
    {
        List<User> users = MockedData.Users;
        foreach (var user in users)
        {
            user.HashedPassword = BC.EnhancedHashPassword(user.Password,13);
        }
        return users;
    }

    public static void Serialize()
    {
        var secureUsers = Secure();
        var json = JsonSerializer.Serialize(secureUsers, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("secureUsers.json", json);
    }
    public static List<User> Deserialize()
    {
        var json = File.ReadAllText("secureUsers.json");
        return JsonSerializer.Deserialize<List<User>>(json);
    }
}