using common.Models;
using System.Text.RegularExpressions;

namespace common;

public static class InputParser
{
    private const string Pattern = "(?<x1>[0-9]*),(?<y1>[0-9]*) -> (?<x2>[0-9]*),(?<y2>[0-9]*)";

    public static List<InputRecord> LoadInput(string path)
    {
        return File.ReadLines(path).Select(line => Regex.Match(line, Pattern)).Select(matches => new InputRecord
        {
            Start = new Coordinates
                { X = int.Parse(matches.Groups["x1"].Value), Y = int.Parse(matches.Groups["y1"].Value) },
            End = new Coordinates
                { X = int.Parse(matches.Groups["x2"].Value), Y = int.Parse(matches.Groups["y2"].Value) }
        }).ToList();
    }
}