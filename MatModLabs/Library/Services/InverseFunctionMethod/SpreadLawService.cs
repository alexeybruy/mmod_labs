using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Services.InverseFunctionMethod
{
    public class SpreadLawService
    {
        public IEnumerable<double> Calculate(IEnumerable<double> values)
        {
            return values.Select(Formula);
        }

        public double Formula(double x)
        {
            return Math.PI - 2 * Math.Acos(2 * x);
        }
    }
}
