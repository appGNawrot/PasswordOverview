using PasswordOverview.Models;

namespace PasswordOverview.Factories;

public class PasswordFactory : IDataFactory<(string type, string name, string password)>
{
    public IData Create((string type, string name, string password) input)
        => new Password(input.type, input.name, input.password);
    
}
