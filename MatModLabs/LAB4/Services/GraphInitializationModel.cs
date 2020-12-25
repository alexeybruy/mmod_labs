using System.Runtime.InteropServices;
using System.Windows;

namespace LAB4.Services
{
    public class GraphInitializationModel
    {
        public int[][] PlacesMatrix { get; set; }

        public int[][] TransitionsMatrix { get; set; }

        public int[] Markers { get; set; }

        public Point[] PlacesPositions { get; set; }

        public Point[] TransitionsPlaces { get; set; }

        public class Point
        {
            public double X { get; set; }
            public double Y { get; set; }
        }
    }
}
