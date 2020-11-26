using System.Collections.Generic;

namespace Firetruck
{
    public interface IFireTruckStationBuilder
    {
        public (int crossroadNumber, List<List<int>> ways) SuitableCrossroad();
    }
}