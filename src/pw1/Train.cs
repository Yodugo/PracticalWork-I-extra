using System;

namespace PwI_Extra
{
    public enum TrainStatus
    {
        EnRoute,
        Waiting,
        Docking,
        Docked
    }
    public abstract class Train
    {
        public string id;
        public int arrivalTime;
        public string type;
        public TrainStatus status = TrainStatus.EnRoute;
        public int dockingTicks;

        public Train(string id, int arrivalTime, string type, TrainStatus status)
        {
            this.id = id;
            this.arrivalTime = arrivalTime;
            this.type = type;
            this.status = status;
        }


        public string GetId()
        {
            return this.id;
        }
        public int GetArrivalTime()
        {
            return this.arrivalTime;
        }
        public string GetType()
        {
            return this.type;
        }
        public TrainStatus Getstatus()
        {
            return this.status;
        }

        public void StartDocking()
        {
            status = TrainStatus.Docking;
            dockingTicks = 2;
        }
        
        public void Tick()
        {
            if (status == TrainStatus.EnRoute && arrivalTime > 0)
            {
                arrivalTime -= 15;
                if (arrivalTime < 0)
                {
                    arrivalTime = 0;
                }
            }
            else if (status == TrainStatus.Docking)
            {
                dockingTicks--;
                if (dockingTicks <= 0)
                {
                    status = TrainStatus.Docked;
                }
            }
        }




    }
}