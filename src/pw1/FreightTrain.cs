using System;

namespace PwI_Extra
{
    public class FreightTrain : Train
    {
        private int maxWeight;
        private string freightType;

        public FreightTrain(string id, int arrivalTime, string type, TrainStatus status, int maxWeight, string freightType) : base(id, arrivalTime, type, status)
        {
            this.maxWeight = maxWeight;
            this.freightType = freightType;
        }
        public int GetMaxWeight()
        {
            return this.maxWeight;
        }
        public string GetFreightType()
        {
            return this.freightType;
        }
        
    }
}