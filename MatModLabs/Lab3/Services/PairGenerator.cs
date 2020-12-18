using System;
using System.Collections.Generic;
using System.Linq;
using Lab3.Models;
using Library.Services.Generators;

namespace Lab3.Services
{
    public class PairGenerator
    {
        public IEnumerable<Pair> GeneratePairs(IEnumerable<SpreadRangeForY> rangesForY, IEnumerable<int> generatedX)
        {
            var random = GenerateRandom(generatedX.Count());

            return generatedX.Select((xId, index) =>
            {
                return new Pair
                {
                    X = xId,
                    Y = rangesForY.First(range =>
                        range.ItemXId == xId && random.ElementAt(index) > range.Left &&
                        random.ElementAt(index) < range.Right).ItemYId
                };
            });
        }

        private IEnumerable<double> GenerateRandom(int size)
        {
            return new MultiplyingCongruentMethod((int)Math.Pow(2, 14), amountK: 2017)
                .GenerateArray(0.517, size).ToList();
        }
    }
}
