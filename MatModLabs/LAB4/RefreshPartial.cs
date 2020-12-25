using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LAB4
{
    public partial class MainWindow
    {
        public void RefreshGraph()
        {
            graphGrid.Children.Clear();

            for (int placeId = 0; placeId < PlacesPositions.Length; placeId++)
            {
                var placesPosition = PlacesPositions[placeId];

                for (int transitionId = 0; transitionId < TransitionsPlaces.Length; transitionId++)
                {
                    var transitionsPlace = TransitionsPlaces[transitionId];

                    if (PlacesMatrix[placeId][transitionId] == 1 || TransitionsMatrix[transitionId][placeId] == 1)
                    {
                        var line = new Line
                        {
                            X1 = placesPosition.X,
                            Y1 = placesPosition.Y,
                            X2 = transitionsPlace.X,
                            Y2 = transitionsPlace.Y,
                            StrokeThickness = 1,
                            Stroke = new SolidColorBrush(Colors.Black),
                        };

                        graphGrid.Children.Add(line);
                    }
                }
            }

            for (var transitionId = 0; transitionId < TransitionsPlaces.Length; transitionId++)
            {
                var transitionsPlace = TransitionsPlaces[transitionId];
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
                    Content = $"T{transitionId + 1}",
                    Margin = new Thickness(
                        transitionsPlace.X - 12,
                        transitionsPlace.Y - 50, 0, 0),
                };

                graphGrid.Children.Add(label);
            }

            for (var placeId = 0; placeId < PlacesPositions.Length; placeId++)
            {
                var placesPosition = PlacesPositions[placeId];

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
                var markersCount = Markers[placeId];

                for (int markerId = 0; markerId < markersCount; markerId++)
                {
                    var markerEllipse = new Ellipse
                    {
                        Margin = new Thickness(
                            placesPosition.X - markerWidth / 2 + ((markerWidth + 2) * markerId),
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
                    Content = $"P{placeId + 1}",
                    Margin = new Thickness(
                        placesPosition.X - 12,
                        placesPosition.Y - 40, 0, 0),
                };

                graphGrid.Children.Add(label);
            }
        }
    }
}
