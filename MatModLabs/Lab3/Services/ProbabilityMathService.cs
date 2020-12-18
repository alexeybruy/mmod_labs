using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3.Services
{
    public class ProbabilityMathService
    {
        private readonly PossibilityService possibilityService;

        public ProbabilityMathService()
        {
            possibilityService = new PossibilityService();
        }

        public double GetMathExpectationForX(IEnumerable<IEnumerable<double>> matrix)
        {
            return GetMathExpectation(possibilityService.GetRowP(matrix));
        }

        public double GetMathExpectationForY(IEnumerable<IEnumerable<double>> matrix)
        {
            return GetMathExpectation(possibilityService.GetColumnP(matrix));
        }

        public double GetDispersionForX(IEnumerable<IEnumerable<double>> matrix)
        {
            return GetDispersion(possibilityService.GetRowP(matrix));
        }

        public double GetDispersionForY(IEnumerable<IEnumerable<double>> matrix)
        {
            return GetDispersion(possibilityService.GetColumnP(matrix));
        }

        private double GetMathExpectation(IEnumerable<double> values, int pow = 1)
        {
            return Enumerable.Range(0, values.Count()).Sum(item => Math.Pow(item, pow) * values.ElementAt(item));
        }

        private double GetDispersion(IEnumerable<double> values)
        {
            return GetMathExpectation(values, 2) - Math.Pow(GetMathExpectation(values), 2);
        }
    }
}
