namespace Minefield.Core;

public interface IPlayer
{
    void Hit();
    bool IsDead { get; }
    int Lives { get; }
    string Position { get; }
}

public class PlayerModel : IPlayer
{
    private int _lives;
    private string _position;

    public PlayerModel(int lives)
    {
        if (_lives <= 0) throw new ArgumentOutOfRangeException();
        
        _lives = lives;
        _position = "A1";
    }

    public void Hit() => _lives--;
    public bool IsDead => _lives <= 0;
    public int Lives => _lives;
    public string Position => _position;
}