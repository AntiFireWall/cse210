namespace Mindfulness;

public class ConsoleInterface
{
    public static void RunInterface()
    {
        BreathingActivity breathingActivity = new BreathingActivity();
        ListingActivity listingActivity = new ListingActivity();
        ReflectingActivity reflectingActivity = new ReflectingActivity();
        
        bool run = true;
        while (run)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Beging Breathing Activity");
            Console.WriteLine("  2. Beging Reflecting Activity");
            Console.WriteLine("  3. Beging Listing Activity");
            Console.WriteLine("  4. quit");
            Console.Write("Select one of the options(Enter the number of the option): ");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1": breathingActivity.Run(); break;
                case "2": reflectingActivity.Run(); break;
                case "3": listingActivity.Run(); break;
                case "4": run = false; break;
                default: Console.WriteLine("Please enter a valid option."); break;
            }
        }
    }
}