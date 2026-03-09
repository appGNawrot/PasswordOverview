using PasswordOverview.Models;

namespace PasswordOverview.Collections;

public class PasswordCollection : ICollection
{
    private List<IPassword> _Passwords { get; set; } = new();
    public IReadOnlyCollection<IData> Items => _Passwords.AsReadOnly();

    public void Add(IData data)
    {
        if ( data is not IPassword password)
            throw new ArgumentNullException("Password is null or invalid data");
        if (_Passwords.Contains(password))
            return;
        _Passwords.Add(password);
    }


    public void AddRange(IEnumerable<IData> data)
    {
        foreach (var item in data)
            Add(item);
    }


    public static PasswordCollection From(IEnumerable<IData> data)
    {
        var collection = new PasswordCollection();
        collection.AddRange(data);
        return collection;
    }
}
