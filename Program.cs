using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqList
{
    // Build a collection of customers who are millionaires
    // Using Custon Types
    public class Customer
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Bank { get; set; }
    }
    public class Bank
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<Bank> banks = new List<Bank>() {
                new Bank(){ Name="First Tennessee", Symbol="FTB"},
                new Bank(){ Name="Wells Fargo", Symbol="WF"},
                new Bank(){ Name="Bank of America", Symbol="BOA"},
                new Bank(){ Name="Citibank", Symbol="CITI"},
            };
            // Using Custom Types
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

            var richPeople = 
            from peeps in customers
            where peeps.Balance >= 1000000
            select peeps;

            // foreach (Customer person in richPeople) {
            //     Console.WriteLine($"{person.Name} has ${person.Balance} in {person.Bank}");
            // }
            var millionaires = customers.GroupBy(y => y.Bank);

            // foreach(var bank in millionaires) {
            //     Console.WriteLine(bank.Key + " : " + bank.Count(y => y.Balance >= 1000000));
            // }

            var millionaireReport = 
            from c in customers
            where c.Balance >= 1000000
            join b in banks on c.Bank equals b.Symbol
            select new {Bank = b.Name, Money = c.Balance};

            // richPeople.Join(bankList, Key => richPeople, Bank => bankList);

            foreach (var customer in millionaireReport)
            {
                Console.WriteLine($"{customer.Bank} has a customer with a balance of ${customer.Money}");
           
            }
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() {"Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry"};

            var LFruits = 
                from fruit in fruits
                // where fruit.Substring(0, 1) == ("L")
                where fruit.StartsWith("L")
                select fruit;
            // Console.WriteLine($"Here are the L Fruits");
            foreach (var l in LFruits) {
                // Console.WriteLine($"{l}");
            }
            // Which of the following numbers are multiples of 4 or 6
            List<int> numbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            var fourSixMultiples = numbers.Where((digit) => digit % 4 == 0 || digit % 6 == 0);
            foreach(int thing in fourSixMultiples) {
                // Console.WriteLine(thing);
            }

            List<string> names = new List<string>()
            {
                "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
                "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
                "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
                "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
                "Francisco", "Tre" 
            };

            var descend = 
                from name in names 
                orderby name descending 
                select name;
            foreach(string name in descend) {
                // Console.WriteLine(name);
            }

            // Build a collection of these numbers sorted in ascending order
            List<int> newNumbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            var ascend = 
                from num in newNumbers
                orderby num ascending
                select num;
            foreach(int num in ascend) {
                // Console.WriteLine(num);
            }

            // Output how many numbers are in this list
            List<int> numbers2 = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            int numCount = numbers2.Count();
            // Console.WriteLine(numCount);

            List<double> purchases = new List<double>()
            {
                2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
            };

            double totalPrice = purchases.Sum();
            // Console.WriteLine($"${totalPrice}");

            // What is our most expensive product?
            List<double> prices = new List<double>()
            {
                879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
            };

            double priciest = prices.Max();

            // Console.WriteLine(priciest);

            /*
                Store each number in the following List until a perfect square
                is detected.

                Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
            */
            List<int> wheresSquaredo = new List<int>()
            {
                66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
            };

            var notSquare = wheresSquaredo.TakeWhile((num) => Math.Sqrt(num) %1 != 0);
                
            foreach(var i in notSquare) {
                // Console.WriteLine(i);
            }
        }

        
    }
}
