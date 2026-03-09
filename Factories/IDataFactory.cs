using PasswordOverview.Models;

namespace PasswordOverview.Factories;

public interface IDataFactory<T>
{
    IData Create(T input);
}
