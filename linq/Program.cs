using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main() {

        // Find the words in the collection that start with the letter 'L'
        List<string> fruits = new List<string>() {"Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry"};

        IEnumerable<string> LFruits = from fruit in fruits 

            where fruit.StartsWith("L")
            select fruit;
        // Which of the following numbers are multiples of 4 or 6
        List<int> numbers = new List<int>() {15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96};

        IEnumerable<int> fourSixMultiples = numbers.Where(number => number % 4 == 0 || number % 6 == 0);
        

        // Write fruits that start with L
        foreach (string fruit in LFruits) {Console.WriteLine($"{fruit} is a fruit that starts with L");}
        foreach (int x in fourSixMultiples) {Console.WriteLine($"{x} is divisible by 4 and/or 6");}

    }
}