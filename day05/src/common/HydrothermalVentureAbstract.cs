using common.Models;

namespace common;

public abstract class HydrothermalVentureAbstract
{
    public List<List<int>> Graph = new();
    public int CountDangerousAreas() => Graph.SelectMany(t => t).Count(t1 => t1 >= 2);

    protected void FillVertical(IEnumerable<InputRecord> input)
    {
        foreach (var record in input.Where(record =>
                     record.Start!.Y == record.End!.Y).Select(record =>
                 {
                     if (record.Start!.X > record.End!.X)
                     {
                         (record.End, record.Start) = (record.Start, record.End);
                     }

                     return record;
                 }))
        {
            for (var i = record.Start!.X; i <= record.End!.X; i++)
            {
                Graph[record.Start.Y][i]++;
            }
        }
    }

    protected void FillHorizontal(IEnumerable<InputRecord> input)
    {
        foreach (var record in input.Where(record =>
                     record.Start!.X == record.End!.X).Select(record =>
                 {
                     if (record.Start!.Y > record.End!.Y)
                     {
                         (record.End, record.Start) = (record.Start, record.End);
                     }

                     return record;
                 }))
        {
            for (var i = record.Start!.Y; i <= record.End!.Y; i++)
            {
                Graph[i][record.Start.X]++;
            }
        }
    }

    protected void PrepareGraph(int maxX, int maxY)
    {
        Graph = new List<List<int>>();
        for (var i = 0; i <= maxY; i++)
        {
            var yList = new List<int>();
            for (var y = 0; y <= maxX; y++)
            {
                yList.Add(0);
            }

            Graph.Add(yList);
        }
    }

    public void DrawGraph()
    {
        foreach (var t in Graph)
        {
            foreach (var t1 in t)
            {
                Console.Write(t1 == 0 ? "." : t1);
            }

            Console.WriteLine();
        }
    }
}