using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1.Services.Generators
{
    public class MultiplyingCongruentMethod
    {
        private double AmountM { get; }
        private double AmountK { get; }

        public MultiplyingCongruentMethod(double amountM, double amountK)
        {
            AmountM = amountM;
            AmountK = amountK;
        }

        public IEnumerable<double> GenerateArray(double seed, double size)
        {
            if (size == 0)
            {
                return Enumerable.Empty<double>();
            }

            return new[] {seed / AmountM}.Concat(GenerateArray(AmountK * seed % AmountM, size - 1));
        }
    }
}
