using PasswordOverview.Collections;

namespace PasswordOverview.Commands;
public interface ICommand
{
    ICollection Run();
}
