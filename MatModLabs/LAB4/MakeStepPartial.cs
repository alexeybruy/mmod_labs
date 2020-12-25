using System.Collections.Generic;
using System.Linq;

namespace LAB4
{
    public partial class MainWindow
    {
        private void MakeStep()
        {
            var allowedTransitionsIds = new List<int>();

            for (int transitionId = 0; transitionId < TransitionsMatrix.Length; transitionId++)
            {
                var linkedPlacesIds = new List<int>();

                for (int placeId = 0; placeId < PlacesMatrix.Length; placeId++)
                {
                    if (PlacesMatrix[placeId][transitionId] > 0)
                    {
                        linkedPlacesIds.Add(placeId);
                    }
                }
                
                if (linkedPlacesIds.All(placeId => Markers[placeId] >= PlacesMatrix[placeId][transitionId]))
                {
                    allowedTransitionsIds.Add(transitionId);
                }
            }

            foreach (var transitionId in allowedTransitionsIds)
            {
                for (int placeId = 0; placeId < PlacesMatrix.Length; placeId++)
                {
                    if (PlacesMatrix[placeId][transitionId] > 0)
                    {
                        Markers[placeId] -= PlacesMatrix[placeId][transitionId];
                    }
                }

                for (int placeId = 0; placeId < TransitionsMatrix[transitionId].Length; placeId++)
                {
                    if (TransitionsMatrix[transitionId][placeId] > 0)
                    {
                        Markers[placeId] += TransitionsMatrix[transitionId][placeId];
                    }
                }
            }
        }
    }
}
