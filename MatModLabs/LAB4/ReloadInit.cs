using System.Linq;
using System.Windows;
using LAB4.Services;

namespace LAB4
{
    public partial class MainWindow
    {
        public void ReloadInit()
        {
            var init = new RetrievingService().Retrieve();

            PlacesMatrix = init.PlacesMatrix;
            TransitionsMatrix = init.TransitionsMatrix;
            Markers = init.Markers;
            PlacesPositions = init.PlacesPositions.Select(point => new Point(point.X, point.Y)).ToArray();
            TransitionsPlaces = init.TransitionsPlaces.Select(point => new Point(point.X, point.Y)).ToArray();
        }
    }
}
