using PasswordOverview.Collections;
namespace PasswordOverview.Commands;

public class CommandInvoker
{
    public ICollection? Run(ICommand command)
        => command?.Run(); 
}
