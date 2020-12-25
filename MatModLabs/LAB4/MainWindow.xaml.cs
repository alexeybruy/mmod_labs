using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LAB4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int[][] PlacesMatrix =
        {
            new[] {1, 0, 0, 0},
            new[] {0, 1, 0, 0},
            new[] {0, 0, 1, 0},
            new[] {0, 0, 0, 1},
            new[] {0, 0, 0, 1},
            new[] {0, 0, 0, 1},
        };

        public int[][] TransitionsMatrix =
        {
            new[] {0, 1, 1, 0, 0, 1},
            new[] {0, 0, 0, 1, 0, 0},
            new[] {0, 0, 0, 0, 1, 0},
            new[] {1, 0, 0, 0, 0, 0},
        };

        public int[] Markers = {5, 0, 0, 0, 0, 1};

        public Point[] PlacesPositions = {
            new Point(x: 100, y: 250),
            new Point(x: 200, y: 100),
            new Point(x: 200, y: 300),
            new Point(x: 400, y: 100),
            new Point(x: 400, y: 300),
            new Point(x: 300, y: 200),
        };

        public Point[] TransitionsPlaces =
        {
            new Point(x: 150, y: 200),
            new Point(x: 300, y: 100),
            new Point(x: 300, y: 300),
            new Point(x: 500, y: 200),
        };

        public MainWindow()
        {
            InitializeComponent();
            RefreshGraph();
        }
        
        public void RefreshGraph()
        {
            graphGrid.Children.Clear();

            for (int i = 0; i < PlacesPositions.Length; i++)
            {
                var placesPosition = PlacesPositions[i];

                for (int j = 0; j < TransitionsPlaces.Length; j++)
                {
                    var transitionsPlace = TransitionsPlaces[j];

                    if (PlacesMatrix[i][j] == 1 || TransitionsMatrix[j][i] == 1)
                    {
                        var line = new Line
                        {
                            X1 = placesPosition.X,
                            Y1 = placesPosition.Y,
                            X2 = transitionsPlace.X,
                            Y2 = transitionsPlace.Y,
                            Stroke = new SolidColorBrush(Colors.Black)
                        };

                        graphGrid.Children.Add(line);
                    }
                }
            }

            for (var i = 0; i < TransitionsPlaces.Length; i++)
            {
                var transitionsPlace = TransitionsPlaces[i];
                var rectHeight = 50;
                var rectWidth = 10;

                var rectangle = new Rectangle
                {
                    Margin = new Thickness(
                        transitionsPlace.X - rectWidth / 2,
                        transitionsPlace.Y - rectHeight / 2, 0, 0),
                    Width = rectWidth,
                    Height = rectHeight,
                    Stroke = new SolidColorBrush(Colors.Black),
                    Fill = new SolidColorBrush(Colors.White),
                };

                graphGrid.Children.Add(rectangle);

                var label = new Label
                {
                    Content = $"T{i + 1}",
                    Margin = new Thickness(
                        transitionsPlace.X - 12,
                        transitionsPlace.Y - 50, 0, 0),
                };

                graphGrid.Children.Add(label);
            }

            for (var i = 0; i < PlacesPositions.Length; i++)
            {
                var placesPosition = PlacesPositions[i];

                var ellipseWidth = 30;

                var ellipse = new Ellipse
                {
                    Margin = new Thickness(
                        placesPosition.X - ellipseWidth / 2,
                        placesPosition.Y - ellipseWidth / 2, 0, 0),
                    Width = ellipseWidth,
                    Height = ellipseWidth,
                    Stroke = new SolidColorBrush(Colors.Black),
                    Fill = new SolidColorBrush(Colors.White),
                };

                graphGrid.Children.Add(ellipse);

                var markerWidth = 5;
                var markersCount = Markers[i];

                for (int j = 0; j < markersCount; j++)
                {
                    var markerEllipse = new Ellipse
                    {
                        Margin = new Thickness(
                            placesPosition.X - markerWidth / 2 + ((markersCount + 2) * j),
                            placesPosition.Y - markerWidth / 2, 0, 0),
                        Width = markerWidth,
                        Height = markerWidth,
                        Stroke = new SolidColorBrush(Colors.Black),
                        Fill = new SolidColorBrush(Colors.Black),
                    };

                    graphGrid.Children.Add(markerEllipse);
                }

                var label = new Label
                {
                    Content = $"P{i+1}",
                    Margin = new Thickness(
                        placesPosition.X - 12,
                        placesPosition.Y - 40, 0, 0),
                };

                graphGrid.Children.Add(label);
            }
        }
    }
}
