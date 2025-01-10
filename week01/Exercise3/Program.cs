using System;

class Program
{
    static void Main(string[] args)
    {
        bool playAgain = true;
        while (playAgain)
        {
            Random randomNumGen = new Random();
            int number = randomNumGen.Next(1,100);
            int guessNumber = 0;
            bool firstTime = true;
            int attempts = 0;
            do
            {
                if (firstTime)
                {
                    Console.Write($"What is the magic number? ");
                    firstTime = false;
                } else {Console.Write($"What is your guess? ");}
                guessNumber = int.Parse(Console.ReadLine());
                if (guessNumber > number){ Console.WriteLine($"Lower"); }
                else if (guessNumber < number){ Console.WriteLine($"Higher"); }
                attempts++;
            } while (number != guessNumber);
            
            Console.WriteLine($"You guessed it!" + $"\n");
            Console.WriteLine("Do you wan to play again? Y/N");
            string answer = Console.ReadLine().ToUpper();
            if (answer == "N" || answer == "NO")
            {
                playAgain = false;
            }
            Console.WriteLine();
        }
    }
}