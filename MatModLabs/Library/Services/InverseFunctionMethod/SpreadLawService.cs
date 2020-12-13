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

        private double Formula(double value)
        {
            var result = Math.Acos(value);

            return double.IsNaN(result) ? 0 : result;
        }
    }
}
