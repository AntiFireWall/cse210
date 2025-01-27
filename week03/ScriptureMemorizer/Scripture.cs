namespace ScriptureMemorizer;

public class Scripture
{
    private Reference _reference;
    public List<Word> _words = new List<Word>();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        var verse = text.Split($" ");
        for (int number = 0; number < verse.Length; number++)
        {
            Word word = new Word(verse[number], number);
            _words.Add(word);
        }
    }

    public void HideRandomWords()
    {
        Random rnd = new Random();
        List<Word> shownWords = _words.Where(word => !word.IsHidden()).ToList();
        if (shownWords.Count < 3)
        {
            for (int i = 0; i <= shownWords.Count; i++)
            {
                int order = shownWords[rnd.Next(0, shownWords.Count - 1)].OrderNumber();
                _words[order].Hide();
                shownWords = _words.Where(word => !word.IsHidden()).ToList();
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                int order = shownWords[rnd.Next(0, shownWords.Count - 1)].OrderNumber();
                _words[order].Hide();
                shownWords = _words.Where(word => !word.IsHidden()).ToList();
            }
        }

    }

    public string GetDisplayText()
    {
        string fullText = "";
        foreach (Word word in _words)
        {
            fullText += $"{word.GetDisplayText()} ";
        }
        return $"{_reference.GetDisplayText()}: {fullText}";
    }

    public bool IsCompletelyHidden()
    {
        int isHidden = 0;
        foreach (Word word in _words)
        {
            if (word.IsHidden())
            {
                isHidden++;
            }
        }
        return isHidden == _words.Count;
    }
    
    
    
}