namespace Minefield.Core;

public interface IPlayer
{
    void Hit();
    bool IsDead { get; }
    int Lives { get; }
    int Moves { get; }
    Position Position { get; }
}

public class Player : IPlayer
{
    private int _lives;
    private int _moves = 0;
    private Position _position;

    public Player(int lives)
    {
        if (lives <= 0) throw new ArgumentOutOfRangeException();
        
        _lives = lives;
        _position = new Position(0, 0);
    }

    public void Move(MoveCommand command)
    {
        var currentX = _position.X;
        var currentY = _position.Y;

        _moves++;
        _position = command switch
        {
            MoveCommand.Up => new Position(currentX, currentY + 1),
            MoveCommand.Down => new Position(currentX, currentY - 1),
            MoveCommand.Left => new Position(currentX - 1, currentY),
            MoveCommand.Right => new Position(currentX + 1, currentY),
            _ => throw new ArgumentOutOfRangeException(nameof(command), command, null)
        };
    }
    
    public void Hit() => _lives--;
    public bool IsDead => _lives <= 0;
    public int Lives => _lives;
    public int Moves => _moves;
    public Position Position => _position;
}