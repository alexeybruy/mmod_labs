using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using LAB4.Services;

namespace LAB4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int[][] PlacesMatrix { get; set; }

        public int[][] TransitionsMatrix { get; set; }

        public int[] Markers { get; set; }

        public Point[] PlacesPositions { get; set; }

        public Point[] TransitionsPlaces { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            var init = new RetrievingService().Retrieve();

            PlacesMatrix = init.PlacesMatrix;
            TransitionsMatrix = init.TransitionsMatrix;
            Markers = init.Markers;
            PlacesPositions = init.PlacesPositions.Select(point => new Point(point.X, point.Y)).ToArray();
            TransitionsPlaces = init.TransitionsPlaces.Select(point => new Point(point.X, point.Y)).ToArray();

            RefreshGraph();
        }

        private void makeStepButton_Click(object sender, RoutedEventArgs e)
        {
            MakeStep();
            RefreshGraph();
        }
    }
}
