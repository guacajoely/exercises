using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main() {

        //Restriction/Filtering Operations
        //--------------------------------------------------------------------------------------------------------

        // Find the words in the collection that start with the letter 'L'
        List<string> fruits = new List<string>() {"Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry"};

        IEnumerable<string> LFruits = from fruit in fruits 

            where fruit.StartsWith("L")
            select fruit;
        // Which of the following numbers are multiples of 4 or 6
        List<int> numbersList = new List<int>() {15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96};

        IEnumerable<int> fourSixMultiples = numbersList.Where(number => number % 4 == 0 || number % 6 == 0);
        

        // Write fruits that start with L
        foreach (string fruit in LFruits) {Console.WriteLine($"{fruit} is a fruit that starts with L");}
        foreach (int x in fourSixMultiples) {Console.WriteLine($"{x} is divisible by 4 and/or 6");}



        //Ordering Operations
        //--------------------------------------------------------------------------------------------------------

        // Order these student names alphabetically, in descending order (Z to A)
        List<string> names = new List<string>()
        {
            "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
            "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
            "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
            "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
            "Francisco", "Tre"
        };

        IEnumerable<string> descending = names.OrderByDescending(n => n);


        // Build a collection of these numbers sorted in ascending order
        List<int> numbersList2 = new List<int>() {15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96};

        IEnumerable<int> ascending = numbersList2.OrderBy(n => n);

        Console.WriteLine("These names should be in descending order");
        foreach (string name in descending) {Console.WriteLine($"{name}");}
        Console.WriteLine("These numbers should be in ascending order");
        foreach (int num in ascending) {Console.WriteLine($"{num}");}



        //Aggregate Operations
        //--------------------------------------------------------------------------------------------------------

        // Output how many numbers are in this list
        List<int> numbersList3 = new List<int>() {15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96};

        int count = numbersList3.Count();

        Console.WriteLine($"There are {count} numbers in numbersList3");

        // How much money have we made?
        List<double> purchases = new List<double>() {2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65};

        double sum = purchases.Sum();

        Console.WriteLine($"The sum of the purchases is {sum}");



        //Partitioning  Operations
        //--------------------------------------------------------------------------------------------------------

        // Store each number in the following List until a perfect square is detected. (81)
        List<int> wheresSquaredo = new List<int>()
        {
            66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
        };

        //get index of first matching number
        int firstMatch = wheresSquaredo.First(num => Math.Sqrt(num)%1 == 0);

        Console.WriteLine($"{firstMatch} is the first perfect square");

        //get index of first match
        int stopHere = wheresSquaredo.IndexOf(firstMatch);

        //then copy stopping at that index
        List<int> newList = wheresSquaredo.GetRange(0, stopHere);
 
        foreach (int num in newList) {Console.WriteLine($"{num}");}



        //Using Custom Types
        //--------------------------------------------------------------------------------------------------------
        // Build a collection of customers who are millionaires

        List<Customer> customers = new List<Customer>() {
            new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
        };

        // Store full bank names in a List
        List<Bank> banks = new List<Bank>() {
            new Bank(){ Name="First Tennessee", Symbol="FTB"},
            new Bank(){ Name="Wells Fargo", Symbol="WF"},
            new Bank(){ Name="Bank of America", Symbol="BOA"},
            new Bank(){ Name="Citibank", Symbol="CITI"},
        };

        List<BankEntry> millionaireReport = (from customer in customers

        //dealing with customers list
            group customer by customer.Bank into bankGroup

        //now dealing with bankGroup list
            select new BankEntry {
                BankName = bankGroup.Key, 
                MillionaireCount = bankGroup.Count(custObj => custObj.Balance > 999999)
            }
            
        ).OrderByDescending(bank => bank.MillionaireCount).ToList();

        foreach(BankEntry entry in millionaireReport)
        {
            Console.WriteLine($"{entry.BankName}: {entry.MillionaireCount}");
        }


        /*
        TASK:
        As in the previous exercise, you're going to output the millionaires,
        but you will also display the full name of the bank. You also need
        to sort the millionaires' names, ascending by their LAST name.

        Example output:
            Tina Fey at Citibank
            Joe Landy at Wells Fargo
            Sarah Ng at First Tennessee
            Les Paul at Wells Fargo
            Peg Vale at Bank of America
        */

        List<MillionaireEntry> detailedMillionaireReport = (from customer in customers

            //filter out non-millionaires
            where customer.Balance > 999999
        
            // Create a new MillionaireEntry Object
            // Grab matching bank object from banks List. This returns Bank object, NOT a string, so need to specify .Name when using
            // Take customer.Name and Split it at the blankspace. This creates a string array! NOT a string, so need to specify index when sorting below
            select new MillionaireEntry {
                Name = customer.Name, 
                Bank = banks.First(bank => bank.Symbol == customer.Bank),
                SplitName = customer.Name.Split(' ')
            }

        ).OrderBy(customer => customer.SplitName[1]).ToList();

        foreach (var millionaire in detailedMillionaireReport)
        {
            Console.WriteLine($"{millionaire.Name} at {millionaire.Bank.Name}");
        }










        
    }




    // Define a bank
    public class Bank
    {
        public string? Symbol { get; set; }
        public string? Name { get; set; }
    }

    // Define a customer
    public class Customer
    {
        public string? Name { get; set; }
        public double Balance { get; set; }
        public string? Bank { get; set; }
    }

    public class BankEntry
    {
        public string? BankName { get; set; }
        public int MillionaireCount { get; set; }
    }

    
    // Define a separate DETAILED bank entry object
    public class MillionaireEntry
    {
        public string? Name { get; set; }
        public Bank Bank { get; set; }

        public string[]? SplitName { get; set; }
    }
    

    
}
