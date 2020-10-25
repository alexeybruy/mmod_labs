﻿using System.Collections.Generic;
using System.Linq;

namespace Lab1.Services.ProbabilityMathematics
{
    public class MathematicalExpectationFormula
    {
        public double Calculate(IEnumerable<double> values)
        {
            return values.Sum() / values.Count();
        }
    }
}
