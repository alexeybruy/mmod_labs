using System.Collections.Generic;

namespace Library.Services.Generators
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
            yield return seed / AmountM;

            for (var i = 0; i < size - 1; i++)
            {
                seed = AmountK * seed % AmountM;

                yield return seed / AmountM;
            }
        }
    }
}
