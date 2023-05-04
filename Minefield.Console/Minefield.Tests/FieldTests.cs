using FluentAssertions;
using Minefield.Core;

namespace Minefield.Tests;

public class FieldTests
{
    [Theory]
    [InlineData(5, 10)]
    [InlineData(1, 1)]
    [InlineData(50, 50)]
    public void GivenAFieldSize_AndNumberMines_TraversingWholeField_ShouldResultInCorrectHits(int fieldSize, int numberMines)
    {
        var field = new Field(fieldSize, numberMines);

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

    [Fact]
    public void IsAtEnd_IfLastColumn_ShouldBeTrue()
    {
        var field = new Field(5, 0);
        field.IsAtEnd(new Position(4, 0)).Should().BeTrue();
    }

    [Fact]
    public void IsAtEnd_IfNotLastColumn_ShouldBeFalse()
    {
        var field = new Field(5, 0);
        field.IsAtEnd(new Position(3, 4)).Should().BeFalse();
    }
}