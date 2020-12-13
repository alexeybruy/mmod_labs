using System;
using System.Collections.Generic;
using System.Linq;
using Library.Services.ProbabilityMathematics;

namespace Library.Services.IndependenceFormula
{
    public class IndependenceTester
    {
        public void ShowTestingResult(IEnumerable<double> valuesX, IEnumerable<double> valuesY)
        {
            var r = GetCoefficient(valuesX, valuesY);

            var stringifiedR = r.ToString("0." + new string('#', 339));

            Console.WriteLine($"При тестировании независимости коэффициент R = {stringifiedR}");
        }

        private double GetCoefficient(IEnumerable<double> x, IEnumerable<double> y)
        {
            return (M(Multiply(x, y)) - M(x) * M(y)) / Math.Sqrt(D(x) * D(y));
        }

        private double M(IEnumerable<double> values)
        {
            return new MathematicalExpectationFormula().Calculate(values);
        }

        private double D(IEnumerable<double> values)
        {
            return new DispersionFormula().Calculate(values);
        }

        private IEnumerable<double> Multiply(IEnumerable<double> valuesX, IEnumerable<double> valuesY)
        {
            return from x in valuesX
                from y in valuesY
                select x * y;
        }
    }
}
