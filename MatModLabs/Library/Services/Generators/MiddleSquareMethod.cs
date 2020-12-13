using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Services.Generators
{
    public class MiddleSquareMethod
    {
        private static readonly int SeedSize = 8;

        private readonly double _offset;

        public MiddleSquareMethod()
        {
            _offset = Math.Pow(10, SeedSize);
        }

        public IEnumerable<double> GenerateArray(double seed, int size)
        {
            if (size == 0)
            {
                return Enumerable.Empty<double>();
            }
            
            return new[] {seed / _offset}.Concat(GenerateArray(Generate(seed), size - 1)).ToList();
        }

        private double Generate(double seed)
        {
            var expanded = Math.Pow(seed, SeedSize / 2);

            var expandedString = expanded.ToString().PadLeft(SeedSize * 2, '0');

            var middleExpandedString = new string(expandedString.Skip(SeedSize / 2).Take(SeedSize).ToArray());

            return double.Parse(middleExpandedString);
        }
    }
}
