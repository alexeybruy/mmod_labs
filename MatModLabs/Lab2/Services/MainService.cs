using System;
using System.Linq;
using Library.Services.Generators;

namespace Lab2.Services
{
    public class MainService
    {
        public void Run(MainWindow window)
        {
            var size = 1000;

            var generatedX = new MultiplyingCongruentMethod((int)Math.Pow(2, 14), amountK: 5017).GenerateArray(0.318, size).ToList();

            var shiftedX = new ConvertToRangeService().Convert(generatedX, -Math.PI / 2, Math.PI / 2);

            var speadedY = new SpreadLawService().Calculate(shiftedX);

            

            window.SetValues(speadedY);
        }
    }
}
