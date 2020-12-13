using System;
using System.Linq;
using Library.Services.Generators;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = 20;

            var generator = new MultiplyingCongruentMethod(amountM: (int)Math.Pow(2, 14), amountK: 5003);

            var matrix = generator.GenerateArray(0.318, size).Select(val => generator.GenerateArray(val, size));

            foreach (var i in matrix)
            {
                foreach (var j in i)
                {
                    Console.Write($"{Math.Round(j,2):0.00}, ");
                }

                Console.WriteLine();
            }
        }
    }
}
