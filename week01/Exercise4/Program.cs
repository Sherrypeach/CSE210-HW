using System;
using System.Collections.Generic;
using System.Linq; // Needed for sorting

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>(); // Create an empty list
        int number;
        
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        do
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());

            if (number != 0)
            {
                numbers.Add(number); // Add number to the list (except 0)
            }

        } while (number != 0);

        // Core Requirements
        int sum = numbers.Sum(); // Get sum of numbers
        double average = numbers.Average(); // Get average
        int max = numbers.Max(); // Get largest number

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");

        // Stretch Challenge: Find the smallest positive number
        int smallestPositive = numbers.Where(n => n > 0).DefaultIfEmpty(int.MaxValue).Min();
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        // Sort and display numbers
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}