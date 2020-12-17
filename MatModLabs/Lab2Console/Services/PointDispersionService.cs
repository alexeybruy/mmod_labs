using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2Console.Services
{
    public class PointDispersionService
    {
        public double GetDispersion(IEnumerable<double> values)
        {
            var average = values.Average();

            return (1.0 / (values.Count() - 1.0)) * values.Sum(val => Math.Pow(val - average, 2));
        }
    }
}
