using System;
using Journal;


class Program
{
    static void Main(string[] args)
    {
        ConsoleInterface.Interface();
        
        // I added a few things
        // 1. When the user wants to save the entries and uses a file name that already exists the program will ask if the user wants to override the file.
        // 2. When the user tries to load a file that doesn't exist the program will tell them to try a different one.
        // 3. The user can make an entry with a custom prompt that they can enter in.
    }
}