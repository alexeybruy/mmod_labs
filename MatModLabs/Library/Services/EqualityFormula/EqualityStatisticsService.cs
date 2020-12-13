using System.Collections.Generic;
using System.Linq;
using Library.Services.Models;

namespace Library.Services.EqualityFormula
{
    public class EqualityStatisticsService
    {
        public IEnumerable<EqualityStatisticsItem> GetChances(IEnumerable<double> values, int rangesCount)
        {
            var minimum = values.Min();

            var maximum = values.Max();

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
