namespace Minefield.Core;

public class GameOrchestrator
{
    private readonly IField _field;
    private readonly IPlayer _player;
    private bool _complete;

    public GameOrchestrator(IField field, IPlayer player)
    {
        _field = field;
        _player = player;
        _complete = false;
    }

    public string Status()
    {
        if (_player.IsDead)
        {
            return "YOU DIED";
        }
        
        return $"Position: {_player.Position.AsChessNotation()} | Lives: {_player.Lives} | Moves: {_player.Moves}";
    }

    public void Start()
    {
        Console.WriteLine("Welcome to Minesweeper! Press Up/Down/Left/Right to move through the field.");
        
        while (!_complete)
        {
            var key = Console.ReadKey();
            var command = KeyToCommand(key.Key);
            _player.Move(command);
            Console.WriteLine(Status());
        }
    }

    private MoveCommand KeyToCommand(ConsoleKey consoleKey)
    {
        return consoleKey switch
        {
            ConsoleKey.UpArrow => MoveCommand.Up,
            ConsoleKey.DownArrow => MoveCommand.Down,
            ConsoleKey.LeftArrow => MoveCommand.Left,
            ConsoleKey.RightArrow => MoveCommand.Right,
        };
    }
        
}