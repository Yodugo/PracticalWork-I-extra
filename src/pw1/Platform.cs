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
        public int dockingTime = 2;

        public Platform(string id, PlatformStatus status, Train currentTrain, int dockingTime)
        {
            this.id = id;
            this.status = status;
            this.currentTrain = currentTrain;
            this.dockingTime = dockingTime;

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



    }
}