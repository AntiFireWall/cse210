using System;
using ScriptureMemorizer;

class Program
{
    static async Task Main(string[] args)
    {
        // I add the ability to choose a verse from an api I found online (This tool HOURSE!!!!).
        // I also made the program hide words that are not hidden, meaning it will not attempt to hide hidden words.
        
        await ConsoleInterface.InterfaceWithApi();
    }
}