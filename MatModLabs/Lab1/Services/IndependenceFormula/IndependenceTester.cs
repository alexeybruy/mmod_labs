using System;
using System.Collections.Generic;
using System.Linq;
using Lab1.Services.ProbabilityMathematics;

namespace Lab1.Services.IndependenceFormula
{
    public class IndependenceTester
    {
        public void ShowTestingResult(IEnumerable<double> valuesX, IEnumerable<double> valuesY)
        {
            var r = GetCoefficient(valuesX, valuesY);

            Console.WriteLine($"При тестировании независимости коэффициент R = {r}");
        }

        private double GetCoefficient(IEnumerable<double> x, IEnumerable<double> y)
        {
            var a = Multiply(x, y);

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
