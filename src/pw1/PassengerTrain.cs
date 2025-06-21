using System;

namespace PwI_Extra
{
    // PassengerTrain inherits from Train
    public class PassengerTrain : Train
    {
        private int numberOfCarriages;
        private int capacity;

        // Constructor for PassengerTrain, calls base Train constructor and initializes specific properties
        public PassengerTrain(string id, int arrivalTime, string type, TrainStatus status, int numberOfCarriages, int capacity) : base(id, arrivalTime, type, status)
        {
            this.numberOfCarriages = numberOfCarriages;
            this.capacity = capacity;
        }

        // Returns the number of carriages
        public int GetNumberOfCarriages()
        {
            return this.numberOfCarriages;
        }

        // Returns the total passenger capacity
        public int GetCapacity()
        {
            return this.capacity;
        }
    }
}
