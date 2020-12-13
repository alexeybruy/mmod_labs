using System;
using System.Collections.Generic;
using System.Linq;
using Library.Services.Models;
using Library.Services.ProbabilityMathematics;

namespace Library.Services.EqualityFormula
{
    public class EqualityTester
    {
        private int DiagramWidth { get; } = 50;
        private int LegendSize { get; } = 30;

        public void ShowTestingDiagram(IEnumerable<double> values, int rangesCount)
        {
            var statistics = new EqualityStatisticsService().GetChances(values, rangesCount);
            Console.WriteLine($"Математическое ожидание СВ: {new MathematicalExpectationFormula().Calculate(values)}");
            Console.WriteLine($"Дисперсия СВ: {new DispersionFormula().Calculate(values)}");
            Console.WriteLine($"Диаграмма тестирования равномерности при разбиении на {rangesCount} диапазонов");
            ShowStatistics(statistics);
        }

        private void ShowStatistics(IEnumerable<EqualityStatisticsItem> statistics)
        {
            foreach (var item in statistics)
            {
                Console.WriteLine(
                    $"Range({Math.Round(item.From, 3)};{Math.Round(item.To, 3)}) - {Math.Round(item.Chance * 100, 2)}%"
                        .PadRight(LegendSize) +
                    GetDiagramProgressBar(item.Chance));
            }
        }

        private string GetDiagramProgressBar(double percent)
        {
            int displayingPart = (int) (percent * DiagramWidth);
            int resentPart = DiagramWidth - displayingPart;

            return $"|{new string(Enumerable.Range(0, displayingPart).Select(x => '=').ToArray())}" +
                   $"{new string(Enumerable.Range(0, resentPart).Select(x => ' ').ToArray())}|";
        }
    }
}
