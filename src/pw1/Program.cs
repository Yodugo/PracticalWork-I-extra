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
            Station station = new Station();
            station.Platforms = new List<Platform>();

            for (int i = 0; i < platformCount; i++)
            {
                station.Platforms.Add(new Platform("P" + i));
            }


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
                        station.LoadFromFile();
                        Console.ReadLine();
                        break;

                    case 2:
                        Console.WriteLine("Starting Simulation...");
                        station.RunSimulation();
                        Console.ReadLine();
                        break;

                    case 3: break;

                    default:
                        Console.WriteLine("Write a correct option");
                        Console.ReadLine();
                        break;
                }


            } while (option != 3);
        }
    }
}