using FluentAssertions;
using Minefield.Core;

namespace Minefield.Tests;

public class PositionTests
{
    [Theory]
    [InlineData(0, 0, "A1")]
    [InlineData(1, 1, "B2")]
    [InlineData(5, 3, "F4")]
    [InlineData(10, 1, "K2")]
    [InlineData(2, 5, "C6")]
    public void AsChessNotation(int x, int y, string notation)
    {
        var pos = new Position(x, y);
        pos.AsChessNotation().Should().Be(notation);
    }
}