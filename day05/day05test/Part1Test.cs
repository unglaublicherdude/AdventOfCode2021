using common;
using Xunit;

namespace day05test;

public class Part1Test
{
    [Fact]
    public void TestCreateGraphArray()
    {
        var valueList = InputParser.LoadInput("input_test");
        var hydrothermalVenture = new part1.HydrothermalVenture(valueList);

        
        Assert.Equal(0, hydrothermalVenture.Graph[0][0]);
        Assert.Equal(1, hydrothermalVenture.Graph[0][7]);
        Assert.Equal(2, hydrothermalVenture.Graph[9][0]);
        Assert.Equal(1, hydrothermalVenture.Graph[9][3]);
    }
    
    [Fact]
    public void TestCountDangerousAreas()
    {
        var valueList = InputParser.LoadInput("input_test");
        var hydrothermalVenture = new part1.HydrothermalVenture(valueList);
        
        Assert.Equal(5, hydrothermalVenture.CountDangerousAreas());
    }
}