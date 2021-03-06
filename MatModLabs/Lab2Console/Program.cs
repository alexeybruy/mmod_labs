﻿using System;
using System.Collections.Generic;
using System.Linq;
using Lab2Console.Services;
using Library.Services.EqualityFormula;
using Library.Services.Generators;
using Library.Services.InverseFunctionMethod;

namespace Lab2Console
{
    class Program
    {
        private static int Size = 20;

        private static int Intervals = 10;

        static void Main(string[] args)
        {
            var generated = Generate();

            new EqualityTester().ShowTestingDiagram(generated, Intervals);

            TrustIntervals(generated);
            PirsonCriteria(generated);

            Console.ReadKey();
        }

        private static IEnumerable<double> Generate()
        {
            var generatedX = new MultiplyingCongruentMethod((int) Math.Pow(2, 14), amountK: 5017)
                .GenerateArray(0.318, Size).ToList();

            var calculatedY = new SpreadLawService().Calculate(generatedX);

            return calculatedY;
        }

        private static void TrustIntervals(IEnumerable<double> values)
        {
            var average = values.Average();
            Console.WriteLine(
                $"Точечные: мат ожидание = {average}, дисперсия = {new PointDispersionService().GetDispersion(values)}");

            var intervalForM = new MathematicalExpectationIntervalService().GetInterval(values);
            Console.WriteLine($"Доверительный интервал для мат ожидания: {intervalForM.Left} < M < {intervalForM.Right}");

            var intervalForD = new DispersionIntervalsService().GetInterval(values);
            Console.WriteLine($"Доверительный интервал для дисперсии: {intervalForD.Left} < D < {intervalForD.Right}");
        }

        private static void PirsonCriteria(IEnumerable<double> values)
        {
            // K = 10 - 1 - 0 = 9
            var xi = 21.07;

            var criteria = new XiSquareCriteriaFormula().Calculate(values, Intervals);

            var resolution = criteria < xi
                ? "Гипотеза верна"
                : "Гипотеза отклонена";

            Console.WriteLine($"Критерий Пирсона = {criteria}, из таблицы = {xi}. {resolution}");
        }
    }
}
