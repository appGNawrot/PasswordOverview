using PasswordOverview.Commands;

namespace PasswordOverview.Builders;

public interface ICommandBuilder
{
    ICommand Build();
}
