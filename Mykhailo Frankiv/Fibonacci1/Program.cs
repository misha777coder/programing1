using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void fibonacci(List<double> numbers, int steps)
    {
        if (steps <= 0)
            return;
        double Next = numbers[numbers.Count - 1] + numbers[numbers.Count - 2];
        numbers.Add(Next);
        fibonacci(numbers, steps - 1);
    }
    
    static List<double> fibonachiLimit(List<double> fibonachi, double limit)
    {
        double next = fibonachi[fibonachi.Count - 1] + fibonachi[fibonachi.Count - 2];
        if (next >= limit)
            return fibonachi;
        fibonachi.Add(next);
        return fibonachiLimit(fibonachi, limit);
    }

    static void Main()
    {
        try
        {
            var inputFile = File.ReadAllText(@"C:\Users\Lenovo\Desktop\Fibonacci\Fibonacci\Main\NewFile1.txt").Split(',');
            int first = int.Parse(inputFile[0]);
            int second = int.Parse(inputFile[1]);
            int steps = int.Parse(File.ReadAllText(@"C:\Users\Lenovo\Desktop\Fibonacci\Fibonacci\Main\NewFile2.txt"));
            double limit = double.Parse(File.ReadAllText(@"C:\Users\Lenovo\Desktop\Fibonacci\Fibonacci\Main\limit.txt"));

            List<double> numbers = new List<double> { first, second };
            fibonacci(numbers, steps - 2);
            File.WriteAllText(@"C:\Users\Lenovo\Desktop\Fibonacci\Fibonacci\Main\OutPut.txt", "Steps: " + string.Join(", ", numbers) + "\n");
            
            List<double> limitedNumbers = new List<double> { first, second };
            fibonachiLimit(limitedNumbers, limit);
            File.AppendAllText(@"C:\Users\Lenovo\Desktop\Fibonacci\Fibonacci\Main\OutPut.txt", "Limit: " + string.Join(", ", limitedNumbers) + "\n");
            Console.WriteLine("Result in output.txt");
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
        catch (FormatException e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }
}