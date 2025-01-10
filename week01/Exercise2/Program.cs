using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please enter your grade percentage: ");
        int gradePercentage = int.Parse(Console.ReadLine().Trim());
        int percentageLastDigit = (int)Char.GetNumericValue(gradePercentage.ToString()[1]);
        string gradeLetter = "";
        bool passed = true;

        if (gradePercentage >= 90)
        {
            gradeLetter = "A";
        }
        else if(gradePercentage >= 80)
        {
            gradeLetter = "B";
        }
        else if(gradePercentage >= 70)
        {
            gradeLetter = "C";
        }
        else if(gradePercentage >= 60)
        {
            gradeLetter = "D";
            passed = false;
        }
        else
        {
            gradeLetter = "F";
            passed = false;
        }
        
        if (percentageLastDigit >= 7 && (!gradeLetter.Equals("A") && !gradeLetter.Equals("F")))
        {
            gradeLetter = gradeLetter + "+";
        }
        else if (percentageLastDigit <= 3 && !gradeLetter.Equals("F"))
        {
            gradeLetter = gradeLetter + "-";
        }


        string passedText = $"Consgratulations! Your have passed!";
        if (!passed)
        {
            passedText = "You can do better!";
        }
        
        Console.WriteLine($"\n"
                            + $"Your grade is {gradeLetter}. {passedText}");

    }
}