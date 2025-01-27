using System;
using ScriptureMemorizer;

class Program
{
    static async Task Main(string[] args)
    {
        // await ConsoleInterface.InterfaceWithApi();
        string test = await GetScriptureApi.GetScripture("Genesis", "1", "1", "2");
        Console.WriteLine(test);
    }
}