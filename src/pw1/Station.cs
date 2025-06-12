using System;

namespace PwI_Extra
{
    public class Station
    {
        public List<Platform> Platforms = new List<Platform>();
        public List<Train> Trains = new List<Train>();

        public Station()
        {

        }
        public void DisplayStatus()
        {
            Console.WriteLine("=====Train Status=====");
            Console.WriteLine();
            foreach (var train in Trains)
            {
                string time = "";

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

                Console.WriteLine($"Train {train.id} - Status: {train.status} - {time}");
            }

            Console.WriteLine("\n====Platform Status====");
            foreach (var platform in Platforms)
            {
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

        public void AdvanceTick()
        {
            Console.WriteLine("Advancing simulation by 15 minutes...\n");

            // 1. Update arrival times for EnRoute trains

            foreach (var train in Trains)
            {
                if (train.status == TrainStatus.EnRoute)
                {
                    train.Tick();
                }
            }
            // 2. Handle new arrived trains (ArrivalTime == 0 and still EnRoute)

            foreach (var train in Trains)
            {
                if (train.status == TrainStatus.EnRoute && train.arrivalTime == 0)
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

            // 3. Try to dock any Waiting trains
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

                    if (freePlatform != null)
                    {
                        freePlatform.AssignTrain(train);
                    }
                }
            }

            // 4. Tick platforms (update docking progress and free when done)
            foreach (var platform in Platforms)
            {
                if (platform.status == PlatformStatus.Occupied)
                {
                    platform.dockingTime--;

                    if (platform.currentTrain != null)
                    {
                        platform.currentTrain.Tick();

                        if (platform.dockingTime <= 0 && platform.currentTrain.status == TrainStatus.Docked)
                        {
                            platform.currentTrain = null;
                        }
                    }
                }

            }
        }


    }
}