using PasswordOverview.Collections;
using PasswordOverview.Consoles;
using PasswordOverview.Factories;
using PasswordOverview.Models;
using PasswordOverview.Parsers;

namespace PasswordOverview.Commands;

public class PasswordWiFiCommand : ICommand
{
    private readonly IConsole _console;
    private readonly ITextParser<string> _wlanProfilesParser;
    private readonly ITextParser<string> _wlanProfilePasswordParser;
    private readonly IDataFactory<(string type, string name, string password)> _factoryPassword;
    private readonly ICollectionFactory _collectionFactory;
    public PasswordWiFiCommand(IConsole console, ITextParser<string> wlanProfilesParser, ITextParser<string> wlanProfilePasswordParser, 
        IDataFactory<(string type, string name, string password)> factoryPassword, ICollectionFactory collectionFactory)
        => (_console, _wlanProfilesParser, _wlanProfilePasswordParser, _factoryPassword, _collectionFactory) 
            = (console, wlanProfilesParser, wlanProfilePasswordParser, factoryPassword, collectionFactory);
    
    public ICollection Run()
    {
        var consoleResult = _console.Run("netsh wlan show profiles");
        var wlanProfiles = _wlanProfilesParser.Parse(consoleResult??"");
        return _collectionFactory.From(GetPasswords(wlanProfiles));
    }



    private IEnumerable<IData> GetPasswords(IEnumerable<string> wlanProfiles)
    {
        foreach (var wlanProfile in wlanProfiles)
        {
            var consoleResult = _console.Run($"netsh wlan show profile name=\"{wlanProfile}\" key=clear");
            var passwords = _wlanProfilePasswordParser.Parse(consoleResult);
            if (passwords != null && passwords.Any())
                yield return _factoryPassword.Create(("WiFi", wlanProfile, passwords.First()));  
        }
    }

}
