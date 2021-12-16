using common;
using Xunit;

namespace day05test;

public class Part2Test
{
    [Fact]
    public void TestCountDangerousAreas()
    {
        var valueList = InputParser.LoadInput("input_test");
        var hydrothermalVenture = new part2.HydrothermalVenture(valueList);
        
        Assert.Equal(12, hydrothermalVenture.CountDangerousAreas());
    }
}