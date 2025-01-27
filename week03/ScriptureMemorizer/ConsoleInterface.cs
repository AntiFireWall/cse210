namespace ScriptureMemorizer;

public class ConsoleInterface
{
    private static string _book;
    private static string _chapter;
    private static string _startVerse;
    private static string _endVerse;
    private static string _text;
    
    public static void Interface()
    {
        Reference reference = new Reference("Genesis", 1, 5);
        Scripture scripture = new Scripture(reference,
            "And God called the light Day, and the darkness he called Night. And the evening and the morning were the first day.");
        bool run = true;
        bool firstRun = true;
        Console.WriteLine("Wellcome to the Scripture Memorizer!");
        Console.WriteLine("Here is the scripture to memorize.");
        Console.WriteLine();
        while (!scripture.IsCompletelyHidden() && run)
        {
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("Press enter to hide words or write 'quit' to end the program.");
            string input = Console.ReadLine().ToLower();
            switch (input)
            {
                case "":
                {
                    scripture.HideRandomWords();
                    break;
                }
                case "quit":
                {
                    run = false;
                    break;
                }
                default:
                {
                    continue;
                }
            }
        }
        
    }
    public static async Task InterfaceWithApi()
    {
        
        bool run = true;
        bool gettingScripture = true;
        
        Console.WriteLine("Wellcome to the Scripture Memorizer!");
        while (gettingScripture)
        {
            Console.WriteLine("Enter the verse you want to memorize.");
            Console.WriteLine("(Make sure to enter the full name of the book, like '1+Nephi'. Also, put a '+' insted of space if there is a number before the book name)");
            Console.Write("Book: ");
            _book = Console.ReadLine().ToLower();
            Console.Write("Chapter: ");
            _chapter = Console.ReadLine();
            Console.Write("Start Verse: ");
            _startVerse = Console.ReadLine();
            Console.Write("End Verse(Press Enter to leave empty if needed): ");
            _endVerse = Console.ReadLine();
            _text = await GetScriptureApi.GetScripture(_book, _chapter, _startVerse, _endVerse);
            if (_text != "")
            {
                gettingScripture = false;
            }
            else
            {
                Console.WriteLine("Please enter a vaild scripture name.");
                Console.WriteLine();
            }
        }
        
        Reference reference;
        
        if (_endVerse == "")
        {
            reference = new Reference(_book.ToUpper(), int.Parse(_chapter), int.Parse(_startVerse));
        }
        else
        {
            reference = new Reference(_book.ToUpper(), int.Parse(_chapter), int.Parse(_startVerse), int.Parse(_endVerse));
        }
        
        Scripture scripture = new Scripture(reference, _text);
        bool isHidden;
        do
        {
            Console.Clear();
            isHidden = scripture.IsCompletelyHidden();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("Press enter to hide words or write 'quit' to end the program.");
            string input = Console.ReadLine().ToLower();
            switch (input)
            {
                case "":
                {
                    scripture.HideRandomWords();
                    break;
                }
                case "quit":
                {
                    run = false;
                    break;
                }
                default:
                {
                    continue;
                }
            }
        } while (!isHidden && run);

    }
}
