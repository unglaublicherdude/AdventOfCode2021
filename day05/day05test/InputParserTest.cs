using common;
using Xunit;

namespace day05test;

public class InputParserTest
{
    [Fact]
    public void TestParseFile()
    {
        var valueList = InputParser.LoadInput("input_test");
        Assert.Equal(0, valueList[0].Start!.X);
        Assert.Equal(9, valueList[0].End!.Y);
        Assert.Equal(7, valueList[4].Start!.X);
        Assert.Equal(7, valueList[4].End!.X);
    }
}