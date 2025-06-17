using System;

namespace PwI_Extra
{
    public enum PlatformStatus
    {
        Free,
        Occupied
    }
    public class Platform
    {
        public string id;
        public PlatformStatus status;
        public Train currentTrain;
        public int dockingTime;

        public Platform(string id)
        {
            this.id = id;
            this.status = PlatformStatus.Free;
            this.currentTrain = null;
            this.dockingTime = 2;

        }


        public string GetId()
        {
            return this.id;
        }
        public PlatformStatus GetStatus()
        {
            return this.status;
        }
        public Train GetCurrentTrain()
        {
            return this.currentTrain;
        }
        public int GetDockingTime()
        {
            return this.dockingTime;
        }

        public void DockTrain(Train train)
        {
            currentTrain = train;
            train.StartDocking();
            status = PlatformStatus.Occupied;
        }

        public void AssignTrain(Train train)
        {
            currentTrain = train;
            dockingTime = 2;
            train.StartDocking();
            status = PlatformStatus.Occupied;
        }



    }
}