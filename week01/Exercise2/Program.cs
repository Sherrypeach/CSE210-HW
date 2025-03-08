using System;

class Program
{
    static void Main()
    {
        // Step 1: Ask the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        string userInput = Console.ReadLine(); // Read input as string
        int grade = int.Parse(userInput); // Convert the string input into an integer

        string letter = ""; // Variable to store the letter grade
        string sign = ""; // Variable to store + or -

        // Step 2: Determine the letter grade
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Step 3: Determine + or - sign (except for A and F)
        int lastDigit = grade % 10; // Get last digit of the grade

        if (letter != "A" && letter != "F") // A+ and F+/F- do not exist
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        // Step 4: Display the final grade
        Console.WriteLine($"Your grade is {letter}{sign}.");

        // Step 5: Check if the user passed
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Keep trying and you'll do better next time.");
        }
    }
}
