using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
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
                    
                    if (PlacesMatrix[placeId][transitionId] >= 1 || TransitionsMatrix[transitionId][placeId] >= 1)
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

                        var polygon = PlacesMatrix[placeId][transitionId] == 1
                            ? GenerateArrowPolygon(placesPosition, transitionsPlace)
                            : GenerateArrowPolygon(transitionsPlace, placesPosition);

                        graphGrid.Children.Add(polygon);
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

        private Polygon GenerateArrowPolygon(Point left, Point right)
        {
            var size = 10;

            var middlePoint = new Point(
                left.X + (right.X - left.X) / 2,
                left.Y + (right.Y - left.Y) / 2);
            
            var angle = Math.Atan2(left.Y - right.Y, left.X - right.X) * 180.0 /
                        Math.PI - 90;
            
            var polygon = new Polygon
            {
                Points = new PointCollection
                {
                    new Point(middlePoint.X, middlePoint.Y),
                    new Point(middlePoint.X - size * 0.4, middlePoint.Y + size),
                    new Point(middlePoint.X + size * 0.4, middlePoint.Y + size)
                },
                RenderTransform = new RotateTransform(angle, middlePoint.X, middlePoint.Y),
                Fill = new SolidColorBrush(Colors.Black),
            };
            return polygon;
        }
    }
}
