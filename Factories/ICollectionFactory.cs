using PasswordOverview.Collections;
using PasswordOverview.Models;

namespace PasswordOverview.Factories;

public interface ICollectionFactory
{
    ICollection From(IEnumerable<IData> items);
}