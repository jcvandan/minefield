using FluentAssertions;
using Minefield.Core;

namespace Minefield.Tests;

public class PositionTests
{
    [Fact]
    public void ZeroZero_A1()
    {
        var pos = new Position(0, 0);
        pos.AsChessNotation().Should().Be("A1");
    }
}