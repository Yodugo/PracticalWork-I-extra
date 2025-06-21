using System;

namespace PwI_Extra
{
    public class Program
    {
        public static void Main()
        {
            int platformCount = 0;

            while (platformCount <= 0)
            {
                Console.Clear();
                Console.Write("Enter the number of platforms to create: ");
                platformCount = int.Parse(Console.ReadLine());
            }

            int option = 0;

            // Create a new station instance
            Station station = new Station();

            // Initialize the list of platforms in the station
            station.Platforms = new List<Platform>();

            // Add the specified number of platforms to the station
            for (int i = 0; i < platformCount; i++)
            {
                station.Platforms.Add(new Platform("P" + i));
            }

            // Display menu until user chooses to exit
            do
            {
                Console.Clear();
                Console.WriteLine("|-------------------------------------|");
                Console.WriteLine("|------- TRAIN MANAGEMENT MENU -------|");
                Console.WriteLine("|-------------------------------------|");
                Console.WriteLine("|                                     |");
                Console.WriteLine("| 1. Load trains from file            |");
                Console.WriteLine("| 2. Start Simulation                 |");
                Console.WriteLine("| 3. Exit                             |");
                Console.WriteLine("|                                     |");
                Console.WriteLine("|-------------------------------------|");
                Console.WriteLine();

                Console.Write("Choose your option: ");

                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        // Load train data from file
                        station.LoadFromFile();
                        Console.ReadLine();
                        break;

                    case 2:
                        // Start the train simulation
                        Console.WriteLine("Starting Simulation...");
                        station.RunSimulation();
                        Console.ReadLine();
                        break;

                    case 3:
                        // Exit the program
                        break;

                    default:
                        // Handle invalid input
                        Console.WriteLine("Write a correct option");
                        Console.ReadLine();
                        break;
                }

            } while (option != 3); // Repeat menu until user chooses to exit
        }
    }
}
