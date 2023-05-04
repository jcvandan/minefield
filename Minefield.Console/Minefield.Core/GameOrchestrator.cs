namespace Minefield.Core;

public class GameOrchestrator
{
    private readonly IField _field;
    private readonly IPlayer _player;

    private int _moves = 0;

    public GameOrchestrator(IField field, IPlayer player)
    {
        _field = field;
        _player = player;
    }

    public string Status() => $"Position: {_player.Position.AsChessNotation()} | Lives: {_player.Lives} | Moves: {_moves}";
}