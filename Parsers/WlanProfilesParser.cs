using System.Text.RegularExpressions;

namespace PasswordOverview.Parsers;

public class WlanProfilesParser : ITextParser<string>
{
    IEnumerable<string> ITextParser<string>.Parse(string text)
    {
        var regex = new Regex(@"All User Profile\s*:\s*(.+)");
        return regex.Matches(text)
                    .Select(line => line?.Groups[1]?.Value?.Trim()??"") 
                    .Where(ssid => !string.IsNullOrEmpty(ssid));
    }
}
