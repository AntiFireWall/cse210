namespace Journal;

public class PromptGenerator
{
    public static List<string> _prompts = ["What are you grateful for today?",
                                           "What was most interesting thing that happaned today?",
                                           "How were you kind to other people?",
                                           "What weired thing did you find?",
                                           "What did the Spirit tell you today?",
                                           "What did you talk about with you friend?",
                                           "What was the best part of my day?",
                                           "If I had one thing I could do over today, what would it be?"];

    public static string GetRandomPrompt()
    {
        Random rnd = new Random();
        return _prompts[rnd.Next(_prompts.Count)];
    }

}                               