using System;

namespace PwI_Extra
{
    public class PassengerTrain : Train
    {
        private int numberOfCarriages;
        private int capacity;

        public PassengerTrain(string id, int arrivalTime, string type, TrainStatus status, int numberOfCarriages, int capacity) : base(id, arrivalTime, type, status)
        {
            this.numberOfCarriages = numberOfCarriages;
            this.capacity = capacity;
        }
        public int GetNumberOfCarriages()
        {
            return this.numberOfCarriages;
        }
        public int GetCapacity()
        {
            return this.capacity;
        }



        
    }
}