using FluentAssertions;
using Minefield.Core;

namespace Minefield.Tests;

public class PlayerModelTests
{
    [Fact]
    public void IsInstantiatedWithNoLives_ExceptionIsThrown()
    {
        Action action = () => new PlayerModel(0);
        action.Should().Throw<ArgumentOutOfRangeException>();
    }
    
    [Fact]
    public void Has1Life_AndIsHit_ThenPlayerIsDead()
    {
        var player = new PlayerModel(1);
        player.Hit();
        player.IsDead.Should().BeTrue();
    }
    
    [Fact]
    public void Has2Lives_AndIsHit_ThenPlayerIsNotDead()
    {
        var player = new PlayerModel(2);
        player.Hit();
        player.IsDead.Should().BeFalse();
    }

    [Fact]
    public void InitialPosition_ShouldBeZeroZero()
    {
        var player = new PlayerModel(2);
        player.Position.Should().Be(new Position(0, 0));
    }
}