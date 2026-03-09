using PasswordOverview.Builders;
using PasswordOverview.Commands;
using PasswordOverview.Consoles;
using PasswordOverview.Factories;
using PasswordOverview.Parsers;

Console.WriteLine("Hi, it's your passwords on your computer:");

ICommandBuilder? builder;

builder = new PasswordWiFiCommandBuilder()
    .WithWlanProfilePasswordParser(new WlanProfilePasswordParser())
    .WithWlanProfilesParser(new WlanProfilesParser())
    .WithCollectionFactory(new PasswordCollectionFactory())
    .WithConsole(new WindowsConsole())
    .WithPasswordFactory(new PasswordFactory());

var resultPasswordWiFi = new CommandInvoker().Run(builder.Build());
if(resultPasswordWiFi is not null)
    foreach (var item in resultPasswordWiFi.Items)
    {
        Console.WriteLine(item);
    }