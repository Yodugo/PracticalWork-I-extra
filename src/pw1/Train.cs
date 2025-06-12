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
        protected string id;
        protected int arrivalTime;
        protected string type;
        protected TrainStatus status;

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



    }
}