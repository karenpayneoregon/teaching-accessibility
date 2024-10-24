#nullable enable
namespace Tinkering.Classes;
public static class StringExtensions
{
    /// <summary>
    /// Converts the first character of the given string to lowercase if it is not already lowercase.
    /// </summary>
    /// <param name="sender">The input string whose first character is to be converted to lowercase.</param>
    /// <returns>
    /// A new string with the first character converted to lowercase if the original first character was uppercase;
    /// otherwise, returns the original string.
    /// </returns>
    public static string? FirstCharacterToLowerCase(this string? sender)
    {
        if (!string.IsNullOrEmpty(sender) && !char.IsUpper(sender[0]))
        {
            return sender.Length == 1 ?
                char.ToUpper(sender[0]).ToString() :
                $"{char.ToUpper(sender[0])}{sender[1..]}";
        }

        return sender;
    }

    /// <summary>
    /// Converts the first character of the given string to uppercase.
    /// </summary>
    /// <param name="sender">The input string.</param>
    /// <returns>
    /// A new string with the first character converted to uppercase 
    /// </returns>
    public static string CapitalizeFirstLetter(this string sender) 
        => string.IsNullOrEmpty(sender) ? sender : char.ToUpper(sender[0]) + sender[1..];
}

