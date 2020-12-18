using System;
using System.Collections.Generic;
using System.Linq;
using Lab3.Models;
using Library.Services.Generators;

namespace Lab3.Services
{
    public class XGenerator
    {
        public IEnumerable<int> Generate(IEnumerable<SpreadRangeForX> rangesForX)
        {
            return GenerateRandom(Program.RandomArraySize)
                .Select(val => rangesForX.First(range => val > range.Left && val < range.Right).ItemXId).ToList();
        }

        private IEnumerable<double> GenerateRandom(int size)
        {
            return new MultiplyingCongruentMethod((int)Math.Pow(2, 14), amountK: 5017)
                .GenerateArray(0.317, size).ToList();
        }
    }
}
