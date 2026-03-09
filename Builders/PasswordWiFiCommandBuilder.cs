using PasswordOverview.Commands;
using PasswordOverview.Consoles;
using PasswordOverview.Factories;
using PasswordOverview.Parsers;

namespace PasswordOverview.Builders;

public class PasswordWiFiCommandBuilder : ICommandBuilder
{
    private ITextParser<string>? _wlanProfilesParser;
    private ITextParser<string>? _wlanProfilePasswordParser;
    private IDataFactory<(string type, string name, string password)>? _passwordFactory;
    private IConsole? _console;
    private ICollectionFactory? _collectionFactory;

    public PasswordWiFiCommandBuilder WithWlanProfilesParser(ITextParser<string> parser)
    {
        _wlanProfilesParser = parser;
        return this;
    }

    public PasswordWiFiCommandBuilder WithWlanProfilePasswordParser(ITextParser<string> parser)
    {
        _wlanProfilePasswordParser = parser;
        return this;
    }

    public PasswordWiFiCommandBuilder WithPasswordFactory(IDataFactory<(string type, string name, string password)>? passwordFactory)
    {
        _passwordFactory = passwordFactory;
        return this;
    }

    public PasswordWiFiCommandBuilder WithConsole(IConsole console)
    {
        _console = console;
        return this;
    }

    public PasswordWiFiCommandBuilder WithCollectionFactory(ICollectionFactory collectionFactory)
    {
        _collectionFactory = collectionFactory;
        return this;
    }

    public ICommand Build()
    {
        if(_wlanProfilesParser is null)
            throw new InvalidOperationException("WLAN Profiles Parser is not set");
        if (_wlanProfilePasswordParser is null)
            throw new InvalidOperationException("Password Parser is not set");
        if (_passwordFactory is null)
            throw new InvalidOperationException("Factory password is not set");
        if (_console is null)
            throw new InvalidOperationException("Console is not set");
        if (_collectionFactory is null)
            throw new InvalidOperationException("CollectionFactory is not set");

        return new PasswordWiFiCommand(
            _console,
            _wlanProfilesParser,
            _wlanProfilePasswordParser,
            _passwordFactory,
            _collectionFactory
        );
    }

   
}
