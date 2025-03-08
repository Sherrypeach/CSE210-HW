using System;

class Program
{
    static void Main()
    {
        // Step 1: Display Welcome Message
        DisplayWelcome();

        // Step 2: Get the user's name
        string userName = PromptUserName();

        // Step 3: Get the user's favorite number
        int userNumber = PromptUserNumber();

        // Step 4: Square the number
        int squaredNumber = SquareNumber(userNumber);

        // Step 5: Display the result
        DisplayResult(userName, squaredNumber);
    }

    // Function to display welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    // Function to ask for and return the user's name
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    // Function to ask for and return the user's favorite number
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    // Function to square a number and return the result
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Function to display the result
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}