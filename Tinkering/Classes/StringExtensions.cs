namespace Tinkering.Classes;
public static class StringExtensions
{
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
}

