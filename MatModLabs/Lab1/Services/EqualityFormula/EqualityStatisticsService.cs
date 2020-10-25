using System.Collections.Generic;
using System.Linq;
using Lab1.Models;

namespace Lab1.Services.EqualityFormula
{
    public class EqualityStatisticsService
    {
        public IEnumerable<EqualityStatisticsItem> GetChances(IEnumerable<double> values, int rangesCount)
        {
            var minimum = 0.0;

            var maximum = 1.0;

            var rangeSize = (maximum - minimum) / rangesCount;

            for (var rangeIndex = 0; rangeIndex < rangesCount; rangeIndex++)
            {
                var from = minimum + rangeSize * rangeIndex;
                var to = minimum + rangeSize * rangeIndex + rangeSize;

                yield return new EqualityStatisticsItem
                {
                    From = from,
                    To = to,
                    Chance = values.Count(val => val >= from && val <= to) / (double)values.Count(),
                };
            }
        }
    }
}
