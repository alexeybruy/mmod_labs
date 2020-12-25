using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3.Services
{
    public class PossibilityService
    {
        public IEnumerable<double> GetColumnP(IEnumerable<IEnumerable<double>> matrix)
        {
            return matrix.First().Select((_, index) => matrix.Sum(row => row.ElementAt(index))).ToList();
        }

        public  IEnumerable<double> GetRowP(IEnumerable<IEnumerable<double>> matrix)
        {
            return matrix.Select(row => row.Sum()).ToList();
        }
    }
}
