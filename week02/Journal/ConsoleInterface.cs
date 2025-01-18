namespace Journal;

public class ConsoleInterface
{
    public static void Interface()
    {
        bool continueRunning = true;
        bool firstLoop = true;
        while (continueRunning)
        {
            if (firstLoop)
            {
                Console.WriteLine("Welcome to the Journal Program!");
                firstLoop = false;
            }
            Console.Write($"Select one of the following choices: \n"+ 
                              $"1) Write \n"+
                              $"2) Display \n"+
                              $"3) Load file \n"+
                              $"4) Save to file \n"+
                              $"5) Custom prompt \n"+
                              $"6) Exit \n"+
                              $"What do you want to do?(Enter the number of your choice) ");
            string choice = Console.ReadLine().ToLower();
            Console.WriteLine();

            switch (choice)
            {
                case "1" or "write":
                    Entry entry = new Entry();
                    JournalClass.AddEntry(entry);
                    Console.WriteLine();
                    break;
                case "2" or "display":   
                    JournalClass.DisplayAllEntries();
                    Console.WriteLine();
                    break;
                case "3" or "load file":
                    Console.Write("Enter file name to load: ");
                    string fileNameForLoad = Console.ReadLine();
                    JournalClass.LoadFromFile(fileNameForLoad);
                    Console.WriteLine();
                    break;
                case "4" or "save to file":
                    Console.Write("Enter a file name: ");
                    string fileName = Console.ReadLine();
                    JournalClass.SaveToFile(fileName);
                    Console.WriteLine();
                    break;
                case "5" or "custom prompt":
                    Entry entry1 = new Entry();
                    JournalClass.AddCustomeEntry(entry1);
                    Console.WriteLine();
                    break;
                case "6" or "exit":
                    continueRunning = false;
                    break;
                default:
                    Console.WriteLine("Please enter a valid choice.");
                    Console.WriteLine();
                    break;
            }

        }
    }
}