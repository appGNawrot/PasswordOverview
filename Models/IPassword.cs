namespace PasswordOverview.Models;

public interface IPassword : IData
{
    string TypePassword { get; }
    string Name { get; }
    string Passowrd { get; }
}
