using System;

namespace PwI_Extra
{
    // Enum representing the status of a platform
    public enum PlatformStatus
    {
        Free,       // Platform is available
        Occupied    // Platform is currently in use
    }

    public class Platform
    {
        public string id;
        public PlatformStatus status;
        public Train currentTrain;
        public int dockingTime;

        // Constructor initializes the platform as free with no train
        public Platform(string id)
        {
            this.id = id;
            this.status = PlatformStatus.Free;
            this.currentTrain = null;
            this.dockingTime = 2;
        }

        // Returns the platform ID
        public string GetId()
        {
            return this.id;
        }

        // Returns the current status of the platform
        public PlatformStatus GetStatus()
        {
            return this.status;
        }

        // Returns the train currently assigned to the platform
        public Train GetCurrentTrain()
        {
            return this.currentTrain;
        }

        // Returns how many ticks docking takes
        public int GetDockingTime()
        {
            return this.dockingTime;
        }

        // Docks a train to this platform and marks it as occupied
        public void DockTrain(Train train)
        {
            currentTrain = train;
            train.StartDocking();           // Begin docking procedure
            status = PlatformStatus.Occupied;
        }

        // Assigns a train to this platform and resets docking time
        public void AssignTrain(Train train)
        {
            currentTrain = train;
            dockingTime = 2;                // Reset docking time
            train.StartDocking();           // Begin docking procedure
            status = PlatformStatus.Occupied;
        }
    }
}
