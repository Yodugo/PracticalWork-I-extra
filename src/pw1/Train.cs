using System;

namespace PwI_Extra
{
    // Enum representing the various states a train can be in
    public enum TrainStatus
    {
        EnRoute,    // Train is on the way to the station
        Waiting,    // Train has arrived but is waiting for a free platform
        Docking,    // Train is currently docking at a platform
        Docked      // Train has completed docking
    }

    // Abstract base class representing a generic train
    public abstract class Train
    {
        public string id;
        public int arrivalTime;
        public string type;

        // Current status of the train
        public TrainStatus status = TrainStatus.EnRoute;

        public int dockingTicks;

        // Constructor to initialize common train properties
        public Train(string id, int arrivalTime, string type, TrainStatus status)
        {
            this.id = id;
            this.arrivalTime = arrivalTime;
            this.type = type;
            this.status = status;
        }

        // Returns the ID of the train
        public string GetId()
        {
            return this.id;
        }

        // Returns arrival time
        public int GetArrivalTime()
        {
            return this.arrivalTime;
        }

        // Returns the type of train
        public string GetType()
        {
            return this.type;
        }

        // Returns the current train status
        public TrainStatus Getstatus()
        {
            return this.status;
        }

        // Starts the docking process for the train
        public void StartDocking()
        {
            status = TrainStatus.Docking;
            dockingTicks = 2; // Docking takes 2 ticks to complete
        }

        // Advances the state of the train by one tick (15 minutes)
        public void Tick()
        {
            // If the train is en route, reduce arrival time
            if (status == TrainStatus.EnRoute && arrivalTime > 0)
            {
                arrivalTime -= 15;
                
                // Prevent arrival time from going below 0
                if (arrivalTime < 0)
                {
                    arrivalTime = 0;
                }
            }
            // If the train is docking, reduce docking time
            else if (status == TrainStatus.Docking)
            {
                dockingTicks = dockingTicks-2;

                // If docking is complete, update status to Docked
                if (dockingTicks <= 0)
                {
                    status = TrainStatus.Docked;
                }
            }
        }
    }
}
