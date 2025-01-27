namespace ScriptureMemorizer;

public class ConsoleInterface
{
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
        string book;
        string chapter;
        string startVerse;
        string endVerse;
        string text;
        
        bool run = true;
        bool gettingScripture = true;
        
        Console.WriteLine("Wellcome to the Scripture Memorizer!");
        while (gettingScripture)
        {
            Console.WriteLine("Enter the verse you want to memorize.");
            Console.WriteLine("(Make sure to enter the full name of the book, like '1+Nephi'. Also, put a '+' insted of space if there is a number before the book name)");
            Console.Write("Book: ");
            book = Console.ReadLine().ToLower();
            Console.Write("Chapter: ");
            chapter = Console.ReadLine();
            Console.Write("Start Verse: ");
            startVerse = Console.ReadLine();
            Console.Write("End Verse(Press Enter to leave empty if needed): ");
            endVerse = Console.ReadLine();
            text = await GetScriptureApi.GetScripture(book, chapter, startVerse, endVerse);
            if (text != "")
            {
                gettingScripture = false;
            }
            else
            {
                Console.WriteLine("Please enter a vaild scripture name.");
                Console.WriteLine();
            }
        }
        
            
    }
}