using common;
using common.Models;

namespace part2;

public class HydrothermalVenture: HydrothermalVentureAbstract
{
    public HydrothermalVenture(IReadOnlyCollection<InputRecord> input)
    {
        var maxX = input.Max(record => record.Start!.X > record.End!.X ? record.Start.X : record.End.X);
        var maxY = input.Max(record => record.Start!.Y > record.End!.Y ? record.Start.Y : record.End.Y);
        PrepareGraph(maxX, maxY);

        FillHorizontal(input);
        FillVertical(input);

        FillDiagonalFromUpperLeftToLowerRight(input);
        FillDiagonalFromUpperRightToLowerLeft(input);
    }

    private void FillDiagonalFromUpperRightToLowerLeft(IEnumerable<InputRecord> input)
    {
        foreach (var record in input.Where(record =>
                     record.Start!.Y > record.End!.Y && record.Start!.X > record.End!.X ||
                     record.Start!.Y < record.End!.Y && record.Start!.X < record.End!.X ).Select(record =>
                 {
                     if (record.Start!.X > record.End!.X)
                     {
                         (record.End, record.Start) = (record.Start, record.End);
                     }

                     return record;
                 }))
        {
            var y = record.Start!.Y;
            for (var x = record.Start!.X; x <= record.End!.X; x++)
            {
                Graph[y][x]++;
                y++;
            }
        }
    }

    private void FillDiagonalFromUpperLeftToLowerRight(IEnumerable<InputRecord> input)
    {
        foreach (var record in input.Where(record =>
                     record.Start!.Y < record.End!.Y && record.Start!.X > record.End!.X ||
                     record.Start!.Y > record.End!.Y && record.Start!.X < record.End!.X).Select(record =>
                 {
                     if (record.Start!.Y > record.End!.Y)
                     {
                         (record.End, record.Start) = (record.Start, record.End);
                     }

                     return record;
                 }))
        {
            var x = record.Start!.X;
            for (var y = record.Start!.Y; y <= record.End!.Y; y++)
            {
                Graph[y][x]++;
                x--;
            }
        }
    }
}