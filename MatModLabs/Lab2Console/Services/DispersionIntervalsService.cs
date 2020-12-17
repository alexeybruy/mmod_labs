using System;
using System.Collections.Generic;
using System.Linq;

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
                Left = values.Count() * s / 37.6,
                Right = values.Count() * s / 8.26,
            };
        }

        public class Interval
        {
            public double Left { get; set; }

            public double Right { get; set; }
        }
    }
}
