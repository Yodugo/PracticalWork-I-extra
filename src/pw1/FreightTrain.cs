using System;

namespace PwI_Extra
{
    // FreightTrain inherits from Train
    public class FreightTrain : Train
    {
        private int maxWeight;
        private string freightType;

        // Constructor for FreightTrain, calls base Train constructor
        public FreightTrain(string id, int arrivalTime, string type, TrainStatus status, int maxWeight, string freightType) : base(id, arrivalTime, type, status)
        {
            this.maxWeight = maxWeight;
            this.freightType = freightType;
        }

        // Returns the maximum weight the train can carry
        public int GetMaxWeight()
        {
            return this.maxWeight;
        }

        // Returns the type of freight carried by the train
        public string GetFreightType()
        {
            return this.freightType;
        }
    }
}
