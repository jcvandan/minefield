using FluentAssertions;
using Minefield.Core;

namespace Minefield.Tests;

public class FieldModelTests
{
    [Fact]
    public void GivenAFieldOfSize5_And10Mines_TraversingWholeField_ShouldResultIn10Hits()
    {
        const int fieldSize = 5;
        const int numberMines = 10;
        
        var field = new FieldModel(fieldSize, numberMines);

        var hits = 0;
        
        for (var row = 0; row < 5; row++)
        for (var col = 0; col < 5; col++)
        {
            if (field.IsHit(new Vector2d(row, col)))
            {
                hits++;
            }
        }

        hits.Should().Be(10);
    }
}