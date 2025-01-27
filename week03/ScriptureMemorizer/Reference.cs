namespace ScriptureMemorizer;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _vers;
    private int _endVerse;

    public Reference(string book, int chapter, int vers)
    {
        _book = book;
        _chapter = chapter;
        _vers = vers;
    }

    public Reference(string book, int chapter, int startVers, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _vers = startVers;
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        if (_endVerse != 0)
        {
            return $"{_book} {_chapter}:{_vers}-{_endVerse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_vers}";
        }
    }
}