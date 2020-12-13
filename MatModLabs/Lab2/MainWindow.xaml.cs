using System.Collections.Generic;
using System.Windows;
using Lab2.Services;
using LiveCharts;

namespace Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            new MainService().Run(this);
        }

        public void SetValues(IEnumerable<double> values)
        {
            MainSeries.Values = new ChartValues<double>(values);
        }
    }
}
