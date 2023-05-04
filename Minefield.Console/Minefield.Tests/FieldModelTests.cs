using FluentAssertions;
using Minefield.Core;

namespace Minefield.Tests;

public class FieldModelTests
{
    [Theory]
    [InlineData(5, 10)]
    [InlineData(1, 1)]
    [InlineData(50, 50)]
    public void GivenAFieldSize_AndNumberMines_TraversingWholeField_ShouldResultInCorrectHits(int fieldSize, int numberMines)
    {
        var field = new FieldModel(fieldSize, numberMines);

        var hits = 0;
        
        for (var row = 0; row < fieldSize; row++)
        for (var col = 0; col < fieldSize; col++)
        {
            if (field.IsHit(new Position(row, col)))
            {
                hits++;
            }
        }

        hits.Should().Be(numberMines);
    }
}