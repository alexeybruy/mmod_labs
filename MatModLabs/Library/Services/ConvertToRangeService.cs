using System.Collections.Generic;
using System.Linq;

namespace Library.Services
{
    public class ConvertToRangeService
    {
        public IEnumerable<double> Convert(IEnumerable<double> values, double min, double max)
        {
            var valuesMin = values.Min();
            var valueMax = values.Max();

            return values.Select(val => ((val - valuesMin) / (valueMax - valuesMin)) * (max - min) + min);
        }
    }
}
