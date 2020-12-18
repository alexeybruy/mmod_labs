using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab3.Services
{
    public  class CovarianceService
    {
        private readonly PossibilityService possibilityService;

        public CovarianceService()
        {
            possibilityService = new PossibilityService();
        }

        public double GetCorrelation(IEnumerable<IEnumerable<double>> matrix)
        {
            var x = possibilityService.GetRowP(matrix);
            var y = possibilityService.GetColumnP(matrix);

            return GetCovariance(matrix) / Math.Sqrt(GetDispersion(x) * GetDispersion(y));
        }

        public double GetCovariance(IEnumerable<IEnumerable<double>> matrix)
        {
            var x = possibilityService.GetRowP(matrix);
            var y = possibilityService.GetColumnP(matrix);

            return GetMathExpectation(matrix) - GetMathExpectation(x) * GetMathExpectation(y);
        }

        private static double GetMathExpectation(IEnumerable<IEnumerable<double>> matrix)
        {
            var sum = 0.0;

            for (int i = 0; i < matrix.Count(); i++)
            {
                var row = matrix.ElementAt(i);

                for (int j = 0; j < row.Count(); j++)
                {
                    var p = row.ElementAt(j);

                    sum += p * i * j;
                }
            }

            return sum;
        }

        private static double GetMathExpectation(IEnumerable<double> values, int pow = 1)
        {
            return Enumerable.Range(0, values.Count()).Sum(item => Math.Pow(item, pow) * values.ElementAt(item));
        }

        private double GetDispersion(IEnumerable<double> values)
        {
            return GetMathExpectation(values, 2) - Math.Pow(GetMathExpectation(values), 2);
        }
    }
}
