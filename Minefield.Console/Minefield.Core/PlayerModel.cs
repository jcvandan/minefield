namespace Minefield.Core;

public interface IPlayer
{
    void Hit();
    bool IsDead { get; }
    int Lives { get; }
    Position Position { get; }
}

public class PlayerModel : IPlayer
{
    private int _lives;
    private Position _position;

    public PlayerModel(int lives)
    {
        if (_lives <= 0) throw new ArgumentOutOfRangeException();
        
        _lives = lives;
        _position = new Position(0, 0);
    }

    public void Hit() => _lives--;
    public bool IsDead => _lives <= 0;
    public int Lives => _lives;
    public Position Position => _position;
}