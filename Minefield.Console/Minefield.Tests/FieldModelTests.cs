using FluentAssertions;
using Minefield.Core;

namespace Minefield.Tests;

public class FieldModelTests
{
    [Fact]
    public void GivenAFieldOfSize5_With10Mines_MineCountShouldBe10()
    {
        var field = new FieldModel(5, 10);
        field.CountMines().Should().Be(10);
    }
}