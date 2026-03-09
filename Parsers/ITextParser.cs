namespace PasswordOverview.Parsers;

public interface ITextParser<T>
{
    IEnumerable<T> Parse(string text);
}
