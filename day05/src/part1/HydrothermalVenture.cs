using common;
using common.Models;

namespace part1;

public class HydrothermalVenture: HydrothermalVentureAbstract
{
    public HydrothermalVenture(IReadOnlyCollection<InputRecord> input)
    {
        var maxX = input.Max(record => record.Start!.X > record.End!.X ? record.Start.X : record.End.X);
        var maxY = input.Max(record => record.Start!.Y > record.End!.Y ? record.Start.Y : record.End.Y);
        PrepareGraph(maxX, maxY);
        
        FillHorizontal(input);
        FillVertical(input);
    }
}