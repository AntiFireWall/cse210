namespace Journal;
using System.IO;

public class JournalClass
{
    public static List<Entry> _entries = new();
    
    public static void AddEntry(Entry entry)
    {
        string prompt = PromptGenerator.GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Entry: ");
        string entryText = Console.ReadLine();
        DateTime currentDate = DateTime.Now;
        entry._date = currentDate.ToShortDateString();
        entry._promptText = prompt;
        entry._entryText = entryText;
        _entries.Add(entry);
    }

    public static void AddCustomeEntry(Entry entry)
    {
        Console.Write($"Prompt: ");
        string prompt = Console.ReadLine();
        Console.Write("Entry: ");
        string entryText = Console.ReadLine();
        DateTime currentDate = DateTime.Now;
        entry._date = currentDate.ToShortDateString();
        entry._promptText = prompt;
        entry._entryText = entryText;
        _entries.Add(entry);
    }

    public static void DisplayAllEntries()
    {
        if (_entries.Count > 0)
        {
            foreach (Entry entry in _entries)
            {
                entry.Display();
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("No journal entries yet.");
        }
    }

    public static void SaveToFile(string filename)
    {
        string defaultPath = "C:/Users/menq/Documents/BYU/cse210/week02/Journal/";
        bool overrideFile = true;
        if (File.Exists(defaultPath + filename + ".txt"))
        {
            Console.WriteLine();
            Console.WriteLine("File name does not exist. Do you wish to override it?(Y/N) ");
            string answer = Console.ReadLine().ToUpper();
            overrideFile = answer == "Y";
        }
        if (overrideFile)
        {
            StreamWriter outputFile = new StreamWriter($"{defaultPath}{filename}.txt");
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
            }
            outputFile.FlushAsync();
            outputFile.Close();
        
            Console.WriteLine($"The file is saved at: {defaultPath}{filename}.txt");
        }
    }

    public static void LoadFromFile(string filename)
    {
        string defaultPath = "C:/Users/menq/Documents/BYU/cse210/week02/Journal/";
        if (!File.Exists(defaultPath + filename + ".txt"))
        {
            Console.WriteLine("File name does not exist. Please try another name.");
        }
        else
        {
            string[] lines = System.IO.File.ReadAllLines($"{defaultPath}{filename}.txt");

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                Entry loadedEntry = new Entry();
                loadedEntry._date = parts[0];
                loadedEntry._promptText = parts[1];
                loadedEntry._entryText = parts[2];
                _entries.Add(loadedEntry);
            }

            Console.WriteLine("Entries loaded from file!");
        }
    }
    
    
}