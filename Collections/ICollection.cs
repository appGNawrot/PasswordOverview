using PasswordOverview.Models;

namespace PasswordOverview.Collections;

public interface ICollection
{
    IReadOnlyCollection<IData> Items { get; }
    void Add(IData data);
    void AddRange(IEnumerable<IData> data);
}
