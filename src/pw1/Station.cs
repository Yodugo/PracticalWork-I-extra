using System;

namespace PwI_Extra
{
    public class Station
    {
        // List of platforms available at the station
        public List<Platform> Platforms = new List<Platform>();
        
        // List of trains currently in the simulation
        public List<Train> Trains = new List<Train>();

        public Station()
        {

        }

        // Display the current status of all trains and platforms
        public void DisplayStatus()
        {
            Console.Clear();
            Console.WriteLine("=====Train Status=====");
            Console.WriteLine();
            foreach (var train in Trains)
            {
                string time = "";

                // Set message depending on train status
                if (train.status == TrainStatus.EnRoute)
                {
                    time = $"{train.arrivalTime} min to arrive";
                }
                else if (train.status == TrainStatus.Docking)
                {
                    time = $"{train.dockingTicks} ticks docking";
                }
                else if (train.status == TrainStatus.Waiting)
                {
                    time = "Waiting for platform";
                }
                else if (train.status == TrainStatus.Docked)
                {
                    time = "Docked";
                }

                Console.WriteLine($"Train {train.id}   Status: {train.status} - {time}");
            }

            Console.WriteLine("\n====Platform Status====");

            foreach (var platform in Platforms)
            {
                // Display platform status
                if (platform.status == PlatformStatus.Free)
                {
                    Console.WriteLine($"Platform {platform.id}: Free");
                }
                else
                {
                    Console.WriteLine($"Platform {platform.id} occupied by train.");
                }
            }
        }

        // Advance the simulation by one tick (15 minutes)
        public void AdvanceTick()
        {
            Console.WriteLine("Advancing simulation by 15 minutes...\n");

            //  Update arrival time for all en route trains
            foreach (var train in Trains)
            {
                if (train.status == TrainStatus.EnRoute)
                {
                    train.Tick();
                }
            }

            //  Assign platform to trains that just arrived
            foreach (var train in Trains)
            {
                if (train.status == TrainStatus.EnRoute && train.arrivalTime == 0)
                {
                    Platform freePlatform = null;

                    // Look for a free platform
                    foreach (var platform in Platforms)
                    {
                        if (platform.status == PlatformStatus.Free)
                        {
                            freePlatform = platform;
                            break;
                        }
                    }

                    // Assign platform or set to waiting
                    if (freePlatform != null)
                    {
                        freePlatform.AssignTrain(train);
                    }
                    else
                    {
                        train.status = TrainStatus.Waiting;
                    }
                }
            }

            //   Try to dock trains that are waiting
            foreach (var train in Trains)
            {
                if (train.status == TrainStatus.Waiting)
                {
                    Platform freePlatform = null;

                    foreach (var platform in Platforms)
                    {
                        if (platform.status == PlatformStatus.Free)
                        {
                            freePlatform = platform;
                            break;
                        }
                    }

                    // Assign free platform if available
                    if (freePlatform != null)
                    {
                        freePlatform.AssignTrain(train);
                    }
                }
            }

            //   Tick platforms to update docking progress
            foreach (var platform in Platforms)
            {
                if (platform.currentTrain != null)
                {
                    platform.currentTrain.Tick();

                    // If docking is complete, mark platform as occupied
                    if (platform.currentTrain.status == TrainStatus.Docked)
                    {
                        platform.status = PlatformStatus.Occupied;
                    }
                }
            }
        }

        // Load train data from a CSV file
        public void LoadFromFile()
        {
            Console.Write("Write the name of the file: ");
            string path = Console.ReadLine();

            if (!File.Exists(path))
            {
                Console.WriteLine($"The file '{path}' was not found.");
                return;
            }

            var lines = File.ReadAllLines(path);
            Trains.Clear();

            for (int i = 1; i < lines.Length; i++) // Skip header
            {
                var line = lines[i];

                try
                {
                    string[] parts = line.Split(',');

                    string id = parts[0];
                    int arrivalTime = int.Parse(parts[1]);
                    string type = parts[2].ToLower();

                    // Create train based on type
                    if (type == "passenger")
                    {
                        int carriages = int.Parse(parts[3]);
                        int capacity = int.Parse(parts[4]);
                        Trains.Add(new PassengerTrain(id, arrivalTime, type, TrainStatus.EnRoute, carriages, capacity));
                    }
                    else if (type == "freight")
                    {
                        int maxWeight = int.Parse(parts[3]);
                        string freight = parts[4];
                        Trains.Add(new FreightTrain(id, arrivalTime, type, TrainStatus.EnRoute, maxWeight, freight));
                    }
                    else
                    {
                        Console.WriteLine($"Unknown train type: {type} in line {i + 1}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing line {i + 1}: {line}");
                    Console.WriteLine($"{ex.Message}");
                }
            }

            Console.WriteLine("Trains loaded successfully from 'Trains.csv'.\n");
        }

        // Check if all trains are docked
        public bool AllTrainsDocked()
        {
            foreach (var train in Trains)
            {
                if (train.Getstatus() != TrainStatus.Docked)
                {
                    return false;
                }
            }
            return true;
        }

        // Run the simulation loop
        public void RunSimulation()
        {
            if (Trains == null || Trains.Count == 0)
            {
                Console.WriteLine("No trains loaded. Simulation cannot start.\n");
                return;
            }

            int tickCount = 0;

            // Continue simulation until all trains are docked
            while (!AllTrainsDocked())
            {
                Console.WriteLine($" Tick number {tickCount + 1} - Press Enter to advance 15 minutes...");
                Console.ReadLine();

                AdvanceTick();      // Progress simulation
                DisplayStatus();    // Show updated status

                tickCount++;
                Console.WriteLine("---------------------------------------------\n");
            }

            Console.WriteLine(" All trains are now in 'Docked' status.\n");
            Console.WriteLine($"Total simulation ticks: {tickCount}");
            Console.ReadLine();
        }
    }
}
