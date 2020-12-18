using System.Collections.Generic;
using System.Linq;
using Lab3.Models;

namespace Lab3.Services
{
    public class BuildRangesService
    {
        public IEnumerable<SpreadRangeForX> BuildForX(IEnumerable<double> values)
        {
            var prev = 0.0;

            return values.Select((value, index) =>
            {
                var range = new SpreadRangeForX
                {
                    ItemXId = index,
                    Left = prev,
                    Right = prev + value
                };

                prev += value;

                return range;
            }).ToList();
        }

        public IEnumerable<SpreadRangeForY> BuildForY(IEnumerable<IEnumerable<double>> matrix)
        {
            return matrix.SelectMany((row, rowIndex) =>
            {
                var prev = 0.0;

                var rowSum = row.Sum();

                return row.Select((columnRange, columnIndex) =>
                {
                    var item = new SpreadRangeForY
                    {
                        Left = prev / rowSum,
                        Right = (prev + columnRange) / rowSum,
                        ItemXId = rowIndex,
                        ItemYId = columnIndex,
                    };

                    prev += columnRange;

                    return item;
                });
            }).ToList();
        }
    }
}
