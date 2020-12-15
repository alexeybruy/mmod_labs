using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2Console.Services
{
    public class DispersionIntervalsService
    {
        public Interval GetInterval(IEnumerable<double> values)
        {
            var average = values.Average();

            var s = (1.0 / (values.Count() - 1.0)) * values.Sum(val => Math.Pow(val - average, 2));

            return new Interval
            {
                Left = values.Count() * s / 18.49,
                Right = values.Count() * s / 16.31,
            };
        }

        public class Interval
        {
            public double Left { get; set; }

            public double Right { get; set; }
        }
    }
}
