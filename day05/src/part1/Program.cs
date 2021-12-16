using common;
using part1;

var hydrothermalVenture = new HydrothermalVenture(InputParser.LoadInput("input"));
hydrothermalVenture.DrawGraph();
Console.WriteLine();
Console.WriteLine(hydrothermalVenture.CountDangerousAreas());