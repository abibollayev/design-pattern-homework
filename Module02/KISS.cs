using System;

public class NumberProcessor
{
    public void ProcessNumbers(int[] numbers)
    {
        if (numbers == null || numbers.Length == 0) return;
        foreach (var n in numbers)
            if (n > 0)
                Console.WriteLine(n);
    }

    public void PrintPositiveNumbers(int[] numbers)
    {
        foreach (var n in numbers)
            if (n > 0)
                Console.WriteLine(n);
    }

    public int Divide(int a, int b)
    {
        if (b == 0) return 0;
        return a / b;
    }
}

