using FluentAssertions;
using Minefield.Core;
using Moq;

namespace Minefield.Tests;

public class GameOrchestratorTests
{
    private readonly Mock<IField> _fieldMock;
    private readonly Mock<IPlayer> _playerMock;

    public GameOrchestratorTests()
    {
        _fieldMock = new Mock<IField>();
        _playerMock = new Mock<IPlayer>();
    }
    
    [Fact]
    public void GameJustStarted_()
    {
        _playerMock.Setup(p => p.Lives).Returns(5);
        _playerMock.Setup(p => p.Position).Returns("A1");
        
        var game = new GameOrchestrator(_fieldMock.Object, _playerMock.Object);
        game.Status().Should().Be("Position: A1 | Lives: 5 | Moves: 0");
    }
}