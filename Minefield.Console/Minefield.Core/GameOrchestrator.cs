namespace Minefield.Core;

public class GameOrchestrator
{
    private readonly IField _field;
    private readonly IPlayer _player;

    public GameOrchestrator(IField field, IPlayer player)
    {
        _field = field;
        _player = player;
    }

    public string Status() => $"Position: {_player.Position.AsChessNotation()} | Lives: {_player.Lives} | Moves: {_player.Moves}";
}