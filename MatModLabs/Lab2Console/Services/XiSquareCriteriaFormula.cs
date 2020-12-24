using System;
using System.Collections.Generic;
using System.Linq;
using Library.Services.EqualityFormula;

namespace Lab2Console.Services
{
    public class XiSquareCriteriaFormula
    {
        public double Calculate(IEnumerable<double> values, int steps)
        {
            var chances = new EqualityStatisticsService().GetChances(values, steps);
            
            double sum = 0;

            for (var i = 0; i < steps; i++)
            {
                var chance = chances.ElementAt(i);

                if (chance.Chance != 0)
                {
                    sum += Math.Pow(0.5 * Math.Cos((chance.From + chance.To) / 2) - chance.Chance, 2)
                           / chance.Chance;
                }
            }

            return sum;
        }
    }
}
