using FluentAssertions;
using Minefield.Core;

namespace Minefield.Tests;

public class PlayerModelTests
{
    [Fact]
    public void PlayerHasOneLife_AndIsHit_ThenPlayerIsDead()
    {
        var player = new PlayerModel(1);
        player.Hit();
        player.IsDead().Should().BeTrue();
    }
}