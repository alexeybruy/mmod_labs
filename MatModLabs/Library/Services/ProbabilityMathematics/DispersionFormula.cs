using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Services.ProbabilityMathematics
{
    public class DispersionFormula
    {
        public double Calculate(IEnumerable<double> values)
        {
            var mathExpectationFormula = new MathematicalExpectationFormula();

            return mathExpectationFormula.Calculate(values.Select(val => Math.Pow(val, 2))) -
                   Math.Pow(mathExpectationFormula.Calculate(values), 2);
        }
    }
}
