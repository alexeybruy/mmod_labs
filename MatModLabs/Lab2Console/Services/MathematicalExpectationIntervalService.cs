using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab2Console.Services
{
    public class MathematicalExpectationIntervalService
    {
        private double StudentTValue = 2.04;

        public Interval GetInterval(IEnumerable<double> values)
        {
            var average = values.Average();

            var s = (1.0 / (values.Count() - 1.0)) * values.Sum(val => Math.Pow(val - average, 2));

            return new Interval
            {
                Left = average - (s * StudentTValue) / Math.Sqrt(values.Count() - 1),
                Right = average + (s * StudentTValue) / Math.Sqrt(values.Count() - 1),
            };
        }

        public class Interval
        {
            public double Left { get; set; }

            public double Right { get; set; }
        }
    }
}
