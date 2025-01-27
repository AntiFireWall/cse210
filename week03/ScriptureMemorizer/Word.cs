namespace ScriptureMemorizer;

public class Word
{
    private string _textActual;
    private string _textDisplay;
    private bool _isHidden;
    private int _orderNumber;

    public Word(string text, int orderNumber)
    {
        _textActual = text;
        _orderNumber = orderNumber;
        _textDisplay = text;
    }

    public void Hide()
    {
        if (!_isHidden)
        {
            _textDisplay = "";
            foreach (char letter in _textActual)
            {
                if (letter == ',' || letter == ':' || letter == '.' || letter == '(' || letter == ')' ||
                    letter == '"' || letter == '?' || letter == '!' || letter == ';')
                {
                    _textDisplay += letter;
                }
                else
                {
                    _textDisplay += "_";   
                }
            }
            _isHidden = true;
        }
    }

    public void Show()
    {
        _isHidden = false;
        _textDisplay = _textActual;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public int OrderNumber()
    {
        return _orderNumber;
    }

    public string GetDisplayText()
    {
        return _textDisplay;
    }
}