using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };
            List<string> fruitStartingWithL = fruits.Where(fruit =>
            {
                bool startWithL = fruit.StartsWith("L");
                return startWithL;
            }).ToList();

            foreach (string fruit in fruitStartingWithL)
            {
                Console.WriteLine(fruit);
            }

            // Which of the following numbers are multiples of 4 or 6
            List<int> numbers = new List<int>()
            {
                15,
                8,
                21,
                24,
                32,
                13,
                30,
                12,
                7,
                54,
                48,
                4,
                49,
                96
            };

            List<int> multiplesOfFourOrSix = numbers.Where(num =>
            {
                bool isDivided = num % 4 == 0 || num % 6 == 0;
                return isDivided;
            }).ToList();

            foreach (int number in multiplesOfFourOrSix)
            {
                Console.WriteLine(number);
            }

            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>()
            {
                "Heather",
                "James",
                "Xavier",
                "Michelle",
                "Brian",
                "Nina",
                "Kathleen",
                "Sophia",
                "Amir",
                "Douglas",
                "Zarley",
                "Beatrice",
                "Theodora",
                "William",
                "Svetlana",
                "Charisse",
                "Yolanda",
                "Gregorio",
                "Jean-Paul",
                "Evangelina",
                "Viktor",
                "Jacqueline",
                "Francisco",
                "Tre"
            };

            names.Sort();

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

            // Build a collection of these numbers sorted in ascending order
            List<int> numbers2 = new List<int>()
            {
                15,
                8,
                21,
                24,
                32,
                13,
                30,
                12,
                7,
                54,
                48,
                4,
                49,
                96
            };

            numbers2.Sort();
            foreach (int num in numbers2)
            {
                Console.WriteLine(num);
            }

            // Output how many numbers are in this list
            List<int> numbers3 = new List<int>()
            {
                15,
                8,
                21,
                24,
                32,
                13,
                30,
                12,
                7,
                54,
                48,
                4,
                49,
                96
            };

            int sumOfNumbers = numbers3.Sum();

            Console.WriteLine(sumOfNumbers);

            // How much money have we made?
            List<double> purchases = new List<double>()
            {
                2340.29,
                745.31,
                21.76,
                34.03,
                4786.45,
                879.45,
                9442.85,
                2454.63,
                45.65
            };

            double moneyWeMade = purchases.Sum();
            Console.WriteLine(moneyWeMade);

            // What is our most expensive product?
            List<double> prices = new List<double>()
            {
                879.45,
                9442.85,
                2454.63,
                45.65,
                2340.29,
                34.03,
                4786.45,
                745.31,
                21.76
            };
            double mostExpensive = prices.Max();
            Console.WriteLine(mostExpensive);

            /*
                Store each number in the following List until a perfect square
                is detected.

                Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
            */
            List<int> wheresSquaredo = new List<int>()
            {
                66,
                12,
                8,
                27,
                82,
                34,
                7,
                50,
                19,
                46,
                81,
                23,
                30,
                4,
                68,
                14
            };

            List<int> squareNumbers = wheresSquaredo.TakeWhile(num =>
            {
                bool isSquared = Math.Sqrt(num) % 1 == 0;
                return !isSquared;
            }).ToList();

            foreach (int item in squareNumbers)
            {
                Console.WriteLine(item);
            }

            List<Customer> customers = new List<Customer>()
            {
                new Customer() { Name = "Bob Lesman", Balance = 80345.66, Bank = "FTB" },
                new Customer() { Name = "Joe Landy", Balance = 9284756.21, Bank = "WF" },
                new Customer() { Name = "Meg Ford", Balance = 487233.01, Bank = "BOA" },
                new Customer() { Name = "Peg Vale", Balance = 7001449.92, Bank = "BOA" },
                new Customer() { Name = "Mike Johnson", Balance = 790872.12, Bank = "WF" },
                new Customer() { Name = "Les Paul", Balance = 8374892.54, Bank = "WF" },
                new Customer() { Name = "Sid Crosby", Balance = 957436.39, Bank = "FTB" },
                new Customer() { Name = "Sarah Ng", Balance = 56562389.85, Bank = "FTB" },
                new Customer() { Name = "Tina Fey", Balance = 1000000.00, Bank = "CITI" },
                new Customer() { Name = "Sid Brown", Balance = 49582.68, Bank = "CITI" }
            };

            var groups = customers.Where(num =>
            {
                bool isMilionaire = num.Balance > 999999;
                return isMilionaire;
            }).GroupBy(customer => customer.Bank);

            foreach (var group in groups)
            {
                Console.WriteLine($"{group.Key} has {group.Count()} customers");

                foreach (Customer customer in group)
                {
                    Console.WriteLine($"**** {customer.Name}");
                }
            }

            // Create some banks and store in a List
            List<Bank> banks = new List<Bank>()
            {
                new Bank() { Name = "First Tennessee", Symbol = "FTB" },
                new Bank() { Name = "Wells Fargo", Symbol = "WF" },
                new Bank() { Name = "Bank of America", Symbol = "BOA" },
                new Bank() { Name = "Citibank", Symbol = "CITI" },
            };

            List<ReportItem> millionaireReport = customers.Where(customer => customer.Balance >= 1000000)
                .Select(customer => new
                {
                    FullName = customer.Name,
                        Bank = customer.Bank
                })
                .Join(banks,
                    customer => customer.Bank,
                    bank => bank.Symbol,
                    (customer, bank) => new ReportItem { CustomerName = customer.FullName, BankName = bank.Name })
                .ToList<ReportItem>();

            foreach (var item in millionaireReport)
            {
                Console.WriteLine($"{item.CustomerName} at {item.BankName}");
            }

            //Another GroupBy Example

            List<Student> allStudents = new List<Student>()
            {
                new Student() { Name = "Madi", Cohort = "27" },
                new Student() { Name = "Jon", Cohort = "28" },
                new Student() { Name = "Fortu", Cohort = "28" },
                new Student() { Name = "Keaton", Cohort = "27" },
                new Student() { Name = "Jon", Cohort = "35" },
                new Student() { Name = "Nick", Cohort = "35" },
                new Student() { Name = "Dylan", Cohort = "35" },
                new Student() { Name = "Dylan", Cohort = "36" },
            };

            var studentGroup = allStudents.GroupBy(student => student.Name);

            foreach (var group in studentGroup)
            {
                Console.WriteLine($"There are {group.Count()} student with this name: {group.Key}");

                foreach (var item in group)
                {
                    Console.WriteLine($"The cohort where he/se is: {item.Cohort}");
                }
            }

            var theMostUsedName = allStudents
                .GroupBy(student => student.Name)
                .OrderByDescending(group => group.Count())
                .First();

            Console.WriteLine(theMostUsedName.Key);

        }

    }
}