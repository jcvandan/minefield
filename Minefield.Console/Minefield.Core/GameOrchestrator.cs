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

    private bool HasReachedEnd => _field.IsAtEnd(_player.Position); 
    private bool IsComplete => HasReachedEnd || _player.IsDead;

    public void Start()
    {
        Console.WriteLine("Welcome to Minesweeper! Press Up/Down/Left/Right to move through the field.");
        
        while (!IsComplete)
        {
            var key = Console.ReadKey();
            
            var command = KeyToCommand(key.Key);
            MakeMove(command);

            Console.WriteLine(Status());
        }
        
        Console.ReadKey();
    }

    public string Status()
    {
        if (_player.IsDead)
        {
            return "YOU DIED";
        }

        if (HasReachedEnd)
        {
            return $"Well done you reached the end without dying! Your score was {_player.Moves}";
        }

        return $"Position: {_player.Position.AsChessNotation()} | Lives: {_player.Lives} | Moves: {_player.Moves}";
    }

    private void MakeMove(MoveCommand command)
    {
        _player.Move(command);
        if (_field.IsHit(_player.Position))
        {
            Console.WriteLine("BOOM! You stepped on a mine...");
            _player.Hit();
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