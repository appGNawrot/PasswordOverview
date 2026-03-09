using System.Text.RegularExpressions;

namespace PasswordOverview.Parsers;

public class WlanProfilePasswordParser : ITextParser<string>
{
    public IEnumerable<string> Parse(string text)
    {
        var regex = new Regex(@"Key Content\s*:\s*(.+)");
        return regex.Matches(text)
                    .Select(line => line?.Groups[1]?.Value?.Trim() ?? "")
                    .Where(password => !string.IsNullOrEmpty(password));
    }
}
