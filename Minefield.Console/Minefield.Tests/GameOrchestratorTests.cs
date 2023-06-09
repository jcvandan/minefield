﻿using FluentAssertions;
using Minefield.Core;
using Moq;

namespace Minefield.Tests;

public class GameOrchestratorTests
{
    private readonly Mock<IField> _fieldMock;
    private readonly Mock<IPlayer> _playerMock;
    
    private readonly GameOrchestrator _game;

    public GameOrchestratorTests()
    {
        _fieldMock = new Mock<IField>();
        _playerMock = new Mock<IPlayer>();
        
        _game = new GameOrchestrator(_fieldMock.Object, _playerMock.Object);
    }
    
    [Fact]
    public void GameJustStarted_ShouldPrintDefaultStatus()
    {
        _playerMock.Setup(p => p.Lives).Returns(5);
        _playerMock.Setup(p => p.Position).Returns(new Position(0, 0));
        
        _game.Status().Should().Be("Position: A1 | Lives: 5 | Moves: 0");
    }
    
    [Fact]
    public void PlayerIsDead_ShouldShowInStatus()
    {
        _playerMock.Setup(p => p.IsDead).Returns(true);
        _game.Status().Should().Be("YOU DIED");
    }

    [Fact]
    public void PlayerReachesEnd_ShouldShowInStatus()
    {
        _playerMock.Setup(p => p.IsDead).Returns(false);
        _playerMock.Setup(p => p.Moves).Returns(6);
        _fieldMock.Setup(p => p.IsAtEnd(It.IsAny<Position>())).Returns(true);
        
        _game.Status().Should().Be("Well done you reached the end without dying! Your score was 6");
    }
}