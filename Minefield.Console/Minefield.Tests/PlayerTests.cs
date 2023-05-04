using FluentAssertions;
using Minefield.Core;

namespace Minefield.Tests;

public class PlayerTests
{
    private readonly Player _player;

    public PlayerTests()
    {
        _player = new Player(2);
    }
    
    [Fact]
    public void IsInstantiatedWithNoLives_ExceptionIsThrown()
    {
        Action action = () => new Player(0);
        action.Should().Throw<ArgumentOutOfRangeException>();
    }
    
    [Fact]
    public void Has1Life_AndIsHit_ThenPlayerIsDead()
    {
        var player = new Player(1);
        player.Hit();
        player.IsDead.Should().BeTrue();
    }
    
    [Fact]
    public void Has2Lives_AndIsHit_ThenPlayerIsNotDead()
    {
        _player.Hit();
        _player.IsDead.Should().BeFalse();
    }

    [Fact]
    public void InitialPosition_ShouldBeZeroZero()
    {
        _player.Position.Should().Be(new Position(0, 0));
    }

    [Fact]
    public void MoveUp_PositionShouldChangeCorrectly()
    {
        _player.Move(MoveCommand.Up);
        _player.Move(MoveCommand.Up);
        
        _player.Position.AsChessNotation().Should().Be("A3");
    }
    
    [Fact]
    public void MoveDown_PositionShouldChangeCorrectly()
    {
        _player.Move(MoveCommand.Up);
        _player.Move(MoveCommand.Up);
        _player.Move(MoveCommand.Down);
        
        _player.Position.AsChessNotation().Should().Be("A2");
    }

    [Fact]
    public void MoveRight_PositionShouldChangeCorrectly()
    {
        _player.Move(MoveCommand.Right);
        _player.Move(MoveCommand.Right);
        
        _player.Position.AsChessNotation().Should().Be("C1");
    }

    [Fact]
    public void MoveLeft_PositionShouldChangeCorrectly()
    {
        _player.Move(MoveCommand.Right);
        _player.Move(MoveCommand.Right);
        _player.Move(MoveCommand.Left);
        
        _player.Position.AsChessNotation().Should().Be("B1");
    }

    [Fact]
    public void MultipleMoves_PositionShouldChangeCorrectly()
    {
        _player.Move(MoveCommand.Up);
        _player.Move(MoveCommand.Up);
        _player.Move(MoveCommand.Up);
        _player.Move(MoveCommand.Right);
        _player.Move(MoveCommand.Right);
        _player.Move(MoveCommand.Right);
        _player.Move(MoveCommand.Down);
        _player.Move(MoveCommand.Left);
        
        _player.Position.AsChessNotation().Should().Be("C3");
    }
}