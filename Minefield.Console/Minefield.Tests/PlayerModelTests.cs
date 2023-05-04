using FluentAssertions;
using Minefield.Core;

namespace Minefield.Tests;

public class PlayerModelTests
{
    [Fact]
    public void PlayerIsInstantiatedWithNoLives_ExceptionIsThrown()
    {
        Action action = () => new PlayerModel(0);
        action.Should().Throw<ArgumentOutOfRangeException>();
    }
    
    [Fact]
    public void PlayerHas1Life_AndIsHit_ThenPlayerIsDead()
    {
        var player = new PlayerModel(1);
        player.Hit();
        player.IsDead.Should().BeTrue();
    }
    
    [Fact]
    public void PlayerHas2Lives_AndIsHit_ThenPlayerIsNotDead()
    {
        var player = new PlayerModel(2);
        player.Hit();
        player.IsDead.Should().BeFalse();
    }
}