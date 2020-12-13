using System.Collections.Generic;
using System.Linq;

namespace Library.Services
{
    public class ConvertToRangeService
    {
        public IEnumerable<double> Convert(IEnumerable<double> values, double min, double max)
        {
            return values.Select(val => val * (max - min) + min);
        }
    }
}
