using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {
        static bool cont = true; // Class-level variable

        private static List<string> activities = new List<string>()
        { 
            "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", 
            "Hiking", "Axe Throwing", "Wine Tasting" 
        };

        static void Main(string[] args)
        {
            Random rng = new Random(); // Random number generator

            Console.Write("Hello, welcome to the random activity generator!\nWould you like to generate a random activity? yes/no: ");
            string response = Console.ReadLine().ToLower();
            cont = response == "yes"; // Fix parsing issue

            Console.WriteLine();
            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();

            Console.WriteLine();
            Console.Write("What is your age? ");
            int userAge = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
            string seeListResponse = Console.ReadLine().ToLower();
            bool seeList = seeListResponse == "sure"; // Fix parsing issue

            if (seeList)
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }

                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                string addToListResponse = Console.ReadLine().ToLower();
                bool addToList = addToListResponse == "yes"; // Fix parsing issue

                while (addToList)
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);

                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }

                    Console.WriteLine();
                    Console.Write("Would you like to add more? yes/no: ");
                    addToListResponse = Console.ReadLine().ToLower();
                    addToList = addToListResponse == "yes"; // Fix parsing issue
                }
            }

            while (cont)
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();
                Console.Write("Choosing your random activity");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();
                int randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber];

                // Fix age restriction check
                if (userAge < 21 && randomActivity == "Wine Tasting") 
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}.");
                    Console.WriteLine("Picking something else!");
                    activities.Remove(randomActivity);
                    randomNumber = rng.Next(activities.Count);
                    randomActivity = activities[randomNumber];
                }

                Console.WriteLine($"Ah got it! {randomActivity}, your random activity is: {userName}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                response = Console.ReadLine().ToLower();
                cont = response == "redo"; // Fix parsing issue
            }
        }
    }
}
