using common;
using part2;

var hydrothermalVenture = new HydrothermalVenture(InputParser.LoadInput("input"));
hydrothermalVenture.DrawGraph();
Console.WriteLine();
Console.WriteLine(hydrothermalVenture.CountDangerousAreas());