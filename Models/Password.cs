namespace PasswordOverview.Models;

public record Password(string TypePassword, string Name, string Passowrd) : IPassword
{
    public override string ToString()
    {
        return $"{Name}({TypePassword}) : { Passowrd} ";
    }
}
