using PasswordOverview.Collections;
using PasswordOverview.Models;

namespace PasswordOverview.Factories;

public class PasswordCollectionFactory : ICollectionFactory
{
    public ICollection From(IEnumerable<IData> items)
    {
        var collection = new PasswordCollection();
        collection.AddRange(items);
        return collection;
    }
}
